using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos.Forms
{
    public partial class frmOrderTypesPopup : DevExpress.XtraEditors.XtraForm
    {
        private frmMain _frmMain;
        private bool isArabicLang = UserInfo.IsArabicLangSelected;
        public frmOrderTypesPopup(frmMain frmMain)
        {
            _frmMain = frmMain;
            InitializeComponent();
        }

        private void frmOrderTypesPopup_Load(object sender, EventArgs e)
        {
            this.Text = isArabicLang ? "نوع الأوردر" : "Order Type";
            var orderTypes = Company.OrderTypes;

            for (int i = 0; i < orderTypes.Count; i++)
            {
                OrderType OrderType = orderTypes[i];
                SimpleButton btnItem = new SimpleButton();
                btnItem.Tag = OrderType.Id;
                btnItem.Click += new EventHandler(btn_Click);
                string details = OrderType.Name;
                btnItem.Name = details;
                btnItem.Margin = new Padding(3, 5, 3, 3);
                btnItem.Size = new Size(120, 70);
                btnItem.ImageOptions.SvgImage = svgImageCollection1[OrderType.SVGLogo];
                btnItem.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
                btnItem.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
                btnItem.Font = new Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point);
                btnItem.Text += " " + (UserInfo.IsArabicLangSelected ? OrderType.LabelAr : OrderType.LabelEn);
                stackPanel1.Controls.Add(btnItem);
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            if ((int)((DevExpress.XtraEditors.SimpleButton)sender).Tag == 3)
            {
                do if (_frmMain.lblCustomerId.Text == "0")
                    {
                        frmCustomerPopup frmCustomerPopup = new frmCustomerPopup(_frmMain);
                        frmCustomerPopup.ShowDialog();
                        if (_frmMain.lblCustomerId.Text == "0")
                        {
                            var res = MessageBox.Show("Customer is required", "Customer is required for delivery order", MessageBoxButtons.OKCancel);
                            if (res != DialogResult.OK)
                                break;
                        }
                    } while (_frmMain.lblCustomerId.Text == "0");
                if (_frmMain.lblCustomerId.Text != "0")
                    _frmMain.SetOrderType((int)((DevExpress.XtraEditors.SimpleButton)sender).Tag, ((DevExpress.XtraEditors.SimpleButton)sender).Text);
            }
            else
            {
                _frmMain.SetOrderType((int)((DevExpress.XtraEditors.SimpleButton)sender).Tag, ((DevExpress.XtraEditors.SimpleButton)sender).Text);
            }
            this.Close();
        }
    }
}