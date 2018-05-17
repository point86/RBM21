using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace RBM21_core
{

    /* Open settings file, located in the same folder as executable, with name RBM21CoreSettings.conf
     * 
     * file format:
     * CameFilePath C:\\programs\\came\\cai.tsp
     * SQLiteDB C:\\users\\desktop\\cai.sqlite
     * SerialPort COM2
     * Enabled True
     */
    class SettingsManager
    {
        public string CameFilePath { get; set; }
        public string SQLiteDB { get; set; }
        public bool Enabled { get; set; }
        public string SerialPort { get; set; }
        private string path;
        public SettingsManager()
        {
            this.path = AppDomain.CurrentDomain.BaseDirectory + "RBM21CoreSettings.conf";
            string[] lines = System.IO.File.ReadAllLines(path);
            /* if input is:
             * SQLiteDB C:\\users\\desktop\\cai.sqlite
             * Regex.match will capture:
             * C:\\users\\desktop\\cai.sqlite 
             * so throw away first word, first blank characters and return all text remaining
             */
            CameFilePath = Regex.Match(lines[0], @"^\w+\s+(.+)").Groups[1].Value;
            SQLiteDB = Regex.Match(lines[1], @"^\w+\s+(.+)").Groups[1].Value;
            SerialPort = Regex.Match(lines[2], @"^\w+\s+(.+)").Groups[1].Value;
            string enabled0 = Regex.Match(lines[3], @"^\w+\s+(.+)").Groups[1].Value;
            if (enabled0 == "True" | enabled0 == "true")
                Enabled = true;
            else
                Enabled = false;
        }
        //public string SaveSettings()
        public void SaveSettings()
        { //FIXME why return something?
            string[] lines = {
                    "CameFilePath " + this.CameFilePath,
                    "SQLiteDB " + this.SQLiteDB,
                    "SerialPort " + this.SerialPort,
                    "Enabled "  + this.Enabled.ToString()
            };
            
            System.IO.File.WriteAllLines(path, lines);
           // return path;
        }
    }
}
