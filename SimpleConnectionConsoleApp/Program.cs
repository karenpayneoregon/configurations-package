using System;
using System.Threading.Tasks;
using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;

namespace SimpleConnectionConsoleApp
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
            await cn.OpenAsync();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
