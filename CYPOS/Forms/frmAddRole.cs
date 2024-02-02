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
    public partial class frmAddRole : Form
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
        frmUserAccess _frmUserAccess = new frmUserAccess();
        public frmAddRole()
        {
            InitializeComponent();
        }
        public frmAddRole(frmUserAccess frmUserAccess)
        {
            _frmUserAccess = frmUserAccess;
            InitializeComponent();
        }

        private void GridFill()
        {
            dgvRoles.AutoGenerateColumns = false;
            string query = "Select * FROM tbl_Roles WHERE IsDeleted = 0 ";
            DataTable dt = DataAccess.GetDataTable(query);
            dgvRoles.DataSource = dt;
            dgvRoles.ClearSelection();
        }

        public void Clear()
        {
            roleNameTxt.Clear();
            GridFill();
        }

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            return row.Index >= lastVisibleRowIndex;
        }
        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }

        private void frmAddRole_Load(object sender, EventArgs e)
        {
            Clear();
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

        private void ArrowUpBtn_Click_1(object sender, EventArgs e)
        {
            DataGridView dgv = dgvRoles;
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
            catch (Exception)
            {
            }
        }

        private void ArrowDwnBtn_Click_1(object sender, EventArgs e)
        {
            DataGridView dgv = dgvRoles;
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
            catch (Exception)
            {
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void SearchRole(string strFieldName, string strSearchText)
        {
            try
            {
                string strSQL;
                if (strSearchText == "0" || strSearchText == "-1")
                {
                    strSQL = "SELECT * FROM tbl_Roles " +
                        "WHERE IsDeleted = 0";
                }
                else
                {
                    strSQL = "SELECT * FROM tbl_Roles " +
                    "WHERE " + strFieldName + "  LIKE  '%" + strSearchText + "%' and IsDeleted = 0";
                }

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);
                dgvRoles.DataSource = dt;
                dgvRoles.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void roleNameTxt_TextChanged(object sender, EventArgs e)
        {
            SearchRole("name", roleNameTxt.Text);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (roleNameTxt.Text.Trim() != "")
            {
                string strSQLInsert = "INSERT INTO tbl_Roles (name,log_date,IsDeleted)  " +
                    "VALUES (N'" + roleNameTxt.Text + "', '" + DateTime.Now.ToString("MM-dd-yyyy") + "', 0)";
                DataAccess.ExecuteSQL(strSQLInsert);
                Messages.InformationMessage("Role Added Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            var id = int.Parse(roleIdLbl.Text);
            if (roleNameTxt.Text != "" )
            {
                string strSQLUpdate = $"UPDATE tbl_Roles " +
                    $"SET name = N'{roleNameTxt.Text}' " +
                    $"WHERE id = {id}";
                DataAccess.ExecuteSQL(strSQLUpdate);
                Messages.InformationMessage("Role Updated Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var warningMsg = MessageBox.Show("Are you sure to delete this role?", "Warning", MessageBoxButtons.OKCancel
                , MessageBoxIcon.Warning);
            if (warningMsg == DialogResult.OK)
            {
                var id = dgvRoles.Rows[dgvRoles.CurrentRow.Index].Cells[0].Value.ToString();
                string sqlQuery = $"UPDATE tbl_Roles " 
                                + $"SET IsDeleted = 1 " 
                                + $"WHERE id = {int.Parse(id)} "; 

                DataAccess.ExecuteScalarSQL(sqlQuery);
                Messages.InformationMessage("Role Deleted Successfully");
                Clear();
            }
            else
            {
                Clear();
            }
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            roleIdLbl.Text = dgvRoles.Rows[dgvRoles.CurrentRow.Index].Cells[0].Value.ToString();
            roleNameTxt.Text = dgvRoles.Rows[dgvRoles.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void ArrowUpBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Up", ArrowUpBtn);
        }

        private void ArrowDwnBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Down", ArrowDwnBtn);
        }

        private void AddBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Role", AddBtn);
        }

        private void refreshBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh", refreshBtn);

        }

        private void editBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Edit Role", editBtn);
        }

        private void deleteBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Delete Role", deleteBtn);
        }

        private void frmAddRole_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmUserAccess.Clear();
        }
    }
}
