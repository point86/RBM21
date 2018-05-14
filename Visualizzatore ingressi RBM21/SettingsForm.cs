using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using RBM21_core;


namespace Visualizzatore_ingressi_RBM21
{
    public partial class SettingsForm : Form
    {
        SettingsManager sm;
        public SettingsForm()
        {
            InitializeComponent();
            /*
            string SqliteDB = Settings.Default.SQLiteDatabasePath;
            string DatiImpianto = Settings.Default.CameRBM21FilePath;*/

            sm = new SettingsManager();
            string SqliteDB = sm.SQLiteDB;
            string DatiImpianto = sm.CameFilePath;
            bool Enabled = sm.Enabled;
            //FIXME servon davvero?
            DBtextBox.Text = (SqliteDB.Replace(@"\\", "\\"));
            CameFiletextBox.Text = (DatiImpianto.Replace(@"\\", "\\"));


            //DBtextBox.Text = (SqliteDB);
            //CameFiletextBox.Text = (DatiImpianto);
            
            if (sm.SerialPort== "COM1")
                radioButton1.Checked = true;
            else if (sm.SerialPort == "COM2")
                radioButton2.Checked = true;

            checkBox1.Checked = sm.Enabled;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label2.Visible = false;
                //   Settings.Default.Enabled = true; //FIXME uncomment!!
                //TODO inert here code for core program, must be ENABLED
            }
            else
            {                
                label2.Visible = true;
                //Settings.Default.Enabled = false; //FIXME uncomment!!
                //TODO inert here code for core program, must be disaBLED
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.DataBindings.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        //change database
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Cambia database ingressi RBM21";
            fd.Filter = "RBM21 database (*.sqlite)|*.sqlite|All files (*.*)|*.*";
            fd.FilterIndex = 1;
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
                DBtextBox.Text = fd.FileName;
        }
        
        //change came file (dati impianto)
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Cambia file impianto RBM21";
            fd.Filter = "impianto RBM21 (*.tsp)|*.tsp|All files (*.*)|*.*";
            fd.FilterIndex = 1;
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
                CameFiletextBox.Text = fd.FileName;
        }

        private void DBtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        /*
         * Retrieve new setting from this form (SettingsForm) and save to c# standard NET settings.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(DBtextBox.Text);
            sm.SQLiteDB = DBtextBox.Text;
            sm.CameFilePath = CameFiletextBox.Text;
            if (radioButton1.Checked == true)
                sm.SerialPort = "COM1";
            else if (radioButton2.Checked == true)
                sm.SerialPort = "COM2";
            bool pastSett = sm.Enabled;
            sm.Enabled = checkBox1.Checked;
            if (!(pastSett == true & sm.Enabled == true))
                enableScheduledTask(checkBox1.Checked);
            sm.SaveSettings();
            this.Close();
        }

        void enableScheduledTask(bool enabled)
        {
            if (enabled == true)
                EnableSync();
            else
                DisableSync();

        }
        /*
         *  Sync will be performed by "RBM21 core.exe". 
         *  Microsoft Windows have a built-in feature to run a specified task in a scheduled manner, Task Scheduler. 
         *  Tasks can be manipulated via Control Panel or with a cmd tool, schtasks, which is used in this case.
         */
        static void EnableSync()
        {
            //calling schtasks with appropriate cmd options
            string RBM21CorePath = AppDomain.CurrentDomain.BaseDirectory + "RBM21 core.exe";
            /* Cmd line:
               Schtasks /Create /tn RBM21Sync /tr "'C:\Users\paolo\Desktop\RBM21\RBM21 core\bin\Debug\RBM21 Core.exe' hardwaresync"  /sc DAILY  /st 12:00:00 /f
            */
            string strArguments = " /Create /tn RBM21Sync /tr \"'" + RBM21CorePath + "' hardwaresync\"  /sc DAILY  /st 12:00:00 /f";
            Process p = new Process();
            p.StartInfo.FileName = "schtasks";
            p.StartInfo.Arguments = strArguments;    
            p.Start();

            p.WaitForExit();                   
        }

        static void DisableSync()
        {
            /* Cmd Line: 
               schtasks /Delete /tn RBM21Sync /f
            */
            string strArguments = " /Delete /tn RBM21Sync /f";
            Process p = new Process();
            p.StartInfo.FileName = @"schtasks";
            p.StartInfo.Arguments = strArguments;
            p.Start();

            p.WaitForExit();
        }
             
        //open windows Tasck Scheduler, from control panel
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start("taskschd.msc", cplPath);
        }
    }
}
