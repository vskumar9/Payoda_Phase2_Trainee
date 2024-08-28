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
    public partial class AddOrUpdateRoom : Form
    {
        private RoomForm roomForm;
        private static string operationType; // Operation type ("ADD" or "UPDATE")
        private static string connectionString = "data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;"; // Database connection string
        private static SqlConnection conn; // SQL connection object
        private static SqlCommand cmd = null;

        // Method to get the SQL connection object
        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection(connectionString);
            return conn;
        }

        public AddOrUpdateRoom(RoomForm roomForm, string type)
        {
            InitializeComponent();
            this.roomForm = roomForm;
            operationType = type;
        }

        private void AddOrUpdateRooms_Load(object sender, EventArgs e)
        {
            // Initialize form controls based on the operation type
            if (operationType.ToUpper().Equals("ADD"))
            {
                InitializeAddRoomControls(); // Initialize controls for adding a room
            }
            else if (operationType.ToUpper().Equals("UPDATE"))
            {
                InitializeUpdateRoomControls(); // Initialize controls for updating a room
            }
        }

        // Method to initialize controls for adding a room
        private void InitializeAddRoomControls()
        {
            // Create and configure Labels for room details
            Label lblRoomNumber = new Label
            {
                Text = "Room Number:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblRoomType = new Label
            {
                Text = "Room Type:",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = "Price:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };

            Label lblIsAvailable = new Label
            {
                Text = "Is Available:",
                Location = new System.Drawing.Point(20, 140),
                AutoSize = true
            };

            // Create and configure TextBoxes for input
            TextBox txtRoomNumber = new TextBox
            {
                Name = "txtRoomNumber",
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtRoomType = new TextBox
            {
                Name = "txtRoomType",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtPrice = new TextBox
            {
                Name = "txtPrice",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            CheckBox chkIsAvailable = new CheckBox
            {
                Name = "chkIsAvailable",
                Location = new System.Drawing.Point(150, 140),
                AutoSize = true
            };

            // Create and configure Button for adding room
            Button btnAdd = new Button
            {
                Text = "Add Room",
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(120, 30)
            };

            // Attach event handler for button click
            btnAdd.Click += new EventHandler(btnAddRoom_Click);

            // Add controls to the form
            this.Controls.Add(lblRoomNumber);
            this.Controls.Add(lblRoomType);
            this.Controls.Add(lblPrice);
            this.Controls.Add(lblIsAvailable);
            this.Controls.Add(txtRoomNumber);
            this.Controls.Add(txtRoomType);
            this.Controls.Add(txtPrice);
            this.Controls.Add(chkIsAvailable);
            this.Controls.Add(btnAdd);
        }

        // Event handler for the Add button click event
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes and checkbox
            string roomNumber = this.Controls["txtRoomNumber"].Text;
            string roomType = this.Controls["txtRoomType"].Text;
            string priceText = this.Controls["txtPrice"].Text;
            bool isAvailable = ((CheckBox)this.Controls["chkIsAvailable"]).Checked;

            // Validate inputs
            if (string.IsNullOrEmpty(roomNumber) || string.IsNullOrEmpty(roomType) ||
                !decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            try
            {
                // Save the room to the database
                SaveRoom(roomNumber, roomType, price, isAvailable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Method to save a new room to the database
        private void SaveRoom(string roomNumber, string roomType, decimal price, bool isAvailable)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO Rooms (RoomNumber, RoomType, Price, IsAvailable) VALUES (@RoomNumber, @RoomType, @Price, @IsAvailable)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    cmd.Parameters.AddWithValue("@RoomType", roomType);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Execute the insert command
                }
            }

            // Notify user and close the form
            MessageBox.Show("Room added successfully.");
            this.Close();
        }

        // Method to initialize controls for updating an existing room
        private void InitializeUpdateRoomControls()
        {
            // Create and configure Labels for room details including ID
            Label lblRoomID = new Label
            {
                Text = "Room ID:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblRoomNumber = new Label
            {
                Text = "Room Number:",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            Label lblRoomType = new Label
            {
                Text = "Room Type:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };

            Label lblPrice = new Label
            {
                Text = "Price:",
                Location = new System.Drawing.Point(20, 140),
                AutoSize = true
            };

            Label lblIsAvailable = new Label
            {
                Text = "Is Available:",
                Location = new System.Drawing.Point(20, 180),
                AutoSize = true
            };

            // Create and configure TextBoxes for input, including room ID
            TextBox txtRoomID = new TextBox
            {
                Name = "txtRoomID",
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtRoomNumber = new TextBox
            {
                Name = "txtURoomNumber",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtRoomType = new TextBox
            {
                Name = "txtURoomType",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtPrice = new TextBox
            {
                Name = "txtUPrice",
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            CheckBox chkIsAvailable = new CheckBox
            {
                Name = "chkUIsAvailable",
                Location = new System.Drawing.Point(150, 180),
                AutoSize = true
            };

            // Create and configure Buttons for updating and retrieving room data
            Button btnUpdate = new Button
            {
                Text = "Update Room",
                Location = new System.Drawing.Point(150, 220),
                Size = new System.Drawing.Size(120, 30)
            };

            Button btnGetData = new Button
            {
                Text = "Get Room Data",
                Location = new System.Drawing.Point(300, 220),
                Size = new System.Drawing.Size(120, 30)
            };

            // Attach event handlers for button clicks
            btnUpdate.Click += new EventHandler(btnUpdateRoom_Click);
            btnGetData.Click += new EventHandler(btnGetRoomData_Click);

            // Add controls to the form
            this.Controls.Add(lblRoomID);
            this.Controls.Add(lblRoomNumber);
            this.Controls.Add(lblRoomType);
            this.Controls.Add(lblPrice);
            this.Controls.Add(lblIsAvailable);
            this.Controls.Add(txtRoomID);
            this.Controls.Add(txtRoomNumber);
            this.Controls.Add(txtRoomType);
            this.Controls.Add(txtPrice);
            this.Controls.Add(chkIsAvailable);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnGetData);
        }

        // Event handler for the Update button click event
        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes and checkbox
            string roomIdText = this.Controls["txtRoomID"].Text;
            string roomNumber = this.Controls["txtURoomNumber"].Text;
            string roomType = this.Controls["txtURoomType"].Text;
            string priceText = this.Controls["txtUPrice"].Text;
            bool isAvailable = ((CheckBox)this.Controls["chkUIsAvailable"]).Checked;

            // Validate inputs
            if (!int.TryParse(roomIdText, out int roomId) ||
                string.IsNullOrEmpty(roomNumber) ||
                string.IsNullOrEmpty(roomType) ||
                !decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            try
            {
                // Update the room in the database
                UpdateRoom(roomId, roomNumber, roomType, price, isAvailable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Method to update an existing room in the database
        private void UpdateRoom(int roomId, string roomNumber, string roomType, decimal price, bool isAvailable)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Rooms SET RoomNumber = @RoomNumber, RoomType = @RoomType, Price = @Price, IsAvailable = @IsAvailable WHERE RoomID = @RoomID", conn))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@RoomID", roomId);
                    cmd.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    cmd.Parameters.AddWithValue("@RoomType", roomType);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the update command
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Room updated successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No room found with the given ID.");
                    }
                }
            }
        }

        // Event handler for the Get Data button click event
        private void btnGetRoomData_Click(object sender, EventArgs e)
        {
            // Load room data into text boxes based on room ID
            LoadRoomData();
        }

        // Method to load room data from the database based on room ID
        private void LoadRoomData()
        {
            using (SqlConnection conn = GetConnection())
            {
                string roomIdText = this.Controls["txtRoomID"].Text;
                if (!int.TryParse(roomIdText, out int roomId))
                {
                    MessageBox.Show("Please enter a valid Room ID.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand("SELECT RoomNumber, RoomType, Price, IsAvailable FROM Rooms WHERE RoomID = @RoomID", conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", roomId);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Safely cast controls to their specific types
                                TextBox txtRoomNumber = this.Controls["txtURoomNumber"] as TextBox;
                                TextBox txtRoomType = this.Controls["txtURoomType"] as TextBox;
                                TextBox txtPrice = this.Controls["txtUPrice"] as TextBox;
                                CheckBox chkIsAvailable = this.Controls["chkUIsAvailable"] as CheckBox;

                                if (txtRoomNumber != null && txtRoomType != null && txtPrice != null && chkIsAvailable != null)
                                {
                                    // Populate text boxes and check box with room data
                                    txtRoomNumber.Text = reader["RoomNumber"].ToString();
                                    txtRoomType.Text = reader["RoomType"].ToString();
                                    txtPrice.Text = reader["Price"].ToString();
                                    chkIsAvailable.Checked = Convert.ToBoolean(reader["IsAvailable"]);
                                }
                                else
                                {
                                    MessageBox.Show("One or more controls are not correctly initialized.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Room not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }


        private void btnBackToRoomForm_Click(object sender, EventArgs e)
        {
            // Close the AddOrUpdateRoom form and notify the parent RoomForm
            this.Close();
            roomForm.OnFormClosed();
        }
    }
}
