using cypos.Reports;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
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
    public partial class frmSelectDeliveryMan : Form
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

        private frmDeliveryOrders _frmDeliveryOrders;

        public frmSelectDeliveryMan()
        {
        }
        public List<int> OrderIds = new List<int>();

        public frmSelectDeliveryMan(frmDeliveryOrders _frm, List<int> any)
        {
            InitializeComponent();
            _frmDeliveryOrders = _frm;
            OrderIds = any;
        }

        public class ListItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public ListItem(int value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void frmSelectDeliveryMan_Load(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM tbl_DeliveryMan WHERE IsDeleted = 0";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtDelivery = DataAccess.GetDataTable(strSQL);
            deliverymanDD.DataSource = dtDelivery;
            deliverymanDD.DisplayMember = "name";
            deliverymanDD.ValueMember = "id";
            comboBoxEdit1.Properties.AppearanceDropDown.Font = new Font(comboBoxEdit1.Font.FontFamily, 12);
            foreach (DataRow item in dtDelivery.Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string name = item["name"].ToString();

                comboBoxEdit1.Properties.Items.Add(new ListItem(id, name)); 
            }

            
        }

        private void setDeliveryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var orderIds = OrderIds;
                var stringOrderIds = string.Join(",", orderIds.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray());
                var deliveryId = int.Parse(deliverymanDD.SelectedValue.ToString());
                int selectedId = 0;
                if (comboBoxEdit1.SelectedItem is ListItem selectedListItem)
                {
                    selectedId = selectedListItem.Value;
                }
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    
                string strSQLInsert = $"UPDATE tbl_TempHeader SET deliveryman_id = {selectedId} " +
                    $",delivery_date ='{now}' WHERE tbl_TempHeader.id  in ({stringOrderIds})";
                DataAccess.ExecuteSQL(strSQLInsert);

                rprtInvoiceReceipt rprt = new rprtInvoiceReceipt(stringOrderIds);
                ReportPrintTool printTool = new ReportPrintTool(rprt);
                printTool.ShowPreviewDialog();
                //this.Close();
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void setDeliveryBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Select Deivery Man", setDeliveryBtn);
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Close", pbxClose);
        }
    }
}
