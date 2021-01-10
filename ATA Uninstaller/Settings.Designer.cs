namespace ATA_Uninstaller
{
    partial class Settings
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioButtonEN = new System.Windows.Forms.RadioButton();
            this.radioButtonSP = new System.Windows.Forms.RadioButton();
            this.radioButtonIT = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(72, 18);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Language";
            // 
            // buttonSave
            // 
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(15, 122);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(144, 122);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // radioButtonEN
            // 
            this.radioButtonEN.AutoSize = true;
            this.radioButtonEN.Location = new System.Drawing.Point(87, 42);
            this.radioButtonEN.Name = "radioButtonEN";
            this.radioButtonEN.Size = new System.Drawing.Size(59, 17);
            this.radioButtonEN.TabIndex = 6;
            this.radioButtonEN.TabStop = true;
            this.radioButtonEN.Text = "English";
            this.radioButtonEN.UseVisualStyleBackColor = true;
            // 
            // radioButtonSP
            // 
            this.radioButtonSP.AutoSize = true;
            this.radioButtonSP.Location = new System.Drawing.Point(87, 65);
            this.radioButtonSP.Name = "radioButtonSP";
            this.radioButtonSP.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSP.TabIndex = 7;
            this.radioButtonSP.TabStop = true;
            this.radioButtonSP.Text = "Spanish";
            this.radioButtonSP.UseVisualStyleBackColor = true;
            // 
            // radioButtonIT
            // 
            this.radioButtonIT.AutoSize = true;
            this.radioButtonIT.Location = new System.Drawing.Point(87, 88);
            this.radioButtonIT.Name = "radioButtonIT";
            this.radioButtonIT.Size = new System.Drawing.Size(53, 17);
            this.radioButtonIT.TabIndex = 8;
            this.radioButtonIT.TabStop = true;
            this.radioButtonIT.Text = "Italian";
            this.radioButtonIT.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(231, 163);
            this.Controls.Add(this.radioButtonIT);
            this.Controls.Add(this.radioButtonSP);
            this.Controls.Add(this.radioButtonEN);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonEN;
        private System.Windows.Forms.RadioButton radioButtonSP;
        private System.Windows.Forms.RadioButton radioButtonIT;
    }
}