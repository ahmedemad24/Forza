using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace cypos.Reports
{
    public partial class rprtReceiptFromMain : DevExpress.XtraReports.UI.XtraReport
    {
        DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();

        public rprtReceiptFromMain(int Id)
        {
            InitializeComponent();
            this.RightToLeft = UserInfo.IsArabicLangSelected ? RightToLeft.Yes : RightToLeft.No;
            this.RightToLeftLayout = UserInfo.IsArabicLangSelected ? RightToLeftLayout.Yes : RightToLeftLayout.No;
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(Id, Id.ToString()));

            this.HeaderId.ValueSourceSettings = staticListLookUpSettings1;
            this.HeaderId.SelectAllValues = true;
            this.IsArabicLangSelected.Value = UserInfo.IsArabicLangSelected;
        }

        private void xrTableRow9_BeforePrint(object sender, CancelEventArgs e)
        {
            var x = UserInfo.IsArabicLangSelected ? Company.OrderTypes.FirstOrDefault(a => a.Id == 3).LabelAr : Company.OrderTypes.FirstOrDefault(a => a.Id == 3).LabelEn;
            if (Company.CompanyType == CompanyTypeEnum.Restaurant)
            {
                if (xrTableCell10.Text != x)
                    xrTableRow9.Visible = false;
                else
                    xrTableRow9.Visible = true;
            }
            else
                xrTableRow9.Visible = false;

        }


        private void xrTableRow14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Company.CompanyType == CompanyTypeEnum.Restaurant)
            {
                var x = UserInfo.IsArabicLangSelected ? Company.OrderTypes.FirstOrDefault(a => a.Id == 1).LabelAr : Company.OrderTypes.FirstOrDefault(a => a.Id == 1).LabelEn;

                if (xrTableCell10.Text != x)
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
            else
            {
                xrTableRow15.Visible = false;
                xrTableRow16.Visible = false;
            }
            
        }

    }
}
