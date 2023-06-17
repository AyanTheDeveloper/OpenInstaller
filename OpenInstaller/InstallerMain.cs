using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
//using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Threading;

namespace OpenInstaller
{
    public partial class InstallerMain : Form
    {
        WebClient webClient = new WebClient();
        public InstallerMain()
        {
            InitializeComponent();
            p1Label.Visible = false;
            p2Label.Visible = false;
        }
        string ext = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select Part 1";
            theDialog.Filter = "OPI files|*.opi";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                filePath = File.ReadAllText(theDialog.FileName);
                p1Label.Visible = true;
                p1Label.Text = "Selected As: " + theDialog.SafeFileName;
            }


        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label4.Text = e.ProgressPercentage.ToString() + "%";
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (textBox1.Text == "Default")
            {
                MessageBox.Show("Download completed! Thanks for using OpenInstaller.", "Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
                label3.Text = "Nothing";
                label4.Text = "0%";
            }
            else
            {
                //var NikeKicks = Path.GetExtension(Environment.CurrentDirectory + @"\Installed\InstalledFile");
                //File.Move(Environment.CurrentDirectory + @"\Installed\" + textBox2.Text + ext, downloadTo);
                MessageBox.Show("Download completed! Thanks for using OpenInstaller.", "Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
                label3.Text = "Nothing";
                label4.Text = "0%";
            }
        }
       
        string filePath = "";
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog theDialog = new FolderBrowserDialog();
          //  theDialog.Title = "Select Download Location";
           // theDialog.Filter = "All files|*.*";
           // theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                
                downloadTo = theDialog.SelectedPath;
                textBox1.Text = downloadTo;
            }
        }
        string downloadTo = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            
                if (filePath == string.Empty)
                {
                    MessageBox.Show("Please select Part 1!");
                }
                if (ext == string.Empty)
                {
                    MessageBox.Show("Please select Part 2!");
                }
                if (textBox1.Text == "Default")
                {
                    string str2 = Environment.CurrentDirectory + @"\" + textBox2 + ext;
                    char[] spearator2 = { ' ' };
                    String[] splitStr2 = str2.Split(spearator2);
                    string RequiredString2 = splitStr2[2];
                    downloadTo = Environment.CurrentDirectory + @"\Installed\" + RequiredString2;
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                    Uri toDownloadURI2 = new Uri(filePath);
                    webClient.DownloadFileAsync(toDownloadURI2, textBox2.Text + ext);
                    label3.Text = textBox2.Text;

                    //string T1 = textBox2 + ext;
                    string str3 = Environment.CurrentDirectory + @"\" + textBox2 + ext;
                    char[] spearator3 = { ' ' };
                    String[] splitStr3 = str3.Split(spearator3);
                    string RequiredString3 = splitStr3[2];
                    //MessageBox.Show(RequiredString);
                    //Thread.Sleep(9000);
                    // Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(existingFileName, newFileName, true);
                    if (File.Exists(downloadTo + @"\" + RequiredString3))
                    {
                        File.Delete(downloadTo + @"\" + RequiredString3);
                    }

                    var currentDir = Environment.CurrentDirectory + @"\" + RequiredString3;
                    var dt = downloadTo;
                    File.Move(currentDir, dt);

                    if (File.Exists(downloadTo) == true)
                    {
                        MessageBox.Show("Verified! File exists.", "Install Verifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                    Uri toDownloadURI = new Uri(filePath);
                    webClient.DownloadFileAsync(toDownloadURI, textBox2.Text + ext);
                    label3.Text = textBox2.Text;

                    //string T1 = textBox2 + ext;
                    string str = Environment.CurrentDirectory + @"\" + textBox2 + ext;
                    char[] spearator = { ' ' };
                    String[] splitStr = str.Split(spearator);
                    string RequiredString = splitStr[2];
                    //MessageBox.Show(RequiredString);
                    //Thread.Sleep(9000);
                    // Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(existingFileName, newFileName, true);
                    if (File.Exists(downloadTo + @"\" + RequiredString))
                    {
                        File.Delete(downloadTo + @"\" + RequiredString);
                    }

                    var currentDir = Environment.CurrentDirectory + @"\" + RequiredString;
                    var dt = downloadTo + @"\" + RequiredString;
                    File.Move(currentDir, dt);

                    if (File.Exists(downloadTo + @"\" + RequiredString) == true)
                    {
                        MessageBox.Show("Verified! File exists.", "Install Verifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            
            
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select Part 2";
            theDialog.Filter = "OPI files|*.opi";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string value = File.ReadAllText(theDialog.FileName);
                ext = value;
                p2Label.Visible = true;
                p2Label.Text = "Selected As: " + theDialog.SafeFileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string FILEPATH2 = Environment.CurrentDirectory + @"\Installed";
            Process.Start("explorer.exe", FILEPATH2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select Part 2";
            theDialog.Filter = "OPI files|*.opi";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {

                string value = File.ReadAllText(theDialog.FileName);
                textBox2.Text = value;

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OPICreator oc = new OPICreator();
            oc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
