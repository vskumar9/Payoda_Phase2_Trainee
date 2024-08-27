using System;
using System.Data.SqlClient;
using System.Linq.Expressions;

internal class Program
{
    private static SqlConnection conn = null;
    private static SqlCommand cmd = null;

    private static List<string> list = new List<string>();

    static int id, count;
    static string name;
    static decimal price;

    private static void Main(string[] args)
    {
        int choice;
        Console.WriteLine("--WELCOME TO APPLICATION--\nEnter the process to be executed:");
        do
        {
            Console.WriteLine("\nSelect below options:\n1.Create\n2.Insert\n3.Delete\n4.Update\n5.Fetch\n6.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            try
            {
            switch(choice)
            {
                    case 1:
                        if (Create())
                        {
                            Console.WriteLine("Table Created successfully");
                        }
                        else
                        {
                            Console.WriteLine("Table Not Created.");
                        }
                        break;
                    case 2:

                        Console.WriteLine("Enter number of product insert: ");
                        count = Convert.ToInt32(Console.ReadLine());

                        while(count > 0)
                        {
                            Console.WriteLine("Enter the product id, name, and price:");
                            id = Convert.ToInt32(Console.ReadLine());
                            name = Console.ReadLine();
                            price = Convert.ToDecimal(Console.ReadLine());
                            if(Insert(id, name, price))
                            {
                                Console.WriteLine($"Id: {id} product successfully inserted.");
                            }
                            else
                            {
                                Console.WriteLine($"Id: {id} product not inserted.");
                            }
                            count -= 1;
                        }
                        break;
                    case 3:

                        Console.WriteLine("Enter product id:");
                        id = Convert.ToInt32(Console.ReadLine());
                        if(Delete(id))
                        {
                            Console.WriteLine($"Product Id: {id} successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine($"Product Id: {id} not deleted/not available.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the product id and price");
                        id = Convert.ToInt32(Console.ReadLine());
                        price = Convert.ToDecimal(Console.ReadLine());
                        if(Update(id, price))
                        {
                            Console.WriteLine($"product id: {id} updated.(price = {price})");
                        }
                        else
                        {
                            Console.WriteLine($"Product id: {id} not updated.");
                        }
                        break;
                    case 5:

                        List<string> list = Fetch;
                        if(list.Count != 0)
                        {
                            string heading = string.Format("{0, -5}{1, -15}{2, -15}", "Id", "Name", "Price");
                            Console.WriteLine(heading);
                            foreach(string str in list)
                            {
                                Console.WriteLine(str);
                            }
                            list.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Not available products.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("--Thank you--\nClosing Application");
                        break;
                    default: 
                        Console.WriteLine("Wrong option selected.");
                        break;
                    }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (choice != 6);
    }


    private static SqlConnection GetConnection()
    {
        conn = new SqlConnection("data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;");
        return conn;
    }

    public static Boolean Create()
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

    public static Boolean Insert(int id, string name, decimal price)
    {
        using (conn = GetConnection())
        {

            SqlCommand cmd = new SqlCommand("insert into Product values(@id, @name, @price)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);

            int val = cmd.ExecuteNonQuery();

            if (val > 0)
            {
                return true;
                //Console.WriteLine("Inserted data.");
            }
            else
            {
                return false;
                //Console.WriteLine("Not Inserted.");
            }
        }
    }

    private static Boolean Update(int id, decimal price)
    {
        try
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("update product set price = @price where id = @id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);

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

    private static Boolean Delete(int id)
    {
        try
        {
            using(conn = GetConnection())
            {
                cmd = new SqlCommand("delete from product where id = @id", conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }
    private static List<string> Fetch
    {
        get
        {
            using (conn = GetConnection())
            {
                cmd = new SqlCommand("select * from Product", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    list.Add(String.Format("{0, -5}{1, -15}{2, -15}", sdr[0].ToString(), sdr[1].ToString(), sdr[2].ToString()));
                }
                return list;
            }
        }
    }
}