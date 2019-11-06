using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace passwdhk
{
    public partial class Configuration : Form
    {
        public string phkRegPath = "SYSTEM\\CurrentControlSet\\Control\\Lsa\\passwdhk";
        public string phkRegDLLName = "passwdhk";
        public string phkRegNotifyPath = "SYSTEM\\CurrentControlSet\\Control\\Lsa";
        public string phkRegNotifyName = "Notification Packages";
        public string[] phkRegNames = new string[] { "logfile",
                                                    "maxlogsize",
                                                    "loglevel",
                                                    "priority",
                                                    "workingdir",
                                                    "urlencode",
                                                    "output2log",
                                                    "doublequote",
                                                    "environment",
                                                    "preChangeProgWait",
                                                    "postChangeProgWait",
                                                    "preChangeProgSkipComp",
                                                    "postChangeProgSkipComp",
                                                    "preChangeProg",
                                                    "preChangeProgArgs",
                                                    "postChangeProg",
                                                    "postChangeProgArgs"};


        private void LoadFromRegistry()
        {
            try
            {
                RegistryKey phkkey = Registry.LocalMachine.OpenSubKey(phkRegPath, true);

                if (phkkey == null)
                {
                    try
                    {
                        phkkey = Registry.LocalMachine.CreateSubKey(phkRegPath);
                    }
                    catch
                    {
                        MessageBox.Show("ERROR Creating PasswordHook Registry Key");
                    }
                }

                foreach (string i in phkRegNames)
                {
                    if (phkkey.GetValue(i) != null)
                    {
                        switch (i)
                        {
                            case "logfile":
                                this.log_filename_t.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "maxlogfile":
                                this.log_maxsize_n.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "loglevel":
                                this.log_level_n.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "priority":
                                int iprior = int.Parse(phkkey.GetValue(i).ToString());
                                switch (iprior)
                                {
                                    case -1:
                                        this.priority_d.SelectedItem = "Idle";
                                        break;
                                    case 0:
                                        this.priority_d.SelectedItem = "Normal";
                                        break;
                                    case 1:
                                        this.priority_d.SelectedItem = "High";
                                        break;
                                    default:
                                        this.priority_d.SelectedItem = "Normal";
                                        break;
                                }
                                break;
                            case "workingdir":
                                this.working_dir_t.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "preChangeProgSkipComp":
                                if (phkkey.GetValue(i).ToString().ToLower() == "true")
                                {
                                    this.preChangeSkipComp.Checked = true;
                                }
                                else
                                {
                                    this.preChangeSkipComp.Checked = false;
                                }
                                break;
                            case "postChangeProgSkipComp":
                                if (phkkey.GetValue(i).ToString().ToLower() == "true")
                                {
                                    this.postChangeSkipComp.Checked = true;
                                }
                                else
                                {
                                    this.postChangeSkipComp.Checked = false;
                                }
                                break;
                            case "urlencode":
                                if (phkkey.GetValue(i).ToString().ToLower() == "true")
                                {
                                    this.password_urlencode_c.Checked = true;
                                }
                                else
                                {
                                    this.password_urlencode_c.Checked = false;
                                }
                                break;
                            case "doublequote":
                                if (phkkey.GetValue(i).ToString().ToLower() == "true")
                                {
                                    this.password_quote_c.Checked = true;
                                }
                                else
                                {
                                    this.password_quote_c.Checked = false;
                                }
                                break;
                            case "output2log":
                                if (phkkey.GetValue(i).ToString().ToLower() == "true")
                                {
                                    this.redirect_output_c.Checked = true;
                                }
                                else
                                {
                                    this.redirect_output_c.Checked = false;
                                }
                                break;
                            case "environment":
                                this.environment_t.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "preChangeProgWait":
                                this.prechange_waittime_n.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "postChangeProgWait":
                                this.postchange_waittime_n.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "preChangeProg":
                                this.prechange_program_t.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "preChangeProgArgs":
                                this.prechange_arguments_t.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "postChangeProg":
                                this.postchange_program_t.Text = phkkey.GetValue(i).ToString();
                                break;
                            case "postChangeProgArgs":
                                this.postchange_arguments_t.Text = phkkey.GetValue(i).ToString();
                                break;
                        }
                    }
                    else
                    {
                        if (phkkey.GetValue("priority") == null) 
                        {
                            this.priority_d.SelectedItem = "Normal";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR Loading Settings");
            }
            try
            {
                RegistryKey NotifyKey = Registry.LocalMachine;
                NotifyKey = NotifyKey.OpenSubKey(phkRegNotifyPath, true);
                string[] NotifyPkgsArray = (string[])NotifyKey.GetValue(phkRegNotifyName);
                ArrayList NotifyPkgsAL = new ArrayList();

                NotifyPkgsAL.AddRange(NotifyPkgsArray);
                if (NotifyPkgsAL.Contains(phkRegDLLName))
                {
                    enable_passwdhk_c.Checked = true;
                }
                else
                {
                    enable_passwdhk_c.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR Loading Password Hook Setting");
            }
        }

        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            LoadFromRegistry();
        }

        private void Prechange_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "c:\\",

                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.prechange_program_t.Text = openFileDialog1.FileName;
            }
        }

        private void Postchange_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "c:\\",

                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.postchange_program_t.Text = openFileDialog1.FileName;
            }
        }

        private void About_Button_Click(object sender, EventArgs e)
        {
            Aboutbox neform = new Aboutbox();
            neform.ShowDialog();
        }

        private void Project_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked." + ex);
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited 
            // to true.
            Project_link.LinkVisited = true;
            //Call the Process.Start method to open the default browser 
            //with a URL:
            System.Diagnostics.Process.Start("https://sf.net/projects/passwdhk");
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Apply_Button_Click(object sender, EventArgs e)
        {
            RegistryKey rootKey = Registry.LocalMachine;
            try
            {
                rootKey = rootKey.OpenSubKey(phkRegPath, true);

                if (rootKey == null)
                {
                    try
                    {
                        rootKey = rootKey.CreateSubKey(phkRegPath);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString(), "ERROR Creating Key");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR Saving Changes");
            }
            try
            {
                rootKey.SetValue("preChangeProg", prechange_program_t.Text.ToString());
                rootKey.SetValue("preChangeProgArgs", prechange_arguments_t.Text.ToString());
                rootKey.SetValue("preChangeProgWait", prechange_waittime_n.Text.ToString());
                rootKey.SetValue("postChangeProg", postchange_program_t.Text.ToString());
                rootKey.SetValue("postChangeProgArgs", postchange_arguments_t.Text.ToString());
                rootKey.SetValue("postChangeProgWait", postchange_waittime_n.Text.ToString());
                rootKey.SetValue("logfile", log_filename_t.Text.ToString());
                rootKey.SetValue("maxlogsize", log_maxsize_n.Text.ToString());
                rootKey.SetValue("loglevel", log_level_n.Text.ToString());
                rootKey.SetValue("environment", environment_t.Text.ToString());
                rootKey.SetValue("workingdir", working_dir_t.Text.ToString());
                switch (priority_d.SelectedItem.ToString())
                {
                    case "Idle":
                        rootKey.SetValue("priority", "-1");
                        break;
                    case "Normal":
                        rootKey.SetValue("priority", "0");
                        break;
                    case "High":
                        rootKey.SetValue("priority", "1");
                        break;
                }
                if (this.preChangeSkipComp.Checked)
                {
                    rootKey.SetValue("preChangeProgSkipComp", "true");
                }
                else
                {
                    rootKey.SetValue("preChangeProgSkipComp", "false");
                }
                if (this.postChangeSkipComp.Checked)
                {
                    rootKey.SetValue("postChangeProgSkipComp", "true");
                }
                else
                {
                    rootKey.SetValue("postChangeProgSkipComp", "false");
                }
                if (this.password_urlencode_c.Checked)
                {
                    rootKey.SetValue("urlencode", "true");
                }
                else
                {
                    rootKey.SetValue("urlencode", "false");
                }
                if (this.password_quote_c.Checked)
                {
                    rootKey.SetValue("doublequote", "true");
                }
                else
                {
                    rootKey.SetValue("doublequote", "false");
                }
                if (this.redirect_output_c.Checked)
                {
                    rootKey.SetValue("output2log", "true");
                }
                else
                {
                    rootKey.SetValue("output2log", "false");
                }
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show(phkRegPath + ex.ToString());
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.ToString(), "ERROR Accessing Registry");
            }

            try
            {
                RegistryKey NotifyKey = Registry.LocalMachine;
                NotifyKey = NotifyKey.OpenSubKey(phkRegNotifyPath, true);
                string[] NotifyPkgsArray = (string[])NotifyKey.GetValue(phkRegNotifyName);
                ArrayList NotifyPkgsAL = new ArrayList();

                NotifyPkgsAL.AddRange(NotifyPkgsArray);
                if (enable_passwdhk_c.Checked)
                {
                    if (NotifyPkgsAL.Contains(phkRegDLLName) == false)
                    {
                        NotifyPkgsAL.Add(phkRegDLLName);
                        NotifyKey.SetValue(phkRegNotifyName, NotifyPkgsAL.ToArray(typeof(string)));
                    }
                }
                else
                {
                    NotifyPkgsAL.Remove(phkRegDLLName);
                    NotifyKey.SetValue(phkRegNotifyName, NotifyPkgsAL.ToArray(typeof(string)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR Enabling or Disabling Password Hook");
            }
        }

        private void Logging_Browse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = "c:\\",

                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.log_filename_t.Text = saveFileDialog1.FileName;
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            LoadFromRegistry();
        }

        private void Workdir_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog
            {
                SelectedPath = this.working_dir_t.Text
            };

            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.working_dir_t.Text = FolderBrowserDialog1.SelectedPath;
            }
        }
    }
}