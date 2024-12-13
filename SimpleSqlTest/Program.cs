using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleSqlTest
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Must specify the name of the connection string to lookup in app.config");
                return;
            }

            

            Console.WriteLine($"Running simple sql test 10 times on {args[0]} connection string.");
            var connectionString = ConfigurationManager.ConnectionStrings[args[0]].ConnectionString;
            Console.WriteLine();
            Console.WriteLine(connectionString);
            Console.WriteLine();

            var sw = new Stopwatch();
            var swTotal = new Stopwatch();
            sw.Start();
            swTotal.Start();
            for(var i = 1; i <= 10; i++)
            {
                swTotal.Start();
                sw.Restart();
                GetBooksSystemSql(connectionString);
                sw.Stop();
                swTotal.Stop();
                Console.WriteLine($"{i}. {sw.ElapsedMilliseconds}ms");
            }
            Console.WriteLine($"Total: {swTotal.ElapsedMilliseconds}ms\r\n");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void GetBooksSystemSql(string connectionString)
        {


            using (var sqlConn = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM Books", sqlConn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process each row
                            var title = reader["Title"].ToString();
                            var author = reader["Author"].ToString();
                            var price = (decimal)reader["Price"];
                            // Add your processing logic here
                        }
                    }
                }
            }

        }
    }
}
