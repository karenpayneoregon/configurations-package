using System;
using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace SimpleConnectionConsoleApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
        }
    }


    public class AspCoreRoot
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionsConfiguration ConnectionsConfiguration { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class ConnectionsConfiguration
    {
        public string ActiveEnvironment { get; set; }
        public string Development { get; set; }
        public string Stage { get; set; }
        public string Production { get; set; }
    }

}





