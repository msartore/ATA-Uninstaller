using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATA_Uninstaller
{
    public partial class Settings : Form
    {
        public int ReturnLanguage { get; set; }
        public static ATA_Uninstaller systemcall; 
        public Settings()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(radioButtonEN.Checked)
            {
                this.DialogResult = DialogResult.OK;
                this.ReturnLanguage = 1;
            }
            if (radioButtonSP.Checked)
            {
                this.DialogResult = DialogResult.OK;
                this.ReturnLanguage = 2;
            }
            if (radioButtonIT.Checked)
            {
                this.DialogResult = DialogResult.OK;
                this.ReturnLanguage = 3;
            }
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            string filename = "settings.ini";
            string temp;
            if (File.Exists(filename))
            {
                foreach (string line in File.ReadLines(filename))
                {

                    if (line.Contains("language:"))
                    {
                        temp = line.Substring(9);
                        switch(Convert.ToInt32(temp))
                        {
                            case 1:
                                labelTitle.Text = "Languages";
                                radioButtonEN.Checked = true;
                                break;
                            case 2:
                                labelTitle.Text = "Idiomi";
                                radioButtonSP.Checked = true;
                                break;
                            case 3:
                                labelTitle.Text = "Lingue";
                                radioButtonIT.Checked = true;
                                break;
                            default:
                                MessageBox.Show("Language number ["+temp+"] doesn't exits", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                }
            }
            else
            {
                File.Create(filename).Dispose();
                File.WriteAllText("settings.ini", "language:1");
                radioButtonEN.Checked = true;
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void systemCall(string command)
        {
            systemcall.systemCommand(command);
        }
    }
}
