using cypos.Forms;
using cypos.Updates.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cypos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Configuration.ConfigurationManager.ConnectionStrings.Add(new System.Configuration.ConnectionStringSettings
            //{
            //    Name = "connection",
            //    ConnectionString = Properties.Settings.Default.CYPOSConnectionString
            //});

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new summaryShift());
        }
    }
}
