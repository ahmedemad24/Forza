using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmSettings : Form
    {
        private frmMain _frmMain;  

        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1;       /*The WM_NCLBUTTONDOWN message is one of those messages. 
                                                         WM = Window Message. NC = Non Client, the part of the 
                                                         * window that's not the client area, the borders and the title bar. 
                                                         L = Left button, you can figure out BUTTONDOWN. */
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /*********************************************/
	    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmSettings(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }
	
        private void pbxClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserType != "Admin")
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
            try
            {
                string strSQL = "SELECT TOP 1 * FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSetting= DataAccess.GetDataTable(strSQL);

                cmbOrderType.SelectedIndex =int.Parse(dtSetting.Rows[0]["default_order_type"].ToString())-1;
                cbxCustomerAfterDo.Checked = bool.Parse(dtSetting.Rows[0]["customer_after_do"].ToString());
                cbxCustomerAfterPo.Checked = bool.Parse(dtSetting.Rows[0]["customer_after_po"].ToString());

                cbxAutoItemNo.Checked = bool.Parse(dtSetting.Rows[0]["auto_item_no"].ToString());
                cbxEnableTable.Checked = bool.Parse(dtSetting.Rows[0]["ask_table"].ToString());
                cbxEnableGuestCount.Checked = bool.Parse(dtSetting.Rows[0]["ask_guest_count"].ToString());
                cbxEnableWaiter.Checked = bool.Parse(dtSetting.Rows[0]["ask_waiter"].ToString());

                txtInvoiceDeleteDays.Text = dtSetting.Rows[0]["delete_hold_days"].ToString();
                txtDefaultDiscRate.Text = dtSetting.Rows[0]["default_discount_rate"].ToString();
                txtItemPerPage.Text = dtSetting.Rows[0]["items_per_page"].ToString();

                txtInvoiceNoPrefix.Text = dtSetting.Rows[0]["invoice_no_prefix"].ToString();
                cbxShowItemImage.Checked = bool.Parse(dtSetting.Rows[0]["show_item_image"].ToString());
                //cbxShowLeadingZeros.Checked = bool.Parse(dtSetting.Rows[0]["show_leading_zeros"].ToString());
                //txtZeroCount.Text = dtSetting.Rows[0]["zeros_count"].ToString();
                //txtInvoiceStartingNo.Text = dtSetting.Rows[0]["starting_invoice_no"].ToString();

                //if (Settings.LastInvoiceAutoNo != 0)
                //{
                //    txtInvoiceStartingNo.Enabled = false;
                //}
                //else
                //{
                //    txtInvoiceStartingNo.Enabled = true;
                //}
                txtKotPrefix.Text = dtSetting.Rows[0]["kot_no_prefix"].ToString();
                cbxKotLeadingZeros.Checked = bool.Parse(dtSetting.Rows[0]["kot_leading_zeros"].ToString());
                txtKotZeroCount.Text = dtSetting.Rows[0]["kot_zeros_count"].ToString();
                txtKotStartingNo.Text = dtSetting.Rows[0]["kot_starting_no"].ToString();

                if (Settings.LastKotAutoNo != 0)
                {
                    txtKotStartingNo.Enabled = false;
                }
                else
                {
                    txtKotStartingNo.Enabled = true;
                }

                cbxPreviewB4Print.Checked = bool.Parse(dtSetting.Rows[0]["preview_before_print"].ToString());
                cbxShowLogo.Checked = bool.Parse(dtSetting.Rows[0]["show_logo"].ToString());

                cbxEnableServiceCharge.Checked = bool.Parse(dtSetting.Rows[0]["enable_sc"].ToString());
                txtScRate.Text = dtSetting.Rows[0]["sc_rate"].ToString();

                cbxPrintKotOnHold.Checked = bool.Parse(dtSetting.Rows[0]["print_kot_after_hold"].ToString());
                cbxShowOtAfterBill.Checked = bool.Parse(dtSetting.Rows[0]["show_ot_after"].ToString());

                cbxPreviewKot.Checked = bool.Parse(dtSetting.Rows[0]["kot_view_before_print"].ToString());   
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtScRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtScRate.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtDefaultDiscRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDefaultDiscRate.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtItemPerPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtInvoiceStartingNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtZeroCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtInvoiceDeleteDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDefaultDiscRate_Leave(object sender, EventArgs e)
        {
            if (txtDefaultDiscRate.Text == string.Empty)
            {
                txtDefaultDiscRate.Text = "0";
            }
            else
            {
                decimal decDiscRate = decimal.Parse(txtDefaultDiscRate.Text);
                if (decDiscRate > 100)
                {
                    txtDefaultDiscRate.Text = "0";
                }
            }
        }

        private void txtScRate_Leave(object sender, EventArgs e)
        {
            if (txtScRate.Text == string.Empty)
            {
                txtScRate.Text = "0";
            }
            else
            {
                decimal decScRate = decimal.Parse(txtScRate.Text);
                if (decScRate > 100)
                {
                    txtScRate.Text = "0";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int orderType = cmbOrderType.SelectedIndex + 1;
                //int autoInvoiceNo = int.Parse(txtInvoiceStartingNo.Text) - 1;

                string strSQLUpdate = "UPDATE tbl_Settings SET items_per_page= '" + txtItemPerPage.Text + "'," +
                                      "show_ot_after = '" + Convert.ToBoolean(cbxShowOtAfterBill.CheckState) + "'," +
                                      "auto_item_no = '" + Convert.ToBoolean(cbxAutoItemNo.CheckState) + "'," +
                                      "ask_table = '" + Convert.ToBoolean(cbxEnableTable.CheckState) + "'," +
                                      "ask_guest_count = '" + Convert.ToBoolean(cbxEnableGuestCount.CheckState) + "'," +
                                      "ask_waiter = '" + Convert.ToBoolean(cbxEnableWaiter.CheckState) + "'," +
                                      "delete_hold_days = '" + txtInvoiceDeleteDays.Text + "'," +
                                      "default_discount_rate = '" + txtDefaultDiscRate.Text + "'," +
                                      "default_order_type = '" + orderType + "'," +
                                      "show_logo = '" + Convert.ToBoolean(cbxShowLogo.CheckState) + "'," +
                                      "enable_sc = '" + Convert.ToBoolean(cbxEnableServiceCharge.CheckState) + "'," +
                                      "sc_rate = '" + txtScRate.Text + "'," +
                                      "customer_after_do = '" + Convert.ToBoolean(cbxCustomerAfterDo.CheckState) + "'," +
                                      "customer_after_po = '" + Convert.ToBoolean(cbxCustomerAfterPo.CheckState) + "'," +
                                      "invoice_no_prefix = '" + txtInvoiceNoPrefix.Text + "'," +
                                      //"show_leading_zeros = '" + Convert.ToBoolean(cbxShowLeadingZeros.CheckState) + "'," +
                                      //"zeros_count = '" + txtZeroCount.Text + "'," +
                                      //"starting_invoice_no = '" + txtInvoiceStartingNo.Text + "'," +
                                      "kot_no_prefix = '" + txtKotPrefix.Text + "'," +
                                      "kot_leading_zeros = '" + Convert.ToBoolean(cbxKotLeadingZeros.CheckState) + "'," +
                                      "kot_zeros_count = '" + txtKotZeroCount.Text + "'," +
                                      "kot_starting_no = '" + txtKotStartingNo.Text + "'," +
                                      "preview_before_print = '" + Convert.ToBoolean(cbxPreviewB4Print.CheckState) + "'," +
                                      "print_kot_after_hold = '" + Convert.ToBoolean(cbxPrintKotOnHold.CheckState) + "'," +
                                      "kot_view_before_print = '" + Convert.ToBoolean(cbxPreviewKot.CheckState) + "', " +
                                      "show_item_image = '"+ Convert.ToBoolean(cbxShowItemImage.CheckState) + "'";
                                      

                DataAccess.ExecuteSQL(strSQLUpdate);

                //if (txtInvoiceStartingNo.Enabled)
                //{
                //    //Update Starting Invoice Numbers / Auto Index (Identity)
                //    string strSQLInvoiceNo = "DBCC CHECKIDENT ('tbl_InvoiceNo', RESEED," + autoInvoiceNo.ToString() + ")";
                //    DataAccess.ExecuteSQL(strSQLInvoiceNo);
                //}

                if (txtKotStartingNo.Enabled)
                {
                    //Update Starting Kot Numbers / Auto Index (Identity)
                    int autoKotNo = int.Parse(txtKotStartingNo.Text);
                    string strSQLKotNo = "DBCC CHECKIDENT ('tbl_KotNo', RESEED," + autoKotNo.ToString() + ")";
                    DataAccess.ExecuteSQL(strSQLKotNo);
                }

                _frmMain.Clear();
                OpenedForms.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenedForms.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbScRate_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtScRate);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbInPrefix_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtInvoiceNoPrefix);
            frmKeyboard.ShowDialog();
        }

        //private void btnStartingNo_Click(object sender, EventArgs e)
        //{
        //    frmNumberboard frmNumberboard = new frmNumberboard(txtInvoiceStartingNo);
        //    frmNumberboard.ShowDialog();
        //}

        //private void btnKbInZeros_Click(object sender, EventArgs e)
        //{
        //    frmNumberboard frmNumberboard = new frmNumberboard(txtZeroCount);
        //    frmNumberboard.ShowDialog();
        //}

        private void btnKbKotZeros_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtKotZeroCount);
            frmNumberboard.ShowDialog();
        }

        private void btnKbKotStart_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtKotStartingNo);
            frmNumberboard.ShowDialog();
        }

        private void btnKbInDeleteDays_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtInvoiceDeleteDays);
            frmNumberboard.ShowDialog();
        }

        private void btnKbPageItems_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtItemPerPage);
            frmNumberboard.ShowDialog();
        }

        private void btnKbDiscRate_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtDefaultDiscRate);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbKotPrefix_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtKotPrefix);
            frmKeyboard.ShowDialog();
        }

        private void cbxEnableWaiter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxShowLogo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxPreviewB4Print_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxCustomerAfterDo_CheckedChanged(object sender, EventArgs e)
        {

        }

        public bool IsCheckedForShowImages;

        private void cbxShowItemImage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowItemImage.Checked)
            {
                IsCheckedForShowImages = true;
            }
            else
            {
                IsCheckedForShowImages = false;
            }
        }
    }
}
