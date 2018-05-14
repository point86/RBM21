using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace RBM21_core
{

    /* settings file format:
     * CameFilePath C:\\programs\\came\\cai.tsp
     * SQLiteDB C:\\users\\desktop\\cai.sqlite
     * Enabled true
     */
    class SettingsManager
    {
        private string CameFilePath = null;
        private string SQLiteDB = null;
        private string enabled = null;
        private string path = null;

        public SettingsManager(string path)
        {
            this.path = path;
            string[] lines = System.IO.File.ReadAllLines(path);

            /* if input is:
             * SQLiteDB C:\\users\\desktop\\cai.sqlite
             * Regex.match will capture:
             * C:\\users\\desktop\\cai.sqlite 
             * so throw away first word, first blank characters and return all text remaining
             */
            CameFilePath = Regex.Match(lines[0], @"^\w+\s+(.+)").Groups[1].Value;
            SQLiteDB = Regex.Match(lines[1], @"^\w+\s+(.+)").Groups[1].Value;
            enabled = Regex.Match(lines[2], @"^\w+\s+(.+)").Groups[1].Value;            
        }
        public void SaveSettings()
        {
            string[] lines = {
                    "CameFilePath " + this.CameFilePath,
                    "SQLiteDB " + this.SQLiteDB,
                    "enabled "  + this.enabled
            };
            System.IO.File.WriteAllLines(this.path, lines);
        }
        public string GetCameFilePath()
        {
            return CameFilePath;
        }
        public string GetSQLITEDB()
        {
            return SQLiteDB;
        }
        public string GetEnabled()
        {
            return enabled;
        }        
    }
}
