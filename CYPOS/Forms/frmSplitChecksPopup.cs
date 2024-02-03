using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static cypos.frmMain;
namespace cypos.Forms
{
    public partial class frmSplitChecksPopup : Form
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
        private frmMain _frmMain = new frmMain();
        private int header_id;
        public string Payable;
        public string InvNo;
        public bool isCanceled = false;
        public frmSplitChecksPopup(frmMain frmMain)
        {
            InitializeComponent();
            listBox1.AllowDrop = true;
            listBox2.AllowDrop = true;
            // Hook up the necessary events
            listBox1.MouseDown += ListBox_MouseDown;
            listBox2.MouseDown += ListBox_MouseDown;
            listBox1.DragEnter += ListBox_DragEnter;
            listBox2.DragEnter += ListBox_DragEnter;
            listBox1.DragDrop += ListBox_DragDrop;
            listBox2.DragDrop += ListBox_DragDrop;
            _frmMain = frmMain;
            header_id = _frmMain.tempHeaderId;
            loadItems();
        }
        // ItemsData class
        public class ItemsData
        {
            public string itemcode { get; set; }
            public string itemName { get; set; }
            public double kot_qty { get; set; }
        }
        public class DraggedItems
        {
            public ItemsData Item { get; set; }
            public ListBox SourceListBox { get; set; }
        }
        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.isCanceled = true;
            this.Close();
        }
        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Close", pbxClose);
        }
        private void loadItems()
        {
            string query = $"SELECT item_name, kot_qty, * FROM tbl_TempDetail WHERE header_id = {header_id}";
            DataTable data = DataAccess.GetDataTable(query);
            listBox1.Items.Clear();
            foreach (DataRow row in data.Rows)
            {
                string itemName = row["item_name"].ToString();
                double kot_qty = Convert.ToDouble(row["kot_qty"].ToString());
                string itemcode = row["item_code"].ToString();
                if (kot_qty > 1)
                {
                    for (int i = 0; i < kot_qty; i++)
                    {
                        listBox1.Items.Add(new ItemsData { itemName = itemName, kot_qty = kot_qty , itemcode = itemcode });
                    }
                }
                else
                {
                    listBox1.Items.Add(new ItemsData { itemName = itemName, kot_qty = kot_qty, itemcode= itemcode });
                }
            }
            listBox1.ValueMember = "itemcode";
            listBox1.DisplayMember = "itemName"; 
            listBox2.ValueMember = "itemcode";
            listBox2.DisplayMember = "itemName";
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
        private void selectOneBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedItem = listBox1.SelectedItem;
                listBox1.Items.Remove(selectedItem);
                listBox2.Items.Add(selectedItem);
            }
        }
        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            // Transfer all items from listBox1 to listBox2
            listBox2.Items.AddRange(listBox1.Items.Cast<object>().ToArray());
            // Clear all items from listBox1
            listBox1.Items.Clear();
        }
        private void disSelectOne_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                var selectedItem = listBox2.SelectedItem;
                listBox2.Items.Remove(selectedItem);
                listBox1.Items.Add(selectedItem);
            }
        }
        private void disSelectAll_Click(object sender, EventArgs e)
        {
            // Transfer all items from listBox1 to listBox2
            listBox1.Items.AddRange(listBox2.Items.Cast<object>().ToArray());
            // Clear all items from listBox1
            listBox2.Items.Clear();
        }
        private void save()
        {
            try
            {
                if (listBox2.Items.Count > 0)
                {
                    string strTax1Name = TaxValue.Tax1Name;
                    string strTax2Name = TaxValue.Tax2Name;

                    string headerQuery = $@"INSERT INTO tbl_TempHeader 
                                        (shift_id,invoiceNo,order_type,invoice_date,invoice_time,kot_no,table_id,no_of_guests,waiter_id
                                        ,customer_id, payment_type,payment_amount, paid_amount,change_amount,due_amount,discount_rate
                                        ,discount_amount ,tax1_name,tax1_rate,tax1_amount,tax2_name,tax2_rate,tax2_amount
                                        , sc_rate,sc_charge,note,user_name,log_date)

                                        SELECT header.shift_id, header.invoiceNo, header.order_type, header.invoice_date
                                        , '{DateTime.Now.ToString("hh:mm tt")}', header.kot_no, header.table_id, header.no_of_guests
                                        , header.waiter_id, header.customer_id, header.payment_type, 0, 0, 0, 0
                                        , 0, 0, '{strTax1Name}', header.tax1_rate, header.tax1_amount, '{strTax2Name}'
                                        ,header.tax2_rate, header.tax2_amount, header.sc_rate, header.sc_charge, ' ... Splited'
                                        , header.user_name, '{DateTime.Now.ToString("MM-dd-yyyy")}'
                                    
                                        FROM tbl_TempHeader header
                                        WHERE id = {header_id} SELECT SCOPE_IDENTITY();";
                    int new_header_id = DataAccess.ExecuteScalarSQL(headerQuery);

                    foreach (var items in listBox2.Items)
                    {
                        dynamic item = items;
                        string itemCode = item.itemcode;
                        string query = $@"IF EXISTS(
                                                SELECT * FROM tbl_TempDetail details
                                                WHERE item_code='{itemCode}' AND header_id = {new_header_id})
                                                BEGIN
                                                  UPDATE tbl_TempDetail SET header_id = details.header_id, qty = (details.qty + 1)
	                                                , kot_qty = (details.kot_qty + 1), log_date = details.log_date
	                                                , last_qty = (details.last_qty + 1) FROM tbl_TempDetail details
	                                                WHERE item_code='{itemCode}' AND header_id = {new_header_id};
	                                                IF EXISTS(
			                                                SELECT * FROM tbl_TempDetail details WHERE item_code = '{itemCode}' AND kot_qty > 1 AND header_id = {header_id}
		                                                )
	                                                BEGIN
	                                                  UPDATE tbl_TempDetail SET header_id = details.header_id, qty= (details.qty -1)
                                                        , kot_qty= (details.kot_qty - 1), log_date=GETDATE() 
                                                        , last_qty= (details.last_qty - 1) FROM tbl_TempDetail details 
                                                        WHERE item_code='{itemCode}' AND header_id = {header_id}
	                                                END
	                                                ELSE
	                                                BEGIN
		                                                DELETE FROM tbl_TempDetail WHERE header_id = {header_id} AND item_code = '{itemCode}'
	                                                END
                                                END 
                                                ELSE 
                                                BEGIN 
	                                                IF EXISTS(
			                                                SELECT * FROM tbl_TempDetail details WHERE item_code = '{itemCode}' AND kot_qty > 1 AND header_id = {header_id}
		                                                )
	                                                BEGIN
	                                                    INSERT INTO tbl_TempDetail (header_id, item_code, item_name, qty, selling_price, total, discount, discount_amount
										                                                , net_amount, profit, tax_apply, show_kitchen, print_kot, kot_qty, log_date, comment, last_qty)
		                                                SELECT {new_header_id}, item_code, item_name, 1, selling_price, selling_price, discount, discount_amount, net_amount, profit, tax_apply
						                                                , show_kitchen, print_kot, 1, log_date, comment + ' ...Transfered', 1 
		                                                FROM tbl_TempDetail
		                                                WHERE header_id = {header_id} AND item_code = '{itemCode}';
	                                                  UPDATE tbl_TempDetail SET header_id = details.header_id, qty= (details.qty - 1)
                                                        , kot_qty= (details.kot_qty - 1), log_date = GETDATE() 
                                                        , last_qty= (details.last_qty - 1) FROM tbl_TempDetail details 
                                                        WHERE item_code='{itemCode}' AND header_id = {header_id};
	                                                END
	                                                ELSE
	                                                BEGIN
		                                                UPDATE tbl_TempDetail SET header_id = {new_header_id} WHERE header_id = {header_id} AND item_code = '{itemCode}'
	                                                END
                                                END";
                        DataAccess.ExecuteSQL(query);
                    }
                    MessageBox.Show("successfully");
                    string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

                    // Create a SqlConnection object
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the database connection
                        connection.Open();

                        // Create a SqlCommand object for the stored procedure
                        using (SqlCommand command = new SqlCommand("UpdateTempHeader", connection))
                        {
                            // Set the command type as stored procedure
                            command.CommandType = CommandType.StoredProcedure;

                            // Add the parameters
                            command.Parameters.AddWithValue("@headerId", new_header_id);

                            // Execute the stored procedure
                            command.ExecuteNonQuery();
                        }

                    }

                    DataTable data = DataAccess.GetDataTable($"SELECT payment_amount, ISNULL(tax1_amount, 0) tax1_amount" +
                        $", ISNULL(tax2_amount, 0) tax2_amount, discount_amount, sc_charge FROM tbl_TempHeader WHERE id = {new_header_id}");
                    decimal payment_amount = Convert.ToDecimal(data.Rows[0]["payment_amount"].ToString());
                    Payable = payment_amount.ToString();
                    InvNo = _frmMain.NextInvoiceNumber();
                    _frmMain.RecallInvoice(new_header_id.ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is no items to split!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var warningMsg = MessageBox.Show("Are you sure to split this check?", "Warning", MessageBoxButtons.OKCancel
                                , MessageBoxIcon.Warning);
            if (warningMsg == DialogResult.OK)
            {
                isCanceled = false;
                save();
            }
            else
            {
                isCanceled = true;
                this.Close();
            }
        }
        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.IndexFromPoint(e.X, e.Y);
            if (selectedIndex >= 0 && listBox.Items.Count > 0)
            {
                // Create a DraggedItem instance with the item and source ListBox
                DraggedItems draggedItem = new DraggedItems
                {
                    Item = listBox.Items[selectedIndex] as ItemsData,
                    SourceListBox = listBox
                };
                // Start the drag and drop operation
                listBox.DoDragDrop(draggedItem, DragDropEffects.Move);
            }
        }
        private void ListBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            // Get the dragged item and source ListBox from the data
            var draggedItem = e.Data.GetData(typeof(DraggedItems)) as DraggedItems;
            if (draggedItem != null && draggedItem.SourceListBox != null && draggedItem.SourceListBox != listBox)
            {
                // Add the item to the target ListBox and remove it from the source ListBox
                listBox.Items.Add(draggedItem.Item);
                draggedItem.SourceListBox.Items.Remove(draggedItem.Item);
            }
        }

        private void frmSplitChecksPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPayment frmPayment = new frmPayment(_frmMain);
            frmPayment.Payable = _frmMain.TotalFinal.ToString();
            frmPayment.InvoiceNo = _frmMain.NextInvoiceNumber();
        }
    }
}
