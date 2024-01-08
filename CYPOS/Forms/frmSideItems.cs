using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos
{
    public partial class frmSideItems : Form
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
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        frmItem _frmItem = new frmItem();

        public frmSideItems(frmItem frmItem)
        {
            InitializeComponent();
            _frmItem = frmItem;

            dgvItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvItems.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvItems.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
        }

        public void GridFill()
        {
            dgvItems.AutoGenerateColumns = false;
            string strSQL = $"SELECT * FROM tbl_Item where parent_item_id = {_frmItem.Item_id} ";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dt = DataAccess.GetDataTable(strSQL);
            dgvItems.DataSource = dt;

        }

        public void Clear()
        {
            txtName.Clear();
            CostPriceTxt.Text = "0";
            SellingPriceTxt.Text = "0";
            DiscountTxt.Text = "0";
            GridFill();
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
            Clear();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvItems;
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

        private void btnDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvItems;
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
            frmItem frmItem = new frmItem();
            //Add button
            decimal result;
            if (!decimal.TryParse(CostPriceTxt.Text, out result) || !decimal.TryParse(SellingPriceTxt.Text, out result) 
                || !decimal.TryParse(DiscountTxt.Text, out result))
            {
                MessageBox.Show("This is a number only field");
            }
            else
            {
                if (txtName.Text.Trim() != "" && CostPriceTxt.Text.Trim() != "" 
                    && SellingPriceTxt.Text.Trim() != "" && DiscountTxt.Text.Trim() != "")
                {
                    string itemCode = GenerateItemCode(txtName.Text);
                    string strSQLInsert = "INSERT INTO tbl_Item (item_code, item_name, cost_price, selling_price, discount, tax_apply" 
                                        + ", show_kitchen, print_kot, show_pos, stock_item, active, weightable, parent_item_id) "
                                        + $"SELECT '{itemCode}', '{txtName.Text}', {CostPriceTxt.Text}, {SellingPriceTxt.Text}" 
                                        + $", {DiscountTxt.Text}, tax_apply, show_kitchen, print_kot, show_pos, stock_item, active, weightable, {_frmItem.Item_id} " 
                                        + $"FROM tbl_Item WHERE id = {_frmItem.Item_id}";
                    DataAccess.ExecuteSQL(strSQLInsert);
                    Messages.InformationMessage("Item Added Successfully");
                    Clear();
                }
                else
                {
                    Messages.ErrorMessage("You should Enter a Valid Values for the fields");
                }
            }
        }

        private string GenerateItemCode(string itemName)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] itemNameBytes = Encoding.UTF8.GetBytes(itemName);
                byte[] hashBytes = sha256.ComputeHash(itemNameBytes);
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                string itemCode = sb.ToString().Substring(0, 8);
                return itemCode;
            }
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Item", button1);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvItems.Rows[dgvItems.CurrentRow.Index].Cells[0].Value.ToString());
            if (txtName.Text != "")
            {
                string strSQLUpdate = $"UPDATE tbl_Item " 
                                    + $"SET item_name = '{txtName.Text}', cost_price = {CostPriceTxt.Text}" 
                                    + $", selling_price = {SellingPriceTxt.Text}, discount = {DiscountTxt.Text} " 
                                    + $"WHERE id = {id}";
                DataAccess.ExecuteSQL(strSQLUpdate);
                MessageBox.Show("Item Edited Successfully!!");
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var warningMsg = MessageBox.Show("Are you sure to delete Item?", "Warning", MessageBoxButtons.OKCancel
                  , MessageBoxIcon.Warning);
            if (warningMsg == DialogResult.OK)
            {
                int id = int.Parse(dgvItems.Rows[dgvItems.CurrentRow.Index].Cells[0].Value.ToString());
                string sqlQuery = $"DELETE FROM tbl_Item WHERE id = {id} ";

                DataAccess.ExecuteScalarSQL(sqlQuery);
                Messages.InformationMessage("Item Deleted Successfully");
                Clear();
            }
            else
            {
                Clear();
            }
        }

        private void dgvRegions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtName.Text = dgvItems.Rows[dgvItems.CurrentRow.Index].Cells["name"].Value.ToString();
                CostPriceTxt.Text = dgvItems.Rows[dgvItems.CurrentRow.Index].Cells["costPriceClm"].Value.ToString();
                SellingPriceTxt.Text = dgvItems.Rows[dgvItems.CurrentRow.Index].Cells["sellingPriceClm"].Value.ToString();
                DiscountTxt.Text = dgvItems.Rows[dgvItems.CurrentRow.Index].Cells["discountClm"].Value.ToString();
            }
            catch
            { }
            
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Refresh", btnRefresh);
        }

        private void btnCustomerUp_MouseHover(object sender, EventArgs e)
        {
            toolTip3.Show("Up", btnUp);
        }

        private void btnCustomerDown_MouseHover(object sender, EventArgs e)
        {
            toolTip4.Show("Down", btnDown);
        }

        private void EditBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip5.Show("Edit Region", EditBtn);
        }

        private void DeleteBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip6.Show("Delete Region", DeleteBtn);
        }

        private void frmSideItems_Load(object sender, EventArgs e)
        {
            itemCodeLbl.Text = _frmItem.Item_name;
            Clear();
        }
    }
}
