using System;

namespace Visualizzatore_ingressi_RBM21
{
    partial class ViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
            this.usersListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.entranceList = new System.Windows.Forms.ListView();
            this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.userInfo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersListView
            // 
            this.usersListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.usersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.Active});
            this.usersListView.FullRowSelect = true;
            this.usersListView.GridLines = true;
            this.usersListView.LabelWrap = false;
            this.usersListView.Location = new System.Drawing.Point(12, 21);
            this.usersListView.MultiSelect = false;
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(450, 601);
            this.usersListView.TabIndex = 4;
            this.toolTip1.SetToolTip(this.usersListView, "Elenco utenti memorizzati nel database");
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.Details;
            this.usersListView.SelectedIndexChanged += new System.EventHandler(this.usersListView_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 113;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Key";
            this.columnHeader3.Width = 69;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "UserCode";
            this.columnHeader4.Width = 100;
            // 
            // Active
            // 
            this.Active.Text = "Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dati utente:";
            // 
            // entranceList
            // 
            this.entranceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Data});
            this.entranceList.FullRowSelect = true;
            this.entranceList.GridLines = true;
            this.entranceList.Location = new System.Drawing.Point(291, 61);
            this.entranceList.MultiSelect = false;
            this.entranceList.Name = "entranceList";
            this.entranceList.Size = new System.Drawing.Size(208, 446);
            this.entranceList.TabIndex = 7;
            this.toolTip1.SetToolTip(this.entranceList, "Ingressi effettuati dall\'utente");
            this.entranceList.UseCompatibleStateImageBehavior = false;
            this.entranceList.View = System.Windows.Forms.View.Details;
            this.entranceList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Data
            // 
            this.Data.Text = "Data";
            this.Data.Width = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ingressi effettuati:";
            // 
            // userInfo
            // 
            this.userInfo.Location = new System.Drawing.Point(25, 61);
            this.userInfo.Multiline = true;
            this.userInfo.Name = "userInfo";
            this.userInfo.ReadOnly = true;
            this.userInfo.Size = new System.Drawing.Size(224, 266);
            this.userInfo.TabIndex = 9;
            this.toolTip1.SetToolTip(this.userInfo, "Dettaglio utente");
            this.userInfo.TextChanged += new System.EventHandler(this.userInfo_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.entranceList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.userInfo);
            this.groupBox1.Location = new System.Drawing.Point(501, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 513);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dettaglio utente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1069, 23);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            this.toolTip1.SetToolTip(this.statusStrip1, "Database di lettura, data ultima scrittura dati");
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(804, 18);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "filename";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.ToolTipText = "Database di lettura";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(250, 18);
            this.toolStripStatusLabel2.Text = "lastUpdate here";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.ToolTipText = "Ultimo scrittura sul database";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click_1);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(851, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sincronizza con RBM21";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.button1, "Avvia sincronizzazione con il dispositivo RBM21 ed aggiorna il database");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 657);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.usersListView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewerForm";
            this.Text = "Visualizzatore ingressi RBM21";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView entranceList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader Data;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ColumnHeader Active;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

