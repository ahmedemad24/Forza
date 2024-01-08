using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cypos.Class
{
    public class SqlHelper
    {
        SqlConnection cn;
        public SqlHelper (string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }

        public bool isConnection
        {
            get
            {
                try
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("Connection", Properties.Settings.Default.CYPOSConnectionString);
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();
                }
                catch
                {
                    return false;
                }
                
                return true;
            }
        }
    }
}
