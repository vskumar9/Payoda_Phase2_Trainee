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
    public partial class RoomForm : Form
    {
        private MainForm _mainForm; // Reference to the main form

        // Connection string for the SQL Server database
        private static string connectionString = "data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;";

        // SQL command to create the Rooms table if it does not exist
        private static string createRoomsTableSql = @"
            CREATE TABLE Rooms (
                RoomID INT IDENTITY(1,1) PRIMARY KEY,
                RoomNumber VARCHAR(10) NOT NULL UNIQUE,
                RoomType VARCHAR(50) NOT NULL,
                Price DECIMAL(10, 2) NOT NULL,
                IsAvailable BIT NOT NULL
            )";

        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;

        // Default constructor for RoomForm
        public RoomForm()
        {
            InitializeComponent();
        }

        // Constructor with a reference to MainForm
        public RoomForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        // Method to get a new SQL connection object
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); // Return a new connection using the connection string
        }

        // Method to ensure that the necessary tables exist in the database
        private static void EnsureTablesExist()
        {
            using (conn = GetConnection())
            {
                conn.Open(); // Open the connection

                // Check if the Rooms table exists
                string checkRoomsTableQuery = "SELECT CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rooms') THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
                using (var checkCommand = new SqlCommand(checkRoomsTableQuery, conn))
                {
                    var tableExists = Convert.ToBoolean(checkCommand.ExecuteScalar()); // Execute the query and check if the table exists
                    if (!tableExists)
                    {
                        // If the table does not exist, create it
                        using (var createCommand = new SqlCommand(createRoomsTableSql, conn))
                        {
                            createCommand.ExecuteNonQuery(); // Execute the SQL command to create the table
                        }
                    }
                }
            }
        }

        // Event handler for form load event
        private void RoomForm_Load(object sender, EventArgs e)
        {
            EnsureTablesExist(); // Ensure that the necessary tables exist in the database

            LoadRooms(); // Load and display rooms data

            DataTable customersTable = GetCustomersData();
            dataGridView1.DataSource = customersTable;

            comboBoxSortOptions.Items.Add("RoomID");
            comboBoxSortOptions.Items.Add("RoomNumber");
            comboBoxSortOptions.Items.Add("RoomType");
            comboBoxSortOptions.Items.Add("Price");
            comboBoxSortOptions.Items.Add("IsAvailable");

            comboBoxSortOptions.SelectedIndex = 0; // Default sorting by FirstName

        }
        private DataTable GetCustomersData()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Rooms";

            using (SqlConnection conn = GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }

        private void ASC_Order_Click(object sender, EventArgs e)
        {
            string sortColumn = comboBoxSortOptions.SelectedItem.ToString();
            DataTable dt = (DataTable)dataGridView1.DataSource;

            if (dt != null)
            {
                dt.DefaultView.Sort = $"{sortColumn} ASC";
                dataGridView1.DataSource = dt;
            }
        }

        private void DESC_Order_Click(object sender, EventArgs e)
        {
            string sortColumn = comboBoxSortOptions.SelectedItem.ToString();
            DataTable dt = (DataTable)dataGridView1.DataSource;

            if (dt != null)
            {
                dt.DefaultView.Sort = $"{sortColumn} DESC";
                dataGridView1.DataSource = dt;
            }
        }

        // Method to load room data into the DataGridView
        private void LoadRooms()
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("SELECT * FROM Rooms", conn); // SQL command to select all rooms
                conn.Open(); // Open the connection
                using (var sdr = cmd.ExecuteReader()) // Execute the command and retrieve the data
                {
                    DataTable dt = new DataTable(); // Create a DataTable to hold the data
                    dt.Load(sdr); // Load the data into the DataTable
                    dataGridView1.DataSource = dt; // Bind the DataTable to the DataGridView
                }
            }
        }

        // Event handler for Add Room button click
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // Open the form to add a new room
            AddOrUpdateRoom roomForm = new AddOrUpdateRoom(this, "ADD");
            roomForm.ShowDialog(); // Show the form as a dialog
        }

        // Event handler for Update Room button click
        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            // Open the form to update an existing room
            AddOrUpdateRoom roomForm = new AddOrUpdateRoom(this, "UPDATE");
            roomForm.ShowDialog(); // Show the form as a dialog
        }

        // Event handler for Delete Room button click
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            string roomNumber = textBox1.Text.Trim(); // Get the room number from the text box
            if (string.IsNullOrEmpty(roomNumber))
            {
                MessageBox.Show("Please enter a room number."); // Show a message if no room number is provided
                return;
            }

            using (conn = GetConnection())
            {
                cmd = new SqlCommand("DELETE FROM Rooms WHERE RoomNumber = @RoomNumber", conn); // SQL command to delete a room
                cmd.Parameters.AddWithValue("@RoomNumber", roomNumber); // Add parameter for room number
                try
                {
                    conn.Open(); // Open the connection
                    int count = cmd.ExecuteNonQuery(); // Execute the command
                    if (count > 0)
                        MessageBox.Show($"RoomID: {roomNumber} deleted."); // Show success message if room is deleted
                    else
                        MessageBox.Show($"RoomID: {roomNumber} not found."); // Show error message if room is not found
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}"); // Show error message if an exception occurs
                }
            }

            LoadRooms(); // Refresh the list of rooms
        }

        // Event handler for the SearchRooms button click
        private void SearchRooms_Click(object sender, EventArgs e)
        {
            // Clear previous search results
            dataGridView1.DataSource = null;

            // Get the search text and trim any extra whitespace
            string text = textBox1.Text.Trim();

            // Check if the search term is empty
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            // Execute the command and display the results
            using (conn = GetConnection())
            {
                try
                {
                    // Open the connection to the database.
                    conn.Open();
                    // Construct the SQL query and parameters based on the search text
                    if (int.TryParse(text, out int roomId))
                    {
                        // Input is an integer, search by RoomID
                        cmd = new SqlCommand("SELECT * FROM Rooms WHERE RoomID = @id", conn);
                        cmd.Parameters.AddWithValue("@id", roomId);
                    }
                    else if (text.Equals("Available", StringComparison.OrdinalIgnoreCase) ||
                             text.Equals("Not Available", StringComparison.OrdinalIgnoreCase))
                    {
                        // Input is a search for availability status
                        bool isAvailable = text.Equals("Available", StringComparison.OrdinalIgnoreCase);
                        cmd = new SqlCommand("SELECT * FROM Rooms WHERE IsAvailable = @isAvailable", conn);
                        cmd.Parameters.AddWithValue("@isAvailable", isAvailable);
                    }
                    else
                    {
                        // Input is not an integer and not availability status, search by RoomNumber or RoomType
                        cmd = new SqlCommand("SELECT * FROM Rooms WHERE RoomNumber LIKE '%' + @SearchTerm + '%' OR RoomType LIKE '%' + @SearchTerm + '%'", conn);
                        cmd.Parameters.AddWithValue("@SearchTerm", text);
                    }

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
                    // Clear the search box after use
                    textBox1.Text = "";
                }
            }
        }


        // Event handler for Back to Main Form button click
        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the current form
            _mainForm.OnFormClosed(); // Notify the main form that this form has been closed
        }

        private void TotalRooms_Click(object sender, EventArgs e)
        {
            // Use a using block to ensure the SqlConnection is properly disposed of after use.
            using (conn = GetConnection())
            {
                // Create a SqlCommand to execute a SQL query that counts the total number of rows in the 'Customers' table.
                cmd = new SqlCommand("select count(*) from Rooms", conn);

                // Open the connection to the database.
                conn.Open();
                int count = (int)cmd.ExecuteScalar(); // ExecuteScalar should be used to get a single value from the database.

                // Show a message box displaying the total number of customers.
                MessageBox.Show($"Total Rooms: {count}");
            }
        }

        // Method to be called when this form is closed
        public void OnFormClosed()
        {
            // Show the MainForm when this form is closed
            this.Show();
        }
    }
}
