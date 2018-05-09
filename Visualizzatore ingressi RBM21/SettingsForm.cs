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
        //TODO save setting to a xml file? and write a custom class?
        public SettingsForm()
        {
            InitializeComponent();
            string SqliteDB = Settings.Default.SQLiteDatabasePath;
            string DatiImpianto = Settings.Default.CameRBM21FilePath;
            DBtextBox.Text = (SqliteDB.Replace(@"\\", "\\"));
            CameFiletextBox.Text = (DatiImpianto.Replace(@"\\", "\\"));

            //DBtextBox.Text = (SqliteDB);
            //CameFiletextBox.Text = (DatiImpianto);
            
            if (Settings.Default.SerialPort== "COM1")
                radioButton1.Checked = true;
            else if (Settings.Default.SerialPort == "COM2")
                radioButton2.Checked = true;

            //set dateTimePicker1 to show only time (and not the calendar)            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.ShowUpDown = true;

            checkBox1.Checked = Settings.Default.Enabled;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.SQLiteDatabasePath = DBtextBox.Text;
            Settings.Default.CameRBM21FilePath = CameFiletextBox.Text;
            
            if (radioButton1.Checked == true)
                Settings.Default.SerialPort = "COM1";
            else if(radioButton2.Checked == true)
                Settings.Default.SerialPort = "COM2";

            Settings.Default.Enabled = checkBox1.Checked;
            enableScheduledTask(checkBox1.Checked);

            this.Close();
        }

        void enableScheduledTask(bool enabled)
        {
            if (enabled == true)
                EnableSync();
            else
                DisableSync();

        }
        static void EnableSync()
        {
            string strArguments = " /Create /tn RBM21Sync /tr \"'C:\\Users\\paolo\\Desktop\\RBM21\\RBM21 core\\bin\\Debug\\RBM21 Core.exe' hardwaresync\"  /sc DAILY  /st 18:25:00 /f";
            Process p = new Process();
            p.StartInfo.FileName = @"schtasks";
            p.StartInfo.Arguments = strArguments;    
            p.Start();

            p.WaitForExit();
        }

        static void DisableSync()
        {

            string strArguments = " /Delete /tn RBM21Sync /f";
            Process p = new Process();
            p.StartInfo.FileName = @"schtasks";
            p.StartInfo.Arguments = strArguments;
            p.Start();

            p.WaitForExit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
