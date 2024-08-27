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
    public partial class RoomForm : Form
    {
        private MainForm _mainForm;
        public RoomForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBackToMainForm_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.OnFormClosed();
        }
    }
}
