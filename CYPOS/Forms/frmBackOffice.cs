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
using cypos.Forms;

namespace cypos
{
    public partial class frmBackOffice : Form
    {
        private frmMain _frmMain;  

        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1;       /*The WM_NCLBUTTONDOWN message is one of those messages. 
                                                         WM = Window Message. NC = Non Client, the part of the 
                                                         * window that's not the client area, the borders and the title bar. 
                                                         L = Left button, you can figure out BUTTONDOWN. */
        public const int HT_CAPTION = 0x2;

        public static bool enabled { get; internal set; }

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

        public frmBackOffice(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            if (UserInfo.IsVaild(35))
            {
                btnCustomer.Visible = true;
            }
            else
            {
                btnCustomer.Visible = false;
            }
            if (UserInfo.IsVaild(39))
            {
                btnCompany.Visible = true;
            }
            else
            {
                btnCompany.Visible = false;
            }
            if (UserInfo.IsVaild(40))
            {
                btnCategory.Visible = true;
            }
            else
            {
                btnCategory.Visible = false;
            }
            if (UserInfo.IsVaild(41))
            {
                btnItems.Visible = true;
            }
            else
            {
                btnItems.Visible = false;
            }
            if (UserInfo.IsVaild(42))
            {
                btnModifiers.Visible = true;
            }
            else
            {
                btnModifiers.Visible = false;
            }
            if (UserInfo.IsVaild(43))
            {
                btnTables.Visible = true;
            }
            else
            {
                btnTables.Visible = false;
            }
            if (UserInfo.IsVaild(44))
            {
                btnLocation.Visible = true;
            }
            else
            {
                btnLocation.Visible = false;
            }
            if(UserInfo.IsVaild(45))
            {
                btnPaymentTypes.Visible = true;
            }
            else
            {
                btnPaymentTypes.Visible = false;
            }
            if (UserInfo.IsVaild(46))
            {
                btnUsers.Visible = true;
            }
            else
            {
                btnUsers.Visible = false;
            }
            if (UserInfo.IsVaild(47))
            {
                btnPurchase.Visible = true;
            }
            else
            {
                btnPurchase.Visible = false;
            }
            if (UserInfo.IsVaild(49))
            {
                btnSupplier.Visible = true;
            }
            else
            {
                btnSupplier.Visible = false;
            }
            if (UserInfo.IsVaild(53))
            {
                btnExpenseGroup.Visible = true;
            }
            else
            {
                btnExpenseGroup.Visible = false;
            }
            if (UserInfo.IsVaild(57))
            {
                btnExpenses.Visible = true;
            }
            else
            {
                btnExpenses.Visible = false;
            }
            if (UserInfo.IsVaild(61))
            {
                btnSettings.Visible = true;
            }
            else
            {
                btnSettings.Visible = false;
            }
            if (UserInfo.IsVaild(62))
            {
                btnPrinters.Visible = true;
            }
            else
            {
                btnPrinters.Visible = false;
            }
            if (UserInfo.IsVaild(63))
            {
                btnReports.Visible = true;
            }
            else
            {
                btnReports.Visible = false;
            }
            if (UserInfo.IsVaild(64))
            {
                btnKitchenDisplay.Visible = true;
            }
            else
            {
                btnKitchenDisplay.Visible = false;
            }
            if (UserInfo.IsVaild(65))
            {
                btnDatabase.Visible = true;
            }
            else
            {
                btnDatabase.Visible = false;
            }
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany frmCompany = new frmCompany();
            frmCompany.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory(_frmMain);
            frmCategory.ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            frmItem frmItem = new frmItem(_frmMain);
            frmItem.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser();
            frmUser.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnKitchenDisplay_Click(object sender, EventArgs e)
        {
            Report.frmKitchenDisplay frmKitchenDisplay = new Report.frmKitchenDisplay();
            frmKitchenDisplay.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports frmReports =new frmReports(_frmMain);
            frmReports.ShowDialog();    
        }

        private void btnModifiers_Click(object sender, EventArgs e)
        {
            frmModifiers frmModifiers = new frmModifiers();
            frmModifiers.ShowDialog();
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (UserInfo.RoleId != 1)
            {
                MessageBox.Show("Only Admin Can Control This Form!");
            }
            else
            {
                frmUserAccess frmUserAccess  = new frmUserAccess();
                frmUserAccess.ShowDialog();
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmInvoiceReceipts frmInvoiceReceipts = new frmInvoiceReceipts(_frmMain);
            frmInvoiceReceipts.ShowDialog();
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            frmDatabase frmDataReset = new frmDatabase();
            frmDataReset.ShowDialog();
        }

        private void frmBackOffice_Load(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmPurchaseList frmPurchaseList = new frmPurchaseList(_frmMain);
            frmPurchaseList.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.ShowDialog();
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            frmExpenses frmExpense = new frmExpenses();
            frmExpense.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings(_frmMain);
            frmSettings.ShowDialog();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            frmTable frmTable = new frmTable(_frmMain);
            frmTable.ShowDialog();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            frmTableLocation frmTableLocation = new frmTableLocation(_frmMain);
            frmTableLocation.ShowDialog();
        }

        private void btnPaymentTypes_Click(object sender, EventArgs e)
        {
            frmPaymentType frmPaymentType = new frmPaymentType(_frmMain);
            frmPaymentType.ShowDialog();
        }

        private void btnPrinters_Click(object sender, EventArgs e)
        {
            frmPrinters frmPrinters = new frmPrinters(_frmMain);
            frmPrinters.ShowDialog();
        }

        private void btnExpenseGroup_Click(object sender, EventArgs e)
        {
            frmExpenseGroup frmExpenseGroup = new frmExpenseGroup(_frmMain);
            frmExpenseGroup.ShowDialog();
        }

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPayments_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("User Access", btnPayments);
        }

        private void btnCustomer_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("All Invoices Receipts", btnCustomer);
        }
    }
}
