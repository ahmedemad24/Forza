using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace cypos.Reports
{
    public partial class rprtInvoiceReceipt : DevExpress.XtraReports.UI.XtraReport
    {
        //public List<int> Ids;
        DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();


        public rprtInvoiceReceipt(string Ids)
        {
            InitializeComponent();
            this.HeaderId.Value = Ids;
        }

        private void xrTableRow9_BeforePrint(object sender, CancelEventArgs e)
        {
            if(xrTableCell10.Text!= "DELIVERY")
                xrTableRow9.Visible = false;
            else
                xrTableRow9.Visible = true;
        }

        private void xrTableRow14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrTableCell10.Text != "DELIVERY")
            {
                xrTableRow12.Visible = false;
                xrTableRow13.Visible = false;
                xrTableRow14.Visible = false;
            }
            else
            {
                xrTableRow12.Visible = true;
                xrTableRow13.Visible = true;
                xrTableRow14.Visible = true;
            }

            if (xrTableCell10.Text != "DINE IN")
            {
                xrTableRow15.Visible = false;
                xrTableRow16.Visible = false;
            }
            else
            {
                xrTableRow15.Visible = true;
                xrTableRow16.Visible = true;
            }


        }

    }
}
