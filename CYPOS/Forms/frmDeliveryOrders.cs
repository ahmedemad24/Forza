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
    public partial class frmDeliveryOrders : Form
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

        frmMain _frmMain = new frmMain();
        public frmDeliveryOrders(frmMain _frm)
        {
            _frmMain = _frm;
            InitializeComponent();
            dgvDelivery.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvDelivery.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvDelivery.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            if (UserInfo.IsVaild(10))
            {
                AddDeliveryman.Visible = true;
            }
            else
            {
                AddDeliveryman.Visible = false;
            }
            if (UserInfo.IsVaild(14))
            {
                ChooseDlv.Visible = true;
            }
            else
            {
                ChooseDlv.Visible = false;
            }
            if (UserInfo.IsVaild(15))
            {
                FinishOrderBtn.Visible = true;
            }
            else
            {
                FinishOrderBtn.Visible = false;
            }
        }
        public List<int> OrderIds = new List<int>();
        private void frmDeliveryOrders_Load(object sender, EventArgs e)
        {
            DeliveryGridFill();
            CounterGridFill();
            FinishOrderBtn.Enabled = false;
            ChooseDlv.Enabled = false;
            Clear();
        }

         public void CounterGridFill()
        {
            DataGridView dgv = dgvDelivery;
            int counterPendding = 0;
            int counterDelivered = 0;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var value = dgv.Rows[i].Cells[7].Value.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                    counterPendding++;
                }
                else
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    counterDelivered++;
                }
            }
            label3.Text = counterPendding.ToString();
            label4.Text = counterDelivered.ToString();
        }
        
        public void DeliveryGridFill()
        {
            string strSQL = "SELECT th.id, th.log_date, c.name, c.phone, c.address, (th.payment_amount + r.ServiceAmount ) payment_amount," +
                " d.name NameDelivery, th.delivery_date " +
                "From tbl_TempHeader th " +
                "INNER JOIN tbl_Customer c ON th.customer_id = c.id " +
                "LEFT JOIN tbl_DeliveryMan d ON d.id = th.deliveryman_id " +
                "left join  tbl_region as r on  r.RegionId = c.RegionId " +
                "WHERE th.order_type = 3";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtDelivery = DataAccess.GetDataTable(strSQL);
            dgvDelivery.DataSource = dtDelivery;
            dgvDelivery.ClearSelection();
        }

        private void SearchCustomer(string strFieldName, string strSearchText)
        {
            try
            {
                string strSQL;
                if (strSearchText == "0" || strSearchText == "-1")
                {
                    strSQL = "SELECT th.id, th.log_date, c.name, c.phone, c.address, th.payment_amount," +
                        " d.name, th.delivery_date " +
                        "From tbl_TempHeader as th, tbl_DeliveryMan as d, tbl_Customer as c " +
                        "Where th.order_type = 3";
                }
                else
                {
                    strSQL = "SELECT th.id, th.log_date, c.name, c.phone, c.address, th.payment_amount, th.delivery_date, d.name " +
                    "From tbl_TempHeader th INNER JOIN tbl_Customer c ON th.customer_id = c.id " +
                    "LEFT JOIN tbl_DeliveryMan d ON d.id = th.deliveryman_id " +
                    "WHERE " + strFieldName + "  LIKE  '%" + strSearchText + "%' and th.order_type = 3";
                }

                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCustomers = DataAccess.GetDataTable(strSQL);
                dgvDelivery.DataSource = dtCustomers;
                CounterGridFill();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void ChooseSelectedForDelivery()
        {
            bool isSelected = false;
            bool IsEmptyOrNull = true;
            foreach (DataGridViewRow row in dgvDelivery.Rows)
            {
                var IsChecked = (bool?) row.Cells["chk"].Value;
                if (IsChecked == true)
                {
                    int id =int.Parse(row.Cells["id"].Value.ToString());
                    OrderIds.Add(id);
                }
                isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                if (isSelected == true)
                {
                    string valueDelev = row.Cells["delName"].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(valueDelev))
                    {
                        IsEmptyOrNull = false;
                    }
                }
            }
            if (IsEmptyOrNull)
            {
                frmSelectDeliveryMan frmSelectDeliveryMan = new frmSelectDeliveryMan(this, OrderIds);

                frmSelectDeliveryMan.ShowDialog();
                OrderIds.Clear();
                hasNoDelivery.Clear();
                dgvDelivery.Refresh();
                DeliveryGridFill();
                CounterGridFill();
            }
            else
            {
                frmSelectDeliveryMan frmSelectDeliveryMan = new frmSelectDeliveryMan(this, OrderIds);
                var warningMsg = MessageBox.Show("Are you sure to change delivery man?", "Warning", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Warning);
                if (warningMsg == DialogResult.OK)
                {
                    frmSelectDeliveryMan.ShowDialog();
                    OrderIds.Clear();
                    hasNoDelivery.Clear();
                    dgvDelivery.Refresh();
                    DeliveryGridFill();
                    CounterGridFill();
                }
                else
                {
                    frmSelectDeliveryMan.Close();
                }
            }
        }

        private void ChooseSelectedForFinishOrder()
        {
            List<decimal> decList = new List<decimal>();
            bool isSelected = false;
            bool IsEmptyOrNull = true;
            decimal value = 0;
            foreach (DataGridViewRow row in dgvDelivery.Rows)
            {
                var IsChecked = (bool?)row.Cells["chk"].Value;
                if (IsChecked == true)
                {
                    int id = int.Parse(row.Cells["id"].Value.ToString());
                    OrderIds.Add(id);
                }
                isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                if (isSelected == true)
                {
                    string valuePayment = row.Cells["payment_amount"].Value.ToString();
                    value += Convert.ToDecimal(valuePayment);
                    if (!string.IsNullOrWhiteSpace(valuePayment))
                    {
                        IsEmptyOrNull = false;
                    }
                }
            }
            if (IsEmptyOrNull)
            {
                MessageBox.Show("Should be any payment amount in the table!");
            }
            else
            {
                frmPayment frmPayment = new frmPayment(_frmMain, OrderIds);
                frmPayment.Payable = value.ToString();
                frmPayment.IsDeliveryOrder = true;
                frmPayment.ShowDialog();
                OrderIds.Clear();
                dgvDelivery.Refresh();
                DeliveryGridFill();
                CounterGridFill();
                Clear();
            }
        }

        public void setDelivery(int id, string name)
        {
            if (id > 0)
            {
                dgvDelivery.CurrentRow.Cells["delName"].Value = name;
            }
            else
            {
                MessageBox.Show("Delivery already existed on this order/s");
            }
        }

        List<bool> hasNoDelivery = new List<bool>();
        int counter = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dgvDelivery.Rows[dgvDelivery.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    {
                        ch1.Value = false;
                        var delVal = dgvDelivery.Rows[dgvDelivery.CurrentRow.Index].Cells[7].Value.ToString();
                        hasNoDelivery.Remove(string.IsNullOrWhiteSpace(delVal));
                        counter--;
                        break;
                    }
                case "False":
                    {
                        var delVal = dgvDelivery.Rows[dgvDelivery.CurrentRow.Index].Cells[7].Value.ToString();
                        ch1.Value = true;
                        hasNoDelivery.Add(string.IsNullOrWhiteSpace(delVal));
                        counter++;
                        break;
                    }
            }
            if ( hasNoDelivery.Count() != 0 && hasNoDelivery.All(a => a == false))
            {
                FinishOrderBtn.Enabled = true;
            }
            else
            {
                FinishOrderBtn.Enabled = false;
            }
            if (counter > 0)
            {
                ChooseDlv.Enabled = true;
            }
            else
            {
                ChooseDlv.Enabled = false;
            }
        }

        private void AddDeliveryman_Click(object sender, EventArgs e)
        {
            frmAddDeliveryman frmAddDeliveryman = new frmAddDeliveryman();
            frmAddDeliveryman.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("d.name", textBox1.Text);
        }

        private void ChooseDlv_Click(object sender, EventArgs e)
        {
            ChooseSelectedForDelivery();
        }

        private void BtnArrowUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDelivery;
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

        private void BtnArrowDwn_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDelivery;
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

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            return row.Index >= lastVisibleRowIndex;
        }

        public void Clear()
        {
            textBox1.Clear();
            ChooseDlv.Enabled = false;
            FinishOrderBtn.Enabled = false;
        }

        //Refresh button ..
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
            DeliveryGridFill();
            CounterGridFill();
        }

        private void FinishOrderBtn_Click(object sender, EventArgs e)
        {
            ChooseSelectedForFinishOrder();
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

               
            }
        }

        

        private void AddDeliveryman_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add new delivery man", AddDeliveryman);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh", button1);
        }

        private void BtnArrowUp_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Up", BtnArrowUp);
        }

        private void BtnArrowDwn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Down", BtnArrowDwn);
        }

        private void ChooseDlv_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Choose Delivery man for selected orders", ChooseDlv);
        }

        private void FinishOrderBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Finish choosen Order/s", FinishOrderBtn);
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }
    }
}
