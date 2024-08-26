using System.Data.SqlClient;

internal class Program
{
    private static SqlConnection conn;

    private static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");
        Create();
        Insert();
        Fetch();
    }

    public static void Create()
    {
        using(conn = new SqlConnection("data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;"))
        {
            SqlCommand cmd = new SqlCommand("create table sample_ADO(id int primary key, name varchar(50))", conn);
            conn.Open();
            int val = cmd.ExecuteNonQuery();

            //if (val > 0)
            //{
                Console.WriteLine("Table Create successfully");
                Console.WriteLine("Query successfully executed.");
            //}
            //else
            //{
            //    Console.WriteLine("Table not created.");
            //}
        }
    }

    public static void Insert()
    {
        using (conn = new SqlConnection("data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;"))
        {

            SqlCommand cmd = new SqlCommand("insert into sample_ADO values(1, 'Sanjeev')", conn);
            conn.Open();
            int val = cmd.ExecuteNonQuery();

            if (val > 0)
            {
                Console.WriteLine("Inserted data.");
            }
            else
            {
                Console.WriteLine("Not Inserted.");
            }
        }
    }

    public static void Fetch()
    {
        using (conn = new SqlConnection("data source=PTSQLTESTDB01;database=KUMAR;integrated security=true;"))
        {
            SqlCommand cmd = new SqlCommand("select * from sample_ADO", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while(sdr.Read())
            {
                Console.WriteLine(sdr[0].ToString() + " " + sdr[1].ToString());
            }
        }
    }
}