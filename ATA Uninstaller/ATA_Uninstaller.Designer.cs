namespace ATA_Uninstaller
{
    partial class ATA_Uninstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATA_Uninstaller));
            this.buttonLogClear = new System.Windows.Forms.Button();
            this.buttonCredits = new System.Windows.Forms.Button();
            this.buttonFileExplorer = new System.Windows.Forms.Button();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.checkedListBoxApp = new System.Windows.Forms.CheckedListBox();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.buttonSyncApp = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtoNonSystemApp = new System.Windows.Forms.RadioButton();
            this.radioButtonSystemApp = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Location = new System.Drawing.Point(49, 456);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(75, 23);
            this.buttonLogClear.TabIndex = 27;
            this.buttonLogClear.Text = "Clear log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            this.buttonLogClear.Click += new System.EventHandler(this.buttonLogClear_Click);
            // 
            // buttonCredits
            // 
            this.buttonCredits.Location = new System.Drawing.Point(504, 10);
            this.buttonCredits.Name = "buttonCredits";
            this.buttonCredits.Size = new System.Drawing.Size(23, 20);
            this.buttonCredits.TabIndex = 26;
            this.buttonCredits.Text = "?";
            this.buttonCredits.UseVisualStyleBackColor = true;
            this.buttonCredits.Click += new System.EventHandler(this.buttonCredits_Click);
            // 
            // buttonFileExplorer
            // 
            this.buttonFileExplorer.Location = new System.Drawing.Point(11, 430);
            this.buttonFileExplorer.Name = "buttonFileExplorer";
            this.buttonFileExplorer.Size = new System.Drawing.Size(113, 23);
            this.buttonFileExplorer.TabIndex = 25;
            this.buttonFileExplorer.Text = "Load bloatware file";
            this.buttonFileExplorer.UseVisualStyleBackColor = true;
            this.buttonFileExplorer.Click += new System.EventHandler(this.buttonFileExplorer_Click);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(11, 11);
            this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(70, 17);
            this.checkBoxSelectAll.TabIndex = 18;
            this.checkBoxSelectAll.Text = "Select All";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(254, 10);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxSearch.Size = new System.Drawing.Size(242, 20);
            this.textBoxSearch.TabIndex = 24;
            this.textBoxSearch.Text = "Search";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // checkedListBoxApp
            // 
            this.checkedListBoxApp.FormattingEnabled = true;
            this.checkedListBoxApp.Location = new System.Drawing.Point(11, 32);
            this.checkedListBoxApp.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBoxApp.Name = "checkedListBoxApp";
            this.checkedListBoxApp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBoxApp.Size = new System.Drawing.Size(516, 334);
            this.checkedListBoxApp.TabIndex = 17;
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Location = new System.Drawing.Point(409, 372);
            this.buttonUninstall.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(118, 23);
            this.buttonUninstall.TabIndex = 19;
            this.buttonUninstall.Text = "Uninstall";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.buttonUninstall_Click);
            // 
            // buttonSyncApp
            // 
            this.buttonSyncApp.Location = new System.Drawing.Point(131, 372);
            this.buttonSyncApp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSyncApp.Name = "buttonSyncApp";
            this.buttonSyncApp.Size = new System.Drawing.Size(118, 23);
            this.buttonSyncApp.TabIndex = 21;
            this.buttonSyncApp.Text = "Sync App";
            this.buttonSyncApp.UseVisualStyleBackColor = true;
            this.buttonSyncApp.Click += new System.EventHandler(this.buttonSyncApp_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(129, 410);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxLog.Size = new System.Drawing.Size(398, 69);
            this.listBoxLog.TabIndex = 22;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(129, 394);
            this.labelLog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLog.Name = "labelLog";
            this.labelLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelLog.Size = new System.Drawing.Size(28, 13);
            this.labelLog.TabIndex = 23;
            this.labelLog.Text = "Log:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtoNonSystemApp);
            this.panel1.Controls.Add(this.radioButtonSystemApp);
            this.panel1.Location = new System.Drawing.Point(11, 373);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 52);
            this.panel1.TabIndex = 20;
            // 
            // radioButtoNonSystemApp
            // 
            this.radioButtoNonSystemApp.AutoSize = true;
            this.radioButtoNonSystemApp.Location = new System.Drawing.Point(3, 26);
            this.radioButtoNonSystemApp.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtoNonSystemApp.Name = "radioButtoNonSystemApp";
            this.radioButtoNonSystemApp.Size = new System.Drawing.Size(104, 17);
            this.radioButtoNonSystemApp.TabIndex = 11;
            this.radioButtoNonSystemApp.TabStop = true;
            this.radioButtoNonSystemApp.Text = "Non System App";
            this.radioButtoNonSystemApp.UseVisualStyleBackColor = true;
            this.radioButtoNonSystemApp.CheckedChanged += new System.EventHandler(this.radioButtoNonSystemApp_CheckedChanged);
            // 
            // radioButtonSystemApp
            // 
            this.radioButtonSystemApp.AutoSize = true;
            this.radioButtonSystemApp.Location = new System.Drawing.Point(26, 4);
            this.radioButtonSystemApp.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonSystemApp.Name = "radioButtonSystemApp";
            this.radioButtonSystemApp.Size = new System.Drawing.Size(81, 17);
            this.radioButtonSystemApp.TabIndex = 10;
            this.radioButtonSystemApp.TabStop = true;
            this.radioButtonSystemApp.Text = "System App";
            this.radioButtonSystemApp.UseVisualStyleBackColor = true;
            this.radioButtonSystemApp.CheckedChanged += new System.EventHandler(this.radioButtonSystemApp_CheckedChanged);
            // 
            // ATA_Uninstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(537, 490);
            this.Controls.Add(this.buttonLogClear);
            this.Controls.Add(this.buttonCredits);
            this.Controls.Add(this.buttonFileExplorer);
            this.Controls.Add(this.checkBoxSelectAll);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.checkedListBoxApp);
            this.Controls.Add(this.buttonUninstall);
            this.Controls.Add(this.buttonSyncApp);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ATA_Uninstaller";
            this.Text = "ATA Uninstaller";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogClear;
        private System.Windows.Forms.Button buttonCredits;
        private System.Windows.Forms.Button buttonFileExplorer;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckedListBox checkedListBoxApp;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.Button buttonSyncApp;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtoNonSystemApp;
        private System.Windows.Forms.RadioButton radioButtonSystemApp;
    }
}

