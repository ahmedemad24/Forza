using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos.Forms
{
    public partial class ShiftEndFrm : DevExpress.XtraEditors.XtraForm
    {
        public int ShiftCode { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal EndAmount { get; set; }
        public ShiftEndFrm()
        {
            InitializeComponent();
        }

        private void ShiftEndFrm_Load(object sender, EventArgs e)
        {
            this.ShiftCodeTxt.Text = this.ShiftCode.ToString();
            this.UserName.Text = this.userName;
            //this.startDatePicker.Text = this.startDate.ToShortDateString();
            this.StartDatePicker.EditValue = this.startDate;
            this.EndDatePicker.EditValue = DateTime.Now;
        }

        private void EndBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ShiftEndFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.EndDate = DateTime.Now;
                this.EndAmount = decimal.Parse(amountTxt.Text);
            }
            else
            {
                this.userId = null;
            }
        }
    }
}