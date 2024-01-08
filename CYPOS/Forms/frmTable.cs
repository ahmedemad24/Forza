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
using DevExpress.XtraPrinting.BarCode;
using iTextSharp.text.pdf.qrcode;
using System.Drawing.Printing;
using QRCoder;
using QRCodeGenerator = QRCoder.QRCodeGenerator;
using QRCode = QRCoder.QRCode;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Configuration;

namespace cypos
{
    public partial class frmTable : Form
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

        public frmTable(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }
	


        public string TableId
        {
            set { lblTableId.Text = value;} 
            get{return lblTableId.Text;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtTableName.Text == "") 
                 { 
                     Messages.InformationMessage("Enter table name"); 
                     txtTableName.Focus(); 
                 }
                else
                 {
                     if (lblTableId.Text == "-")
                     {
                         if (DataAccess.RecordExits("tbl_Tables", "table_name", txtTableName.Text) ==1)
                         {
                             Messages.InformationMessage("Table already exist");
                             txtTableName.Focus();
                         }
                         else
                         {
                            int result;
                            if (int.TryParse(tableNumTxt.Text, out result))
                            {
                                string strSQLInsert = " INSERT INTO tbl_Tables (table_name,no_of_chairs,location_id, table_NO) " +
                                    "VALUES ('" + txtTableName.Text + "','" + txtNoOfChairs.Text + "'" +
                                    ",'" + cmbLocation.SelectedValue + "', " + tableNumTxt.Text + ")";
                                DataAccess.ExecuteSQL(strSQLInsert);
                                LoadTableList("");
                                Clear();
                            }
                            else
                            {
                                Messages.ExceptionMessage("You should enter the table number in digits only!");
                            }
                         }
                     }
                     else 
                     {
                         string strSQLUpdate = "UPDATE tbl_Tables SET table_name = '" + txtTableName.Text + "'," +
                              " no_of_chairs= '" + txtNoOfChairs.Text + "', " +
                              " location_id= '" + cmbLocation.SelectedValue + "', " +
                              " table_NO = " + int.Parse(tableNumTxt.Text) + "" +
                              " WHERE id = '" + lblTableId.Text + "'";
                         DataAccess.ExecuteSQL(strSQLUpdate);
                         LoadTableList("");
                         Clear();
                         OpenedForms.Close();
                     }
                 }         
            }
            catch (Exception ex)
            {
                int res;
                if (!int.TryParse(tableNumTxt.Text, out res))
                    Messages.ExceptionMessage("You should enter the table number in digits only!");
                else
                    Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserType != "Admin")
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
            try
            {
                //Table Location
                string strSQL = "SELECT id,location_name FROM tbl_TableLocation ORDER BY location_name";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtLocation = DataAccess.GetDataTable(strSQL);
                cmbLocation.DataSource = dtLocation;
                cmbLocation.ValueMember = "id";
                cmbLocation.DisplayMember = "location_name";

                LoadTableList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void Clear()
        {
            lblTableId.Text = "-";
            txtTableName.Clear();
            txtNoOfChairs.Text = "0";
            cmbLocation.SelectedIndex = 0;
            txtTableName.Focus();
        }

        public void LoadTableList(string value="")
        {
            floTableList.Controls.Clear();

            try
            {
                string strSQL = "SELECT * FROM tbl_Tables WHERE (table_name like '" + value + "%' ) ORDER BY table_NO";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Tables Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnTable = new Button();
                    btnTable.Name = dataReader["id"].ToString();
                    btnTable.Tag = dataReader["id"];
                    btnTable.Text = "Table" + "\n " + dataReader["table_name"].ToString();
                    //btnTable.Text += dataReader["no_of_chairs"].ToString();

                    btnTable.Margin = new Padding(3, 3, 3, 3);
                    btnTable.Size = new Size(100, 50);

                    btnTable.Font = new System.Drawing.Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnTable.TextAlign = ContentAlignment.MiddleCenter;
                    btnTable.Click += new EventHandler(btnTable_Click);
                    floTableList.Controls.Add(btnTable);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnTable_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.TableId = s;
        }

   
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenedForms.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.DeleteMessage();

            if (result == true)
            {
                if (lblTableId.Text != "-")
                {
                    string strSQLDelete = "DELETE FROM tbl_Tables WHERE id = '" + lblTableId.Text.ToString() + "'";
                    DataAccess.ExecuteSQL(strSQLDelete);
                    //Messages.DeletedMessage();
                    LoadTableList("");
                    Clear();
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

        private void lblTableId_TextChanged(object sender, EventArgs e)
        {
            if (lblTableId.Text != "-")
            {
                GetTableById(lblTableId.Text);
                btnDelete.Visible = true;
            }
        }

        private void GetTableById(string TableId)
        {
            string strSQL = "SELECT * FROM tbl_Tables WHERE (id ='" + TableId + "' )";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtTable = DataAccess.GetDataTable(strSQL);

            lblTableId.Text = dtTable.Rows[0]["id"].ToString();
            txtTableName.Text = dtTable.Rows[0]["table_name"].ToString();
            txtNoOfChairs.Text = dtTable.Rows[0]["no_of_chairs"].ToString();
            cmbLocation.SelectedValue = int.Parse(dtTable.Rows[0]["location_id"].ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTableList(txtSearch.Text.ToString());
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtNoOfChairs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearch);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTable_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTableName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbNoOfCharge_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtNoOfChairs);
            frmNumberboard.ShowDialog();
        }

        private void qrBtn_Click(object sender, EventArgs e)
        {
            string baseURL = ConfigurationManager.AppSettings["BaseURL"];
            if (lblTableId.Text == "-")
            {
                var warningMsg = MessageBox.Show("There is no specific information for a table. Do you want to generate and print QR codes for all tables?"
                    , "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (warningMsg == DialogResult.OK)
                {
                    foreach (Button button in floTableList.Controls.OfType<Button>())
                    {
                        string tableId = button.Tag.ToString();
                        string qrCodeUrl = baseURL + tableId;
                        Bitmap qrCode = GenerateQRCode(qrCodeUrl);
                        SaveQRCodeAsPdf(qrCode, tableId);
                    }
                    MessageBox.Show("All Tables QRCodes has successfully Printed");
                }
            }
            else
            {
                string tableId = lblTableId.Text;
                string qrCodeUrl = baseURL + tableId;
                Bitmap qrCode = GenerateQRCode(qrCodeUrl);
                PrintQRCode(qrCode);
            }
        }

        private Bitmap GenerateQRCode(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }

        private void GenerateAndPrintQRCodeForUniqueId()
        {
            string baseURL = ConfigurationManager.AppSettings["BaseURL"];
            string uniqueId = Guid.NewGuid().ToString();
            string qrCodeUrl = baseURL + uniqueId;
            Bitmap qrCode = GenerateQRCode(qrCodeUrl);
            PrintQRCode(qrCode);
        }

        private string saveDirectoryPath = null;
        private void SaveQRCodeAsPdf(Bitmap qrCode, string tableId)
        {
            try
            {
                if (saveDirectoryPath == null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = $"qrCode-{tableId}.pdf";
                    saveFileDialog.Filter = "PDF files|*.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        saveDirectoryPath = Path.GetDirectoryName(saveFileDialog.FileName);
                    }
                }

                string fileName = $"qrCode-{tableId}.pdf";
                string filePath = Path.Combine(saveDirectoryPath, fileName);

                using (Document document = new Document())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                    document.Open();
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(qrCode, System.Drawing.Imaging.ImageFormat.Bmp);
                    document.Add(image);
                }
            }
            catch(Exception) { }
        }

        private void PrintQRCode(Bitmap qrCode)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawImage(qrCode, new PointF(100, 100));
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
                MessageBox.Show("QRCode has successfully Printed");
            }
            else
            {
                MessageBox.Show("The operation canceled!");
            }
        }

        private void carQrBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateAndPrintQRCodeForUniqueId();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong! message: " + ex.Message + "");
            }
        }

        private void qrBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Generate and print QRCode for table/s.", qrBtn);
        }

        private void carQrBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Generate and print QRCode for TAKEAWAY.", carQrBtn);
        }
    }
}
