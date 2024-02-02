using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace cypos.Reports
{
    public partial class summaryShiftRprt : DevExpress.XtraReports.UI.XtraReport
    {
        private string startDateVal;
        private string endDateVal;
        private string ShiftVal;
        public summaryShiftRprt(string start, string end, string shift)
        {
            startDateVal = start;
            endDateVal = end;
            ShiftVal = shift;

            InitializeComponent();
        }

        private void summaryShiftRprt_DataSourceDemanded(object sender, EventArgs e)
        {
            this.EndDateParam.Value = DateTime.Parse(this.endDateVal);
            this.StartDateParam.Value = DateTime.Parse(this.startDateVal);
            this.ShiftIdParam.Value = this.ShiftVal;
        }

        private void ActualyAmount_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
