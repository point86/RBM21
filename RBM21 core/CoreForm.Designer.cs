namespace RBM21_core
{
    partial class CoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoreForm));
            this.button1 = new System.Windows.Forms.Button();
            this.LogLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close (--)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogLabel
            // 
            this.LogLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogLabel.Location = new System.Drawing.Point(0, 0);
            this.LogLabel.Multiline = true;
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.ReadOnly = true;
            this.LogLabel.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogLabel.Size = new System.Drawing.Size(857, 389);
            this.LogLabel.TabIndex = 2;
            this.LogLabel.Text = " -- LOG WINDOW --\r\n";
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 452);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CoreForm";
            this.Text = "RBM21 Core";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox LogLabel;
    }
}

