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

namespace cypos.Forms
{
    public partial class frmTransferTablePopup : Form
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
        readonly frmTransferPopup _transferPopup;

        public frmTransferTablePopup()
        {
            InitializeComponent();
        }

        public frmTransferTablePopup(int headerID, int tableID, frmTransferPopup transferPopup)
        {
            InitializeComponent();
            _headerID = headerID;
            _tableID = tableID;
            _transferPopup = transferPopup;
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
                         + "CASE WHEN tbl_TempHeader.table_id > 0 THEN 1 ELSE 0 END = 0\r\n " 
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

        private void saveTable()
        {
            try
            {
                int id = int.Parse(openedTablesCbx.SelectedValue.ToString());
                if (id != 0)
                {
                    string query = $"UPDATE tbl_TempHeader SET table_id = {id} WHERE id = {_headerID} AND table_id = {_tableID}; " +
                                   $"UPDATE Notification_TempHeader SET table_id = {id} WHERE table_id = {_tableID};";
                    DataAccess.ExecuteSQL(query);
                    MessageBox.Show("Saved Successfully");
                    _transferPopup.Transfered = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Tables found !");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveTable();
        }

        private void openedTablesCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveTable();
        }
    }
}
