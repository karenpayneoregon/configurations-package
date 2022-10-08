using System;
using ConfigurationLibrary.Classes;

namespace SimpleConnectionConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationHelper.ConnectionStringWeb();
            Console.WriteLine(connectionString);
            Console.ReadLine();
        }
    }
}
