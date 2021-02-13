using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using Ionic.Zip;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ATA_Uninstaller
{
    public partial class ATA_Uninstaller : Form
    {
        private MainMenu mainMenu;
        private List<string> arrayApks = new List<string>();
        private MenuItem FileMenu;
        private MenuItem Settings;
        private MenuItem About;


        public ATA_Uninstaller()
        {
            InitializeComponent();

            string filename = "settings.ini";
            string temp = "";
            if (File.Exists(filename))
            {
                foreach (string line in File.ReadLines(filename))
                {

                    if (line.Contains("language:"))
                    {
                        temp = line.Substring(9);
                        if (IsDigitsOnly(temp))
                            ChangeFormLanguage(Convert.ToInt32(temp));
                    }
                }
            }
            else
            {
                ChangeFormLanguage(1);
            }    
        }
        private void About_clicked(object sender, EventArgs e)
        {
            MessageShowBox("Dev:\nMassimiliano Sartore\nCopyright 2020 Massimiliano Sartore", 2);
        }
        private void Exit_clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ChangeLanguage_clicked(object sender, EventArgs e)
        {
            string filename = "settings.ini";
            Settings set = new Settings();
            set.ShowDialog();
            if (set.DialogResult == DialogResult.OK)
            {
                if (File.Exists(filename))
                {
                    System.Text.StringBuilder output = new System.Text.StringBuilder(File.ReadAllText(filename));
                    output[File.ReadAllText(filename).IndexOf("language:") + 9] = Convert.ToChar(set.ReturnLanguage+48);
                    string str = output.ToString();
                    File.WriteAllText("settings.ini", str);
                    ChangeFormLanguage(set.ReturnLanguage);
                }
            }
        }

        private void ChangeFormLanguage(int lan)
        {
            List<string> text = new List<string>();
            switch (lan)
            {
                case 2:
                    checkBoxSelectAll.Text = "Seleccionar todo";
                    radioButtoNonSystemApp.Text = "App que no pertenece\n al sistema";
                    radioButtonSystemApp.Text = "App del sistema";
                    buttonKillAdb.Text = "Terminar Adb";
                    buttonLogClear.Text = "Borrar registro";
                    buttonSyncApp.Text = "Sincronizar aplicaciones";
                    buttonUninstall.Text = "Desinstalar";
                    textBoxSearch.Text = "Buscar";
                    text.Add("Subir archivo de bloatware");
                    text.Add("Cerca");
                    text.Add("Configuraciones");
                    text.Add("Cambiar idioma");
                    text.Add("Información");
                    text.Add("Créditos");
                    break;
                case 3:
                    checkBoxSelectAll.Text = "Seleziona tutto";
                    radioButtoNonSystemApp.Text = "App non di sistema";
                    radioButtonSystemApp.Text = "App di sistema";
                    buttonKillAdb.Text = "Termina Adb";
                    buttonLogClear.Text = "Cancella log";
                    buttonSyncApp.Text = "Sincronizza app";
                    buttonUninstall.Text = "Disinstalla";
                    textBoxSearch.Text = "Cerca";
                    text.Add("Carica bloatware file");
                    text.Add("Chiudi");
                    text.Add("Impostazioni");
                    text.Add("Cambia lingua");
                    text.Add("Informazioni");
                    text.Add("Crediti");
                    break;
                default:
                    checkBoxSelectAll.Text = "Select All";
                    radioButtoNonSystemApp.Text = "Non system app";
                    radioButtonSystemApp.Text = "System App";
                    buttonKillAdb.Text = "Kill Adb";
                    buttonLogClear.Text = "Clear log";
                    buttonSyncApp.Text = "Sync app";
                    buttonUninstall.Text = "Uninstall";
                    textBoxSearch.Text = "Search";
                    text.Add("Load bloatware file");
                    text.Add("Exit");
                    text.Add("Settings");
                    text.Add("Change Language");
                    text.Add("Info");
                    text.Add("Credits");
                    break;

            }
            MenuCreation(text);
        }

        private void MenuCreation(List<string> text)
        {
            mainMenu = new MainMenu();
            FileMenu = mainMenu.MenuItems.Add("&File");
            FileMenu.MenuItems.Add(new MenuItem("&"+text[0], new EventHandler(this.LoadBloatwareFile_clicked)));
            FileMenu.MenuItems.Add(new MenuItem("&"+text[1], new EventHandler(this.Exit_clicked)));
            this.Menu = mainMenu;
            Settings = mainMenu.MenuItems.Add("&"+ text[2]);
            Settings.MenuItems.Add(new MenuItem("&"+ text[3], new EventHandler(this.ChangeLanguage_clicked)));
            About = mainMenu.MenuItems.Add("&"+ text[4]);
            About.MenuItems.Add(new MenuItem("&"+ text[5], new EventHandler(this.About_clicked)));
            this.Menu = mainMenu;
        }

        private void LoadBloatwareFile_clicked(object sender, EventArgs e)
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
                        checkedListBoxApp.Items.Clear();
                        LogWriteLine("Searching matching app...");
                        foreach (string line in File.ReadLines(file))
                        {
                            if (line.Contains("#"))
                            {
                                line.Substring(0, line.IndexOf("#"));
                            }
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
                        MessageShowBox("file not supported", 0);
                    }
                }
                if (noAppFound)
                {
                    MessageShowBox("no app found, try another config", 0);
                    LogWriteLine("Matching app not found!");
                }
                else
                {
                    LogWriteLine("Matching app/s found!");
                }
            }
            else
            {
                MessageShowBox("sync your app by pressing \"sync app\" button", 1);
            }
        }

        static public void systemCommand(string command)
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

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
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
                List<string> arrayApk= new List<string>();
                foreach (Object list in checkedListBoxApp.CheckedItems)
                {
                    arrayApk.Add(list.ToString());
                }
                LoadingForm load = new LoadingForm(arrayApk, command);
                load.ShowDialog();
                if (load.DialogResult == DialogResult.OK)
                    backgroundWorkerSyncApp.RunWorkerAsync();
                else
                    MessageShowBox("Error during uninstallation process", 0);
            }
            else
            {
                MessageShowBox("No app selected", 1);
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
                LogWriteLine("System App selected");
        }

        private void radioButtoNonSystemApp_CheckedChanged(object sender, EventArgs e)
        {
            buttonSyncApp.Enabled = true;
            if (!radioButtonSystemApp.Checked)
                LogWriteLine("Non System App selected");

        }

        private void buttonSyncApp_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerSyncApp.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Ionic"))
                {
                    MessageShowBox("Ionic.Zip.dll not found!", 0);
                }
            }
        }

        private void LogWriteLine(string str)
        {
            listBoxLog.Invoke((Action)delegate
             {
                 listBoxLog.Items.Add(str);
                 listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
             });
        }

        private void ATA_Uninstaller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                systemCommand("taskkill /f /im adb.exe");
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
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

        private void buttonLogClear_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private void buttonKillAdb_Click(object sender, EventArgs e)
        {
            systemCommand("taskkill /f /im adb.exe");
            LogWriteLine("Adb killed");
            MessageShowBox("Adb killed", 2);
        }

        private void backgroundWorkerSyncApp_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            arrayApks.Clear();
            checkedListBoxApp.Invoke((Action)delegate
            {
                checkedListBoxApp.Items.Clear();
            });
            if (File.Exists("adb.exe") && File.Exists("AdbWinUsbApi.dll") && File.Exists("AdbWinApi.dll"))
            {
                LogWriteLine("Checking device");
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
                        LogWriteLine("device found!");
                        File.Delete(filename);
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
                                checkedListBoxApp.Invoke((Action)delegate
                                {
                                    checkedListBoxApp.Items.Add(str);
                                    checkedListBoxApp.CheckOnClick = true;
                                });
                            }
                        }
                        else
                        {
                            File.Delete(filename);
                            MessageShowBox(filename+" not found!", 0);
                        }
                    }
                    else
                    {
                        File.Delete(filename);
                        LogWriteLine("DEVICE NOT FOUND/MULTIPLE DEVICES FOUND!");
                        MessageShowBox("Error device not found/ multiple devices found", 0);
                    }
                }
            }
            else
            {
                adbMissingForm adbError = new adbMissingForm();
                adbError.ShowDialog();
                switch(adbError.DialogResult)
                {
                    case DialogResult.Yes:
                        LogWriteLine("Downloading sdk platform tool...");
                        using (var client = new WebClient())
                        {
                            client.DownloadFile("https://dl.google.com/android/repository/platform-tools-latest-windows.zip?authuser=2", "sdkplatformtool.zip");
                            LogWriteLine("sdk platform tool downloaded");
                            LogWriteLine("unzipping sdk platform tool");
                            using (ZipFile zip = ZipFile.Read("sdkplatformtool.zip"))
                            {
                                zip.ExtractAll(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
                            }
                            LogWriteLine("sdk platform tool downloaded Downloaded!");
                            LogWriteLine("Getting things ready...");
                            systemCommand("move platform-tools\\adb.exe \"%cd%\"");
                            systemCommand("move platform-tools\\AdbWinUsbApi.dll \"%cd%\"");
                            systemCommand("move platform-tools\\AdbWinApi.dll \"%cd%\"");
                            File.Delete("sdkplatformtool.zip");
                            systemCommand("rmdir /Q /S platform-tools");
                            LogWriteLine("ATA Uninstaller ready!");
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.OK:
                        System.Diagnostics.Process.Start("https://developer.android.com/license?authuser=2");
                        break;
                    default:
                        break;
                }
            }
        }

        /* Type 0 Error, Type 1 Warning, Type 2 Info */
        private void MessageShowBox(string message, int type)
        {
            switch(type)
            {
                case 0:
                    MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:
                    MessageBox.Show(message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 2:
                    MessageBox.Show(message, "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageShowBox("Error in MessageShowBox", 0);
                    break;
            }
        }
    }
}
