using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace RBM21_core
{
    class DBmanager
    {
        SQLiteConnection dbConnection;
        SQLiteCommand command;
        string path;

        public DBmanager(string path)
        {
            this.path = path;
            //SQLite memorize the database in a single file. If it doesn't exist, it must be created.
            if (!File.Exists(path))
                CreateDatabase(path);
            else
            {
                dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
                dbConnection.Open();
            }                                       
        }

        public User GetUser(string usercode)
        {            
            string sql = "select * from users where usercode ='" + usercode + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.HasRows) //fixme is it necessary?
                return null;

            User usr = new User();
            usr.Nome = (string)(reader["name"]);
            usr.Key = (string)(reader["key"]);
            usr.UserCode = (string)(reader["usercode"]);
            usr.Active = (long)(reader["active"]) == 1 ? true : false;
            string time = (string)reader["time"];
            usr.Entrances = GetEntrances(usr.UserCode);
            usr.CreditoResiduo = (int)((long)reader["creditoresiduo"]);
            return usr;
        }

        public List<User> GetAllUsers() {
            List<User> result = new List<User>();
            //string sql = "select * from users;";
            string sql = "select * from users order by active DESC, name ASC;"; //ORDER BY rating DESC, name ASC
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (!reader.HasRows) //fixme is it necessary?
                return result;

            User usr;
            while (reader.Read())
            {
                usr = new User();
                usr.Nome = (string)(reader["name"]);
                usr.Key = (string)(reader["key"]);
                usr.UserCode = (string)(reader["usercode"]);
                usr.Active= (long)(reader["active"]) == 1 ? true : false;                
                usr.CreditoResiduo = (int)((long)reader["creditoresiduo"]);
                //string time = (string)reader["time"];                
                usr.Entrances = GetEntrances(usr.UserCode);
                string dt = (string)(reader["datainserimento"]);
                usr.DataInserimento = DateTime.Parse(dt);
                result.Add(usr);
            }
            return result;
        }
        
        /*
         * Add new user to users table. User is identified by column usercode. 
         * Before proceding to insert new user in database, mark as Inactive all users with the same key.
         */

        public int AddUser(User usr, DateTime time)
        {
            var ulist = SearchByKey(usr.Key);

            foreach (string usercode in ulist ?? Enumerable.Empty<string>())
                SetInactive(usercode);

            //TODO find if this key have another user associated, and mark him as Inactive.
            //string cmd = string.Format("insert into users (name, key, usercode, active, time, creditoresiduo) values (\"{0}\", \"{1}\", \"{2}\", {3}, \"{4}\", {5})", usr.Nome, usr.Key, usr.UserCode, usr.Active? 1:0, usr.Time.ToString("yyyy-MM-dd HH:mm:ss"), usr.CreditoResiduo);
            //string cmd = string.Format("insert into users (name, key, usercode, active, creditoresiduo, datainserimento) values (\"{0}\", \"{1}\", \"{2}\", {3}, {4})", usr.Nome, usr.Key, usr.UserCode, usr.Active ? 1 : 0, usr.CreditoResiduo);
            string cmd = string.Format("insert into users (name, key, usercode, active, creditoresiduo, datainserimento) values (\"{0}\", \"{1}\", \"{2}\", {3}, {4}, \"{5}\")", usr.Nome, usr.Key, usr.UserCode, usr.Active ? 1 : 0, usr.CreditoResiduo, time.ToString("yyyy-MM-dd HH:mm:ss"));
            command = new SQLiteCommand(cmd, dbConnection);
            int rows = command.ExecuteNonQuery();
            Tools.LogMessageToFile(String.Format("DBmanager - AddUser \"{0}\": {1}. {2} rows affected (database: {3}).", usr.UserCode, usr.ToString(), rows, path));

            return rows;//rows affected by the previous command (must be 1)
        }

        public int SetInactive(string usercode)
        {            
            string cmd = string.Format("UPDATE users SET active = 0 WHERE usercode = \"{0}\";", usercode);
            command = new SQLiteCommand(cmd, dbConnection);
            int rows = command.ExecuteNonQuery();
            Tools.LogMessageToFile(String.Format("DBmanager - SetInactive \"{0}\". {1} rows affected. (database: {2}).", usercode, rows, path));
            return rows;//rows affected by the previous command (must be 1)   
        }

        public List<string> GetEntrances(string usercode)
        {            
            Debug.WriteLine("GetEntrances "+usercode);
            //items are ordered  by time, descending order (example 2018-03-07 01:54:00):
            string sql = "select * from entrances where usercode = '" + usercode + "'  order by time desc;";            
          // string sql = "select * from entrances where usercode = '" + usercode + "'  order by date(time) DESC;";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
                return null;

            List<string> result = new List<string>();
            while (reader.Read())
                result.Add((string)(reader["time"]));
            return result;
        }

        //given the specified key, return the list of all usercodes associated (so 1 must be active and the others inactive users).
        //FIXME why not return only the single active usercode?
        public List<string> SearchByKey(string key)
        {
            string sql = string.Format("SELECT usercode FROM USERS where key=\"{0}\";", key);
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
                return null;

            List<string> result = new List<string>();
            while (reader.Read())
                result.Add((string)(reader["usercode"]));
            return result;
        }

        public List<User> GetActiveUsers()
        {
                List<User> result = new List<User>();
                string sql = "SELECT * FROM USERS WHERE active=1;";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (!reader.HasRows) //fixme is it necessary?
                    return result;

                User usr;
                while (reader.Read())
                {
                    usr = new User();
                    usr.Nome = (string)(reader["name"]);
                    usr.Key = (string)(reader["key"]);
                    usr.UserCode = (string)(reader["usercode"]);
                    usr.Active = (long)(reader["active"]) == 1 ? true : false;
                    usr.CreditoResiduo = (int)((long)reader["creditoresiduo"]);
                   // string time = (string)(reader["time"]);
                    usr.Entrances = GetEntrances(usr.UserCode);
                //usr.Time = DateTime.Parse(time);
                    string dt = (string)(reader["datainserimento"]);
                    usr.DataInserimento = DateTime.Parse(dt);
                    result.Add(usr);
                }
                return result;
        }

        //given User usr (identified by usr.usercode), update user associated.
        public int updateUser(User usr)
        {            
            string cmd = string.Format("UPDATE users SET name = \"{0}\", key = \"{1}\", usercode = \"{2}\", active = {3}, creditoresiduo = {4} WHERE usercode = \"{5}\";", usr.Nome, usr.Key, usr.UserCode, usr.Active?1:0, usr.CreditoResiduo, usr.UserCode);
            command = new SQLiteCommand(cmd, dbConnection);
            int rows = command.ExecuteNonQuery();
            Tools.LogMessageToFile(String.Format("DBmanager - updateUser \"{0}\":  {1}. {2} rows affected (database: {3}).", usr.UserCode, usr.ToString(), rows, path));

            return rows;//rows affected by the previous command (must be 1)            
        }
        public int AddEntrance(User usr, DateTime date)
        {
            string cmd = string.Format("insert into entrances (usercode, time) values (\"{0}\", \"{1}\")", usr.UserCode, date.ToString("yyyy-MM-dd HH:mm:ss"));
            command = new SQLiteCommand(cmd, dbConnection);
            int rows = command.ExecuteNonQuery();
            Tools.LogMessageToFile(String.Format("DBmanager - AddEntrance \"{0}\" at {1}. {2} rows affected (database: {3}).", usr.UserCode, date.ToString(), rows, path));

            return rows;
        }

        public void CreateDatabase(string path)
        {
            Tools.LogMessageToFile(String.Format("DBmanager - CreateDatabase {0} .", path));
            string cmd;
            Debug.WriteLine("Creating SQLite database file: {0}", path);
            SQLiteConnection.CreateFile(path);
            dbConnection = new SQLiteConnection("Data Source=" + path + ";Version=3;");
            dbConnection.Open();

            //cmd = "CREATE TABLE users (name TEXT(100), key TEXT(10), usercode TEXT(110), active INTEGER, time TEXT(25), creditoresiduo INTEGER);";
            cmd = "CREATE TABLE users (name TEXT(100), key TEXT(10), usercode TEXT(110), active INTEGER, creditoresiduo INTEGER, datainserimento TEXT(25));";
            command = new SQLiteCommand(cmd, dbConnection);
            command.ExecuteNonQuery();

            cmd = "CREATE TABLE entrances (usercode TEXT(110), time TEXT(25));";
            command = new SQLiteCommand(cmd, dbConnection);
            command.ExecuteNonQuery();
            //dbConnection.Close();
        }


        /* Populate Database with 55 random users (with entrances). */
        
        public void populateDB()
        {
            Tools.LogMessageToFile("DBmanager - populateDB()");
            string[] nomi = {"Lucio", "Gianni", "Luca", "Marco", "Giovanni", "Giovanna", "Laura", "Marika", "Gilda", "Gildo", "Mike", "Mauro", "Stefano", "Pietro",
                              "Anthony", "Antonio", "Lucas", "Mark", "Sebastian", "Susanna", "Rosy", "Rossella", "Gianbattista", "Gianmarco", "Roby", "Tony",
                              "Hilary", "Hans", "Guido", "Federica", "Federico", "Tonio", "Caterina", "Catherine", "Thomas", "Tommaso", "Gianna", "Bianca", "Nadia", "Aleksandra"};
            string[] cognomi = { "Venturato", "Borella", "Di Bartolomei", "Bianchini", "Trovato", "Marchi", "Fontana", "Comaneci", "Casaburi", "Dellonica", "Bartolazzi", "Bartolini",
                                 "Sozza", "Sorcia", "Sorza", "Sarcinelli", "Zamprogno", "Zamberlati", "Buttalaffa", "Contini", "Dandini", "Mallori", "Gagliardini", "Berlusconi",
                                "Di Maio", "Cesca", "D'Agostin", "Hammeliki", "Bastianich", "Gallina", "Gallettoni", "Gallonetto", "Lucchetta", "Lanfredini", "Zoff",
                                "Cannavaro", "Zanetti", "Bergomi", "Francescato", "Franceschini", "Zoff", "Conte", "Iuliano", "Tudor", "Dechamp", "Zidane", "Di Livio", "Peruzzi" };
            Random rnd = new Random();
            int numUsers = 55; 
            User[] users = new User[numUsers];
            for (int i=0; i<numUsers; i++)
            {
                users[i] = new User();
                string nome  = nomi[rnd.Next(0, nomi.Length)] + " " + cognomi[rnd.Next(0, cognomi.Length)];
                users[i].Nome = nome;
                users[i].CreditoResiduo = rnd.Next(0, 50);
                users[i].Active = rnd.Next(0, 2) == 1 ? true : false;
                users[i].Time = DateTime.Parse("1999-05-30, 22:22:22");
                users[i].Key = (i.ToString() + nome).Substring(0, 10);
               // users[i].Position = i;
                users[i].UserCode = users[i].Key;
            }

            Debug.WriteLine("Populating database with {0} users", users.Length);
            int z = 0;
            foreach (User usr in users)
            {                
                AddUser(usr, DateTime.Now);
                Debug.WriteLine("Generating user {0} data...", z);
                

                int NumEntrances = rnd.Next(1, 300);
                for (int i =0; i<NumEntrances; i++)
                {
                          int month = rnd.Next(1, 13); // creates a number between 1 and 12
                          int day = rnd.Next(1, 28);
                          int hour = rnd.Next(0, 24);
                          int min = rnd.Next(0, 60);
                          AddEntrance(usr, new DateTime(2018, month, day, hour, min, 0));
                }
                z++;
            }                    
        }
        public void Close()
        {
            dbConnection.Close();
        }
    }
}
