using Microsoft.CodeAnalysis;
using MVC_ADO.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVC_ADO.DataAccess
{
    public class ProductDataAccess
    {

        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;

        Product product;

        static int id, count;
        static string name;
        static decimal price;

        private static SqlConnection GetConnection()
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;");
            return conn;
        }

        public Boolean Create()
        {
            try
            {
                using (conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("create table Product(id int primary key, name varchar(50), price decimal(10,2))", conn);
                    conn.Open();
                    int val = cmd.ExecuteNonQuery();
                    //Console.WriteLine("Table Create successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Product Insert(Product product)
        {
            using (conn = GetConnection())
            {

                SqlCommand cmd = new SqlCommand("insert into Product values(@id, @name, @price)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);

                int val = cmd.ExecuteNonQuery();

                if (val > 0)
                {
                    return product;
                    //Console.WriteLine("Inserted data.");
                }
                else
                {
                    return null;
                    //Console.WriteLine("Not Inserted.");
                }
            }
        }

        public Boolean Update(Product product)
        {
            try
            {
                using (conn = GetConnection())
                {
                    cmd = new SqlCommand("update product set name = @name, price = @price where id = @id", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@id", product.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return false;
        }

        public void Delete(int id)
        {
            try
            {
                using (conn = GetConnection())
                {
                    cmd = new SqlCommand("delete from product where id = @id", conn);
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Product> Fetch
        {
            get
            {
                List<Product> list = new List<Product>();
                //List<Product> lstpro = new List<Product>();
                using (conn = GetConnection())
                {
                    cmd = new SqlCommand("select * from Product", conn);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        list.Add(new Product()
                        {
                            Id = Convert.ToInt32(sdr[0].ToString()),
                            Name = sdr[1].ToString(),
                            Price = Convert.ToDecimal(sdr[2].ToString())
                        });
                    }
                }
                return list;
            }
        }

        public Product GetProductById(int? id)
        {
            //List<Product> lstpro = new List<Product>();
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("select * from Product where id = @id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                    {
                    product = new Product()
                    {
                        Id = Convert.ToInt32(sdr[0].ToString()),
                        Name = sdr[1].ToString(),
                        Price = Convert.ToDecimal(sdr[2].ToString())
                    };
                }
            }
            return product;
        }
    }
}
