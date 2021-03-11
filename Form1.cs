using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace getInstalledApplications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> Software = getInstalledSoftware();

            foreach(string s in Software)
            {
                ListViewItem lvItem = new ListViewItem() { Text = s };
                lView_SoftwareOverview.Items.Add(lvItem);
            }
        }

        private List<string> getInstalledSoftware()
        {
            List<string> installedSoftware = new List<string>();

            ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Product");

            ManagementObjectCollection result = mSearcher.Get();

            foreach(ManagementObject mObject in result)
            {
                if (mObject["Name"] != null)
                    installedSoftware.Add(mObject["Name"].ToString());
            }

            return installedSoftware;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
