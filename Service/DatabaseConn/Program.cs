
namespace DatabaseConn
{
    using System;
    using System.Data.SqlClient;
    using MyApp.DataAccess.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    class Program
    {
        //private static string SqlConnectionString = "Server=tcp:shipping-co.database.windows.net,1433;Initial Catalog=shipping-co;Persist Security Info=False;User ID=shipping-dbadmin;Password=Bacon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static void Main(string[] args)
        {
                var context = new shippingcoContext();

                var getUSer = context.Users
                                      .Where(s => s.Id == 2)
                                      .ToList();
            
                Console.WriteLine(getUSer[0].Username);

            // string queryString = "SELECT * FROM Users;";

            // using(var client = new SqlConnection(SqlConnectionString))
            // {
            //     SqlCommand command = new SqlCommand(queryString, client);
            //     client.Open();
            //     SqlDataReader reader = command.ExecuteReader();
            //     while (reader.Read())
            //     {
            //         Console.WriteLine(String.Format("{0}, {1}, {2}",
            //             reader[0], reader[1], reader[2]));
            //     }
            //     reader.Close();
            //     client.Close();

            // }

        }
    }
}
