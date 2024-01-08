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
    public partial class frmSideItemsPopup : Form
    {
        frmMain _frmMain = new frmMain();
        ErrorLog objerror = new ErrorLog();
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
        public frmSideItemsPopup(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void GetItems()
        {
            string query = "SELECT * FROM tbl_Item WHERE parent_item_id = " + _frmMain.ItemId + "";
            DataAccess.ExecuteSQL(query);
            DataTable dt = DataAccess.GetDataTable(query);
            LoadItems(dt);
        }

        //private void CenterFormOnScreen()
        //{
        //    // Calculate the center coordinates of the screen
        //    int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        //    int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        //    int formWidth = this.Width;
        //    int formHeight = this.Height;
        //    int centerX = (screenWidth - formWidth) / 2;
        //    int centerY = (screenHeight - formHeight) / 2;

        //    // Set the form's location to center it on the screen
        //    this.Location = new Point(centerX, centerY);
        //}

        private void LoadItems(DataTable dtItems)
        {
            panel1.Controls.Clear();

            try
            {
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    DataRow dataReader = dtItems.Rows[i];

                    Button btnItem = new Button();
                    btnItem.FlatStyle = FlatStyle.Popup;
                    btnItem.FlatAppearance.BorderColor = Color.Gray;
                    btnItem.BackgroundImage = Properties.Resources.item_button_bg;
                    btnItem.Tag = dataReader["id"];
                    btnItem.Click += new EventHandler(_frmMain.btnItem_Click);
                    btnItem.Click += new EventHandler(this.pbxClose_Click);

                    string details = dataReader["item_name"].ToString();
                    btnItem.Name = details;
                    btnItem.Margin = new Padding(3, 5, 3, 3);
                    btnItem.Size = new Size(95, 100);

                    btnItem.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
                    btnItem.TextAlign = ContentAlignment.MiddleCenter;
                    btnItem.TextImageRelation = TextImageRelation.ImageAboveText;

                    btnItem.Text += dataReader["item_name"].ToString();
                    panel1.Controls.Add(btnItem);
                    
                }
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - LoadItems", Global.ERROR_WRITE_PATH);
            }
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

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }

        private void frmSideItemsPopup_Load(object sender, EventArgs e)
        {
            GetItems();
        }
    }
}
