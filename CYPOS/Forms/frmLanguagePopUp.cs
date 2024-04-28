using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos.Forms
{
    public partial class frmLanguagePopUp : DevExpress.XtraEditors.XtraForm
    {
        private bool LangFlag = false;
        public frmLanguagePopUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfo.IsArabicLangSelected = false;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            LangFlag = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserInfo.IsArabicLangSelected = true;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ar-EG");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ar-EG");
            //Thread.CurrentThread.CurrentCulture.DateTimeFormat 
            LangFlag = true;
            this.Close();
        }

        private void frmLanguagePopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!LangFlag)
                e.Cancel = true;
        }
    }
}