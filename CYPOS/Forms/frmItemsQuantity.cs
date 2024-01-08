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
    public partial class frmItemsQuantity : Form
    {
        frmMain _frmMain = new frmMain();
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
        public frmItemsQuantity(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }
        
        private void frmCommentPopup_Load(object sender, EventArgs e)
        {
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

        private void AddBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add item's quantity", AddBtn);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int result;

                if (!int.TryParse(QuantityTextBox.Text, out result))
                {
                    MessageBox.Show("This is a number only field");
                }
                else
                {
                    _frmMain.QtyValue = QuantityTextBox.Text;
                    this.Close();
                }
            }
            catch(Exception){}
        }
    }
}
