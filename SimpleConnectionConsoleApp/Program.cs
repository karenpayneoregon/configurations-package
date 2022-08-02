using System;
using ConfigurationLibrary.Classes;

namespace SimpleConnectionConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationHelper.ConnectionString();
            Console.WriteLine(connectionString);
            Console.ReadLine();
        }
    }
}
