
namespace ConfigurationLibrary.Classes
{
    public class ConfigurationMapAsp
    {
        public string ActiveEnvironment { get; set; }
        public string Development { get; set; }
        public string Stage { get; set; }
        public string Production { get; set; }
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


}
