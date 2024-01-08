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
    public partial class frmCustomerPopup : Form
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

        public frmCustomerPopup(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvCustomers.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvCustomers.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            if (UserInfo.IsVaild(27))
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
            if (UserInfo.IsVaild(28))
            {
                deleteBtn.Visible = true;
            }
            else
            {
                deleteBtn.Visible = false;
            }
            if (UserInfo.IsVaild(29))
            {
                btnSaveAndClose.Visible = true;
            }
            else
            {
                btnSaveAndClose.Visible = false;
            }
            if (UserInfo.IsVaild(30))
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
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

        public void CustomerGridFill()
        {
            dgvCustomers.AutoGenerateColumns = false;
            string strSQL = "SELECT cs.*,r.RegionName,r.ServiceAmount FROM tbl_Customer as cs " +
                "left join  tbl_region as r on  r.RegionId=cs.RegionId WHERE cs.IsDeleted = 0 ";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtCustomer = DataAccess.GetDataTable(strSQL);
            dgvCustomers.DataSource = dtCustomer;
            dgvCustomers.Columns["clmRegion"].Width = 125;
            dgvCustomers.Columns["clmPhone"].Width = 150;
        }



        private void btnCustomerUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvCustomers;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[2].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                //dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = rowIndex - 1;

                if (lblCustomerId.Text != "-")
                {
                    deleteBtn.Visible = true;
                }
                else
                {
                    deleteBtn.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCustomerDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvCustomers;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[2].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                //dgv.ClearSelection();
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

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        private void SearchCustomer(string strFieldName, string strSearchText)
        {
            try
            {
                string strSQL;
                if (strFieldName != "r.RegionId")
                {
                    strSQL = " SELECT cs.*,r.RegionName, iif(cs.RegionId is null , 0 ,cs.RegionId) RegionId ,r.ServiceAmount FROM tbl_Customer as cs " +
                            "left join  tbl_region as r on cs.RegionId = r.RegionId " +
                            " WHERE cs.IsDeleted = 0 AND " + strFieldName + "  LIKE  '%" + strSearchText + "%'";
                }
                else
                {
                    if (strSearchText == "0" || strSearchText == "-1")
                    {
                        strSQL = " SELECT cs.*,r.RegionName, iif(cs.RegionId is null , 0 ,cs.RegionId) RegionId ,r.ServiceAmount FROM tbl_Customer as cs " +
                                "left join  tbl_region as r on cs.RegionId = r.RegionId WHERE cs.IsDeleted = 0 ";
                    }
                    else
                    {
                        strSQL = " SELECT cs.*,r.RegionName, iif(cs.RegionId is null , 0 ,cs.RegionId)  ,r.ServiceAmount FROM tbl_Customer as cs " +
                                "left join  tbl_region as r on cs.RegionId = r.RegionId " +
                                " WHERE cs.IsDeleted = 0 AND " + strFieldName + " = " + strSearchText;
                    }

                }

            DataAccess.ExecuteSQL(strSQL);
                DataTable dtCustomers = DataAccess.GetDataTable(strSQL);
                dgvCustomers.DataSource = dtCustomers;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
            if (lblCustomerId.Text != "-")
            {
                deleteBtn.Visible = true;
            }
            else
            {
                deleteBtn.Visible = false;
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (region.SelectedValue == null)
                MessageBox.Show("Please Select a region");
            else
            {
                try
                {
                    string query = "select ServiceAmount from tbl_region WHERE IsDeleted = 0 AND RegionId= " + region.SelectedValue.ToString();
                    DataTable dt = DataAccess.GetDataTable(query);

                    if (txtName.Text == "") { Messages.InformationMessage("Enter Customer Name"); txtName.Focus(); }
                    else if (txtAddress.Text == "") { Messages.InformationMessage("Enter Address"); txtAddress.Focus(); }
                    //else if (comboBox1.Text == "") { Messages.InformationMessage("Enter City"); comboBox1.Focus(); }
                    else if (txtPhone.Text == "") { Messages.InformationMessage("Enter Phone No."); txtPhone.Focus(); }
                    else
                    {
                        if (lblCustomerId.Text == "-")
                        {
                            {
                                string strSQLInsert = "INSERT INTO tbl_Customer (name,address,RegionId, phone,email)  VALUES ('" + txtName.Text + "', '" + txtAddress.Text + "', '" + region.SelectedValue.ToString() + "', '" + txtPhone.Text + "', '" + txtEmail.Text + "'); SELECT @@IDENTITY";
                                int LastInsertedId = DataAccess.ExecuteScalarSQL(strSQLInsert);

                                _frmMain.SetCustomer(LastInsertedId, txtName.Text, decimal.Parse(dt.Rows[0][0].ToString()));
                                Messages.InformationMessage("Customer is successfully added ,and selected");
                            }
                        }
                        else
                        {
                            string strSQLUpdate = "UPDATE tbl_Customer SET name = '" + txtName.Text + "', address= '" + txtAddress.Text + "', RegionId= '" + region.SelectedValue.ToString() + "', Phone = '" + txtPhone.Text + "', email = '" + txtEmail.Text + "' WHERE id = '" + lblCustomerId.Text + "'";
                            DataAccess.ExecuteSQL(strSQLUpdate);
                            _frmMain.SetCustomer(int.Parse(lblCustomerId.Text), txtName.Text, decimal.Parse(dt.Rows[0][0].ToString()));
                            Messages.InformationMessage("Customer is successfully updated ,and selected");
                        }
                        this.Close();
                        Clear();
                    }

                }
                catch (Exception ex)
                {
                    Messages.InformationMessage(ex.Message);
                }

            }
        }


        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    lblCustomerId.Text = dgvCustomers.CurrentRow.Cells["clmId"].Value.ToString();
                    txtName.Text = dgvCustomers.CurrentRow.Cells["clmName"].Value.ToString();
                    txtAddress.Text = dgvCustomers.CurrentRow.Cells["clmAddress"].Value.ToString();
                    txtPhone.Text = dgvCustomers.CurrentRow.Cells["clmPhone"].Value.ToString();
                    txtEmail.Text = dgvCustomers.CurrentRow.Cells["clmEmail"].Value.ToString();
                    var clmRegion = dgvCustomers.CurrentRow.Cells["clmRegionId"].Value.ToString();
                    if (x.Contains(string.IsNullOrEmpty(clmRegion)? 0 : int.Parse(clmRegion)))
                    {
                        region.SelectedValue = clmRegion;
                    }
                    else
                    {
                        region.SelectedValue =  0 ;
                    }
                    btnSelectAndClose.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbCusName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCusAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtAddress);
            frmKeyboard.ShowDialog();
        }

        //private void btnKbCusCity_Click(object sender, EventArgs e)
        //{
        //    frmKeyboard frmKeyboard = new frmKeyboard(comboBox1);
        //    frmKeyboard.ShowDialog();
        //}

        private void btnKbCusPhone_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPhone);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCusEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmail);
            frmKeyboard.ShowDialog();
        }

        private void frmCustomerPopup_Load(object sender, EventArgs e)
        {
            txtPhone.Focus();
            CustomerGridFill();
            Clear();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("cs.name", txtName.Text);
        }

        //private void txtCity_TextChanged(object sender, EventArgs e)
        //{
        //    SearchCustomer("city", comboBox1.Text);
        //}

        private void txtCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("cs.address", txtAddress.Text);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("cs.phone", txtPhone.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CustomerGridFill();
            Clear();
        }
        List<int> x;
        private void Clear()
        {
            lblCustomerId.Text = "-";
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            btnSelectAndClose.Enabled = false;

            string strSqlSelect = "SELECT * FROM tbl_region WHERE IsDeleted = 0 ";
            DataAccess.ExecuteSQL(strSqlSelect);
            DataTable dt = DataAccess.GetDataTable(strSqlSelect);
            x = dt.AsEnumerable().Select(a => a.Field<int>("RegionId")).ToList();
            DataRow dataRow = dt.NewRow();
            dataRow[0] = 0;
            dataRow[1] = "--Select Region--";
            dt.Rows.InsertAt(dataRow, 0);

            region.DataSource = dt;
            region.ValueMember = "RegionId";
            region.DisplayMember = "RegionName";

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

        private void btnSelectAndClose_Click(object sender, EventArgs e)
        {
            if (region.SelectedValue == null || Convert.ToInt32(region.SelectedValue) == 0) 
                MessageBox.Show("Please Select a region");
            else
            {
                string query = "select ServiceAmount from tbl_region WHERE IsDeleted = 0 AND RegionId= " + region.SelectedValue.ToString();
                DataTable dt = DataAccess.GetDataTable(query);
                _frmMain.SetCustomer(int.Parse(lblCustomerId.Text), txtName.Text, decimal.Parse(dt.Rows[0][0].ToString()));
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" &&
                txtAddress.Text.Trim() != "" &&
                txtPhone.Text.Trim() != "" &&
                !region.SelectedValue.Equals(0))
            {
                string strSQLInsert = "INSERT INTO tbl_Customer (name,address,RegionId, phone,email)  VALUES ('" + txtName.Text + "', '" + txtAddress.Text + "','" + region.SelectedValue + "','" + txtPhone.Text + "', '" + txtEmail.Text + "')";
                DataAccess.ExecuteSQL(strSQLInsert);
                Messages.InformationMessage("Customer Added Successfully");
                CustomerGridFill();
                Clear();
            }
            else
            {
                Messages.ErrorMessage("Fill Fields To Add New Customer");
            }
            
        }

        private void region_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCustomer("r.RegionId", region.SelectedIndex.ToString());

        }

        private void pnlInner_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Customer",button1);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Region", button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddRegion addRegion = new frmAddRegion(this);
            addRegion.ShowDialog();
            Clear();
            //addRegion.Show();


        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            bool result = Messages.DeleteMessage();

            if (result == true && (lblCustomerId.Text != "-"))
            {
                string strSQLDelete = "DELETE FROM tbl_Customer WHERE id = '" + lblCustomerId.Text + "'";
                DataAccess.ExecuteSQL(strSQLDelete);
                Messages.DeletedMessage();
                CustomerGridFill();
                Clear();
            }
        }
    }
}
