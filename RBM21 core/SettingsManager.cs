using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace RBM21_core
{
    class SettingsManager
    {
        string DatabasePath;
        string CameFilePath;
        bool active;

        public SettingsManager(string path)
        {
            StreamReader sr = File.OpenText(path);

        }

        public void SaveSettings()
        {

        }



    }
}
