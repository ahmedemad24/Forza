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
    public partial class frmExpenseGroup : Form
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

        public frmExpenseGroup(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            dgvGroup.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvGroup.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvGroup.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);


            if (UserInfo.IsVaild(54))
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
            }
            if (UserInfo.IsVaild(55))
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
            if (UserInfo.IsVaild(56))
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
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

        public void GroupGridFill()
        {
            dgvGroup.AutoGenerateColumns = false;
            string strSQL = "SELECT * FROM  tbl_ExpenseGroup ORDER BY group_name";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtGroup = DataAccess.GetDataTable(strSQL);
            dgvGroup.DataSource = dtGroup;
        }



        private void btnCustomerUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvGroup;
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
            DataGridView dgv = dgvGroup;
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

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        private void SearchGroup(string strSearchText)
        {
            try
            {
                string strSQL = " SELECT * FROM  tbl_ExpenseGroup " +
                                " WHERE group_name LIKE  '%" + strSearchText + "%'";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtGroup = DataAccess.GetDataTable(strSQL);
                dgvGroup.DataSource = dtGroup;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGroupName.Text == "") { Messages.InformationMessage("Enter Group"); txtGroupName.Focus(); }
                else
                {
                    if (lblGroupId.Text == "-")
                    {
                        {
                            string strSQLInsert = "INSERT INTO tbl_ExpenseGroup (group_name)  VALUES ('" + txtGroupName.Text + "'); SELECT @@IDENTITY";
                            int LastInsertedId = DataAccess.ExecuteScalarSQL(strSQLInsert);
                            //Messages.InformationMessage("Successfully saved");
                        }
                    }
                    else
                    {
                        string strSQLUpdate = "UPDATE tbl_ExpenseGroup SET group_name = '" + txtGroupName.Text + "' WHERE id = '" + lblGroupId.Text + "'";
                        DataAccess.ExecuteSQL(strSQLUpdate);
                        //Messages.InformationMessage("Successfully Updated");
                    }
                    GroupGridFill();
                    Clear();
                }

            }
            catch (Exception ex)
            {
                Messages.InformationMessage("Record Exits");
            }
        }


        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    lblGroupId.Text = dgvGroup.CurrentRow.Cells["clmId"].Value.ToString();
                    txtGroupName.Text = dgvGroup.CurrentRow.Cells["clmGroup"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbGroup_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtGroupName);
            frmKeyboard.ShowDialog();
        }


        private void frmExpenseGroup_Load(object sender, EventArgs e)
        {
            GroupGridFill();
            Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GroupGridFill();
            Clear();
        }

        private void Clear()
        {
            lblGroupId.Text = "-";
            txtGroupName.Clear();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchGroup(txtSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGroup.RowCount > 0)
                {
                    foreach (DataGridViewRow row in dgvGroup.SelectedRows)
                    {
                        bool result = Messages.DeleteMessage();

                        if (result == true)
                        {
                            string strSQL = "DELETE FROM tbl_ExpenseGroup WHERE id = '" + row.Cells["clmId"].Value.ToString() + "'";
                            DataAccess.ExecuteSQL(strSQL);
                            GroupGridFill();
                            //Messages.DeletedMessage();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearch);
            frmKeyboard.ShowDialog();
        }
    }
}
