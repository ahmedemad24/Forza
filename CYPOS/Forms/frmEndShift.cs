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
    public partial class frmEndShift : Form
    {
        public int ShiftCode { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal EndAmount { get; set; }
        public frmEndShift()
        {
            InitializeComponent();
        }

        private void frmEndShift_Load(object sender, EventArgs e)
        {
            this.txtShiftCode.Text = this.ShiftCode.ToString();
            this.txtUserName.Text = this.userName;
            //this.startDatePicker.Text = this.startDate.ToShortDateString();
            this.startDatePicker.Value = this.StartTimePicker.Value = this.startDate;
            this.enddatePicker.Value = this.EndTimePicker.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmEndShift_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.EndDate = DateTime.Now;
                this.EndAmount = decimal.Parse(txtAmount.Text);
            }
            else
            {
                this.userId = null;
            }
        }
    }
}
