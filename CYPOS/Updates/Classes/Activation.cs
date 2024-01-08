using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos
{
    public static class Activation
    {
        public static string manufatureID = identifier("Win32_DiskDrive", "SerialNumber");

        public static bool Activate(string ActivationCode)
        {
            if (ActivationCode != string.Empty)
            {

                try
                {
                    var JsonString = Encryption.Decrypt(ActivationCode);
                    ActivationModel AM = new ActivationModel();
                    AM = JsonConvert.DeserializeObject<ActivationModel>(JsonString);
                    if (AM.Serial == manufatureID)
                    {
                        MessageBox.Show("تم التفعيل بنجاح");
                        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
                        key.SetValue("Key1", ActivationCode);
                        key.Close();
                        return true;
                    }
                }
                catch
                {
                    MessageBox.Show("كود التفعيل خطاء");
                    return false;
                }
                return false;

            }
            else
            {
                MessageBox.Show("قم بإدخال كود التفعيل");
                return false;
            }
        }

        public static bool ChickActivation()
        {
            return true;
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\OurSettings");
                string Value = key.GetValue("Key1").ToString();
                key.Close();
                var JsonString = Encryption.Decrypt(Value);
                ActivationModel AM = new ActivationModel();
                AM = JsonConvert.DeserializeObject<ActivationModel>(JsonString);
                if (AM.Serial == manufatureID)
                {
                    TimeSpan difference = (DateTime.Today - AM.StartDate);
                    if (AM.NOfDays > difference.Days)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("لقد انتهت مدة الاشتراك");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("الرجاء التواصل مع البائع لتفعيل البرنامج");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("البرنامج غير مفعل تواصل مع البائع");
                return false;
            }

        }

        private static string identifier(string wmiClass, string wmiProperty)
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
    }

}
