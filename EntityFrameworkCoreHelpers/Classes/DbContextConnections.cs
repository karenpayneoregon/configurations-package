using System.Diagnostics;
using ConfigurationLibrary.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCoreHelpers.Classes
{
    public class DbContextConnections
    {
        /// <summary>
        /// Simple configuration for setting the connection string
        /// </summary>
        /// <param name="optionsBuilder"></param>
        public static void NoLogging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString());
        }

        /// <summary>
        /// Default logging to output window
        /// </summary>
        public static void StandardLogging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message));
        }
        /// <summary>
        /// Writes/appends to a file
        /// Make sure that the folder exists, as coded folder name is Logs under the app folder.
        /// One way to ensure the folder exists is to use MsBuild task MakeDir as in
        /// the test project ShadowPropertiesUnitTestProject.
        /// </summary>
        public static void CustomLogging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextLogger().Log)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        /// <summary>
        /// Writes/appends to a file
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <param name="fileName">File name to write log data too</param>
        public static void CustomLogging(DbContextOptionsBuilder optionsBuilder, string fileName)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextLogger(fileName).Log)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
