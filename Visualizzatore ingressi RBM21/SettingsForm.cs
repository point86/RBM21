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
using System.IO;
using System.Security.Principal;
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
            if (!IsAdministrator())
            {
                DisableAll();
                labelWarning.Visible = true;
                linkLabel2.Visible = true;
            }

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

        private void DisableAll()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            DBtextBox.Enabled = false;
            CameFiletextBox.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            btnCreateNew.Enabled = false;
            checkBox1.Enabled = false;
            button1.Enabled = false;
            //label6.Enabled = false;

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                label2.Visible = false;            
            else                         
                label2.Visible = true;                
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
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
        /* check if running as administrator */
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
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
         *  
         *  if fail, will return false (so user is notified there is something wrong).
         */
        static void EnableSync()
        {
            //calling schtasks with appropriate cmd options
            string RBM21CorePath = AppDomain.CurrentDomain.BaseDirectory + "RBM21 core.exe";
            /* Cmd line:
             * Schtasks /Create /tn RBM21Sync /tr "'C:\Users\paolo\Desktop\RBM21\RBM21 core\bin\Debug\RBM21 Core.exe' hardwaresync"  /sc DAILY  /st 12:00:00 /f
               Schtasks /Create /tn RBM21Sync /tr "'C:\Users\paolo\Desktop\RBM21\RBM21 core\bin\Debug\RBM21 Core.exe' hardwaresync"  /sc DAILY  /st 12:00:00 /RL HIGHEST /f
            */
            string strArguments = " /Create /tn RBM21Sync /tr \"'" + RBM21CorePath + "' hardwaresync\"  /sc DAILY  /st 12:00:00  /RL HIGHEST /f";
            Process p = new Process();
            p.StartInfo.FileName = "schtasks";
            p.StartInfo.Arguments = strArguments;    
            p.Start();
            p.WaitForExit();
            /* on startup cmd will be:
             *  Schtasks /Create /tn RBM21Sync /tr "'C:\Users\paolo\Desktop\RBM21\RBM21 core\bin\Debug\RBM21 Core.exe' hardwaresync"  /sc ONSTART   /f
             */            
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

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
          
            SaveFileDialog sd = new SaveFileDialog();   
            sd.Title = "Creazione nuovo database ingressi RBM21";
            //sd.InitialDirectory = @"C:\";
            sd.DefaultExt = ".sqlite";
            sd.OverwritePrompt = false;
            sd.Filter = "RBM21 database (*.sqlite)|*.sqlite";                      
            if (sd.ShowDialog() == DialogResult.OK)
            {
                if (!File.Exists(sd.FileName))
                {
                    //if file didn't exists, open a new database there (DBmanager constructor will handle that)
                    DBmanager dbm = new DBmanager(sd.FileName);
                    dbm.Close();
                    MessageBox.Show("Operazione completata con successo.\r\nIl database " + sd.FileName + " è stato creato. Per utilizzarlo, utilizzare il pulsante \"cambia\".",
                                "Operazione completata",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }
                //if file aleady exists, do nothing and warn the user.
                else
                    MessageBox.Show("Esiste gia un database nella posizione " + sd.FileName + "\r\nPer creare un nuovo database, specificare un nuovo nome.",
                                "Operazione non riuscita",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }               
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Per eseguire questo programma in modalità amministratore, fare click con il tasto destro del mouse sull'icona del programma e sceglire: Proprietà -> Compatibilità. A questo punto abilitare \"Esegui come amministratore\" e confermare con OK");
        }
    }
}
