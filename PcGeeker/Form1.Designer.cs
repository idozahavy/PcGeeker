namespace PcGeeker
{
    partial class Form1
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
            if(disposing && (components != null))
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.allTabPage = new System.Windows.Forms.TabPage();
            this.allTabListBox = new System.Windows.Forms.ListBox();
            this.cautionTabPage = new System.Windows.Forms.TabPage();
            this.warningTabPage = new System.Windows.Forms.TabPage();
            this.infoTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.allTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.allTabPage);
            this.tabControl.Controls.Add(this.cautionTabPage);
            this.tabControl.Controls.Add(this.warningTabPage);
            this.tabControl.Controls.Add(this.infoTabPage);
            this.tabControl.Location = new System.Drawing.Point(18, 194);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(414, 265);
            this.tabControl.TabIndex = 0;
            // 
            // allTabPage
            // 
            this.allTabPage.Controls.Add(this.allTabListBox);
            this.allTabPage.Location = new System.Drawing.Point(4, 29);
            this.allTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.allTabPage.Name = "allTabPage";
            this.allTabPage.Size = new System.Drawing.Size(406, 232);
            this.allTabPage.TabIndex = 0;
            this.allTabPage.Text = "All";
            this.allTabPage.UseVisualStyleBackColor = true;
            // 
            // allTabListBox
            // 
            this.allTabListBox.FormattingEnabled = true;
            this.allTabListBox.ItemHeight = 20;
            this.allTabListBox.Location = new System.Drawing.Point(4, 5);
            this.allTabListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.allTabListBox.Name = "allTabListBox";
            this.allTabListBox.Size = new System.Drawing.Size(391, 204);
            this.allTabListBox.TabIndex = 0;
            // 
            // cautionTabPage
            // 
            this.cautionTabPage.BackColor = System.Drawing.Color.Transparent;
            this.cautionTabPage.Location = new System.Drawing.Point(4, 29);
            this.cautionTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cautionTabPage.Name = "cautionTabPage";
            this.cautionTabPage.Size = new System.Drawing.Size(406, 232);
            this.cautionTabPage.TabIndex = 1;
            this.cautionTabPage.Text = "Caution";
            // 
            // warningTabPage
            // 
            this.warningTabPage.Location = new System.Drawing.Point(4, 29);
            this.warningTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.warningTabPage.Name = "warningTabPage";
            this.warningTabPage.Size = new System.Drawing.Size(406, 232);
            this.warningTabPage.TabIndex = 2;
            this.warningTabPage.Text = "Warning";
            this.warningTabPage.UseVisualStyleBackColor = true;
            // 
            // infoTabPage
            // 
            this.infoTabPage.Location = new System.Drawing.Point(4, 29);
            this.infoTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.infoTabPage.Name = "infoTabPage";
            this.infoTabPage.Size = new System.Drawing.Size(406, 232);
            this.infoTabPage.TabIndex = 3;
            this.infoTabPage.Text = "Info";
            this.infoTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chartreuse;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(46, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 93);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pc Good";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(84, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 51);
            this.label2.TabIndex = 2;
            this.label2.Text = "continue working on your computer, we will check your performance loads";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.allTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage allTabPage;
        private System.Windows.Forms.TabPage cautionTabPage;
        private System.Windows.Forms.TabPage warningTabPage;
        private System.Windows.Forms.TabPage infoTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox allTabListBox;
        private System.Windows.Forms.Timer timer1;
    }
}

