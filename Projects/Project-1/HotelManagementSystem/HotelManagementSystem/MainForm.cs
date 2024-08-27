using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class MainForm : Form
    {
        // Constructor for MainForm, initializes components
        public MainForm()
        {
            InitializeComponent();
        }

        // Event handler for the label1 click event
        private void label1_Click(object sender, EventArgs e)
        {
            // Intentionally left empty, can be used for label click event handling
        }

        // Event handler for the CustomerFrom button click event
        private void CustomerFrom_Click(object sender, EventArgs e)
        {
            try
            {
                // Create and show the CustomerForm dialog
                CustomerForm customerForm = new CustomerForm(this);
                customerForm.ShowDialog();
                // this.Hide(); // Optional: hide the main form if needed
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Event handler for the RoomForm button click event
        private void RoomForm_Click(object sender, EventArgs e)
        {
            try
            {
                // Create and show the RoomForm dialog
                RoomForm roomForm = new RoomForm(this);
                roomForm.ShowDialog();
                // this.Hide(); // Optional: hide the main form if needed
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Event handler for the ReservationForm button click event
        private void ReservationForm_Click(object sender, EventArgs e)
        {
            try
            {
                // Create and show the ReservationForm dialog
                ReservationForm reservationForm = new ReservationForm(this);
                reservationForm.ShowDialog();
                // this.Hide(); // Optional: hide the main form if needed
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Method to be called when another form (e.g., CustomerForm) is closed
        public void OnFormClosed()
        {
            // Show the MainForm when the other form is closed
            this.Show();
        }

        // Event handler for the ExitApplication button click event
        private void ExitApplication_Click(object sender, EventArgs e)
        {
            // Close the MainForm and exit the application
            this.Close();
        }

        // Event handler for the form load event
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Intentionally left empty, can be used for initialization when the form loads
        }
    }
}
