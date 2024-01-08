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
    public partial class frmCommentPopup : Form
    {
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
        public frmCommentPopup()
        {
            InitializeComponent();
        }
        frmMain _frmMain = new frmMain();
        public frmCommentPopup(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void frmCommentPopup_Load(object sender, EventArgs e)
        {
            ShowComment(_frmMain.selectedItem, _frmMain.tempHeaderId);
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }

        private void AddBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Comment", AddBtn);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string comment = commentTextBox.Text;
                string selectedItem = _frmMain.selectedItem;
                int tempHeaderID = _frmMain.tempHeaderId;

                if (tempHeaderID > 0)
                {
                    string sqlQuery = $"UPDATE tbl_TempDetail SET comment = (N'{comment}') WHERE item_code = '{selectedItem}' AND header_id = {tempHeaderID} ";
                    DataAccess.ExecuteSQL(sqlQuery);
                }

                _frmMain.dgvItemList.CurrentRow.Cells["Comment_Value"].Value = commentTextBox.Text; 
                MessageBox.Show("Comment Added Successfully!");
                this.Close();
            }
            catch(Exception){}
        }
            
        private void ShowComment(string itemCode, int tempHeaderID)
        {
            if (tempHeaderID > 0)
            {
                string query = "SELECT TOP 1 comment FROM tbl_TempDetail WHERE item_code = '" + itemCode + "' AND header_id = "+ tempHeaderID +" ORDER BY detail_id DESC";
                DataAccess.ExecuteSQL(query);
                DataTable dt = DataAccess.GetDataTable(query);
                if (dt.Rows.Count > 0)
                    commentTextBox.Text = dt.Rows[0]["comment"].ToString();
            }
            else
            {
                if (_frmMain.dgvItemList.CurrentRow.Cells["Comment_Value"].Value == null)
                {
                    _frmMain.dgvItemList.CurrentRow.Cells["Comment_Value"].Value = " ";
                }
                commentTextBox.Text = _frmMain.dgvItemList.CurrentRow.Cells["Comment_Value"].Value.ToString();
            }
        }
    }
}
