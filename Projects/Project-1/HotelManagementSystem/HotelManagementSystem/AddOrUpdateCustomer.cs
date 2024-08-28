using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HotelManagementSystem
{
    public partial class AddOrUpdateCustomer : Form
    {
        private CustomerForm customerForm; // Reference to the parent CustomerForm
        private static string operationType; // Operation type ("ADD" or "UPDATE")
        private static string connectionString = "data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;"; // Database connection string
        private static SqlConnection conn; // SQL connection object

        // Method to get the SQL connection object
        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection(connectionString);
            return conn;
        }

        // Constructor for the AddOrUpdateCustomer form
        public AddOrUpdateCustomer(CustomerForm customerForm, string type)
        {
            InitializeComponent();
            this.customerForm = customerForm; // Set the reference to the parent form
            operationType = type; // Set the operation type (either "ADD" or "UPDATE")
        }

        // Event handler for the form load event
        private void AddOrUpdateCustomer_Load(object sender, EventArgs e)
        {
            // Initialize form controls based on the operation type
            if (operationType.ToUpper().Equals("ADD"))
            {
                InitializeAddControls(); // Initialize controls for adding a customer
            }
            else if (operationType.ToUpper().Equals("UPDATE"))
            {
                InitializeUpdateControls(); // Initialize controls for updating a customer
            }
        }

        // Method to initialize controls for adding a customer
        private void InitializeAddControls()
        {
            // Create and configure Labels for customer details
            Label lblFirstName = new Label
            {
                Text = "First Name:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblLastName = new Label
            {
                Text = "Last Name:",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            Label lblEmail = new Label
            {
                Text = "Email:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };

            Label lblPhoneNumber = new Label
            {
                Text = "Phone Number:",
                Location = new System.Drawing.Point(20, 140),
                AutoSize = true
            };

            // Create and configure TextBoxes for input
            TextBox txtFirstName = new TextBox
            {
                Name = "txtFirstName",
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtLastName = new TextBox
            {
                Name = "txtLastName",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtEmail = new TextBox
            {
                Name = "txtEmail",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20)
            };

            TextBox txtPhoneNumber = new TextBox
            {
                Name = "txtPhoneNumber",
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20)
            };

            // Create and configure Button for adding customer
            Button btnAdd = new Button
            {
                Text = "Add Customer",
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(120, 30)
            };

            // Attach event handler for button click
            btnAdd.Click += new EventHandler(btnAdd_Click);

            // Add controls to the form
            this.Controls.Add(lblFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblPhoneNumber);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtPhoneNumber);
            this.Controls.Add(btnAdd);
        }

        // Event handler for the Add button click event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes
            string firstName = this.Controls["txtFirstName"].Text;
            string lastName = this.Controls["txtLastName"].Text;
            string email = this.Controls["txtEmail"].Text;
            string phoneNumber = this.Controls["txtPhoneNumber"].Text;

            // Validate inputs
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                ValidateEmail(email);
                ValidatePhoneNumber(phoneNumber);

                SaveCustomer(firstName, lastName, email, phoneNumber);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Save the customer to the database
        }

        // Method to save a new customer to the database
        private void SaveCustomer(string firstName, string lastName, string email, string phoneNumber)
        {
            using (conn = GetConnection())
            {
                string query = "INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Execute the insert command
                }
            }

            // Notify user and close the form
            MessageBox.Show("Customer added successfully.");
            this.Close();
        }

        // Method to initialize controls for updating an existing customer
        private void InitializeUpdateControls()
        {
            // Create and configure Labels for customer details including ID
            Label lblCustomerId = new Label
            {
                Text = "Customer ID:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };

            Label lblFirstName = new Label
            {
                Text = "First Name:",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true
            };

            Label lblLastName = new Label
            {
                Text = "Last Name:",
                Location = new System.Drawing.Point(20, 100),
                AutoSize = true
            };

            Label lblEmail = new Label
            {
                Text = "Email:",
                Location = new System.Drawing.Point(20, 140),
                AutoSize = true
            };

            Label lblPhoneNumber = new Label
            {
                Text = "Phone Number:",
                Location = new System.Drawing.Point(20, 180),
                AutoSize = true
            };

            // Create and configure TextBoxes for input, including a customer ID
            TextBox txtCustomerId = new TextBox
            {
                Name = "txtUCustomerId",
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(200, 20),
                Text = ""
            };

            TextBox txtFirstName = new TextBox
            {
                Name = "txtUFirstName",
                Location = new System.Drawing.Point(150, 60),
                Size = new System.Drawing.Size(200, 20),
                Text = ""
            };

            TextBox txtLastName = new TextBox
            {
                Name = "txtULastName",
                Location = new System.Drawing.Point(150, 100),
                Size = new System.Drawing.Size(200, 20),
                Text = ""
            };

            TextBox txtEmail = new TextBox
            {
                Name = "txtUEmail",
                Location = new System.Drawing.Point(150, 140),
                Size = new System.Drawing.Size(200, 20),
                Text = ""
            };

            TextBox txtPhoneNumber = new TextBox
            {
                Name = "txtUPhoneNumber",
                Location = new System.Drawing.Point(150, 180),
                Size = new System.Drawing.Size(200, 20),
                Text = ""
            };

            // Create and configure Buttons for updating and retrieving customer data
            Button btnUpdate = new Button
            {
                Text = "Update Customer",
                Location = new System.Drawing.Point(150, 220),
                Size = new System.Drawing.Size(120, 30)
            };

            Button btnGetData = new Button
            {
                Text = "Get Customer",
                Location = new System.Drawing.Point(300, 220),
                Size = new System.Drawing.Size(120, 30)
            };

            // Attach event handlers for button clicks
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnGetData.Click += new EventHandler(btnGetData_Click);

            // Add controls to the form
            this.Controls.Add(lblCustomerId);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblPhoneNumber);
            this.Controls.Add(txtCustomerId);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtPhoneNumber);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnGetData);
        }

        // Event handler for the Update button click event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes
            string customerIdText = this.Controls["txtUCustomerId"].Text;
            string firstName = this.Controls["txtUFirstName"].Text;
            string lastName = this.Controls["txtULastName"].Text;
            string email = this.Controls["txtUEmail"].Text;
            string phoneNumber = this.Controls["txtUPhoneNumber"].Text;

            // Validate inputs
            if (!int.TryParse(customerIdText, out int customerId) ||
                string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }
            try
            {
                ValidateEmail(email);
                ValidatePhoneNumber(phoneNumber);

                UpdateCustomer(customerId, firstName, lastName, email, phoneNumber);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Update the customer in the database
        }

        // Event handler for the Get Data button click event
        private void btnGetData_Click(object sender, EventArgs e)
        {
            // Load customer data into text boxes based on customer ID
            LoadCustomerData();
        }

        // Method to update an existing customer in the database
        private void UpdateCustomer(int customerId, string firstName, string lastName, string email, string phoneNumber)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber WHERE CustomerID = @CustomerID", conn))
                {
                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); // Execute the update command
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No customer found with the given ID.");
                    }
                }
            }
        }

        // Method to load customer data from the database based on customer ID
        private void LoadCustomerData()
        {
            using (conn = GetConnection())
            {
                string customerIdText = this.Controls["txtUCustomerId"].Text;
                if (!int.TryParse(customerIdText, out int customerId))
                {
                    MessageBox.Show("Please enter a valid Customer ID.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand("SELECT FirstName, LastName, Email, PhoneNumber FROM Customers WHERE CustomerID = @CustomerID", conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate text boxes with customer data
                                this.Controls["txtUFirstName"].Text = reader["FirstName"].ToString();
                                this.Controls["txtULastName"].Text = reader["LastName"].ToString();
                                this.Controls["txtUEmail"].Text = reader["Email"].ToString();
                                this.Controls["txtUPhoneNumber"].Text = reader["PhoneNumber"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Customer not found.");
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

        private void ValidateEmail(string email)
        {
            // This method validates the email address using a regular expression pattern.
            // The pattern checks for a valid email format.

            // Define the regex pattern for a valid email address.
            var emailPattern = @"^[a-zA-Z0-9_+&*-]+(?:\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,7}$";

            // Use the Regex.IsMatch method to check if the email matches the pattern.
            if (!Regex.IsMatch(email, emailPattern))
            {
                // If the email does not match the pattern, throw an InvalidException with an error message.
                throw new InvalidException($"Invalid Mail ID: {email}");
            }
            
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            // This method validates the phone number using a regular expression pattern.
            // The pattern checks for a valid 10-digit phone number starting with a digit between 6 and 9.

            // Define the regex pattern for a valid phone number.
            var phonePattern = @"^[6-9][0-9]{9}$";

            // Use the Regex.IsMatch method to check if the phone number matches the pattern.
            if (!Regex.IsMatch(phoneNumber, phonePattern))
            {
                // If the phone number does not match the pattern, throw an InvalidException with an error message.
                throw new InvalidException($"Invalid Phone number: {phoneNumber}");
            }
            
        }

        // Event handler for the Back button click event
        private void btnBackToCustomerForm_Click(object sender, EventArgs e)
        {
            // Close the AddOrUpdateCustomer form and notify the parent CustomerForm
            this.Close();
            customerForm.OnFormClosed();
        }
    }

    // Custom exception class to handle validation errors.
    // This class inherits from the base Exception class and allows for custom error messages.
    public class InvalidException : Exception
    {
        // Constructor that takes a message parameter and passes it to the base Exception class constructor.
        public InvalidException(string message) : base(message)
        {
        }
    }
}
