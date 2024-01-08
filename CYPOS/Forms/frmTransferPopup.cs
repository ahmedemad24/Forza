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
    public partial class frmTransferPopup : Form
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

        public bool Transfered = false;
        frmMain _frmMain = new frmMain();
        public frmTransferPopup(frmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Close", pbxClose);
        }

        private void transferItemsBtn_Click(object sender, EventArgs e)
        {
            frmTransferItemsPopup frmTransferItemsPopup = new frmTransferItemsPopup(_frmMain,this);
            frmTransferItemsPopup.ShowDialog();
            if (Transfered)
            {
                Transfered = false;
                _frmMain.Clear();
                this.Close();
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

        private void transferTableBtn_Click(object sender, EventArgs e)
        {
            int headerID = _frmMain.tempHeaderId;
            int tableId = _frmMain.tableeId;
            frmTransferTablePopup frmTransferTablePopup = new frmTransferTablePopup(headerID, tableId, this);
            frmTransferTablePopup.ShowDialog();
            if (Transfered) 
            {
                Transfered = false;
                _frmMain.Clear();
                this.Close();
            }
        }
    }
}
