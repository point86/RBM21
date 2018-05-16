using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace RBM21_core
{
    class Tools
    {
        public Tools() { } //FIXME è necessario? questa classe non deve essere istanziata.
        public static void LogMessageToFile(string msg)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "RBM21_core.log";
            System.IO.StreamWriter sw = System.IO.File.AppendText(path);
            
            try
            {                
                var logLine = System.String.Format("[{0}] {1}", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
        /* If size of Log file is too much bigger (bigger than 10000 lines), throw away first 5000 lines         
         */ 
        public static void LogSizeManager()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "RBM21_core.log";
            var lineCount = File.ReadLines(path).Count();
            if (lineCount > 100000)
            {
                string[] allLines = File.ReadAllLines(path);
                string[] LastHalfLines = allLines.Skip(allLines.Length / 2).ToArray();
                File.WriteAllLines(path, LastHalfLines);
            }
            LogMessageToFile("------ LogSizeManager: successfully deleted first 50000 lines of this file. ------");
        }
    }
}
