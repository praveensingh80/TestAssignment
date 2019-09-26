using Framework.Config;
using System;
using System.IO;

namespace Framework.Helpers
{
    public class LogHelpers
    {
        //Log file name
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamWriter = null;

        //Create file to store log informattion
        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;
            if(Directory.Exists(dir))
            {
                _streamWriter = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamWriter = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //write text in log file
        public static void Write(string logMessage)
        {
            _streamWriter.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamWriter.WriteLine("    {0}", logMessage);
            _streamWriter.Flush();
        }
    }
}
