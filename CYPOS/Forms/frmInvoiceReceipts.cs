using cypos.Reports;
using DevExpress.XtraReports.UI;
using iTextSharp.testutils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos.Forms
{
    public partial class frmInvoiceReceipts : Form
    {

        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        /*********************************************/
        frmMain _frmMain = new frmMain();

        public frmInvoiceReceipts(frmMain _frm)
        {
            _frmMain = _frm;
            InitializeComponent();
            dgvInvoiceReceipts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvInvoiceReceipts.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvInvoiceReceipts.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            if (UserInfo.IsVaild(36))
            {
                filterBoxPnl.Visible = true;
            }
            else
            {
                filterBoxPnl.Visible = false;
            }
            if (UserInfo.IsVaild(37))
            {
                prntInvBtn.Visible = true;
            }
            else
            {
                prntInvBtn.Visible = false;
            }
            if (UserInfo.IsVaild(38))
            {
                AvoidInvBtn.Visible = true;
            }
            else
            {
                AvoidInvBtn.Visible = false;
            }
        }

        private void frmDeliveryOrders_Load(object sender, EventArgs e)
        {
            Clear();
        }

        public void CounterGridFill()
        {
            DataGridView dgv = dgvInvoiceReceipts;
            Color clr = ColorTranslator.FromHtml("#FF8A8A");
            Color dueColor = ColorTranslator.FromHtml("#0E8A8A");
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var value = dgv.Rows[i].Cells["payment_type"].Value.ToString();
                var dueValue = decimal.Parse(dgv.Rows[i].Cells["due_amount"].Value.ToString());
                var invoiceStatus = dgv.Rows[i].Cells["invoice_status"].Value.ToString();
                if (value == "Canceled" || value == "Gifted")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = clr;
                }
                else if (dueValue > 0 && invoiceStatus != "Open")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = dueColor;
                }
            }
            rowsCountLbl.Text = dgvInvoiceReceipts.Rows.Count.ToString() + " Invoices Found";
        }

        private void Search(string fromdate = "", string toDate = "", int shiftId = 0, string username = "", string invNo = "")
        {
            try
            {
                string FilterQuery = $@"
select tbl.* ,isnull(c.name,'') customerName from
(SELECT
    invoice_id, invoice_no,customer_id
    , CASE 
        WHEN i.order_type = 1 THEN 'DINE IN' 
        WHEN i.order_type = 2 THEN 'TAKE AWAY' 
        WHEN i.order_type = 3 THEN 'DELIVERY' 
        WHEN i.order_type = 4 THEN 'PICK UP' 
    END order_type
    , iif(due_amount<=0,'Close','Debit') invoice_status, cast(log_date as date) invoice_date,FORMAT(log_date, 'hh:mm tt') invoice_time
    , CASE 
        WHEN isCanceled = 1 THEN 'Canceled' 
        WHEN isGifted = 1 THEN 'Gifted' 
        ELSE payment_type 
    END payment_type 
    , user_name, discount_rate, payment_amount, shift_id, log_date 
    , paid_amount, change_amount, due_amount, isnull(note, 'ClosedINV') note 
FROM tbl_InvoiceHeader i 
union all 
Select 
     id, invoiceNo ,customer_id 
     , CASE 
         WHEN t.order_type = 1 THEN 'DINE IN' 
         WHEN t.order_type = 2 THEN 'TAKE AWAY' 
         WHEN t.order_type = 3 THEN 'DELIVERY' 
         WHEN t.order_type = 4 THEN 'PICK UP' 
         END order_type 
     , 'Open' invoice_status, cast(log_date as date) invoice_date,FORMAT(log_date, 'hh:mm tt') invoice_time, payment_type 
     , user_name, discount_rate, payment_amount, shift_id, log_date, paid_amount, change_amount, due_amount, isnull(note, 'fromTemp') note 
FROM tbl_TempHeader t) tbl 
left join tbl_Customer C on tbl.customer_id=c.id
where 
     (tbl.shift_id = {shiftId} or {shiftId}=0) and 
     (tbl.user_name = '{username}' or '{username}' ='') and 
     (tbl.invoice_no = '{invNo}' or '{invNo}' ='') and  
     (('{toDate}'='' and '{fromdate}'='') or
     (cast('{toDate}' as date) >= cast(log_date as date) and '{fromdate}'='') or 
     ('{toDate}' ='' and cast('{fromdate}' as date) <= cast(log_date as date)) or 
     (cast('{toDate}' as date) >= cast(log_date as date) and cast('{fromdate}' as date) <= cast(log_date as date)))
ORDER BY log_date DESC";

                DataTable dt = DataAccess.GetDataTable(FilterQuery);
                dgvInvoiceReceipts.DataSource = dt;
                CounterGridFill();
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnArrowUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvInvoiceReceipts;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[2].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            }
            catch (Exception)
            {
            }
        }

        private void BtnArrowDwn_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvInvoiceReceipts;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[2].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
                if (RowIsVisible(selectedRow))
                {
                    dgv.FirstDisplayedScrollingRowIndex = selectedRow.Index + 1;
                }
            }
            catch (Exception)
            {
            }
        }

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            return row.Index >= lastVisibleRowIndex;
        }

        public void Clear()
        {
            prntInvBtn.Enabled = false;
            AvoidInvBtn.Enabled = false;
            string sqlQuery = "SELECT user_name,user_name id FROM tbl_User ";
            DataTable dt = DataAccess.GetDataTable(sqlQuery);
            DataRow dataRow = dt.NewRow();
            dataRow["id"] = "";
            dataRow["user_name"] = "--Select Username--";
            dt.Rows.InsertAt(dataRow, 0);
            UsernameComb.DataSource = dt;
            UsernameComb.DisplayMember = "user_name";
            UsernameComb.ValueMember = "id";
            textBox1.Clear();
            ToDate.Value = DateTime.Now;
            fromDate.Value = DateTime.Now.AddDays(-1);
            CounterGridFill();
            dgvInvoiceReceipts.ClearSelection();
            textBox2.Clear();
        }

        //Refresh button ..
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlInner_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            //Search();
            Search(
                fromDate.Checked ? fromDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , ToDate.Checked ? ToDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , string.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text)
                , UsernameComb.Items.Count == 0 ? "" : UsernameComb.SelectedValue.ToString());
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            Search(
                fromDate.Checked ? fromDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , ToDate.Checked ? ToDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , string.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text)
                , UsernameComb.Items.Count == 0 ? "" : UsernameComb.SelectedValue.ToString());
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Search(
                fromDate.Checked ? fromDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , ToDate.Checked ? ToDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , string.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text)
                , UsernameComb.Items.Count == 0 ? "" : UsernameComb.SelectedValue.ToString());
        }

        private void UsernameComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(
                fromDate.Checked ? fromDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , ToDate.Checked ? ToDate.Value.Date.ToString("MM-dd-yyyy") : ""
                , string.IsNullOrEmpty(textBox1.Text) ? 0 : Convert.ToInt32(textBox1.Text)
                , UsernameComb.Items.Count == 0 ? "" : UsernameComb.SelectedValue.ToString());
        }

        private void dgvInvoiceReceipts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dgvInvoiceReceipts.CurrentRow.Cells["payment_type"].Value.ToString();
            var note = dgvInvoiceReceipts.CurrentRow.Cells["note"].Value.ToString();
            if (note != null)
            {
                if (value == "Canceled" || value == "Gifted")
                {
                    textBox2.Text = note;
                    textBox2.Enabled = false;
                    AvoidInvBtn.Enabled = false;
                }
                else
                {
                    textBox2.Text = "";
                    textBox2.Enabled = true;
                    AvoidInvBtn.Enabled = true;
                }
            }
            else
            {
                return;
            }
            prntInvBtn.Enabled = true;
        }

        private void prntInvBtn_Click(object sender, EventArgs e)
        {
            ValidateUserType validateFrm = new ValidateUserType();
            validateFrm.ShowDialog();

            if (validateFrm.userType == "Admin")
            {
                try
                {
                    var id = dgvInvoiceReceipts.CurrentRow.Cells["id"].Value.ToString();
                    var status = dgvInvoiceReceipts.CurrentRow.Cells["invoice_status"].Value.ToString();
                    if (status == "Open")
                    {
                        string[] holdId = { id };
                        rprtInvoiceReceipt rprtForTemp = new rprtInvoiceReceipt(string.Join(",", holdId));
                        ReportPrintTool printTool1 = new ReportPrintTool(rprtForTemp);
                        printTool1.ShowPreview();
                    }
                    else
                    {
                        rprtReceiptFromMain rprtForInvoice = new rprtReceiptFromMain(int.Parse(id));
                        ReportPrintTool printTool2 = new ReportPrintTool(rprtForInvoice);
                        printTool2.ShowPreview();
                    }
                }
                catch (Exception exp)
                {
                    Messages.ExceptionMessage(exp.Message);
                }
            }
            else
            {
                MessageBox.Show("Sorry , Not Authorized");
            }
        }

        private void AvoidInvBtn_Click(object sender, EventArgs e)
        {
            
            
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Messages.InformationMessage("You Must Enter A Note For This Invoice!!");
            }
            else
            {
            var warningMsg = MessageBox.Show("Invoice will be canceled! Are you sure avoid this invoice?", 
                "Warning", MessageBoxButtons.OKCancel
                   , MessageBoxIcon.Warning);
                if (warningMsg == DialogResult.OK)
                {
                    ValidateUserType validateFrm = new ValidateUserType();
                    validateFrm.ShowDialog();

                    if (validateFrm.userType == "Admin")
                    {
                        try
                        {
                            var id = dgvInvoiceReceipts.CurrentRow.Cells["id"].Value.ToString();
                            var status = dgvInvoiceReceipts.CurrentRow.Cells["invoice_status"].Value.ToString();
                            var ordetType = dgvInvoiceReceipts.CurrentRow.Cells["order_type"].Value.ToString();
                            var paymentType = dgvInvoiceReceipts.CurrentRow.Cells["payment_type"].Value.ToString();
                            var paymentAmount = dgvInvoiceReceipts.CurrentRow.Cells["payment_amount"].Value.ToString();
                            var paidAmount = dgvInvoiceReceipts.CurrentRow.Cells["paid_amount"].Value.ToString();
                            var changeAmount = dgvInvoiceReceipts.CurrentRow.Cells["change_amount"].Value.ToString();
                            var dueAmount = dgvInvoiceReceipts.CurrentRow.Cells["due_amount"].Value.ToString();
                            var invoiceDate = dgvInvoiceReceipts.CurrentRow.Cells["invoice_date"].Value.ToString();
                            var invoiceTime = dgvInvoiceReceipts.CurrentRow.Cells["invoice_time"].Value.ToString();
                            var note = textBox2.Text;

                            if (status == "Open")
                            {
                                if (ordetType == "DELIVERY")
                                {
                                    _frmMain.SaveDeliveryOrders(int.Parse(id), paymentType, note, true, true);
                                    Clear();
                                }
                                else
                                {
                                    _frmMain.SaveInvoice(int.Parse(id), decimal.Parse(paymentAmount), decimal.Parse(paidAmount), decimal.Parse(changeAmount)
                                    , decimal.Parse(dueAmount), invoiceDate, invoiceTime, paymentType, note, true, true);
                                    Clear();
                                }
                            }
                            else
                            {
                                string query = $"UPDATE tbl_InvoiceHeader SET isCanceled =  1, user_name='{UserInfo.UserName}',CancelDate = '{DateTime.Now}' , note = '{note}' WHERE invoice_id = {int.Parse(id)}";
                                DataAccess.ExecuteSQL(query);
                                Clear();
                            }
                        }
                        catch (Exception exp)
                        {
                            Messages.ExceptionMessage(exp.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Sorry , Not Authorized");
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void BtnArrowUp_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Up", BtnArrowUp);
        }

        private void BtnArrowDwn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Down", BtnArrowDwn);
        }

        private void prntInvBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Print Select Invoice", prntInvBtn);
        }

        private void AvoidInvBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Avoid/Cancel An Invoice", AvoidInvBtn);
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh", button1);
        }

        private void dgvInvoiceReceipts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CounterGridFill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var invoiceStatus = dgvInvoiceReceipts.CurrentRow.Cells["invoice_status"].Value.ToString();
            if (invoiceStatus != "Debit")
            {
                Messages.WarningMessage("Available Only For 'Debit' Invoices!");
            }
            else
            {
                frmPayment frmPayment = new frmPayment(this);
                frmPayment.Payable = dgvInvoiceReceipts.CurrentRow.Cells["due_amount"].Value.ToString();
                frmPayment.InvoiceNo = dgvInvoiceReceipts.CurrentRow.Cells["invoice_no"].Value.ToString();
                frmPayment.InvoiceId = int.Parse(dgvInvoiceReceipts.CurrentRow.Cells["id"].Value.ToString());
                frmPayment.customerId = int.Parse(dgvInvoiceReceipts.CurrentRow.Cells["customer_id"].Value.ToString());
                frmPayment.ShowDialog();
            }
        }
    }
}
