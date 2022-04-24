using System;
using System.IO;

namespace EntityFrameworkCoreHelpers.Classes
{
    /// <summary>
    /// For logging messages from DbContext.
    /// </summary>
    public class DbContextLogger
    {
        private string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt");

        public DbContextLogger(string fileName)
        {
            _fileName = fileName;
        }

        public DbContextLogger()
        {
            
        }
        /// <summary>
        /// append to the existing stream
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            
            if (!File.Exists(_fileName))
            {
                File.CreateText(_fileName).Close();
            }

            StreamWriter streamWriter = new(_fileName, true);

            streamWriter.WriteLine(message);

            streamWriter.WriteLine("-----------------------------------------------------------------");

            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}