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

namespace GridViewApp
{
    public partial class Form1 : Form
    {
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;
        private static int id;
        private static string name;
        private static decimal price;
        public Form1()
        {
            InitializeComponent();
        }

        private static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;");
            return conn;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using(conn = GetConnection())
            {
                cmd = new SqlCommand("select * from product", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("insert into product values(@id, @name, @price)", conn);
                conn.Open();
                id = Convert.ToInt32(textBox1.Text);
                name = Convert.ToString(textBox2.Text);
                price = Convert.ToDecimal(textBox3.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);

                int count = cmd.ExecuteNonQuery();
                if(count > 0) MessageBox.Show("Inserted data.");


                Form1_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("delete from product where id = @id", conn);
                conn.Open();
                id = Convert.ToInt32(textBox1.Text);
                
                cmd.Parameters.AddWithValue("@id", id);

                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Deleted data.");


                Form1_Load(sender, e);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("update product set price = @price where id = @id", conn);
                conn.Open();
                id = Convert.ToInt32(textBox1.Text);
                price = Convert.ToDecimal(textBox3.Text);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);

                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Updated data.");


                Form1_Load(sender, e);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("select * from product where id = @id", conn);
                conn.Open();

                id = Convert.ToInt32(textBox1.Text);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                dataGridView1.DataSource = dt;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("select count(*) from product", conn);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show($"Total Product: {count}");
            }
        }
    }
}
