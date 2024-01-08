using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos
{
    public partial class frm_Activation : Form
    {
        public string manufatureID;
        public frm_Activation()
        {
            InitializeComponent();
        }
        private string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass mc = new ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        private void btnChick_Click(object sender, EventArgs e)
        {
            Activation.Activate(txtActivationCode.Text);

        }

        private void frm_Activation_Load(object sender, EventArgs e)
        {
            var l = Activation.ChickActivation();
            manufatureID = identifier("Win32_DiskDrive", "SerialNumber");
            txtSerial.Text = (manufatureID).ToString();
        }
    }
}
