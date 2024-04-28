using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using cypos.Reports;
using DevExpress.XtraReports.UI;
using static System.Net.WebRequestMethods;

namespace cypos
{
    public partial class frmRecallInvoices : Form
    {
        private frmMain _frmMain;
        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1;
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
        private int customerID;
        public frmRecallInvoices(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
            dgvItems.AutoGenerateColumns = false;

            //Grids Fonts
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvItems.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvItems.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);

            var orderTypes = Company.OrderTypes;
            if (orderTypes.FirstOrDefault(a => a.Id == 1) != null)
            {
                tabPage1.Text = UserInfo.IsArabicLangSelected ? orderTypes.FirstOrDefault(a => a.Id == 1).LabelAr : orderTypes.FirstOrDefault(a => a.Id == 1).LabelEn;
                tabPage1.Tag = 1;
            }
            else
            {
                tabPage1.Hide();
                tbMain.TabPages.Remove(tabPage1);
                //floDineIn.Visible = false;
            }
            if (orderTypes.FirstOrDefault(a => a.Id == 2) != null)
                tabPage2.Text = UserInfo.IsArabicLangSelected ? orderTypes.FirstOrDefault(a => a.Id == 2).LabelAr : orderTypes.FirstOrDefault(a => a.Id == 1).LabelEn;
            if (orderTypes.FirstOrDefault(a => a.Id == 3) != null)
                tabPage3.Text = UserInfo.IsArabicLangSelected ? orderTypes.FirstOrDefault(a => a.Id == 3).LabelAr : orderTypes.FirstOrDefault(a => a.Id == 1).LabelEn;
            if (orderTypes.FirstOrDefault(a => a.Id == 4) != null)
                tabPage4.Text = UserInfo.IsArabicLangSelected ? orderTypes.FirstOrDefault(a => a.Id == 4).LabelAr : orderTypes.FirstOrDefault(a => a.Id == 1).LabelEn;

            LoadOrderList(int.Parse(tbMain.SelectedTab.Name.Replace("tabPage", "")));

            lblOrderType.Text = "";
            lblTable.Text = "";
            lblGuests.Text = "";
            lblTotal.Text = "0.00";
            btnPrintKot.Enabled = false;
            btnRecall.Enabled = false;
            rejectBtn.Visible = false;

            if (UserInfo.IsVaild(6))
            {
                PrntOnlyBtn.Visible = true;
            }
            else
            {
                PrntOnlyBtn.Visible = false;
            }
            if (UserInfo.IsVaild(7))
            {
                btnPrintKot.Visible = true;
            }
            else
            {
                btnPrintKot.Visible = false;
            }
            if (UserInfo.IsVaild(8))
            {
                btnRecall.Visible = true;
            }
            else
            {
                btnRecall.Visible = false;
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

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab.Name.Replace("tabPage", "") == "1")//Dine In
            {
                floDineIn.Controls.Clear();
                LoadOrderList(1);
                btnPrintKot.Visible = true;
                PrntOnlyBtn.Visible = true;
                filterByUser.Visible = true;
                rejectBtn.Visible = false;
            }
            else if (((TabControl)sender).SelectedTab.Name.Replace("tabPage", "") == "2")//Take Away
            {
                floTakeAway.Controls.Clear();
                LoadOrderList(2);
                btnPrintKot.Visible = true;
                PrntOnlyBtn.Visible = true;
                filterByUser.Visible = true;
                rejectBtn.Visible = false;
            }
            else if (((TabControl)sender).SelectedTab.Name.Replace("tabPage", "") == "3")//Delivery Order
            {
                floDeliveryOrder.Controls.Clear();
                LoadOrderList(3);
                btnPrintKot.Visible = true;
                PrntOnlyBtn.Visible = true;
                filterByUser.Visible = true;
                rejectBtn.Visible = false;
            }
            else if (((TabControl)sender).SelectedTab.Name.Replace("tabPage", "") == "4")//Pickup order
            {
                floPickupOrder.Controls.Clear();
                LoadOrderList(4);
                btnPrintKot.Visible = true;
                PrntOnlyBtn.Visible = true;
                filterByUser.Visible = true;
                rejectBtn.Visible = false;
            }
            else if (((TabControl)sender).SelectedTab == tabPage5)
            {
                btnPrintKot.Visible = false;
                PrntOnlyBtn.Visible = false;
                filterByUser.Visible = false;
                rejectBtn.Visible = true;
                rejectBtn.Enabled = false;
                flowLayoutPanel1.Controls.Clear();
                LoadNotificationOrderList();
            }

