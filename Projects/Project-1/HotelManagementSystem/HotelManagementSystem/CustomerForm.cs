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
using static System.Net.Mime.MediaTypeNames;

namespace HotelManagementSystem
{
    public partial class CustomerForm : Form
    {
        // Reference to the main form
        private MainForm _mainForm;

        // Connection string for the database
        private static string connectionString = "data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;";

        // SQL command to create the Customers table if it does not exist
        private static string createTableSql = @"CREATE TABLE Customers (
                                          CustomerID INT IDENTITY(1,1) PRIMARY KEY,
                                          FirstName VARCHAR(50) NOT NULL,
                                          LastName VARCHAR(50) NOT NULL,             
                                          Email VARCHAR(100) NOT NULL UNIQUE,        
                                          PhoneNumber VARCHAR(15) NULL)";

        private static string tableName = "Customers";
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;

        // Constructor with optional MainForm parameter
        public CustomerForm()
        { }

        public CustomerForm(MainForm mainForm)
        {
            InitializeComponent();
            this._mainForm = mainForm;
        }

        // Method to establish a database connection
        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection(connectionString);
            return conn;
        }

        // Method to ensure the Customers table exists, creates it if not
        public static void EnsureTableExists(string tableName, string createTableSql)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                // Check if the table exists
                string checkTableQuery = "SELECT CASE WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";

                using (var checkCommand = new SqlCommand(checkTableQuery, conn))
                {
                    checkCommand.Parameters.AddWithValue("@TableName", tableName);
                    var tableExists = Convert.ToBoolean(checkCommand.ExecuteScalar());

                    if (!tableExists)
                    {
                        // Table does not exist, so create it
                        using (var createCommand = new SqlCommand(createTableSql, conn))
                        {
                            createCommand.ExecuteNonQuery();
                            // Console.WriteLine($"Table '{tableName}' created successfully.");
                        }
                    }
                    else
                    {
                        // Console.WriteLine($"Table '{tableName}' already exists.");
                    }
                }
            }
        }

        // Load event handler for the form
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // Ensure the Customers table exists
            EnsureTableExists(tableName, createTableSql);

            // Populate the DataGridView with all customers
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("select * from Customers", conn);
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    dataGridView1.DataSource = dt;
                }

            }
        }

        // Event handler for the ViewCustomers button click
        private void ViewCustomers_Click(object sender, EventArgs e)
        {
            // Refresh the DataGridView with all customers
            CustomerForm_Load(sender, e);
        }

        // Event handler for the SearchCustomer button click
        private void SearchCustomer_Click(object sender, EventArgs e)
        {
            // Clear previous search results
            dataGridView1.DataSource = null;

            string text = textBox1.Text.Trim();

            // Check if the search term is empty
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            using (var conn = GetConnection())
            {
                if (int.TryParse(text, out int customerId))
                {
                    // Input is an integer, search by CustomerID
                    cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                }
                else
                {
                    // Input is not an integer, search by name
                    cmd = new SqlCommand("SELECT * FROM Customers WHERE FirstName LIKE '%' + @SearchTerm + '%' OR LastName LIKE '%' + @SearchTerm + '%'", conn);
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
                    textBox1.Text = ""; // Clear the search box after use
                }
            }
        }

        // Event handler for the DeleteCustomer button click
        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            // Check if the search term is empty
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            using (var conn = GetConnection())
            {
                if (int.TryParse(text, out int customerId))
                {
                    // Input is an integer, delete by CustomerID
                    cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", customerId);
                }
                else
                {
                    // Input is not an integer, prompt user to enter a CustomerID
                    MessageBox.Show("Please enter a CustomerID.");
                    return;
                }

                try
                {
                    conn.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                        MessageBox.Show($"Deleted {text}.");
                    else
                        MessageBox.Show($"CustomerID: {text} not found."); // Show error message if room is not found
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    textBox1.Text = ""; // Clear the search box after use
                }
            }
        }

        // Event handler for the AddCustomer button click
        private void AddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Open a dialog to add a new customer
                AddOrUpdateCustomer addOrUpdateCustomer = new AddOrUpdateCustomer(this, "ADD");
                addOrUpdateCustomer.ShowDialog();
                // this.Hide(); // Optional: hide the current form
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Event handler for the UpdateCustomer button click
        private void UpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Open a dialog to update an existing customer
                AddOrUpdateCustomer addOrUpdateCustomer = new AddOrUpdateCustomer(this, "UPDATE");
                addOrUpdateCustomer.ShowDialog();
                // this.Hide(); // Optional: hide the current form
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void TotalCustomers_Click(object sender, EventArgs e)
        {
            // Use a using block to ensure the SqlConnection is properly disposed of after use.
            using (var conn = GetConnection())
            {
                // Create a SqlCommand to execute a SQL query that counts the total number of rows in the 'Customers' table.
                cmd = new SqlCommand("select count(*) from Customers", conn);

                // Open the connection to the database.
                conn.Open();
                int count = (int)cmd.ExecuteScalar(); // ExecuteScalar should be used to get a single value from the database.

                // Show a message box displaying the total number of customers.
                MessageBox.Show($"Total Customers: {count}");
            }
        }
        // Event handler for the BackToMainForm button click
        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Optionally notify MainForm that this form was closed
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
