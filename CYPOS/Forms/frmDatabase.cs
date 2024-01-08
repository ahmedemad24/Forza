using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmDatabase : Form
    {
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

        public frmDatabase()
        {
            InitializeComponent();
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

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = Messages.QuestionMessage("Do you want to reset database?");

                if (result == true)
                {
                    bool isChecked = false;
                    foreach (var control in grpMasters.Controls) 
                    {
                        if (control is CheckBox)
                        {
                            if (((CheckBox)control).Checked)
                            {
                                isChecked = true;
                            }
                        }
                    }

                    foreach (var control in grpTransaction.Controls)
                    {
                        if (control is CheckBox)
                        {
                            if (((CheckBox)control).Checked)
                            {
                                isChecked = true;
                            }
                        }
                    }

                    if (!isChecked)
                    {
                        Messages.InformationMessage("Nothing selected!");
                    }
                    else
                    {
                        if (cbxItem.Checked)
                        {
                            string strSQL = " DELETE tbl_Item; DBCC CHECKIDENT ('tbl_Item', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxCategory.Checked)
                        {
                            string strSQL = " DELETE tbl_Category; DBCC CHECKIDENT ('tbl_Category', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxTables.Checked)
                        {
                            string strSQL = " DELETE tbl_Tables; DBCC CHECKIDENT ('tbl_Tables', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxTableLocation.Checked)
                        {
                            string strSQL = " DELETE tbl_TableLocation; DBCC CHECKIDENT ('tbl_TableLocation', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxSuppliers.Checked)
                        {
                            string strSQL = " DELETE tbl_Supplier; DBCC CHECKIDENT ('tbl_Supplier', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxCustomers.Checked)
                        {
                            string strSQL = " DELETE tbl_Customer; DBCC CHECKIDENT ('tbl_Customer', RESEED,1);" +
                                "\n DELETE tbl_CarCutomer; DBCC CHECKIDENT ('tbl_CarCutomer', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }
                        if (cbxRegions.Checked)
                        {
                            string strSQL = " DELETE tbl_region; DBCC CHECKIDENT ('tbl_region', RESEED,1);";
                            DataTable datTble = DataAccess.GetDataTable(strSQL);
                        }
                        
                        if (cbxPendingOrders.Checked)
                        {
                            string strSQL = " DELETE Notification_TempDetail; DBCC CHECKIDENT ('Notification_TempDetail', RESEED,1);" +
                                "\n DELETE Notification_TempHeader; DBCC CHECKIDENT ('Notification_TempHeader', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }
                        if (cbxShifts.Checked)
                        {
                            string strSQL = " DELETE tbl_UserShifts; "+
                                "\n DELETE tbl_InvoiceNo; " +
                                "\n DBCC CHECKIDENT ('tbl_InvoiceNo', RESEED," + Settings.StartingInvoiceNo.ToString() + ")";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxInvoices.Checked)
                        {
                            string strSQL = "DELETE tbl_InvoiceHeader; " +
                                            "DELETE tbl_InvoiceDetail; " +
                                            //"DELETE tbl_InvoiceNo; " +
                                            "DELETE tbl_TempHeader; " +
                                            "DELETE tbl_TempDetail; " +
                                            "DELETE tbl_KotNo; " +
                                            "DELETE tbl_HoldNo; ";

                            DataTable dtTable = DataAccess.GetDataTable(strSQL);


                            //Update Starting Invoice Numbers / Auto Index (Identity)
                            //string strSQLInvoiceNo = "DBCC CHECKIDENT ('tbl_InvoiceNo', RESEED," + autoInvoiceNo.ToString() + ")";
                            //DataAccess.ExecuteSQL(strSQLInvoiceNo);

                            //Update Starting Kot Numbers / Auto Index (Identity)
                            int autoKotNo = Settings.StartingKotNo;
                            string strSQLKotNo = "DBCC CHECKIDENT ('tbl_KotNo', RESEED," + autoKotNo.ToString() + ")";
                            DataAccess.ExecuteSQL(strSQLKotNo);

                            //Update Starting Auto Index (Identity)
                            int autoHoldId = Settings.StartingKotNo;
                            string strSQLHold = "DBCC CHECKIDENT ('tbl_HoldNo', RESEED,1)";
                            DataAccess.ExecuteSQL(strSQLHold);
                        }
                        
                        if (cbxDeliveryMen.Checked)
                        {
                            string strSQL = " DELETE tbl_DeliveryMan; DBCC CHECKIDENT ('tbl_DeliveryMan', RESEED,1);";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }
                        if (cbxPurchases.Checked)
                        {
                            string strSQL = " DELETE tbl_Purchase; DBCC CHECKIDENT ('tbl_Purchase', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }

                        if (cbxExpenses.Checked)
                        {
                            string strSQL = "DELETE tbl_Expense; DBCC CHECKIDENT ('tbl_Expense', RESEED,1)";
                            DataTable dtTable = DataAccess.GetDataTable(strSQL);
                        }
                        //Messages.InformationMessage("Successfully truncated");
                        OpenedForms.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }   
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDatabase_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserType != "Admin")
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
        }

        private void cbxCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCategory.Checked)
                cbxItem.Checked = true;
        }

        private void cbxTableLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTableLocation.Checked)
                cbxTables.Checked = true;
        }

        private void cbxRegions_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRegions.Checked)
                cbxCustomers.Checked = true;
        }

        private void cbxDeliveryMen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDeliveryMen.Checked)
                cbxInvoices.Checked = true;
        }
    }
}
