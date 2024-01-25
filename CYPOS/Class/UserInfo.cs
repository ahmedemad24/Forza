using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;

namespace cypos
{
 
    public static class UserInfo
    {
        public static string Userid { get; set; }
        public static string UserName { get; set; }
        public static string UserPassword { get; set; }
        public static int RoleId { get; set; }
        public static string UserType { get; set; }
        public static string UserShiftCode { get; set; }
        public static bool IsArabicLangSelected { get; set; }

        public static List<int> Privilege = new List<int>();

        public static bool IsVaild(int formId)
        {
            if (Privilege.Contains(formId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetDeviceId()
        {
            try
            {
                //string ip = Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();
                string MachineName = Dns.GetHostName();
                //return (ip + ";" + MachineName);
                return (MachineName);

            }
            catch (Exception ex) { return null; }
        }
    }  
}
