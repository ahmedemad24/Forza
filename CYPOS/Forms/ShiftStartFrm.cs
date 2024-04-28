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
    public partial class ShiftStartFrm : DevExpress.XtraEditors.XtraForm
    {
        public int ShiftCode { get; set; }
        public DateTime startDate { get; set; }
        public string userId { get; set; }
        public decimal Amount { get; set; }
        public ShiftStartFrm()
        {
            InitializeComponent();
        }

        private void StartShiftFrm_Load(object sender, EventArgs e)
        {
            string sqlQuery;// = "select user_name from tbl_User where id=" + userId;
            DataTable dt;//= DataAccess.GetDataTable(sqlQuery);
            this.UserName.Text = UserInfo.UserName;// dt.Rows[0].ItemArray[0].ToString();
            sqlQuery = "select max(id) from tbl_UserShifts";
            dt = DataAccess.GetDataTable(sqlQuery);
            this.ShiftCode = (dt.Rows[0].ItemArray[0].ToString() == "" ? 0 : int.Parse(dt.Rows[0].ItemArray[0].ToString())) + 1;
            this.ShiftCodeTxt.Text = this.ShiftCode.ToString();
            this.StartDatePicker.EditValue = DateTime.Now;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void StartShiftFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.startDate = DateTime.Now;
                this.Amount = decimal.Parse(amountTxt.Text);
            }
            else
            {
                this.userId = null;
            }
        }
    }
}