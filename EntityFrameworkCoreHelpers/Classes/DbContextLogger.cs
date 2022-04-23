using System;
using System.IO;

namespace EntityFrameworkCoreHelpers.Classes
{
    /// <summary>
    /// For logging messages from DbContext.
    /// </summary>
    public class DbContextLogger
    {
        private readonly string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt");
        /// <summary>
        /// append to the existing stream
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            
            if (!File.Exists(fileName))
            {
                File.CreateText(fileName).Close();
            }

            StreamWriter streamWriter = new(fileName, true);

            streamWriter.WriteLine(message);

            streamWriter.WriteLine("-----------------------------------------------------------------");

            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}