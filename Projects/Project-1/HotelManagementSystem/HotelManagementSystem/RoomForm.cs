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
            using (var conn = GetConnection())
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
            
        }

        // Method to load room data into the DataGridView
        private void LoadRooms()
        {
            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand("SELECT * FROM Rooms", conn); // SQL command to select all rooms
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
            var roomForm = new AddOrUpdateRoom(this, "ADD");
            roomForm.ShowDialog(); // Show the form as a dialog
        }

        // Event handler for Update Room button click
        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            // Open the form to update an existing room
            var roomForm = new AddOrUpdateRoom(this, "UPDATE");
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

            using (var conn = GetConnection())
            {
                var cmd = new SqlCommand("DELETE FROM Rooms WHERE RoomNumber = @RoomNumber", conn); // SQL command to delete a room
                cmd.Parameters.AddWithValue("@RoomNumber", roomNumber); // Add parameter for room number
                try
                {
                    conn.Open(); // Open the connection
                    int count = cmd.ExecuteNonQuery(); // Execute the command
                    if (count > 0)
                        MessageBox.Show($"Room {roomNumber} deleted."); // Show success message if room is deleted
                    else
                        MessageBox.Show($"Room {roomNumber} not found."); // Show error message if room is not found
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}"); // Show error message if an exception occurs
                }
            }

            LoadRooms(); // Refresh the list of rooms
        }

        // Event handler for Back to Main Form button click
        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the current form
            _mainForm.OnFormClosed(); // Notify the main form that this form has been closed
        }
    }
}
