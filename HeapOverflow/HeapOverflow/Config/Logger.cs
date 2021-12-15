using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HeapOverflow.Config
{
    public class Logger
    {
        private static readonly string _directory = @"C:\ProgramData\Heapoverflow";
        private static readonly string _filePath = _directory + @"\log.txt";
        private string className = "Empty";

        public Logger(string className)
        {
            this.className = className;
            CreateDirectory();
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

        }

        public void Log(string data)
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    var file = File.Create(_filePath);
                    file.Close();
                }
                File.AppendAllText(_filePath, ">>>" + DateTime.Now + "  " + className + "\r\n" + data + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}