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
    public partial class frmCompany : Form
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

        public frmCompany()
        {
            InitializeComponent();
            
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void frmCompany_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserType != "Admin")
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
            try
            {
                string strSQL = "SELECT TOP 1 * FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCompany = DataAccess.GetDataTable(strSQL);

                txtCompanyName.Text = dtCompany.Rows[0]["company_name"].ToString();
                txtCompanyAddress.Text = dtCompany.Rows[0]["company_address"].ToString();
                txtEmail.Text = dtCompany.Rows[0]["email"].ToString();
                txtPhone.Text = dtCompany.Rows[0]["company_phone"].ToString();
                txtWebSite.Text = dtCompany.Rows[0]["web"].ToString();
                txtTax1Name.Text = dtCompany.Rows[0]["tax1_name"].ToString();
                txtTax1Rate.Text = dtCompany.Rows[0]["tax1_rate"].ToString();
                txtTax2Name.Text = dtCompany.Rows[0]["tax2_name"].ToString();
                txtTax2Rate.Text = dtCompany.Rows[0]["tax2_rate"].ToString();
                txtTaxRegNo.Text = dtCompany.Rows[0]["tax_no"].ToString();
                txtFootermsg.Text = dtCompany.Rows[0]["footer_message"].ToString();

                //if (dtCompany.Rows[0]["cal_method"].ToString() == "0" )
                //{
                //    rdbNoTax.Checked = true;
                //}
                if (dtCompany.Rows[0]["tax_type"].ToString() == "0")
                {
                    rdbNoTax.Checked = true;
                }
                if (dtCompany.Rows[0]["tax_type"].ToString() == "1")
                {
                    rdbLevel1.Checked = true;
                }
                if (dtCompany.Rows[0]["tax_type"].ToString() == "2")
                {
                    rdbLevel2.Checked = true;
                }

                if (dtCompany.Rows[0]["cal_method"].ToString() == "1")
                {
                    rdbCalBase1.Checked = true;

                }
                if (dtCompany.Rows[0]["cal_method"].ToString() == "2")
                {
                    rdbCalBase2.Checked = true;

                }

                string strImagePath = Application.StartupPath + @"\Images\" + dtCompany.Rows[0]["logo"].ToString();
                pbxLogo.ImageLocation = strImagePath;
                pbxLogo.InitialImage.Dispose();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "" || txtCompanyAddress.Text == "" || txtPhone.Text == "" || txtTax1Rate.Text == "")
            {
                Messages.WarningMessage("Enter company details.");
            }
            else
            {
                try
                {
                    int strTaxtype = 0;
                    int intCalMethod = 0;

                    if (rdbNoTax.Checked)
                        strTaxtype = 0;
                    else if (rdbLevel1.Checked)
                        //  strTaxtype = rdbLevel1.Text.Trim().Replace(" ", string.Empty);
                        strTaxtype = 1;
                    else if (rdbLevel2.Checked)
                        //strTaxtype = rdbLevel2.Text.Trim().Replace(" ", string.Empty);
                        strTaxtype = 2;



                    if (rdbCalBase1.Checked)
                        intCalMethod = 1;
                    else if (rdbCalBase2.Checked)
                        intCalMethod = 2;


                    string strLogo = txtCompanyName.Text.Substring(0, txtCompanyName.Text.IndexOf(' ')).ToLower() + "_logo" + lblFileExtension.Text;

                    string strSQLUpdate = "UPDATE tbl_Company SET company_name= N'" + txtCompanyName.Text + "', company_address = N'" + txtCompanyAddress.Text + "'," +
                            " company_phone = '" + txtPhone.Text + "', email = '" + txtEmail.Text + "', web = '" + txtWebSite.Text + "'," +
                            " tax_no = '" + txtTaxRegNo.Text + "' , footer_message = N'" + txtFootermsg.Text + "' , logo = '" + strLogo + "'," +
                            " tax_type = '" + strTaxtype + "', tax1_name = '" + txtTax1Name.Text + "', tax1_rate = '" + txtTax1Rate.Text + "'," +
                            " tax2_name = '" + txtTax2Name.Text + "', tax2_rate= '" + txtTax2Rate.Text + "', cal_method = '" + intCalMethod + "'";
                    DataAccess.ExecuteSQL(strSQLUpdate);

                    ///////////////////// Logo upload  /////////////////
                    string path = Application.StartupPath + @"\Images\";
                    System.IO.File.Delete(path + @"\" + strLogo);
                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Images\");
                    string filename = path + @"\" + openFileDialog1.SafeFileName;
                    pbxLogo.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                    System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + strLogo);

                    this.Close();
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }

        private void txtTax1Rate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTax2Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtTax2Rate.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //  openFileDialog1.InitialDirectory = @"C:\";
                //  openFileDialog1.Title = "Browse Text Files";

                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = ".jpg";
                // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
                openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg| PNG Files (*.png)|*.png";

                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                //openFileDialog1.ReadOnlyChecked = true;
                //openFileDialog1.ShowReadOnly = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pbxLogo.ImageLocation = openFileDialog1.FileName;
                    lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pbxLogo.Image = cypos.Properties.Resources.logo;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
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

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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

        private void rdbNoTax_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNoTax.Checked)
            {
                grpTax1.Enabled = false;
                grpTax2.Enabled = false;
                grpCalMethod.Enabled = false;
            }
        }

        private void rdbLevel1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLevel1.Checked)
            {
                grpTax1.Enabled = true;
                grpTax2.Enabled = false;
                grpCalMethod.Enabled = false;
            }
        }

        private void rdbLevel2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLevel2.Checked)
            {
                grpTax1.Enabled = true;
                grpTax2.Enabled = true;
                grpCalMethod.Enabled = true;
            }
        }

        private void btnKbCompany_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCompanyName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCompanyAddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbPhone_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPhone);
            frmKeyboard.ShowDialog();
        }

        private void btnKbEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmail);
            frmKeyboard.ShowDialog();
        }

        private void btnKbWebsite_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtWebSite);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTaxRegNo_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTaxRegNo);
            frmKeyboard.ShowDialog();
        }

        private void btnKbMessage_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtFootermsg);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTax1_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTax1Name);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTax2_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTax2Name);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTax1Rate_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTax1Rate);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTax2Rate_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTax2Rate);
            frmKeyboard.ShowDialog();
        }     
    }
}
