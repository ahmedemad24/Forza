using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace cypos.Reports
{
    public partial class rprtReceiptFromMain : DevExpress.XtraReports.UI.XtraReport
    {
        DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();

        public rprtReceiptFromMain(int Id)
        {
            InitializeComponent();

            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(Id, Id.ToString()));

            this.HeaderId.ValueSourceSettings = staticListLookUpSettings1;
            this.HeaderId.SelectAllValues = true;
        }

        private void xrTableRow9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(xrTableCell10.Text != "DELIVERY")
                xrTableRow9.Visible = false;
            else
                xrTableRow9.Visible = true;
        }

        private void xrTableRow12_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrTableCell10.Text != "DELIVERY")
            {
                xrTableRow12.Visible = false;
                xrTableRow13.Visible = false;
            }
            else
            {
                xrTableRow12.Visible = true;
                xrTableRow13.Visible = true;
            }
        }

        private void xrTableRow2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(xrTableCell10.Text == "TAKE AWAY")
            {
                xrTableCell4.Visible = false;
                xrTableCell8.Visible = false;
            }
            else
            {
                xrTableCell4.Visible = true;
                xrTableCell8.Visible = true;
            }
        }
    }
}
