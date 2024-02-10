﻿using cypos.Forms;
using System;
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

            //Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-AR");
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ar-AR");

            Application.Run(new FrmJobTitlesCRUD());
            //Application.Run(new XtraForm1());
            //Application.Run(new summaryShift());
        }
    }
}
