using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HeapOverflow.Config
{
    public class Logger
    {
        private readonly string _filePath = "log.txt";
        private string className = "Empty";

        public Logger(string className)
        {
            this.className = className;
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