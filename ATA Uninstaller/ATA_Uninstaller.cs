using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ATA_Uninstaller
{
    public partial class ATA_Uninstaller : Form
    {
        private List<string> arrayApks = new List<string>();
        public ATA_Uninstaller()
        {
            InitializeComponent();
        }

        private void systemCommand(string command)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(command);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            buttonSyncApp.Enabled = false;
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            if (checkedListBoxApp.CheckedItems.Count > 0)
            {
                string command = "";
                if (radioButtoNonSystemApp.Checked)
                {
                    command = "adb uninstall ";
                }
                if (radioButtonSystemApp.Checked)
                {
                    command = "adb shell pm uninstall -k --user 0 ";
                }
                foreach (Object list in checkedListBoxApp.CheckedItems)
                {
                    listBox("Uninstalling " + list);
                    systemCommand(command + list);
                    listBox(list + " uninstalled!");
                }
                checkDeviceStatus();
            }
            else
            {
                MessageBox.Show("No app selected", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {
                for (int i = 0; i < checkedListBoxApp.Items.Count; i++)
                    checkedListBoxApp.SetItemCheckState(i, System.Windows.Forms.CheckState.Checked);
            }
            else
            {
                for (int i = 0; i < checkedListBoxApp.Items.Count; i++)
                    checkedListBoxApp.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
            }
        }

        private void radioButtonSystemApp_CheckedChanged(object sender, EventArgs e)
        {
            buttonSyncApp.Enabled = true;
            if (radioButtonSystemApp.Checked)
                listBox("System App selected");
        }

        private void radioButtoNonSystemApp_CheckedChanged(object sender, EventArgs e)
        {
            buttonSyncApp.Enabled = true;
            if (!radioButtonSystemApp.Checked)
                listBox("Non System App selected");
        }

        private void buttonSyncApp_Click(object sender, EventArgs e)
        {
            checkDeviceStatus();
        }

        private void listBox(string str)
        {
            listBoxLog.Items.Add(str);
            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
        }

        private void checkDeviceStatus()
        {
            arrayApks.Clear();
            checkedListBoxApp.Items.Clear();
            listBox("Checking device");
            systemCommand("adb shell getprop ro.build.version.release > check.tmp");
            string androidV;
            string filename = "check.tmp";
            bool phone = false;
            if (File.Exists(filename))
            {
                androidV = File.ReadAllText(filename);
                if (androidV.Any(char.IsDigit))
                    phone = true;
                if (phone)
                {
                    listBox("device found!");

                    var arrayApksUni = new List<int>();
                    if (radioButtoNonSystemApp.Checked)
                    {
                        systemCommand("adb shell pm list packages -3 > APKNS.tmp");
                        filename = "APKNS.tmp";
                    }
                    if (radioButtonSystemApp.Checked)
                    {
                        systemCommand("adb shell pm list packages -s > APKS.tmp");
                        filename = "APKS.tmp";
                    }

                    if (File.Exists(filename))
                    {
                        foreach (string line in File.ReadLines(filename))
                        {
                            if (line.Contains("package:"))
                            {
                                arrayApks.Add(line.Substring(8));
                            }
                        }
                        File.Delete(filename);
                        foreach (string str in arrayApks)
                        {
                            checkedListBoxApp.Items.Add(str);
                            checkedListBoxApp.CheckOnClick = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                else
                {
                    listBox("DEVICE NOT FOUND/MULTIPLE DEVICES FOUND!");
                }
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            checkedListBoxApp.Items.Clear();
            foreach (string str in arrayApks)
            {
                if (str.Contains(textBoxSearch.Text))
                    checkedListBoxApp.Items.Add(str);
            }
        }

        private void buttonFileExplorer_Click(object sender, EventArgs e)
        {
            if (checkedListBoxApp.Items.Count > 0)
            {
                bool noAppFound = true;
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Title = "Select A File";
                openDialog.Filter = "ATA Files (*.ata)|*.ata";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = openDialog.FileName;
                    if (file.Contains(".ata"))
                    {
                        listBoxLog.Items.Add("Searching matching app...");
                        foreach (string line in File.ReadLines(file))
                        {
                            checkedListBoxApp.Items.Clear();
                            foreach (string str in arrayApks)
                            {
                                if (str.Contains(line))
                                {
                                    checkedListBoxApp.Items.Add(str);
                                    noAppFound = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("file not supported", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (noAppFound)
                {
                    MessageBox.Show("no app found, try another config", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listBoxLog.Items.Add("Matching app not found!");
                }
                else
                {
                    listBoxLog.Items.Add("Matching app/s found!");
                }
            }
            else
            {
                MessageBox.Show("sync your app by pressing \"sync app\" button", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dev:\nMassimiliano Sartore\nCopyright 2020 Massimiliano Sartore", "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLogClear_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }
    }
}
