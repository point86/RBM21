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
using System;
using System.Reflection;
using System.Diagnostics;
using System.Security.Policy;  //for evidence object
using System.Data.SQLite;
using RBM21_core;

namespace Visualizzatore_ingressi_RBM21
{
    public partial class ViewerForm : Form
    {       
        User[] users;
        DBmanager dbm;

        public ViewerForm(bool modify, string CurrentDatabase)
        {
            InitializeComponent();

            //toolStripStatusLabel1.Text = CurrentDatabase
            //if filepath is hardcoded, must remove the backslash;
            toolStripStatusLabel1.Text = CurrentDatabase.Replace(@"\\", "\\");
            DateTime lastModified = System.IO.File.GetLastWriteTime(CurrentDatabase);
            toolStripStatusLabel2.Text = "Ultima modifica: "+lastModified.ToString("ddd dd MMM, HH:mm");

            //if bool = true, can show the sync button, so database can be upgraded via ViewerForm
            //otherwise database is ONLY READ (maybe an old database, backup, etc..).
            button1.Visible = modify;
            //disable "Sincronizzazione" button, if sync is disabled (and change the tooltip text so user will be informed)
            button1.Enabled = Settings.Default.Enabled;
            if(button1.Enabled == false)            
                toolTip1.SetToolTip(this.button1, "La sincronizzazione è disabilitata, controlla su \"Impostazioni\" nella schermata precedente");
            toolTip1.SetToolTip(this.button1, "ciaooooo");

            //if db does not exist?
            dbm = new DBmanager(CurrentDatabase);
            users = dbm.GetAllUsers().ToArray();
         //   FileReader fr = new FileReader(Settings.Default.CameRBM21FilePath);
            foreach (User usr in users ?? Enumerable.Empty<User>())
            {
                //string[] row = { usr.Position.ToString(), usr.Nome, usr.Key, usr.Active.ToString() };
                string[] row = {usr.Nome, usr.Key, usr.UserCode, usr.Active.ToString() };
                ListViewItem listViewItem = new ListViewItem(row);
                listViewItem.Tag = usr;
                usersListView.Items.Add(listViewItem);
            }
            //dbm.populateDB(users);
            //last column width will fit the parent object.
             usersListView.AutoResizeColumn(3,ColumnHeaderAutoResizeStyle.HeaderSize);            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnClosed(EventArgs e)
        {
            dbm.Close();
            base.OnClosed(e);
        }

        /* SINCRONIZZAZIONE */
        private void button2_Click(object sender, EventArgs e)
        {
            //User[] users = new User[50];
            //users = rbm21.ReadAllUsers();
            //https://msdn.microsoft.com/it-it/library/system.windows.forms.listview(v=vs.110).aspx
/*            for (int i=0; i<51; i++)
            {
                User usr = rbm21.GetRBM21UserData(i);
                string[] row = { usr.Position.ToString(), usr.Nome, usr.Key, };
                var listViewItem = new ListViewItem(row);
                usersListView.Items.Add(listViewItem);
            }           
*/            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void usersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when user change selection, this method get called (with index == 0), so this had to be managed;
            if (usersListView.SelectedItems.Count == 0)
                return;

            //update listview entranceList with data about all entrances (of the selected user).
           // entranceList.Update();

            //update userInfo to show info about the selected user
            ListView.SelectedListViewItemCollection lv = this.usersListView.SelectedItems;
            userInfo.Text = lv[0].Tag.ToString(); //cast to User?
            

            User u = (User)lv[0].Tag;

            entranceList.Items.Clear();
            foreach (string l in u.Entrances ?? Enumerable.Empty<string>())
            {
                entranceList.Items.Add(new ListViewItem(l));
            }
            /*
            //query database
            List<string> entrances = dbm.GetEntrances(u.Key);
            //clear all data in entranceView
            entranceList.Items.Clear();
            //load new data in entranceView
            foreach (string l in entrances ?? Enumerable.Empty<string>())
            {
                entranceList.Items.Add(new ListViewItem (l));
            } */           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * start: "rbm21core.exe hardwaresync", in the same folder as this exe             
             */

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void userInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
        

        
    

