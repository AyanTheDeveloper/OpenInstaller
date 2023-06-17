using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenInstaller
{
    public partial class OPICreator : Form
    {
        public OPICreator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Environment.CurrentDirectory + @"\Created\" + textBox3.Text + "-Part1.opi", textBox1.Text);
                File.WriteAllText(Environment.CurrentDirectory + @"\Created\" + textBox3.Text + "-Part2.opi", textBox2.Text);
                MessageBox.Show("Success!", "OPI Creator");
            }
            catch
            {
                MessageBox.Show("Error");
            }
            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string FILEPATH2 = Environment.CurrentDirectory + @"\Created\";
            Process.Start("explorer.exe", FILEPATH2);
        }
    }
}
