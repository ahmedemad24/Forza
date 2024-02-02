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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using cypos.Forms;
using cypos.Reports;
using DevExpress.XtraReports.UI;

namespace cypos
{
    public partial class frmPayment : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        private frmMain _frmMain;
        private frmInvoiceReceipts _frmInvoice;
        private string strInvoiceNo; 
        private int invoiceId;
        private int? CustomerId;
        public bool IsDeliveryOrder;
        public bool IsInstallment;
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

        public string InvoiceNo
        {
            set { strInvoiceNo = value; }
            get { return strInvoiceNo; }
        }

        public int InvoiceId
        {
            set { invoiceId = value; }
            get { return InvoiceId; }
        }
        public int? customerId
        {
            set { this.CustomerId= value; }
            get { return this.CustomerId; }
        }
        public string Payable
        {
            set { lblPayable.Text = value; }
            get { return lblPayable.Text; }
        }

        public List<int> OrderIds = new List<int>();
        int OrderTypes = 0;
        public frmPayment(frmMain _frm, List<int> any)
        {
            InitializeComponent();
            OrderIds = any;
            _frmMain = _frm;
            OrderTypes = 3;
            formFunctionPointer += new functioncall(Replicate); // Coin and papernotes
            moneyPad1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumericKeypad);
            moneyPad1.NumaricKeypad = numformFunctionPointer;
            txtPaidAmount.Text = "0";
            lblChangeAmount.Text = "0";

