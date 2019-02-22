
namespace DatabaseConn
{
    using System;
    using System.Data.SqlClient;
    using MyApp.DataAccess.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
                var context = new shippingcoContext();

                var quotes = context.Quotes
                .Where(q => q.ClientId.ToString() == "1")
                .ToList();
            
                Console.WriteLine(quotes[0].Id );


        }
    }
}
