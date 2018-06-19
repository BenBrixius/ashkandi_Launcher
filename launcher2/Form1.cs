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


namespace launcher2
{
    public partial class launcher : Form
    {
        string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\realms.txt";


        public launcher()
        {
            InitializeComponent();

            if (!File.Exists(path)) 
            {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path)) 
            {
                sw.WriteLine("set realmlist logon.lightshope.org" + "\r\n" + "n/a" + "\r\n" + "n/a");
            }	
            } else
            {
                string[] lines = System.IO.File.ReadAllLines(path);

                    txtRealm1.Text = lines[0];
                    txtRealm2.Text = lines[1];
                    txtRealm3.Text = lines[2];
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtRealm1.Enabled == true)
            {
                txtRealm1.Enabled = false;
            } else
            {
                txtRealm1.Enabled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (txtRealm2.Enabled == true)
            {
                txtRealm2.Enabled = false;
            }
            else
            {
                txtRealm2.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (txtRealm3.Enabled == true)
            {
                txtRealm3.Enabled = false;
            }
            else
            {
                txtRealm3.Enabled = true;
            }
        }

        public void writeRealmList(string a)
        {
            File.WriteAllText("realmlist.wtf", a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            writeRealmList(txtRealm1.Text);
            Process.Start("WoW.exe");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeRealmList(txtRealm2.Text);
            Process.Start("WoW.exe");
            Close();
        }

        private void btnPlay3_Click(object sender, EventArgs e)
        {
            writeRealmList(txtRealm3.Text);
            Process.Start("WoW.exe");
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(path))
            sw.WriteLine(txtRealm1.Text + "\r\n" + txtRealm2.Text + "\r\n" + txtRealm3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select the checkbox to unlock and lock the realmlist entry. \r\rPressing save changes will keep the list up to date if you change them. \r\rPressing play will automatically change your realmlist, close the launcher, and open WoW. \r\rData is kept in realms.txt in same directory.", "Halp Window");
        }
    }
}