            if (UserInfo.IsVaild(16))
            {
                GiftBtn.Visible = true;
            }
            else
            {
                GiftBtn.Visible = false;
            }
            if (UserInfo.IsVaild(17))
            {
                btnAvoid.Visible = true;
            }
            else
            {
                btnAvoid.Visible = false;
            }
            if (UserInfo.IsVaild(18))
            {
                btnPrint.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
            }
            if (UserInfo.IsVaild(69))
            {
                int itemsCount = _frmMain.dgvItemList.Rows.Count;
                if (itemsCount == 1 || itemsCount == 0)
                {
                    splitCheckBtn.Visible = false;
                }
                else
                {
                    splitCheckBtn.Visible = true;
                }
            }
            else
            {
                splitCheckBtn.Visible = false;
            }
        }

        public frmPayment(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            formFunctionPointer += new functioncall(Replicate); // Coin and papernotes
            moneyPad1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumericKeypad);
            moneyPad1.NumaricKeypad = numformFunctionPointer;
            txtPaidAmount.Text = "0";
            lblChangeAmount.Text = "0";


            if (UserInfo.IsVaild(22))
            {
                GiftBtn.Visible = true;
            }
            else
            {
                GiftBtn.Visible = false;
            }
            if (UserInfo.IsVaild(23))
            {
                btnAvoid.Visible = true;
            }
            else
            {
                btnAvoid.Visible = false;
            }
            if (UserInfo.IsVaild(24))
            {
                btnPrint.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
            }
            if (UserInfo.IsVaild(69))
            {
                int itemsCount = _frmMain.dgvItemList.Rows.Count;
                if (itemsCount == 1 || itemsCount == 0)
                {
                    splitCheckBtn.Visible = false;
                }
                else
                {
                    splitCheckBtn.Visible = true;
                }
            }
            else
            {
                splitCheckBtn.Visible = false;
            }
        }

        public frmPayment(frmInvoiceReceipts _frm)
        {
            InitializeComponent();
            _frmInvoice = _frm;
            IsInstallment = true;
            _frmMain = new frmMain();
            formFunctionPointer += new functioncall(Replicate); // Coin and papernotes
            moneyPad1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumericKeypad);
            moneyPad1.NumaricKeypad = numformFunctionPointer;
            txtPaidAmount.Text = "0";
            lblChangeAmount.Text = "0";


            if (UserInfo.IsVaild(22))
            {
                GiftBtn.Visible = true;
            }
            else
            {
                GiftBtn.Visible = false;
            }
            if (UserInfo.IsVaild(23))
            {
                btnAvoid.Visible = true;
            }
            else
            {
                btnAvoid.Visible = false;
            }
            if (UserInfo.IsVaild(24))
            {
                btnPrint.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
            }
            if (UserInfo.IsVaild(69))
            {
                int itemsCount = _frmMain.dgvItemList.Rows.Count;
                if (itemsCount == 1 || itemsCount == 0)
                {
                    splitCheckBtn.Visible = false;
                }
                else
                {
                    splitCheckBtn.Visible = true;
                }
            }
            else
            {
                splitCheckBtn.Visible = false;
            }
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (lblPayable.Text == "")
            {
                //Messages.InformationMessage("Llease enter amount");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(txtPaidAmount.Text) >= Convert.ToDouble(lblPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(txtPaidAmount.Text) - Convert.ToDouble(lblPayable.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        lblChangeAmount.Text = changeAmt.ToString("N2");
                        lblDueAmount.Text = "0";
                        this.AcceptButton = btnPrint;
                    }
                    if (Convert.ToDouble(txtPaidAmount.Text) <= Convert.ToDouble(lblPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(lblPayable.Text) - Convert.ToDouble(txtPaidAmount.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        lblDueAmount.Text = changeAmt.ToString("N2");
                        lblChangeAmount.Text = "0";
                        this.AcceptButton = btnPrint;
                    }

                }
                catch (Exception)
                {
                    lblChangeAmount.Text = "0";
                    //Messages.ExceptionMessage(exp.Message);
                }
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

        #region Currency Pad
        public delegate void functioncall(string currencyvalue);
        public delegate void numvaluefunctioncall(string Numvalue);

        private event functioncall formFunctionPointer;
        private event numvaluefunctioncall numformFunctionPointer;

        private void Replicate(string currencyvalue)
        {
            if (currencyvalue == "XX") // All clear
            {
                txtPaidAmount.Text = "";
            }
            else if (currencyvalue == "BXC") //Backspace
            {
                if ((String.Compare(txtPaidAmount.Text, " ") < 0))
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1 + 1);
                }
                else
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1);
                }
                txtPaidAmount.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtPaidAmount.Text))
                {
                    txtPaidAmount.Text = "0.00";
                    txtPaidAmount.Text = (Convert.ToDouble(txtPaidAmount.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                else
                {
                    txtPaidAmount.Text = (Convert.ToDouble(txtPaidAmount.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                txtPaidAmount.Focus();
            }

        }

        private void NumericKeypad(string Numvalue)
        {
            if (Numvalue == ".")
            {
                if (!txtPaidAmount.Text.Contains('.'))
                {
                    txtPaidAmount.Text += Numvalue;
                    txtPaidAmount.Focus();
                }
            }
            else
            {
                txtPaidAmount.Text += Numvalue;
                txtPaidAmount.Focus();
            }
        }
        #endregion

        private void frmPayment_Load(object sender, EventArgs e)
        {
            if (OrderTypes == 3)
            {
                btnPrint.Visible = false;
            }
            LoadPaymentTypes();
            txtPaidAmount.Text = lblPayable.Text;
            lblDueAmount.Text = "0";
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPaidAmount.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }

        private void btnSaveOnly_Click(object sender, EventArgs e)
        {
            if (txtPaidAmount.Text == string.Empty) 
                txtPaidAmount.Text = "0";
            if (IsInstallment)
            {
                if (this.CustomerId == null)
                {
                    MessageBox.Show("Please Select Customer");
                    frmCustomerPopup customerPopup = new frmCustomerPopup(_frmMain);
                    customerPopup.ShowDialog();
                }
                else
                {
                    //ValidateUserType validateFrm = new ValidateUserType();
                    //validateFrm.ShowDialog();
                    if (UserInfo.UserType == "Admin")
                    {
                        try
                        {
                            lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                            lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;
                            int invoiceId = this.invoiceId;
                            _frmMain.SaveInstallmentInvoice(invoiceId, Convert.ToDecimal(txtPaidAmount.Text));
                            this.Close();
                            _frmMain.Clear();
                        }
                        catch (Exception exp)
                        {
                            Messages.ExceptionMessage(exp.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry , Not Authorized");
                    }
                }
            }
            else
            {
                if (decimal.Parse(this.lblPayable.Text) > decimal.Parse(this.txtPaidAmount.Text))
                {
                    if ((_frmMain != null && (_frmMain.lblCustomerId.Text == "" || _frmMain.lblCustomerId.Text == "0"))) 
                    {
                        MessageBox.Show("Please Select Customer");
                        frmCustomerPopup customerPopup = new frmCustomerPopup(_frmMain);
                        customerPopup.ShowDialog();
                    }
                    else
                    {
                        //ValidateUserType validateFrm = new ValidateUserType();
                        //validateFrm.ShowDialog();

                        if (UserInfo.UserType == "Admin")
                        {
                            try
                            {
                                lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                                lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;
                                int invoiceId = this.invoiceId;
                                invoiceId = _frmMain.SaveInvoice(Convert.ToDecimal(lblPayable.Text), 0, Convert.ToDecimal(lblChangeAmount.Text), Convert.ToDecimal(lblDueAmount.Text) + Convert.ToDecimal(txtPaidAmount.Text), dtpDate.Text, dtpDate.Value.ToString("hh:mm tt"), lblPaymentType.Text, txtNote.Text, true, false, false);
                                _frmMain.SaveInstallmentInvoice(invoiceId, Convert.ToDecimal(txtPaidAmount.Text));
                                this.Close();
                                _frmMain.Clear();
                            }
                            catch (Exception exp)
                            {
                                Messages.ExceptionMessage(exp.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry , Not Authorized");
                        }
                    }
                }
                else
                {
                    try
                    {
                        lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                        lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;

                        if (OrderTypes == 3)
                        {
                            foreach(var id in OrderIds)
                            {
                                _frmMain.SaveDeliveryOrders(id, lblPaymentType.Text, txtNote.Text);
                            }
                        }
                        else
                        {
                        _frmMain.SaveInvoice(Convert.ToDecimal(lblPayable.Text), Convert.ToDecimal(txtPaidAmount.Text)
                            , Convert.ToDecimal(lblChangeAmount.Text), Convert.ToDecimal(lblDueAmount.Text), dtpDate.Text
                            , dtpDate.Value.ToString("hh:mm tt"), lblPaymentType.Text, txtNote.Text);
                        }
                        this.Close();
                    }
                    catch (Exception exp)
                    {
                        Messages.ExceptionMessage(exp.Message);
                    }
                }
            }
        }

        public void LoadPaymentTypes()
        {
            floPaymentTypes.Controls.Clear();
            try
            {
                string strSQL = "SELECT id, payment_type FROM tbl_PaymentType ORDER BY id";

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];
                    Button btnPaymentType = new Button();

                    //btnPaymentType.FlatStyle = FlatStyle.Flat;
                    //btnPaymentType.FlatAppearance.BorderSize = 1;
                    //btnPaymentType.FlatAppearance.BorderColor = Color.Gray;
                    //btnPaymentType.BackColor = Color.LightYellow;
                    btnPaymentType.Click += new EventHandler(btnPayType_Click);

                    btnPaymentType.Name = dataReader["id"].ToString();

                    btnPaymentType.Margin = new Padding(3, 3, 3, 3);

                    btnPaymentType.Size = new Size(100, 50);

                    btnPaymentType.Tag = dataReader["id"].ToString();
                    btnPaymentType.Text = dataReader["payment_type"].ToString();

                    btnPaymentType.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnPaymentType.TextAlign = ContentAlignment.MiddleCenter;
                    btnPaymentType.TextImageRelation = TextImageRelation.ImageBeforeText;

                    string strTag = btnPaymentType.Tag.ToString();
                    if (strTag == "1")//Cash
                    {
                        lblPaymentType.Text = "Cash";
                        btnPaymentType.BackgroundImage = Properties.Resources.accept_paytype;
                    }
                    floPaymentTypes.Controls.Add(btnPaymentType);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnPayType_Click(object sender, EventArgs e)
        {
            Button btnPayType = sender as Button;

            if (btnPayType.BackgroundImage == null)
            {
                //Clear All Seleted Buttons
                IEnumerable<Button> buttons = floPaymentTypes.Controls.OfType<Button>();
                foreach (Button btn in buttons)
                {
                    btn.BackgroundImage = null;
                }

                btnPayType.BackgroundImage = Properties.Resources.accept_paytype;
                lblPaymentType.Text = btnPayType.Text;
            }
            else
            {
                btnPayType.BackgroundImage = null;
                lblPaymentType.Text = "-";
            }
        }

        private void btnAvoid_Click(object sender, EventArgs e)
        {
            //_frmMain.Clear();
            //this.Close();
            try
            {
                if (txtPaidAmount.Text == string.Empty)
                    txtPaidAmount.Text = "0";
                lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;

                if (IsDeliveryOrder)
                {
                    foreach (var id in OrderIds)
                    {
                        _frmMain.SaveDeliveryOrders(id, lblPaymentType.Text, txtNote.Text, true, true);
                    }
                }
                else
                {
                    _frmMain.SaveInvoice(Convert.ToDecimal(lblPayable.Text), Convert.ToDecimal(txtPaidAmount.Text), 
                        Convert.ToDecimal(lblChangeAmount.Text), Convert.ToDecimal(lblDueAmount.Text), dtpDate.Text, 
                        dtpDate.Value.ToString("hh:mm tt"), lblPaymentType.Text, txtNote.Text,true,true);
                }

                this.Close();
            }
            catch (Exception exp)
            {
                Messages.ExceptionMessage(exp.Message);
            }
        }

        #region Direct print
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);
        }

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.1in</PageWidth>
                <PageHeight>11.0in</PageHeight>
                <MarginTop>0.2in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0.1in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }


        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool IsSuccess = false;
            int invoiceId=0;
            if (txtPaidAmount.Text == string.Empty) txtPaidAmount.Text = "0";
            if (Convert.ToDecimal(txtPaidAmount.Text) > 0)
            {
                if (IsDeliveryOrder)
                {
                    foreach (var id in OrderIds)
                    {
                        _frmMain.SaveDeliveryOrders(id, lblPaymentType.Text, txtNote.Text);
                    }
                }
                else
                {
                    if (IsInstallment)
                    {
                        if (this.CustomerId == null)
                        {
                            MessageBox.Show("Please Select Customer");
                            frmCustomerPopup customerPopup = new frmCustomerPopup(_frmMain);
                            customerPopup.ShowDialog();
                        }
                        else
                        {
                            //ValidateUserType validateFrm = new ValidateUserType();
                            //validateFrm.ShowDialog();
                            if (UserInfo.UserType == "Admin")
                            {
                                try
                                {
                                    lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                                    lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;
                                    invoiceId = this.invoiceId;
                                    _frmMain.SaveInstallmentInvoice(invoiceId, Convert.ToDecimal(txtPaidAmount.Text));
                                    IsSuccess = true;
                                }
                                catch (Exception exp)
                                {
                                    Messages.ExceptionMessage(exp.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sorry , Not Authorized");
                            }
                        }
                    }
                    else
                    {
                        if (decimal.Parse(this.lblPayable.Text) > decimal.Parse(this.txtPaidAmount.Text))
                        {
                            if ((_frmMain != null && (_frmMain.lblCustomerId.Text == "" || _frmMain.lblCustomerId.Text == "0")))
                            {
                                MessageBox.Show("Please Select Customer");
                                frmCustomerPopup customerPopup = new frmCustomerPopup(_frmMain);
                                customerPopup.ShowDialog();
                            }
                            else
                            {
                                //ValidateUserType validateFrm = new ValidateUserType();
                                //validateFrm.ShowDialog();

                                if (UserInfo.UserType == "Admin")
                                {
                                    try
                                    {
                                        lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                                        lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;
                                        invoiceId = this.invoiceId;
                                        invoiceId = _frmMain.SaveInvoice(Convert.ToDecimal(lblPayable.Text), 0, Convert.ToDecimal(lblChangeAmount.Text), Convert.ToDecimal(lblDueAmount.Text) + Convert.ToDecimal(txtPaidAmount.Text), dtpDate.Text, dtpDate.Value.ToString("hh:mm tt"), lblPaymentType.Text, txtNote.Text, true, false, false);
                                        _frmMain.SaveInstallmentInvoice(invoiceId, Convert.ToDecimal(txtPaidAmount.Text));
                                        IsSuccess = true;
                                    }
                                    catch (Exception exp)
                                    {
                                        Messages.ExceptionMessage(exp.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry , Not Authorized");
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                                lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;

                                if (OrderTypes == 3)
                                {
                                    foreach (var id in OrderIds)
                                    {
                                        _frmMain.SaveDeliveryOrders(id, lblPaymentType.Text, txtNote.Text);
                                    }
                                }
                                else
                                {
                                    invoiceId= _frmMain.SaveInvoice(Convert.ToDecimal(lblPayable.Text), Convert.ToDecimal(txtPaidAmount.Text)
                                        , Convert.ToDecimal(lblChangeAmount.Text), Convert.ToDecimal(lblDueAmount.Text), dtpDate.Text
                                        , dtpDate.Value.ToString("hh:mm tt"), lblPaymentType.Text, txtNote.Text);
                                }
                                IsSuccess = true;
                            }
                            catch (Exception exp)
                            {
                                Messages.ExceptionMessage(exp.Message);
                            }
                        }
                    }
                }
                if (OrderTypes == 3)
                    this.Close();

                if (IsSuccess && !IsDeliveryOrder)
                { 
                    if (Settings.PreviewBeforePrint)
                    {
                        rprtReceiptFromMain rprtForInvoice = new rprtReceiptFromMain(invoiceId);
                        ReportPrintTool printTool2 = new ReportPrintTool(rprtForInvoice);
                        printTool2.ShowPreview();
                    }
                    else
                    {
                        rprtReceiptFromMain rprtForInvoice = new rprtReceiptFromMain(invoiceId);
                        ReportPrintTool printTool2 = new ReportPrintTool(rprtForInvoice);
                        printTool2.Print();
                    }
                    this.Close();
                }
            }
        }

        private void btnExact_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Text = lblPayable.Text;
        }

        private void btnKbNote_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtNote);
            frmKeyboard.ShowDialog();
        }

        private void GiftBtn_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(this.lblPayable.Text) > decimal.Parse(this.txtPaidAmount.Text))
            {
                MessageBox.Show("يجب دفع المبلغ المستحق");
            }
            else
            {
                //ValidateUserType validateFrm = new ValidateUserType();
                //validateFrm.ShowDialog();

                if (UserInfo.UserType == "Admin")
                {
                    try
                    {
                        lblChangeAmount.Text = lblChangeAmount.Text == "" ? "0" : lblChangeAmount.Text;
                        lblDueAmount.Text = txtPaidAmount.Text == "0" ? lblPayable.Text : lblDueAmount.Text;

                        if (IsDeliveryOrder == true)
                        {
                            foreach (var id in OrderIds)
                            {
                                _frmMain.SaveDeliveryOrders(id, lblPaymentType.Text, txtNote.Text, true, false, true);
                            }
                        }

                        _frmMain.SaveInvoice(Convert.ToDecimal(lblPayable.Text), Convert.ToDecimal(txtPaidAmount.Text), Convert.ToDecimal(lblChangeAmount.Text), Convert.ToDecimal(lblDueAmount.Text), dtpDate.Text, dtpDate.Value.ToString("hh:mm tt"), lblPaymentType.Text, txtNote.Text,true, false, true);
                        this.Close();
                        _frmMain.Clear();
                    }
                    catch (Exception exp)
                    {
                        Messages.ExceptionMessage(exp.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Sorry , Not Authorized");
                }
            }
            
        }
        private void splitCheckBtn_Click(object sender, EventArgs e)
        {
            frmSplitChecksPopup frmSplitChecksPopup = new frmSplitChecksPopup(_frmMain);
            frmSplitChecksPopup.ShowDialog();
            if (!frmSplitChecksPopup.isCanceled)
            {
                this.Payable = frmSplitChecksPopup.Payable;
                this.InvoiceNo = frmSplitChecksPopup.InvNo;
                this.txtPaidAmount.Text = frmSplitChecksPopup.Payable;
            }
        }
    }
}
