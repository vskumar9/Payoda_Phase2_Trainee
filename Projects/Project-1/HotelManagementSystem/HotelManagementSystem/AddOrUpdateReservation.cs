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
    public partial class AddOrUpdateReservation : Form
    {

        private ReservationForm _reservationForm;
        private static string connectionString = "data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;";
        private static string _operationType; // Operation type ("ADD" or "UPDATE")
        private static SqlConnection conn; // SQL connection object
        private static SqlCommand cmd = null;

        public AddOrUpdateReservation(ReservationForm reservationForm, string operationType)
        {
            InitializeComponent();
            _reservationForm = reservationForm;
            _operationType = operationType;
        }

        // Method to get the SQL connection object
        private static SqlConnection GetConnection()
        {
            conn = new SqlConnection(connectionString);
            return conn;
        }

        private void AddOrUpdateReservation_Load(object sender, EventArgs e)
        {
            // Initialize form controls based on the operation type
            if (_operationType.ToUpper().Equals("ADD"))
            {
                InitializeAddReservationControls(); // Initialize controls for adding a reservation
            }
            else if (_operationType.ToUpper().Equals("UPDATE"))
            {
                InitializeUpdateReservationControls(); // Initialize controls for updating a reservation
            }
        }

        // Method to initialize controls for adding a reservation
        private void InitializeAddReservationControls()
        {
            // Create and configure Labels for reservation details
            Label lblCustomerID = new Label
            {
                Text = "Customer ID:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblRoomID = new Label
            {
                Text = "Room ID:",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            Label lblCheckInDate = new Label
            {
                Text = "Check-In Date:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };

            Label lblCheckOutDate = new Label
            {
                Text = "Check-Out Date:",
                Location = new System.Drawing.Point(20, 140),
                AutoSize = true
            };

            // Create and configure TextBoxes for input
            TextBox txtCustomerID = new TextBox
            {
                Name = "txtCustomerID",
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtRoomID = new TextBox
            {
                Name = "txtRoomID",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            DateTimePicker dtpCheckInDate = new DateTimePicker
            {
                Name = "dtpCheckInDate",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            DateTimePicker dtpCheckOutDate = new DateTimePicker
            {
                Name = "dtpCheckOutDate",
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create and configure Button for adding reservation
            Button btnAdd = new Button
            {
                Text = "Add Reservation",
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(120, 30)
            };

            // Attach event handler for button click
            btnAdd.Click += new EventHandler(btnAddReservation_Click);

            // Add controls to the form
            this.Controls.Add(lblCustomerID);
            this.Controls.Add(lblRoomID);
            this.Controls.Add(lblCheckInDate);
            this.Controls.Add(lblCheckOutDate);
            this.Controls.Add(txtCustomerID);
            this.Controls.Add(txtRoomID);
            this.Controls.Add(dtpCheckInDate);
            this.Controls.Add(dtpCheckOutDate);
            this.Controls.Add(btnAdd);
        }

        // Event handler for the Add button click event
        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes and date pickers
            string customerIDText = this.Controls["txtCustomerID"].Text;
            string roomIDText = this.Controls["txtRoomID"].Text;
            DateTime checkInDate = ((DateTimePicker)this.Controls["dtpCheckInDate"]).Value;
            DateTime checkOutDate = ((DateTimePicker)this.Controls["dtpCheckOutDate"]).Value;

            // Validate inputs
            if (!int.TryParse(customerIDText, out int customerID) ||
                !int.TryParse(roomIDText, out int roomID))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            if (checkInDate >= checkOutDate)
            {
                MessageBox.Show("Check-Out Date must be after Check-In Date.");
                return;
            }

            try
            {
                // Save the reservation to the database
                SaveReservation(customerID, roomID, checkInDate, checkOutDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Method to save a new reservation to the database
        private void SaveReservation(int customerID, int roomID, DateTime checkInDate, DateTime checkOutDate)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO Reservations (CustomerID, RoomID, CheckInDate, CheckOutDate) VALUES (@CustomerID, @RoomID, @CheckInDate, @CheckOutDate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Execute the insert command
                }
            }

            // Notify user and close the form
            MessageBox.Show("Reservation added successfully.");
            this.Close();
        }

        // Method to initialize controls for updating an existing reservation
        private void InitializeUpdateReservationControls()
        {
            // Create and configure Labels for reservation details including ID
            Label lblReservationID = new Label
            {
                Text = "Reservation ID:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblCustomerID = new Label
            {
                Text = "Customer ID:",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            Label lblRoomID = new Label
            {
                Text = "Room ID:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };

            Label lblCheckInDate = new Label
            {
                Text = "Check-In Date:",
                Location = new System.Drawing.Point(20, 140),
                AutoSize = true
            };

            Label lblCheckOutDate = new Label
            {
                Text = "Check-Out Date:",
                Location = new System.Drawing.Point(20, 180),
                AutoSize = true
            };

            // Create and configure TextBoxes for input, including reservation ID
            TextBox txtReservationID = new TextBox
            {
                Name = "txtReservationID",
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtCustomerID = new TextBox
            {
                Name = "txtUCustomerID",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtRoomID = new TextBox
            {
                Name = "txtURoomID",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            DateTimePicker dtpCheckInDate = new DateTimePicker
            {
                Name = "dtpUCheckInDate",
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            DateTimePicker dtpCheckOutDate = new DateTimePicker
            {
                Name = "dtpUCheckOutDate",
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create and configure Buttons for updating and retrieving reservation data
            Button btnUpdate = new Button
            {
                Text = "Update Reservation",
                Location = new System.Drawing.Point(150, 220),
                Size = new System.Drawing.Size(120, 30)
            };

            Button btnGetData = new Button
            {
                Text = "Get Reservation Data",
                Location = new System.Drawing.Point(300, 220),
                Size = new System.Drawing.Size(150, 30)
            };

            // Attach event handlers for button clicks
            btnUpdate.Click += new EventHandler(btnUpdateReservation_Click);
            btnGetData.Click += new EventHandler(btnGetReservationData_Click);

            // Add controls to the form
            this.Controls.Add(lblReservationID);
            this.Controls.Add(lblCustomerID);
            this.Controls.Add(lblRoomID);
            this.Controls.Add(lblCheckInDate);
            this.Controls.Add(lblCheckOutDate);
            this.Controls.Add(txtReservationID);
            this.Controls.Add(txtCustomerID);
            this.Controls.Add(txtRoomID);
            this.Controls.Add(dtpCheckInDate);
            this.Controls.Add(dtpCheckOutDate);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnGetData);
        }

        // Event handler for the Update button click event
        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes and date pickers
            string reservationIDText = this.Controls["txtReservationID"].Text;
            string customerIDText = this.Controls["txtUCustomerID"].Text;
            string roomIDText = this.Controls["txtURoomID"].Text;
            DateTime checkInDate = ((DateTimePicker)this.Controls["dtpUCheckInDate"]).Value;
            DateTime checkOutDate = ((DateTimePicker)this.Controls["dtpUCheckOutDate"]).Value;

            // Validate inputs
            if (!int.TryParse(reservationIDText, out int reservationID) ||
                !int.TryParse(customerIDText, out int customerID) ||
                !int.TryParse(roomIDText, out int roomID))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            if (checkInDate >= checkOutDate)
            {
                MessageBox.Show("Check-Out Date must be after Check-In Date.");
                return;
            }

            try
            {
                // Update the reservation in the database
                UpdateReservation(reservationID, customerID, roomID, checkInDate, checkOutDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Method to update an existing reservation in the database
        private void UpdateReservation(int reservationID, int customerID, int roomID, DateTime checkInDate, DateTime checkOutDate)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Reservations SET CustomerID = @CustomerID, RoomID = @RoomID, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate WHERE ReservationID = @ReservationID", conn))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the update command
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Reservation updated successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No reservation found with the given ID.");
                    }
                }
            }
        }

        // Event handler for the Get Data button click event
        private void btnGetReservationData_Click(object sender, EventArgs e)
        {
            // Load reservation data into text boxes based on reservation ID
            LoadReservationData();
        }

        // Method to load reservation data from the database based on reservation ID
        private void LoadReservationData()
        {
            using (SqlConnection conn = GetConnection())
            {
                string reservationIDText = this.Controls["txtReservationID"].Text;
                if (!int.TryParse(reservationIDText, out int reservationID))
                {
                    MessageBox.Show("Please enter a valid Reservation ID.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand("SELECT CustomerID, RoomID, CheckInDate, CheckOutDate FROM Reservations WHERE ReservationID = @ReservationID", conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationID);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Safely cast controls to their specific types
                                TextBox txtCustomerID = this.Controls["txtUCustomerID"] as TextBox;
                                TextBox txtRoomID = this.Controls["txtURoomID"] as TextBox;
                                DateTimePicker dtpCheckInDate = this.Controls["dtpUCheckInDate"] as DateTimePicker;
                                DateTimePicker dtpCheckOutDate = this.Controls["dtpUCheckOutDate"] as DateTimePicker;

                                if (txtCustomerID != null && txtRoomID != null && dtpCheckInDate != null && dtpCheckOutDate != null)
                                {
                                    // Populate text boxes and date pickers with reservation data
                                    txtCustomerID.Text = reader["CustomerID"].ToString();
                                    txtRoomID.Text = reader["RoomID"].ToString();
                                    dtpCheckInDate.Value = (DateTime)reader["CheckInDate"];
                                    dtpCheckOutDate.Value = (DateTime)reader["CheckOutDate"];
                                }
                                else
                                {
                                    MessageBox.Show("One or more controls are not correctly initialized.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Reservation not found.");
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


        private void btnBackToReservationForm_Click(object sender, EventArgs e)
        {
            // Close the AddOrUpdateCustomer form and notify the parent CustomerForm
            this.Close();
            _reservationForm.OnFormClosed();
        }
    }
}
