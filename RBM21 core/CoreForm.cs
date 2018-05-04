﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.IO;

/*
 * 
 * By default RBM21_core will only sync database "users" and local CAME file.
 * To sync with RBM21 hardware, this program must be called with args[1] = "hardwaresync"
 */
namespace RBM21_core
{
    public partial class CoreForm : Form
    {
        static System.Windows.Forms.Timer exitTimer = new System.Windows.Forms.Timer();
        static int secondsToExit = 2000;

        public CoreForm()
        {
            Tools.LogMessageToFile("CoreForm --- START OPERATION ---");
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            InitializeComponent();
            String[] args = Environment.GetCommandLineArgs();

            LogLabel.Text += "CameRBM21FilePath: " + Settings.Default.CameRBM21FilePath + "\r\n";
            LogLabel.Text += "SQLiteDatabasePath: " + Settings.Default.SQLiteDatabasePath + "\r\n";
        
            if(CheckNeedToSync(Settings.Default.CameRBM21FilePath, Settings.Default.SQLiteDatabasePath))
                SyncUsersTable(); 

            //sync RBM21 (external unit) with local sqlite database (only if specified by cmd line option)
            if (args.Length == 2 && args[1] == "hardwaresync")
                HardwareSync();

            LogLabel.Text += "\r\n - OPERATIONS COMPLETED -";
            button1.Enabled = true;
            exitTimer.Tick += new EventHandler(TimerEventProcessor);          
            exitTimer.Interval = 1000;
            exitTimer.Start();
            
            Tools.LogMessageToFile("CoreForm - FINISH OPERATIONS -");
        }
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Tools.LogMessageToFile("CoreForm - Exception Occurred: "+ e.ExceptionObject.ToString());
            MessageBox.Show(e.ExceptionObject.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            //  Environment.Exit(1);
        }
        /* Check if SQLite "Users" table need to be updated. An update must be performed when CAME file (dati impianto) contains
         * more recent data than SQlite table, so there is the need to sync.
         */
        private bool CheckNeedToSync(string CameFile, string dbFile)
        {
            /* If GetLastWriteTime() input is the path to a NON-existent file, raise an exception. 
             * (GetLastWriteTime() return a valid Date also if file does not exists).*/
            if (!File.Exists(CameFile))
                throw new IOException("File: " + CameFile + " does not exist.");
                       
            DateTime cameFileDate = System.IO.File.GetLastWriteTime(CameFile);
            DateTime dbFileDate = System.IO.File.GetLastWriteTime(dbFile);
            //return true if cameFile is more recent than dbFile
            int result = DateTime.Compare(cameFileDate, dbFileDate);
            if (result > 0)
                return true;
            else
                return false;
        }

        /* if secondsToExit == 0 -> Close application, otherwise decrement counter */
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (secondsToExit == 0)
                Application.Exit();
            button1.Text = "Close (" + secondsToExit + ")";
            secondsToExit--;
            exitTimer.Start();
        }        


            //update database table "users" with came's program file  (dati impianto)
        private void SyncUsersTable()
        {            
            Tools.LogMessageToFile("CoreForm - SyncUsersTable(). CAME file: "+ Settings.Default.CameRBM21FilePath +", SQLite file: " + Settings.Default.SQLiteDatabasePath);
            FileReader fr = new FileReader(Settings.Default.CameRBM21FilePath);
            DBmanager dbm = new DBmanager(Settings.Default.SQLiteDatabasePath);
           // dbm.populateDB();
            List <User> cameList = fr.ParseFile();
            List<User> dbList = dbm.GetAllUsers();

           LogLabel.Text += string.Format("Found {0} users in CAME file ({1}).\r\n", cameList.Count,  Settings.Default.CameRBM21FilePath);
           LogLabel.Text += string.Format("Found {0} users in SQLite database ({1}).\r\n", dbList.Count, Settings.Default.SQLiteDatabasePath);

           Dictionary<string, User> cameUsers = cameList.ToDictionary(x => x.UserCode, x => x);
           Dictionary<string, User> dbUsers = dbList.ToDictionary(x => x.UserCode, x => x);
                                   
            //users that have to be ADDED to sqlite
            List<User> ToAdd = new List<User>();
            foreach (string usercode in cameUsers.Keys) //cameUsers is a Dictionary where the Keys are UserCode values.
                if (!dbUsers.ContainsKey(usercode))
                {
                    LogLabel.Text += "Add \"" + usercode + "\" to SQLite user table.\r\n";
                    dbm.AddUser(cameUsers[usercode]);
                }
        }

        /*update datbase table "entrances". Sync data between RBM21 and local sqlite database. */
            private void HardwareSync()
        {
            LogLabel.Text += "Performing sync with RBM21 on "+ Settings.Default.SerialPort+ "\r\n";
            Tools.LogMessageToFile("CoreForm - Performing sync with RBM21 on Port: " + Settings.Default.SerialPort + " SQLite file: " + Settings.Default.SQLiteDatabasePath);
            
            Rbm21Polling rbm21 = new Rbm21Polling(Settings.Default.SerialPort); //se non va e si pianta? che fffamo?
            DBmanager dbm = new DBmanager(Settings.Default.SQLiteDatabasePath);

            List<User> rbm21List = new List<User>();
            List<User> dbList = new List<User>();
            rbm21List = rbm21.ReadAllUsers();
            dbList = dbm.GetActiveUsers();
            /* Since we are syncing with rbm21, we are only dealing with active users. Active users can be identified
             * with ONLY their key (UserCode is superflous). 
             *     Length(Active users in sqlite) == Length(Rbm21 users)   */
            Dictionary<string, User> rbm21Users = rbm21List.ToDictionary(x => x.Key, x => x);
            Dictionary<string, User> dbUsers = dbList.ToDictionary(x => x.Key, x => x);

            Debug.WriteLine("Length check: rbm21List={0}, dbList={1}.", rbm21List.Count, dbList.Count);
            
            foreach (string key in rbm21Users.Keys)
            {
                var rbm21Time = rbm21Users[key].Time;
                var dbTime = dbUsers[key].Time;
                int result = DateTime.Compare(dbTime, rbm21Time);
                if (result >= 0) //if sqlite date is more recent than rbm21's, do nothing.
                    continue;
                //else we have to upgrade database.
                int r1 = dbm.AddEntrance(dbUsers[key], rbm21Users[key].Time);
                int a = dbm.updateUser(new User(dbUsers[key].Position, dbUsers[key].Nome, dbUsers[key].Key, rbm21Users[key].CreditoResiduo, rbm21Users[key].Time, dbUsers[key].UserCode, true));
                LogLabel.Text += "Aggiunto ingresso: \"" + dbUsers[key].UserCode + "\" Time:" + rbm21Time.ToString() + "\r\n";
            }
            dbm.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Tools.LogMessageToFile("CoreForm - button1_Click(), Application.Exit()");
            Application.Exit();
        }


        

    }
}
