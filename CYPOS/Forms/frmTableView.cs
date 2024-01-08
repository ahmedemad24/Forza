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
    public partial class frmTableView : Form
    {
         private frmMain _frmMain;  

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
	    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmTableView(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            LoadTableLocation();
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

        #region Table Management

        public void LoadTableLocation()
        {
            tbTableLocation.TabPages.Clear();
            try
            {
                //string strSQL = "SELECT DISTINCT Id,location_name FROM tbl_TableLocation";

                string strSQL = "SELECT DISTINCT tbl_Tables.location_id, tbl_TableLocation.location_name " +
                               "FROM tbl_Tables INNER JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    TabPage tp = new TabPage(dataReader["location_name"].ToString());
                    tp.Padding = new Padding(10, 10, 10, 10);
                    tp.Tag = dataReader["location_id"].ToString();
                    tp.BackColor = Color.White;
                    tbTableLocation.TabPages.Add(tp);

                    FlowLayoutPanel floPanel = new FlowLayoutPanel();
                    floPanel.Dock = DockStyle.Fill;
                    LoadTables(floPanel, int.Parse(tp.Tag.ToString()));
                    tp.Controls.Add(floPanel);
                }
            }
            catch (Exception exp)
            {
                Messages.ExceptionMessage(exp.Message);
            }
        }


        public void LoadTables(FlowLayoutPanel floPanel, int locationId)
        {
            floPanel.Controls.Clear();
            try
            {
                string strSQL = "SELECT DISTINCT CASE WHEN tbl_TempHeader.table_id > 0 THEN 1 ELSE 0 END AS locked," +
                                "tbl_Tables.id , tbl_Tables.table_name,ISNULL(tbl_TempHeader.no_of_guests,0) AS guest_count  FROM tbl_Tables " +
                                "LEFT JOIN tbl_TempHeader ON tbl_Tables.id = tbl_TempHeader.table_id " +
                                "WHERE tbl_Tables.location_id= " + locationId + " ORDER BY table_name";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Panel pnlTable = new Panel();
                    PictureBox pbxTableImage = new PictureBox();
                    Panel pnlTableName = new Panel();
                    Label lblTableName = new Label();
                    Label lblOrderCount = new Label();
                    PictureBox pbxTableStatus = new PictureBox();

                    pnlTable.BorderStyle = BorderStyle.FixedSingle;
                    pnlTable.Size = new Size(100, 100);
                    pbxTableImage.Cursor = Cursors.Hand;
                    lblTableName.Cursor = Cursors.Hand;
                    pbxTableStatus.Cursor = Cursors.Hand;
                    string strStatusName = dataReader["table_name"].ToString();
                    pbxTableStatus.Name = "pbx" + strStatusName.Replace(" ", "");
                    pbxTableImage.Image = cypos.Properties.Resources.table;
                    pbxTableImage.SizeMode = PictureBoxSizeMode.CenterImage;

                    pbxTableImage.Click += new EventHandler(Table_Click);
                    lblTableName.Click += new EventHandler(Table_Click);
                    pbxTableStatus.Click += new EventHandler(Table_Click);
                    lblOrderCount.Click += new EventHandler(Table_Click);

                    pbxTableImage.Parent = pnlTable;
                    lblOrderCount.Parent = pbxTableImage;
                    pnlTableName.Parent = pnlTable;
                    lblTableName.Parent = pnlTableName;
                    pbxTableStatus.Parent = pnlTableName;

                    pbxTableImage.Dock = DockStyle.Fill;
                    pnlTableName.Dock = DockStyle.Bottom;

                    lblTableName.AutoSize = false;

                    lblTableName.Dock = DockStyle.Fill;
                    pnlTableName.Height = 25;

                    pbxTableStatus.Dock = DockStyle.Right;

                    lblOrderCount.AutoSize = false;
                    lblOrderCount.Size = pbxTableImage.Size;
                    lblOrderCount.BackColor = Color.Transparent;
                    lblOrderCount.ForeColor = Color.Yellow;
                    lblOrderCount.BringToFront();

                    bool isLocked = Convert.ToBoolean(dataReader["locked"]);
                    if (isLocked)
                    {
                        pbxTableStatus.Image = cypos.Properties.Resources.status_red;
                    }
                    else
                    {
                        pbxTableStatus.Image = cypos.Properties.Resources.status_green;
                    }


                    pbxTableStatus.SizeMode = PictureBoxSizeMode.CenterImage;
                    pbxTableStatus.Width = 25;


                    pnlTableName.BackColor = Color.FromArgb(10, 41, 98);
                    lblTableName.Tag = dataReader["id"].ToString();
                    lblTableName.Text = dataReader["table_name"].ToString();

                    int tableId = int.Parse(dataReader["id"].ToString());

                    int ORDER_COUNT = Miscellaneous.TableOrderCount(tableId);
                    if (ORDER_COUNT != 0)
                    {
                        if (ORDER_COUNT == 1)
                        {
                            lblOrderCount.Text = ORDER_COUNT.ToString() + Environment.NewLine + "Order";
                        }
                        else
                        {
                            lblOrderCount.Text = ORDER_COUNT.ToString() + Environment.NewLine + "Orders";
                        }
                    }
                    else
                    {
                        lblOrderCount.Text = string.Empty;
                    }

                    lblOrderCount.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    lblTableName.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    pbxTableImage.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    pbxTableStatus.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    lblTableName.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    lblTableName.TextAlign = ContentAlignment.MiddleLeft;
                    lblTableName.ForeColor = Color.White;

                    lblOrderCount.Font = new Font("Tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);
                    lblOrderCount.TextAlign = ContentAlignment.MiddleCenter;

                    floPanel.Controls.Add(pnlTable);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        protected void Table_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label lblTable = sender as Label;
                string strTable = lblTable.Tag.ToString();

                string[] table = strTable.Split(',');
                string pbxStatus = table[2].ToString();
                if (pbxStatus.ToLower() == "true")
                {
                    string getHeaderId_Qry = $"select id from tbl_TempHeader where table_id={Convert.ToInt32(table[0])}";
                    DataTable dt = DataAccess.GetDataTable(getHeaderId_Qry);
                    string HeaderId = dt.Rows[0]["id"].ToString();
                    _frmMain.RecallInvoice(HeaderId);
                    this.Close();
                }
                else
                {
                    if (Settings.AskTable && !Settings.AskGuestCount && !Settings.AskWaiter)
                    {
                        //_frmMain.Clear();
                        _frmMain.SetTable(int.Parse(table[0]), table[1].ToString(), 0, 0, string.Empty);
                        this.Close();
                    }
                    else if (Settings.AskTable && (Settings.AskGuestCount || Settings.AskWaiter))
                    {
                        //_frmMain.Clear();
                        frmOpenTable frmOpenTable = new frmOpenTable(_frmMain);
                        frmOpenTable.TableId = int.Parse(table[0]);
                        frmOpenTable.TableNo = table[1].ToString();
                        string strStatusName = table[1].ToString();
                        frmOpenTable.pbxStatusName = "pbx" + strStatusName.Replace(" ", "");
                        frmOpenTable.ShowDialog();
                        this.Close();
                    }
                }
                
            }
            else if (sender is PictureBox)
            {
                PictureBox pbxTable = sender as PictureBox;
                string strTable = pbxTable.Tag.ToString();

                string[] table = strTable.Split(',');

                if (Settings.AskTable && !Settings.AskGuestCount && !Settings.AskWaiter)
                {
                }
                else if (Settings.AskTable && (Settings.AskGuestCount || Settings.AskWaiter))
                {
                    string pbxStatus = table[2].ToString();
                }
            }
        }
        #endregion 
    }
}
