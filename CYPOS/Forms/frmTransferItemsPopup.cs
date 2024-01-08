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
    public partial class frmTransferItemsPopup : Form
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
        readonly frmTransferPopup _transferPopup;
        readonly frmMain _frmMain;
        public frmTransferItemsPopup(frmMain frmMain, frmTransferPopup transferPopup)
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
            _transferPopup = transferPopup;
            loadItems();
        }
        // ItemData class
        public class ItemData
        {
            public string itemName { get; set; }
            public double kot_qty { get; set; }
            public string itemcode { get; set; }
            public override string ToString()
            {
                return itemName;
            }
        }
        public class DraggedItem
        {
            public ItemData Item { get; set; }
            public ListBox SourceListBox { get; set; }
        }
        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Close", pbxClose);
        }
        private void loadItems()
        {
            int header_id = _frmMain.tempHeaderId;
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
                        listBox1.Items.Add(new ItemData { itemName = itemName, kot_qty = kot_qty , itemcode = itemcode });
                    }
                }
                else
                {
                    listBox1.Items.Add(new ItemData { itemName = itemName, kot_qty = kot_qty, itemcode= itemcode });
                }
            }
            listBox1.ValueMember = "itemcode";
            listBox1.DisplayMember = "itemName"; 
            listBox2.ValueMember = "itemcode";
            listBox2.DisplayMember = "itemName";
        }
        private void loadOpenedTables()
        {
            int table_id = _frmMain.tableeId;
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
                         + $"CASE WHEN tbl_TempHeader.table_id > 0 THEN 1 ELSE 0 END = 1\r\n AND table_id <> {table_id} "
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
        }
        private void frmTransferItemsPopup_Load(object sender, EventArgs e)
        {
            loadOpenedTables();
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
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            if (openedTablesCbx.SelectedIndex > 0)
            {
                int second_table_id = int.Parse(openedTablesCbx.SelectedValue.ToString());
                string selectQuery = $@"SELECT TOP 1 details.header_id from tbl_TempDetail details
                                join tbl_TempHeader header on details.header_id = header.id
                                WHERE header.table_id = {second_table_id}";
                int recieved_headerId = DataAccess.ExecuteScalarSQL(selectQuery);
                int sender_headerId = _frmMain.tempHeaderId;
                foreach (var items in listBox2.Items)
                {
                    dynamic item = items;
                    string itemCode = item.itemcode;
                    string query = $@"IF EXISTS(
                                            SELECT * FROM tbl_TempDetail details
                                            WHERE item_code='{itemCode}' AND header_id = {recieved_headerId})
                                            BEGIN
                                              UPDATE tbl_TempDetail SET header_id = details.header_id, qty = (details.qty + 1)
	                                            , kot_qty = (details.kot_qty + 1), log_date = details.log_date
	                                            , last_qty = (details.last_qty + 1) FROM tbl_TempDetail details
	                                            WHERE item_code='{itemCode}' AND header_id = {recieved_headerId};
	                                            IF EXISTS(
			                                            SELECT * FROM tbl_TempDetail details WHERE item_code = '{itemCode}' AND kot_qty > 1 AND header_id = {sender_headerId}
		                                            )
	                                            BEGIN
	                                              UPDATE tbl_TempDetail SET header_id = details.header_id, qty= (details.qty -1)
                                                    , kot_qty= (details.kot_qty - 1), log_date=GETDATE() 
                                                    , last_qty= (details.last_qty - 1) FROM tbl_TempDetail details 
                                                    WHERE item_code='{itemCode}' AND header_id = {sender_headerId}
	                                            END
	                                            ELSE
	                                            BEGIN
		                                            DELETE FROM tbl_TempDetail WHERE header_id = {sender_headerId} AND item_code = '{itemCode}'
	                                            END
                                            END 
                                            ELSE 
                                            BEGIN 
	                                            IF EXISTS(
			                                            SELECT * FROM tbl_TempDetail details WHERE item_code = '{itemCode}' AND kot_qty > 1 AND header_id = {sender_headerId}
		                                            )
	                                            BEGIN
	                                                INSERT INTO tbl_TempDetail (header_id, item_code, item_name, qty, selling_price, total, discount, discount_amount
										                                            , net_amount, profit, tax_apply, show_kitchen, print_kot, kot_qty, log_date, comment, last_qty)
		                                            SELECT {recieved_headerId}, item_code, item_name, 1, selling_price, selling_price, discount, discount_amount, net_amount, profit, tax_apply
						                                            , show_kitchen, print_kot, 1, log_date, comment + ' ...Transfered', 1 
		                                            FROM tbl_TempDetail
		                                            WHERE header_id = {sender_headerId} AND item_code = '{itemCode}';
	                                              UPDATE tbl_TempDetail SET header_id = details.header_id, qty= (details.qty - 1)
                                                    , kot_qty= (details.kot_qty - 1), log_date = GETDATE() 
                                                    , last_qty= (details.last_qty - 1) FROM tbl_TempDetail details 
                                                    WHERE item_code='{itemCode}' AND header_id = {sender_headerId};
	                                            END
	                                            ELSE
	                                            BEGIN
		                                            UPDATE tbl_TempDetail SET header_id = {recieved_headerId} WHERE header_id = {sender_headerId} AND item_code = '{itemCode}'
	                                            END
                                            END";
                    DataAccess.ExecuteSQL(query);
                }
                _frmMain.updateNotificationHeaderAndDetails(second_table_id);
                MessageBox.Show("successfully");
                // Create a SqlConnection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = new SqlCommand("UpdateTempHeaderAfterTransfer", connection))
                    {
                        // Set the command type as stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameters
                        command.Parameters.AddWithValue("@headerId", recieved_headerId);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand("UpdateTempHeaderAfterTransfer", connection))
                    {
                        // Set the command type as stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the parameters
                        command.Parameters.AddWithValue("@headerId", sender_headerId);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                    }
                }
                _transferPopup.Transfered = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("You should select a table First!");
            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            save();
        }
        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int selectedIndex = listBox.IndexFromPoint(e.X, e.Y);
            if (selectedIndex >= 0 && listBox.Items.Count > 0)
            {
                // Create a DraggedItem instance with the item and source ListBox
                DraggedItem draggedItem = new DraggedItem
                {
                    Item = listBox.Items[selectedIndex] as ItemData,
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
            var draggedItem = e.Data.GetData(typeof(DraggedItem)) as DraggedItem;
            if (draggedItem != null && draggedItem.SourceListBox != null && draggedItem.SourceListBox != listBox)
            {
                // Add the item to the target ListBox and remove it from the source ListBox
                listBox.Items.Add(draggedItem.Item);
                draggedItem.SourceListBox.Items.Remove(draggedItem.Item);
            }
        }
    }
}
