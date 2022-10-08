
namespace ConfigurationLibrary.Classes
{
    public class ConfigurationMapAsp
    {
        public string ActiveEnvironment { get; set; }
        public string Development { get; set; }
        public string Stage { get; set; }
        public string Production { get; set; }
    }


    public class Rootobject
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionsConfiguration ConnectionsConfiguration { get; set; }
        public ConnectionStrings ConnectionStrings1 { get; set; }
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



    public class ConnectionStrings
    {
        public string ActiveEnvironment { get; set; }
        public string Development { get; set; }
        public string Stage { get; set; }
        public string Production { get; set; }
    }

}
