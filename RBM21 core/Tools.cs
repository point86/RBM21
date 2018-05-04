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
            System.IO.StreamWriter sw = System.IO.File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "RBM21_core.log");
            
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

    }
}
