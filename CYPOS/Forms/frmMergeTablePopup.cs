using cypos.Reports;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;

namespace cypos.Forms
{
    public partial class frmMergeTablePopup : Form
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

        frmMain _frmMain = new frmMain();
        int _headerID;
        int _tableID;

        public frmMergeTablePopup()
        {
            InitializeComponent();
        }

        public frmMergeTablePopup(int headerID ,int tableID)
        {
            InitializeComponent();
            _headerID = headerID;
            _tableID = tableID;
        }

        public frmMergeTablePopup(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Close", pbxClose);
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

        private void loadFreeTables()
        {
            int table_id = _frmMain.tableeId;
            string query = "SELECT DISTINCT\r\n " 
                         + "CASE WHEN tbl_TempHeader.table_id > 0 THEN 1 ELSE 0 END AS locked,\r\n " 
                         + "tbl_Tables.id,\r\n " 
                         + "tbl_Tables.table_name,\r\n " 
                         + "ISNULL(tbl_TempHeader.no_of_guests, 0) AS guest_count\r\n " 
                         + "FROM\r\n " 
                         + "tbl_Tables\r\n " 
                         + "LEFT JOIN\r\n " 
                         + "tbl_TempHeader ON tbl_Tables.id = tbl_TempHeader.table_id " 
                         + "\r\nWHERE\r\n " 
                         + $"CASE WHEN tbl_TempHeader.table_id > 0 THEN 1 ELSE 0 END = 1\r\n AND table_id <> {table_id} "
                         + "ORDER BY\r\n " 
                         + "tbl_Tables.table_name;";

            DataTable dt = DataAccess.GetDataTable(query);
            DataRow dataRow = dt.NewRow();
            dataRow["id"] = 0;
            dataRow["table_name"] = "--Select Table--";
            dt.Rows.InsertAt(dataRow, 0);
            openedTablesCbx.DataSource = dt;
            openedTablesCbx.DisplayMember = "table_name";
            openedTablesCbx.ValueMember = "id"; 
            openedTablesCbx.SelectedIndexChanged += new System.EventHandler(this.openedTablesCbx_SelectedIndexChanged);
        }

        private void frmTransferTablePopup_Load(object sender, EventArgs e)
        {
            loadFreeTables();
        }

        private void MergeTables()
        {
            try
            {
                if (openedTablesCbx.SelectedIndex > 0)
                {
                    int after_merging_table_id = int.Parse(openedTablesCbx.SelectedValue.ToString());
                    string selectQuery = $@"SELECT TOP 1 details.header_id from tbl_TempDetail details
                                    join tbl_TempHeader header on details.header_id = header.id
                                    WHERE header.table_id = {after_merging_table_id}";
                    int after_merging_table_headerId = DataAccess.ExecuteScalarSQL(selectQuery);
                    int before_merging_table_headerId = _frmMain.tempHeaderId;

                    string selectItemsQueryBefore = $@"SELECT item_name, kot_qty, * FROM tbl_TempDetail WHERE header_id = {before_merging_table_headerId}";
                    DataTable dataTableBeforeMerge = DataAccess.GetDataTable(selectItemsQueryBefore);
                    List<string> itemCodesList = new List<string>();
                    if (dataTableBeforeMerge.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTableBeforeMerge.Rows.Count; i++)
                        {
                            string before_merge_item_code = dataTableBeforeMerge.Rows[i]["item_code"].ToString();
                            double before_merge_kot_qty = Convert.ToDouble(dataTableBeforeMerge.Rows[i]["kot_qty"].ToString());

                            if (before_merge_kot_qty > 1)
                            {
                                for (int j = 0; j < before_merge_kot_qty; j++)
                                {
                                    itemCodesList.Add(before_merge_item_code);
                                }
                            }
                            else
                            {
                                itemCodesList.Add(before_merge_item_code);
                            }
                        }
                    }

                    string selectItemsQueryAfter = $@"SELECT item_name, kot_qty, * FROM tbl_TempDetail WHERE header_id = {after_merging_table_headerId}";
                    DataTable dataTableAfterMerge = DataAccess.GetDataTable(selectItemsQueryAfter);

                    if (dataTableAfterMerge.Rows.Count > 0)
                    {
                        foreach (string itemCode in itemCodesList)
                        {
                                string query = $@"IF EXISTS(
                                                    SELECT * FROM tbl_TempDetail details
                                                    WHERE item_code='{itemCode}' AND header_id = {after_merging_table_headerId})
                                                    BEGIN
                                                      UPDATE tbl_TempDetail SET header_id = details.header_id, qty = (details.qty + 1)
	                                                    , kot_qty = (details.kot_qty + 1), log_date = details.log_date
	                                                    , last_qty = (details.last_qty + 1) FROM tbl_TempDetail details
	                                                    WHERE item_code='{itemCode}' AND header_id = {after_merging_table_headerId};
	                                                    IF EXISTS(
			                                                    SELECT * FROM tbl_TempDetail details WHERE item_code = '{itemCode}' 
                                                                AND kot_qty > 1 AND header_id = {before_merging_table_headerId}
		                                                    )
	                                                    BEGIN
	                                                      UPDATE tbl_TempDetail SET header_id = details.header_id, qty= (details.qty -1)
                                                            , kot_qty= (details.kot_qty - 1), log_date=GETDATE() 
                                                            , last_qty= (details.last_qty - 1) FROM tbl_TempDetail details 
                                                            WHERE item_code='{itemCode}' AND header_id = {before_merging_table_headerId}
	                                                    END
	                                                    ELSE
	                                                    BEGIN
		                                                    DELETE FROM tbl_TempDetail WHERE header_id = {before_merging_table_headerId} AND item_code = '{itemCode}'
	                                                    END
                                                    END 
                                                    ELSE 
                                                    BEGIN 
	                                                    IF EXISTS(
			                                                    SELECT * FROM tbl_TempDetail details WHERE item_code = '{itemCode}' AND kot_qty > 1 AND header_id = {before_merging_table_headerId}
		                                                    )
	                                                    BEGIN
	                                                        INSERT INTO tbl_TempDetail (header_id, item_code, item_name, qty, selling_price, total, discount, discount_amount
										                                                    , net_amount, profit, tax_apply, show_kitchen, print_kot, kot_qty, log_date, comment, last_qty)
		                                                    SELECT {after_merging_table_headerId}, item_code, item_name, 1, selling_price, selling_price, discount, discount_amount, net_amount, profit, tax_apply
						                                                    , show_kitchen, print_kot, 1, log_date, comment + ' ...Transfered', 1 
		                                                    FROM tbl_TempDetail
		                                                    WHERE header_id = {before_merging_table_headerId} AND item_code = '{itemCode}';
	                                                      UPDATE tbl_TempDetail SET header_id = details.header_id, qty= (details.qty - 1)
                                                            , kot_qty= (details.kot_qty - 1), log_date = GETDATE() 
                                                            , last_qty= (details.last_qty - 1) FROM tbl_TempDetail details 
                                                            WHERE item_code='{itemCode}' AND header_id = {before_merging_table_headerId};
	                                                    END
	                                                    ELSE
	                                                    BEGIN
		                                                    UPDATE tbl_TempDetail SET header_id = {after_merging_table_headerId} WHERE header_id = {before_merging_table_headerId} AND item_code = '{itemCode}'
	                                                    END
                                                    END";
                                DataAccess.ExecuteSQL(query);
                        }
                        MessageBox.Show("Successfully Megred");
                        string deleteQuery = $"DELETE FROM tbl_TempHeader WHERE id = {before_merging_table_headerId}";
                        DataAccess.ExecuteSQL(deleteQuery);
                        
                        _frmMain.updateNotificationHeaderAndDetails(after_merging_table_id);
                        _frmMain.RecallInvoice(after_merging_table_headerId.ToString());
                        itemCodesList.Clear();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You should select a table First!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openedTablesCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            MergeTables();
        }
    }
}
