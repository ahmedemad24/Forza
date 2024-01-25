using cypos.Forms;
using cypos.Updates.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

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

            //Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-AR");
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ar-AR");

            Application.Run(new XtraForm1());
            //Application.Run(new summaryShift());
        }
    }
}
