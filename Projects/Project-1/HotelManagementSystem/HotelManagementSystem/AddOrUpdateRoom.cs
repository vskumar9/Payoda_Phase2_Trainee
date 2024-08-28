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

        private void AddOrUpdateRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
