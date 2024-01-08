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

namespace cypos
{
    public partial class frmAddRegion : Form
    {
        private frmCustomerPopup _frmCustomerPopup;

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
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public frmAddRegion(frmCustomerPopup _frm)
        {
            InitializeComponent();
            _frmCustomerPopup = _frm;

            dgvRegions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvRegions.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvRegions.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            if (UserInfo.IsVaild(31))
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
            if (UserInfo.IsVaild(32))
            {
                EditBtn.Visible = true;
            }
            else
            {
                EditBtn.Visible = false;
            }
            if (UserInfo.IsVaild(33))
            {
                DeleteBtn.Visible = true;
            }
            else
            {
                DeleteBtn.Visible = false;
            }
        }

        public void RegionGridFill()
        {
            dgvRegions.AutoGenerateColumns = false;
            string strSQL = "SELECT * FROM tbl_region WHERE IsDeleted = 0";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtRegion = DataAccess.GetDataTable(strSQL);
            dgvRegions.DataSource = dtRegion;
        }

        public void Clear()
        {
            txtName.Clear();
            amount.Value = 0;
        }

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RegionGridFill();
            Clear();
        }

        private void btnCustomerUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvRegions;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnCustomerDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvRegions;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
                if (RowIsVisible(selectedRow))
                {
                    dgv.FirstDisplayedScrollingRowIndex = selectedRow.Index + 1;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text.Trim() != "")
            {
                string strSQLInsert = "INSERT INTO tbl_Region (RegionName,ServiceAmount)  VALUES ('" + txtName.Text + "', '" + amount.Value + "')";
                DataAccess.ExecuteSQL(strSQLInsert);
                Messages.InformationMessage("Region Added Successfully");
                RegionGridFill();
                Clear();
            }
            else
            {
                Messages.ErrorMessage("You should Enter a Valid Region Name Or Amount");
            }
            
        }

        private void frmAddRegion_Load(object sender, EventArgs e)
        {
            RegionGridFill();
            Clear();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Region", button1);
        }

        private void btnKbCusName_Click(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var id = int.Parse(testID.Text);
            var amountValue = amount.Value.ToString();
            if (txtName.Text != "" && amount.Value.ToString() != "")
            {
                string strSQLUpdate = $"UPDATE tbl_region " +
                    $"SET RegionName = '{txtName.Text}', ServiceAmount = {decimal.Parse(amountValue)} " +
                    $"WHERE RegionId = {id}";
                DataAccess.ExecuteSQL(strSQLUpdate);
                MessageBox.Show("Region Edited Successfully!!");
                RegionGridFill();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            Clear();
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRegions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var warningMsg = MessageBox.Show("Are you sure to delete Region man?", "Warning", MessageBoxButtons.OKCancel
                  , MessageBoxIcon.Warning);
            if (warningMsg == DialogResult.OK)
            {
                var id = dgvRegions.Rows[dgvRegions.CurrentRow.Index].Cells[0].Value;
                string sqlQuery = $"UPDATE tbl_Customer " +
                    $"SET RegionId = NULL " +
                    $"WHERE RegionId = {id}; " +
                    $"UPDATE tbl_region " +
                    $"SET IsDeleted = 1 " +
                    $"WHERE RegionId = {id}";

                DataAccess.ExecuteScalarSQL(sqlQuery);
                Messages.InformationMessage("Region Deleted Successfully");
                Clear();
                RegionGridFill();
            }
            else
            {
                Clear();
            }
        }

        private void pnlButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvRegions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            testID.Text = dgvRegions.Rows[dgvRegions.CurrentRow.Index].Cells[0].Value.ToString();
            txtName.Text = dgvRegions.Rows[dgvRegions.CurrentRow.Index].Cells[1].Value.ToString();
            amount.Value = decimal.Parse(dgvRegions.Rows[dgvRegions.CurrentRow.Index].Cells[2].Value.ToString());
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Refresh", btnRefresh);
        }

        private void btnCustomerUp_MouseHover(object sender, EventArgs e)
        {
            toolTip3.Show("Up", btnCustomerUp);
        }

        private void btnCustomerDown_MouseHover(object sender, EventArgs e)
        {
            toolTip4.Show("Down", btnCustomerDown);
        }

        private void EditBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip5.Show("Edit Region", EditBtn);
        }

        private void DeleteBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip6.Show("Delete Region", DeleteBtn);
        }
    }
}
