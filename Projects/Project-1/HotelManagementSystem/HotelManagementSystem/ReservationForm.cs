using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class ReservationForm : Form
    {
        // Reference to the main form
        private MainForm _mainForm;

        // Connection string for the database
        private static string connectionString = "data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;";

        // SQL command to create the Reservation table if it does not exist
        private static string createTableSql = @"
            CREATE TABLE Reservations (
                ReservationID INT IDENTITY(1,1) PRIMARY KEY,
                CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
                RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID),
                CheckInDate DATETIME,
                CheckOutDate DATETIME
            )";

        private static string tableName = "Reservations";
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;

        public ReservationForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        // Method to establish a database connection
        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection(connectionString);
            return conn;
        }

        public static void EnsureTableExists(string tableName, string createTableSql)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                string checkTableQuery = "SELECT CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
                using (var checkCommand = new SqlCommand(checkTableQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@TableName", tableName);
                    var tableExists = Convert.ToBoolean(checkCommand.ExecuteScalar());

                    if (!tableExists)
                    {
                        using (var createCommand = new SqlCommand(createTableSql, conn))
                        {
                            createCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            EnsureTableExists(tableName, createTableSql);
            LoadReservations();
        }

        private void LoadReservations()
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("SELECT * FROM Reservations", conn);
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void ViewReservations_Click(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void SearchReservation_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string text = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            using (conn = GetConnection())
            {
                if (int.TryParse(text, out int reservationId))
                {
                    cmd = new SqlCommand("SELECT * FROM Reservations WHERE ReservationID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", reservationId);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM Reservations WHERE CustomerID IN (SELECT CustomerID FROM Customers WHERE FirstName LIKE '%' + @SearchTerm + '%' OR LastName LIKE '%' + @SearchTerm + '%')", conn);
                    cmd.Parameters.AddWithValue("@SearchTerm", text);
                }

                try
                {
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(sdr);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    textBox1.Text = "";
                }
            }
        }

        private void DeleteReservation_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            using (var conn = GetConnection())
            {
                if (int.TryParse(text, out int reservationId))
                {
                    cmd = new SqlCommand("DELETE FROM Reservations WHERE ReservationID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", reservationId);
                }
                else
                {
                    MessageBox.Show("Please enter a valid ReservationID.");
                    return;
                }

                try
                {
                    conn.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                        MessageBox.Show($"Deleted reservation ID: {text}.");
                    else
                        MessageBox.Show($"ReservationID: {text} not found."); // Show error message if reseration is not found
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    textBox1.Text = "";
                }
            }
        }

        private void AddReservation_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrUpdateReservation addOrUpdateReservation = new AddOrUpdateReservation(this, "ADD");
                addOrUpdateReservation.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void UpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrUpdateReservation addOrUpdateReservation = new AddOrUpdateReservation(this, "UPDATE");
                addOrUpdateReservation.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void TotalReservations_Click(object sender, EventArgs e)
        {
            using (var conn = GetConnection())
            {
                cmd = new SqlCommand("SELECT COUNT(*) FROM Reservations", conn);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                MessageBox.Show($"Total Reservations: {count}");
            }
        }


        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.OnFormClosed();
        }

        // Method to be called when this form is closed
        public void OnFormClosed()
        {
            // Show the MainForm when this form is closed
            this.Show();
        }
    }
}
