using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

/*
 * Open and read data from CAME local file (dati impinato, on hard disk).
 */
namespace RBM21_core
{
    class FileReader
    {
        private string path;
        public FileReader(string path)
        {
            this.path = path;            
        }

        public List<User> ParseFile() //TODO if file doesn't exists? use exceptions!
        {
           // throw new IOException("ma daiiiii");

            List<User> userlist = new List<User>();
            if (!File.Exists(path))
            {
                //FIXME raise error
                Debug.WriteLine("file non esiteee");
                return null;
            }
            StreamReader sr = File.OpenText(this.path);
            ConsumeLines(sr);

            User u = ParseUserfromFile(sr);
            while (u != null)
            {
                userlist.Add(u);
                u = ParseUserfromFile(sr);
            }
            return userlist;

        }
        private User ParseUserfromFile(StreamReader sr)
        {
            User usr = new User();

            string t = sr.ReadLine();
            if (t.StartsWith(";----------------")) {
                while (!sr.EndOfStream){
                    sr.ReadLine(); }
                return null;

            }

            //G0, position
            string s= Regex.Match(t, @"<..>\s*(?<val>\d+)").Groups["val"].Value;
            usr.Position = Int32.Parse(s);

            //G1, name
            s = Regex.Match(sr.ReadLine(), @"<..>(?<name>[\w ]+)").Groups["name"].Value;
            usr.Nome = s;

            sr.ReadLine(); //FIXME this would be W0 (=89), is that useless?
            sr.ReadLine();
            sr.ReadLine();

            //G5..G9, key
            string key = "";
            for (int i = 0; i < 5; i++) {                
                s = Regex.Match(sr.ReadLine(), @"<..>\s*(?<val>\d+)").Groups["val"].Value;               
                key = key + Int32.Parse(s).ToString("X2");                
            }
            usr.Key = key;

            //GA, prepagato (col dx)
            s = Regex.Match(sr.ReadLine(), @"<..>(?<name>[\w ]+)").Groups["name"].Value;            
            usr.CreditoResiduo = Int32.Parse(s);

            //GB, last access (time)
            s = Regex.Match(sr.ReadLine(), @"<..>(?<name>[\w ]+)").Groups["name"].Value;
            int minutes = Int32.Parse(s);

            //GC, colonna sx prepagato (SKIP)
            sr.ReadLine();
            //s = Regex.Match(sr.ReadLine(), @"<..>(?<name>[\w ]+)").Groups["name"].Value;
            //usr.CreditoIns = Int32.Parse(s);

            //GD, last access (day)
            s = Regex.Match(sr.ReadLine(), @"<..>(?<name>[\w ]+)").Groups["name"].Value;
            int day = Int32.Parse(s);

            usr.Time = timeCalculator(day, minutes); //FIXME is useful????? DO I NEED IT???? I DON?T THINK!!!

            //usr.UserCode = usr.Key;// +usr.Nome; //FIXME
            usr.UserCode = usr.Key+usr.Nome;
            usr.Active = true;
            //<wu>, end of section
            sr.ReadLine(); 

            return usr;
        }

        /*consume initial line with non users data.
         * So consume all lines until we reach: 
         *       ;-----------------------------------------
         *       ;       Dati Utenti                       
         *       ;-----------------------------------------
         * so StreamReader sr will contain only users data.
         */
        private void ConsumeLines(StreamReader sr) {      
            string line = "";
            while ((line = sr.ReadLine()) != null){
                if (line.Contains(";----------") && sr.ReadLine().Contains("Dati Utenti") && sr.ReadLine().Contains(";----------")){
                    break;
                }
                
            }

        }

        /*
         * RBM21 memorize only Day and Time, not Month's of last access.
         * So we need to guess that value! if day is futher than now, RBM21 is referring to the previous month.
         */
        public static DateTime timeCalculator(int entDay, int entMinutes) //minutes: total time expresses in minutes (HH=minutes/60; MM=minutes%60)
        {
            DateTime now = DateTime.Now;
            //case RBM21 data is in the past
            if (now.Day > entDay | (now.Day == entDay & (now.Hour * 60 + now.Minute >= entMinutes)))
                return new DateTime(now.Year, now.Month, entDay, entMinutes / 60, entMinutes % 60, 0);
            //case RBM21 data is in the future
            else
            {
                var y = now.Year;
                var m = now.Month-1;
                if (m == 0)
                {
                    m = 12;
                    y--;
                }
                return new DateTime(y, m, entDay, entMinutes / 60, entMinutes % 60, 0);
            }           
        }
    }
}