            lblOrderType.Text = "";
            lblTable.Text = "";
            lblGuests.Text ="";
            lblWaiterName.Text = "";
            lblTotal.Text = "";
            lblDate.Text = "";
            lblTime.Text = "";
            lblUser.Text = "";
            lblKotNo.Text = "0";
            lblHoldId.Text = "0";
            lblOrderTypeId.Text = "0";
            lblTableId.Text = "0";
            lblWaiterId.Text = "0";

            dgvItems.DataSource = null;
        }

        public void LoadOrderList(int orderType=1)
        {
            string filter= "";
            if (this.filterByUser.Checked)
            {
                filter = " tbl_TempHeader.user_name='" + UserInfo.UserName + "' and";
            }

            try
            {
                string strSQL = "SELECT tbl_TempHeader.id, tbl_TempHeader.invoice_date," +
                               "tbl_TempHeader.order_type, tbl_TempHeader.table_id, tbl_TempHeader.no_of_guests," +
                               "tbl_TempHeader.waiter_id, tbl_TempHeader.customer_id, tbl_TempHeader.payment_type," +
                               "tbl_TempHeader.payment_amount, tbl_TempHeader.change_amount,tbl_TempHeader.due_amount," +
                               "tbl_TempHeader.discount_rate, tbl_TempHeader.discount_amount, tbl_TempHeader.tax1_name," +
                               "tbl_TempHeader.tax1_rate,tbl_TempHeader.tax1_amount, tbl_TempHeader.tax2_name," +
                               "tbl_TempHeader.tax2_rate, tbl_TempHeader.tax2_amount, tbl_TempHeader.note," +
                               "tbl_TempHeader.user_name,tbl_TempHeader.status, tbl_TempHeader.log_date,tbl_Tables.table_name,tbl_User.name AS waiter_name," +
                               "CASE WHEN tbl_TempHeader.customer_id = 0 THEN 'Cash' ELSE tbl_Customer.name END AS customer_name " +
                               "FROM tbl_TempHeader LEFT JOIN tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id " +
                               "LEFT JOIN tbl_Customer ON tbl_TempHeader.customer_id = tbl_Customer.id " +
                               "LEFT JOIN tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id " +
                               "WHERE "+filter+" order_type='" + orderType + "' ORDER BY tbl_TempHeader.table_id";

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];
                    Button btnInvoice = new Button();
                    btnInvoice.FlatStyle = FlatStyle.Flat;
                    btnInvoice.FlatAppearance.BorderSize = 1;
                    btnInvoice.FlatAppearance.BorderColor = Color.Gray;
                    string strStatus = dt.Rows[i]["status"].ToString();
                    if (strStatus == "Done")
                    {
                        btnInvoice.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        btnInvoice.BackColor = Color.Orange;
                    }

                    btnInvoice.Tag = dataReader["id"];
                    btnInvoice.Click += new EventHandler(btnInvoice_Click);

                    btnInvoice.Name = dataReader["id"].ToString();

                    btnInvoice.Margin = new Padding(3, 3, 3, 3);

                    btnInvoice.Size = new Size(150, 55);

                    btnInvoice.Text = "Hold Id: " + dataReader["id"] + "\n";
                    if (orderType != 1)
                    {
                        btnInvoice.Text += "Customer: " + dataReader["customer_name"]  + "\n";
                        btnInvoice.Text += "Amount: " + dataReader["payment_amount"].ToString();
                    }
                    else
                    {
                        btnInvoice.Text += "Table #: " + dataReader["table_name"] + " (" + dataReader["no_of_guests"] + ")" + "\n";
                        btnInvoice.Text += "Waiter: " + dataReader["waiter_name"].ToString();
                    }
                    btnInvoice.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnInvoice.TextAlign = ContentAlignment.TopLeft;
                    btnInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
                    if (orderType == 1)
                    {
                        floDineIn.Controls.Add(btnInvoice);
                        if(tbMain.SelectedTab != tabPage1)
                            tbMain.SelectedTab = tabPage1;
                    }
                    else if (orderType == 2)
                    {
                        floTakeAway.Controls.Add(btnInvoice);
                        if (tbMain.SelectedTab != tabPage2)
                            tbMain.SelectedTab = tabPage2;
                    }
                    else if (orderType == 3)
                    {
                        floDeliveryOrder.Controls.Add(btnInvoice);
                        if (tbMain.SelectedTab != tabPage3)
                            tbMain.SelectedTab = tabPage3;
                    }
                    else if (orderType == 4)
                    {
                        floPickupOrder.Controls.Add(btnInvoice);
                        if (tbMain.SelectedTab != tabPage4)
                            tbMain.SelectedTab = tabPage4;
                    }
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        public void LoadNotificationOrderList()
        {
            string filter = "";
            if (this.filterByUser.Checked)
            {
                filter = "Where th.user_name='" + UserInfo.UserName + "'";
            }

            try
            {
                string selectNotificationQuery = $@"select DISTINCT th.*, c.name customer_name, u.user_name waiter_name, t.table_NO from Notification_TempHeader th
	                                                left join Notification_TempDetail td on td.header_id = th.id
	                                                LEFT JOIN tbl_Tables t ON th.table_id = t.id
	                                                LEFT JOIN tbl_Customer c ON th.customer_id = c.id
	                                                LEFT JOIN tbl_User u ON th.waiter_id = u.id 
                                                    WHERE approved = 0";

                DataTable data = DataAccess.GetDataTable(selectNotificationQuery);

                int currentImage = 0;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dataReader = data.Rows[i];
                    Button btnInvoice = new Button();
                    btnInvoice.FlatStyle = FlatStyle.Flat;
                    btnInvoice.FlatAppearance.BorderSize = 1;
                    btnInvoice.FlatAppearance.BorderColor = Color.Gray;
                    string strStatus = data.Rows[i]["status"].ToString();
                    if (strStatus == "Done")
                    {
                        btnInvoice.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        btnInvoice.BackColor = Color.Orange;
                    }

                    btnInvoice.Tag = dataReader["id"];
                    btnInvoice.Click += new EventHandler(btnNotificationInvoice_Click);

                    btnInvoice.Name = dataReader["id"].ToString();

                    btnInvoice.Margin = new Padding(3, 3, 3, 3);

                    btnInvoice.Size = new Size(150, 55);

                    btnInvoice.Text = "Hold Id: " + dataReader["id"] + "\n";

                    int orderType = int.Parse(data.Rows[i]["order_type"].ToString());
                    int customerId = int.Parse(data.Rows[i]["customer_id"].ToString());

                    if (orderType != 1)
                    {
                        if (customerId > 0)
                        {
                            string customerName = data.Rows[i]["customer_name"].ToString();
                            btnInvoice.Text += "Customer: " + customerName + "\n";
                            btnInvoice.Text += "Amount: " + dataReader["payment_amount"].ToString() + "\n";
                        }
                        else
                        {
                            btnInvoice.Text += "Table #: " + dataReader["table_NO"] + " (" + dataReader["no_of_guests"] + ")" + "\n";
                            btnInvoice.Text += "Waiter: " + dataReader["waiter_name"].ToString() + "\n";
                        }
                    }
                    else
                    {
                        btnInvoice.Text += "Table #: " + dataReader["table_NO"] + " (" + dataReader["no_of_guests"] + ")" + "\n";
                        btnInvoice.Text += "Waiter: " + dataReader["waiter_name"].ToString();
                    }

                    btnInvoice.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnInvoice.TextAlign = ContentAlignment.TopLeft;
                    btnInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;

                    flowLayoutPanel1.Controls.Add(btnInvoice);
                    currentImage++;
                }
            }
            catch(Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            Button btnInvoice = sender as Button;

            string strSQL = $@"SELECT tbl_TempHeader.id, tbl_TempHeader.invoice_date,tbl_TempHeader.invoice_time,{(UserInfo.IsArabicLangSelected? "Type.LabelAr" : "Type.LabelEn")} OrdertypeLabel, tbl_TempHeader.order_type,
                            tbl_TempHeader.table_id,tbl_Tables.table_name, tbl_TempHeader.no_of_guests,tbl_TempHeader.waiter_id,
                            tbl_User.name AS waiter_name,tbl_TempHeader.user_name,tbl_TempHeader.payment_amount,tbl_TempDetail.item_code,
                            tbl_TempDetail.item_name, tbl_TempDetail.qty,tbl_TempDetail.total,tbl_TempDetail.show_kitchen,tbl_TempDetail.print_kot,
                            tbl_TempDetail.kot_qty FROM tbl_TempDetail INNER JOIN tbl_TempHeader ON tbl_TempDetail.header_id = tbl_TempHeader.id 
                            LEFT JOIN tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id 
                            LEFT JOIN tbl_OrderTypes TYPE ON TYPE.company_type_id={(int)Company.CompanyType} and type.Id = tbl_TempHeader.order_type
                            LEFT JOIN tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id 
                            WHERE tbl_TempHeader.id='" + btnInvoice.Tag.ToString() + "'";

            DataAccess.ExecuteSQL(strSQL);
            DataTable dt = DataAccess.GetDataTable(strSQL);

            dgvItems.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                lblHoldId.Text = dr["id"].ToString();
                int iOrderType = int.Parse(dr["order_type"].ToString());
                string strOrderType=string.Empty;
                strOrderType = dr["OrdertypeLabel"].ToString();
                
                lblOrderTypeId.Text = dr["order_type"].ToString();
                lblOrderType.Text = strOrderType.ToString();
                lblTableId.Text = dr["table_id"].ToString();
                lblTable.Text = dr["table_name"].ToString();
                lblGuests.Text = dr["no_of_guests"].ToString();
                lblWaiterId.Text = dr["waiter_id"].ToString();
                lblWaiterName.Text = dr["waiter_name"].ToString();

                lblDate.Text = dr["invoice_date"].ToString();
                lblTime.Text = dr["invoice_time"].ToString();
                lblUser.Text = dr["user_name"].ToString();

                decimal decTotal = decimal.Parse(dr["payment_amount"].ToString());
                lblTotal.Text = decTotal.ToString("N2");
                btnRecall.Enabled = true;
                rejectBtn.Enabled = true;
                btnPrintKot.Enabled = true;
            }
        }

