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
    public partial class frmAddDeliveryman : Form
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

        public frmAddDeliveryman()
        {
            InitializeComponent();

            dgvDeliveryMen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvDeliveryMen.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvDeliveryMen.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            if (UserInfo.IsVaild(11))
            {
                AddBtn.Visible = true;
            }
            else
            {
                AddBtn.Visible = false;
            }
            if (UserInfo.IsVaild(12))
            {
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
            }
            if (UserInfo.IsVaild(13))
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
            }
        }

        public void DeliveryGridFill()
        {
            string strSQL = "SELECT * FROM tbl_DeliveryMan " +
                "WHERE IsDeleted = 0";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtRegion = DataAccess.GetDataTable(strSQL);
            dgvDeliveryMen.DataSource = dtRegion;
            dgvDeliveryMen.ClearSelection();
        }

        public void Clear()
        {
            DeliveryNameTxt.Clear();
            DeliveryPhnTxt.Clear();
        }

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            return row.Index >= lastVisibleRowIndex;
        }

        private void SearchDelivery(string strFieldName, string strSearchText)
        {
            try
            {
                string strSQL;
                if (strSearchText == "0" || strSearchText == "-1")
                {
                    strSQL = "SELECT * FROM tbl_DeliveryMan " +
                        "WHERE IsDeleted = 0";
                }
                else
                {
                    strSQL = "SELECT * FROM tbl_DeliveryMan d " +
                    "WHERE " + strFieldName + "  LIKE  '%" + strSearchText + "%' and IsDeleted = 0";
                }

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);
                dgvDeliveryMen.DataSource = dt;
                dgvDeliveryMen.Refresh();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmAddDeliveryman_Load(object sender, EventArgs e)
        {
            DeliveryGridFill();
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeliveryGridFill();
            Clear();
        }

        private void ArrowUpBtn_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDeliveryMen;
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

        private void ArrowDwnBtn_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDeliveryMen;
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (DeliveryNameTxt.Text.Trim() != "")
            {
                string strSQLInsert = "INSERT INTO tbl_DeliveryMan (name,phone_num,IsDeleted)  " +
                    "VALUES ('" + DeliveryNameTxt.Text + "', '" + DeliveryPhnTxt.Text + "', 0)";
                DataAccess.ExecuteSQL(strSQLInsert);
                Messages.InformationMessage("Delivery Man Added Successfully");
                DeliveryGridFill();
                Clear();
            }
            else
            {
                MessageBox.Show("SomeTHing went wrong!");
            }
        }

        private void AddBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Delivery", AddBtn);

        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeliveryNameTxt_TextChanged(object sender, EventArgs e)
        {
            SearchDelivery("d.name", DeliveryNameTxt.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete Button
            var warningMsg = MessageBox.Show("Are you sure to delete delivery man?", "Warning", MessageBoxButtons.OKCancel
                  , MessageBoxIcon.Warning);
            if (warningMsg == DialogResult.OK)
            {
                var id = dgvDeliveryMen.Rows[dgvDeliveryMen.CurrentRow.Index].Cells[0].Value;
                string sqlQuery = $"UPDATE tbl_TempHeader " +
                    $"SET deliveryman_id = NULL " +
                    $"WHERE deliveryman_id = {id}; " +
                    $"UPDATE tbl_DeliveryMan " +
                    $"SET IsDeleted = 1 " +
                    $"WHERE id = {id}";

                DataAccess.ExecuteScalarSQL(sqlQuery);
                Messages.InformationMessage("Delivery Man Deleted Successfully");
                Clear();
                DeliveryGridFill();
            }
            else
            {
                Clear();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Edit Dilevery
            var id = int.Parse(deliveryIdLbl.Text);
            if (DeliveryNameTxt.Text != "" && DeliveryPhnTxt.Text != "")
            {
                string strSQLUpdate = $"UPDATE tbl_DeliveryMan " +
                    $"SET name = '{DeliveryNameTxt.Text}', phone_num = '{DeliveryPhnTxt.Text}' " +
                    $"WHERE id = {id}";
                DataAccess.ExecuteSQL(strSQLUpdate);
                DeliveryGridFill();
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void dgvDeliveryMen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deliveryIdLbl.Text = dgvDeliveryMen.Rows[dgvDeliveryMen.CurrentRow.Index].Cells[0].Value.ToString();
            DeliveryNameTxt.Text = dgvDeliveryMen.Rows[dgvDeliveryMen.CurrentRow.Index].Cells[1].Value.ToString();
            DeliveryPhnTxt.Text = dgvDeliveryMen.Rows[dgvDeliveryMen.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Edit Delivery", button3);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh", button1);
        }

        private void ArrowUpBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Up", ArrowUpBtn);
        }

        private void ArrowDwnBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Down", ArrowDwnBtn);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Delete Delivery", button2);
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }
    }
}
