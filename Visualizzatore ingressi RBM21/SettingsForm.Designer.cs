namespace Visualizzatore_ingressi_RBM21
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.DBtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.CameFiletextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBtextBox
            // 
            this.DBtextBox.BackColor = System.Drawing.SystemColors.Window;
            this.DBtextBox.Location = new System.Drawing.Point(179, 78);
            this.DBtextBox.Name = "DBtextBox";
            this.DBtextBox.ReadOnly = true;
            this.DBtextBox.Size = new System.Drawing.Size(298, 20);
            this.DBtextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.DBtextBox, "Database sul quale memorizzare i dati relativi agli ingressi");
            this.DBtextBox.TextChanged += new System.EventHandler(this.DBtextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default Database:";
            this.toolTip1.SetToolTip(this.label1, "Database sul quale memorizzare i dati relativi agli ingressi");
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(40, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "COM 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(104, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "COM 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CAME file:";
            this.toolTip1.SetToolTip(this.label3, "File contenente di dati impianto di RBM21 (generalemente in C:\\Programmi\\RBM21)");
            // 
            // CameFiletextBox
            // 
            this.CameFiletextBox.BackColor = System.Drawing.SystemColors.Window;
            this.CameFiletextBox.Location = new System.Drawing.Point(179, 117);
            this.CameFiletextBox.Name = "CameFiletextBox";
            this.CameFiletextBox.ReadOnly = true;
            this.CameFiletextBox.Size = new System.Drawing.Size(298, 20);
            this.CameFiletextBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.CameFiletextBox, "File contenente di dati impianto di RBM21 (generalemente in C:\\Programmi\\RBM21)");
            this.CameFiletextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(286, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Porta seriale";
            this.toolTip1.SetToolTip(this.groupBox1, "Porta seriale");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(224, 247);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox1.Size = new System.Drawing.Size(224, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Abilita sincronizzazione automatica";
            this.toolTip1.SetToolTip(this.checkBox1, "Abilita/Disabilita sincronizzazione");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(115, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(481, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "ATTENZIONE! La sincronizzazione automatica dei dati è disabilitata.";
            this.label2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(404, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(525, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 29);
            this.button2.TabIndex = 0;
            this.button2.Text = "Annulla modifiche";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(483, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 22);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cambia";
            this.toolTip1.SetToolTip(this.button3, "Database (esistente) sul quale memorizzare i dati relativi agli ingressi");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(483, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 20);
            this.button4.TabIndex = 12;
            this.button4.Text = "Cambia";
            this.toolTip1.SetToolTip(this.button4, "File contenente di dati impianto di RBM21 (generalemente in C:\\Programmi\\RBM21)");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 16;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(539, 77);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(70, 21);
            this.btnCreateNew.TabIndex = 24;
            this.btnCreateNew.Text = "Crea nuovo";
            this.toolTip1.SetToolTip(this.btnCreateNew, "Crea un nuovo database nel path desiderato");
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(505, 314);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Task Scheduler";
            this.toolTip1.SetToolTip(this.linkLabel1, "Windows Task Scheduler");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(96, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 35);
            this.label8.TabIndex = 19;
            this.label8.Text = "Porta seriale alla quale è collegato il dispositivo esterno RBM21:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(87, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(500, 2);
            this.label4.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(105, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(428, 60);
            this.label6.TabIndex = 21;
            this.label6.Text = "L\'ora alla quale avviene la sincronizzazione dei dati tra RBM21 ed il database lo" +
    "cale (su computer) è  modificabile tramite il \"Task Scheduler\" di Windows. Il ta" +
    "sk responsabile è \"RBM21Sync\".";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWarning
            // 
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelWarning.ImageKey = "(none)";
            this.labelWarning.Location = new System.Drawing.Point(-8, 9);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(647, 43);
            this.labelWarning.TabIndex = 26;
            this.labelWarning.Text = "Attenzione! La modifica delle impostazioni è disabilitata. Per abilitarla eseguir" +
    "e questo programma con i permessi di amministratore.";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWarning.Visible = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(522, 41);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(105, 13);
            this.linkLabel2.TabIndex = 27;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Maggiori informazioni";
            this.linkLabel2.Visible = false;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(651, 434);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CameFiletextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DBtextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Impostazioni";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DBtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CameFiletextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}