        protected void btnNotificationInvoice_Click(object sender, EventArgs e)
        {
            Button btnInvoice = sender as Button;
            int headerID = int.Parse(btnInvoice.Tag.ToString());

            string selectNotificationQuery = $@"select td.*, td.id detail_id, th.id Nheader_id,{(UserInfo.IsArabicLangSelected ? "Type.LabelAr" : "Type.LabelEn")} OrdertypeLabel,  th.order_type, t.id table_id, t.table_NO, t.table_name 
                                                , th.no_of_guests, th.waiter_id, u.name waiter_name, u.user_name, th.customer_id, th.payment_amount    
                                                from Notification_TempDetail td
	                                            join Notification_TempHeader th on td.header_id = th.id
                                                LEFT JOIN tbl_OrderTypes TYPE ON TYPE.company_type_id ={(int)Company.CompanyType}
                                                    and type.Id = th.order_type
                                                LEFT JOIN tbl_Tables t ON th.table_id = t.id
	                                            LEFT JOIN tbl_Customer c ON th.customer_id = c.id
	                                            LEFT JOIN tbl_User u ON th.waiter_id = u.id 
                                                WHERE th.id = {headerID}";
            DataTable dt = DataAccess.GetDataTable(selectNotificationQuery);

            dgvItems.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                lblHoldId.Text = dr["Nheader_id"].ToString();
                string strOrderType=string.Empty;
                strOrderType = dr["OrdertypeLabel"].ToString();
                
                lblOrderTypeId.Text = dr["order_type"].ToString();
                lblOrderType.Text = strOrderType.ToString();
                lblTableId.Text = dr["table_id"].ToString();
                lblTable.Text = dr["table_name"].ToString();
                lblGuests.Text = dr["no_of_guests"].ToString();
                lblWaiterId.Text = dr["waiter_id"].ToString();
                lblWaiterName.Text = dr["waiter_name"].ToString();
                customerID = int.Parse(dr["customer_id"].ToString());

                lblDate.Text = dr["invoice_date"].ToString();
                lblTime.Text = dr["invoice_time"].ToString();
                lblUser.Text = dr["user_name"].ToString();

                decimal decTotal = decimal.Parse(dr["payment_amount"].ToString());
                lblTotal.Text = decTotal.ToString("N2");
            }
                btnRecall.Enabled = true;
            rejectBtn.Enabled = true;

        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbMain.SelectedIndex == 4)
                {
                    _frmMain.isNotificationOrder = true;
                }
                else
                {
                    _frmMain.isNotificationOrder = false;
                }
                _frmMain.RecallInvoice(lblHoldId.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnPrintKot_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        #region KOT

        private void NextKotNumber()
        {
            int inNextAutoNo;
            int inStartNo;
            int inLastAutoNo;
            string strNextAutoNo;
            string strNextKotNo;

            inStartNo = Settings.StartingKotNo;
            inLastAutoNo = Settings.LastKotAutoNo;

            if (inLastAutoNo == 0)//First Use
            {
                inNextAutoNo = inStartNo;
            }
            else
            {
                inNextAutoNo = inLastAutoNo + 1;
            }
            if (Settings.KotLeadingZeros)
            {
                strNextAutoNo = inNextAutoNo.ToString().PadLeft(Settings.KotZerosCount, '0');
            }
            else
            {
                strNextAutoNo = inNextAutoNo.ToString();
            }
            strNextKotNo = Settings.KotNoPrefix + strNextAutoNo;
            lblKotNo.Text = strNextKotNo;
        }


        #endregion

        private void filterByUser_CheckedChanged(object sender, EventArgs e)
        {
            if (tbMain.SelectedIndex == 0)//Dine In
            {
                floDineIn.Controls.Clear();
                LoadOrderList(1);
            }
            else if (tbMain.SelectedIndex == 1)//Take Away
            {
                floTakeAway.Controls.Clear();
                LoadOrderList(2);
            }
            else if (tbMain.SelectedIndex == 2)//Delivery Order
            {
                floDeliveryOrder.Controls.Clear();
                LoadOrderList(3);
            }
            else if (tbMain.SelectedIndex == 3)//Pickup order
            {
                floPickupOrder.Controls.Clear();
                LoadOrderList(4);
            }
            else if (tbMain.SelectedIndex == 4)//Pinding Orders
            {
                tabPage5.Controls.Clear();
                LoadNotificationOrderList();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrntOnlyBtn_Click(object sender, EventArgs e)
        {
            string[] holdId = { lblHoldId.Text.ToString() };
            rprtInvoiceReceipt rprt = new rprtInvoiceReceipt(string.Join(",", holdId));
            ReportPrintTool printTool = new ReportPrintTool(rprt);
            printTool.ShowPreview();
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            var warningMsg = MessageBox.Show("Are you sure to reject this header?", "Warning", MessageBoxButtons.OKCancel
                 , MessageBoxIcon.Warning);
            if (warningMsg == DialogResult.OK)
            {
                int id = int.Parse(lblHoldId.Text.ToString());
                int tableId = int.Parse(lblTableId.Text.ToString());
                int customer_id = customerID;
                string sqlQuery;

                if (customer_id > 0)
                {
                    string selectHeaderIdByCustomerId = $@"SELECT * FROM tbl_TempHeader WHERE customer_id = {customer_id} SELECT SCOPE_IDENTITY()";
                    int headerID = DataAccess.ExecuteScalarSQL(selectHeaderIdByCustomerId);

                    sqlQuery = $@"DELETE FROM tbl_TempDetail WHERE header_id = {headerID}";
                    DataAccess.ExecuteSQL(sqlQuery);

                    sqlQuery = $@"DELETE FROM tbl_TempHeader WHERE id = {headerID}";
                    DataAccess.ExecuteSQL(sqlQuery);

                    sqlQuery = $@"DELETE FROM Notification_TempDetail WHERE header_id = {id}";
                    DataAccess.ExecuteSQL(sqlQuery);

                    sqlQuery = $@"DELETE FROM Notification_TempHeader WHERE id = {id}";
                    DataAccess.ExecuteSQL(sqlQuery);
                }
                else
                {
                    string selectHeaderIdByCustomerId = $@"SELECT * FROM tbl_TempHeader WHERE table_id = {tableId} SELECT SCOPE_IDENTITY()";
                    int headerID = DataAccess.ExecuteScalarSQL(selectHeaderIdByCustomerId);

                    sqlQuery = $@"DELETE FROM tbl_TempDetail WHERE header_id = {headerID}";
                    DataAccess.ExecuteSQL(sqlQuery);

                    sqlQuery = $@"DELETE FROM tbl_TempHeader WHERE id = {headerID}";
                    DataAccess.ExecuteSQL(sqlQuery);

                    sqlQuery = $@"DELETE FROM Notification_TempDetail WHERE header_id = {id}";
                    DataAccess.ExecuteSQL(sqlQuery);

                    sqlQuery = $@"DELETE FROM Notification_TempHeader WHERE id = {id}";
                    DataAccess.ExecuteSQL(sqlQuery);
                }
                Messages.InformationMessage("Header Rejected Successfully");
            }
        }
    }
}
