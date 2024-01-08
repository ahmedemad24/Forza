using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmUser : Form
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

        public frmUser()
        {
            InitializeComponent();             
        }

        // Get User ID from ManagerUser form
        public string Uid
        {
            set { lblUid.Text = value; }
            get { return lblUid.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 
        

        // Load User Info for Update 
        public void GetUserById(string Uid)
        {
            string strSQL = "SELECT u.*, r.name roleName FROM tbl_User u " 
                            + "LEFT JOIN tbl_Roles r ON u.roleId = r.id " 
                            + "WHERE u.id = '" + Uid + "' ";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtUser = DataAccess.GetDataTable(strSQL);

            //lblUid.Text = dtUser.Rows[0]["id"].ToString();
            txtUserFullName.Text = dtUser.Rows[0]["name"].ToString();
            txtAddress.Text = dtUser.Rows[0]["address"].ToString();
            txtEmailaddress.Text = dtUser.Rows[0]["email"].ToString();
            txtContact.Text = dtUser.Rows[0]["contact"].ToString();
            dtDOB.Value =DateTime.Parse(dtUser.Rows[0]["dob"].ToString());
            txtUsername.Text = dtUser.Rows[0]["user_name"].ToString();
            txtPassword.Text = dtUser.Rows[0]["password"].ToString();
            lblImageName.Text =dtUser.Rows[0]["image_name"].ToString();
                        
            string path = Application.StartupPath + @"\Images\" + dtUser.Rows[0]["image_name"].ToString() + "";
            pbxUserImage.ImageLocation = path;
            pbxUserImage.InitialImage.Dispose();
            
            var roleName = dtUser.Rows[0]["roleName"].ToString();
            if (roleName == "")
            {
                userRoleCmb.Text = "--Select UserType--";
            }
            else
            {
                userRoleCmb.Text = dtUser.Rows[0]["roleName"].ToString();
            }

        }
       
        private int GetNextUserId()
        {
            int NextId;

            string sql = "SELECT id FROM tbl_User ORDER BY id DESC";
            DataTable dt = DataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                NextId = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) + 1;
            }
            else
            {
                NextId = 1;
            }
            return NextId;
        }


        private void frmUser_Load(object sender, EventArgs e)
        {
            if (UserInfo.RoleId != 1)
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
            try
            { 
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        public void LoadUserList(string SearchText="")
        {
            floUserList.Controls.Clear();
            string strSQL=string.Empty;
            string img_directory = Application.StartupPath + @"\Images\";
            string[] files = Directory.GetFiles(img_directory, "*.jpg *.png"); // "*.png"

            try
            {
                if (SearchText != string.Empty)
                {
                    strSQL = "SELECT * FROM tbl_User WHERE name like '" + SearchText + "%' OR user_name LIKE '" + SearchText + "%' " +
                          " OR contact LIKE '" + SearchText + "%' ";
                }
                else
                {
                    strSQL = "SELECT * FROM tbl_User";
                }

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnUser = new Button();
                    btnUser.Tag = dataReader["id"];
                    btnUser.Click += new EventHandler(btnUser_Click);
                    btnUser.Name = dataReader["name"].ToString() + "\n Contact: " + dataReader["contact"].ToString();

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(128, 128);
                    il.Images.Add(Image.FromFile(img_directory + dataReader["image_name"]));

                    btnUser.Image = il.Images[0];
                    btnUser.Margin = new Padding(2, 2, 2, 2);

                    btnUser.Size = new Size(148, 200);

                    btnUser.Text += "\n UId: " + dataReader["user_name"];
                    btnUser.Text += "\n Name: " + dataReader["name"].ToString();

                    btnUser.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnUser.TextAlign = ContentAlignment.BottomCenter;
                    btnUser.TextImageRelation = TextImageRelation.ImageAboveText;
                    btnUser.FlatStyle = FlatStyle.Flat;
                    btnUser.FlatAppearance.BorderSize = 0;
                    floUserList.Controls.Add(btnUser);
                    currentImage++;
                }
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Users Found";
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        protected void btnUser_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();

            this.Uid = s;
        }


        private void Clear()
        {
            lblUid.Text = "-";
            txtUserFullName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmailaddress.Text = string.Empty;
            lblImageName.Text = string.Empty;
            dtDOB.Text = string.Empty;
            pbxUserImage.Image = cypos.Properties.Resources.no_image;
            btnSave.BackgroundImage = cypos.Properties.Resources.save100x45;
            LoadUserList();
            txtUserFullName.Focus();

            string sqlQuery = "SELECT id,name FROM tbl_Roles WHERE IsDeleted = 0 ";
            DataTable dt = DataAccess.GetDataTable(sqlQuery);
            DataRow dataRow = dt.NewRow();
            dataRow["id"] = 0;
            dataRow["name"] = "--Select UserType--";
            dt.Rows.InsertAt(dataRow, 0);
            userRoleCmb.DataSource = dt;
            userRoleCmb.DisplayMember = "name";
            userRoleCmb.ValueMember = "id";
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtUserFullName.Text == "" )
            {
                Messages.InformationMessage("Please enter user's full name");
                txtUserFullName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                Messages.InformationMessage("Please enter address");
                txtAddress.Focus();
            }
            else if (txtContact.Text == ""  )
            {
                Messages.InformationMessage("Please enter contact nos.");
                txtContact.Focus();
            }
            else if (txtEmailaddress.Text == "")
            {
                Messages.InformationMessage("Please enter email address");
                txtEmailaddress.Focus();
            }
            else if (txtUsername.Text == "")
            {
                Messages.InformationMessage("Please enter user name");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                Messages.InformationMessage("Please enter password");
                txtPassword.Focus();
            }
            else if (userRoleCmb.Items.Count == 0)
            {
                Messages.InformationMessage("Please select user type");
            }
            else
            {
                try
                {
                    string userRole = userRoleCmb.Items.Count == 0 ? "" : userRoleCmb.Text;
                    string roleId = userRoleCmb.SelectedValue.ToString();

                    if(lblUid.Text == "-")
                    {
                        string strImageName = txtUsername.Text + lblFileExtension.Text;

                        string strSQLInsert = "INSERT INTO tbl_User (name, address,contact,email, dob , user_name , password , user_type , image_name, roleId) " +
                                              "VALUES('" + txtUserFullName.Text + "', '" + txtAddress.Text + "', '" + txtEmailaddress.Text + "', " +
                                              "'" + txtContact.Text + "',  '" + dtDOB.Value.ToString("yyyy-MM-dd") + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "', " +
                                              "'" + userRole + "', '" + strImageName + "', " + int.Parse(roleId) + ")";
                        DataAccess.ExecuteSQL(strSQLInsert);

                        //Picture Upload
                        string strPath = Application.StartupPath + @"\Images\";
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(strPath + @"\" + strImageName);

                        if (!System.IO.Directory.Exists(strPath))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Images\");
                        string filename = strPath + @"\" + openFileDialog1.SafeFileName;
                        pbxUserImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(strPath + @"\" + openFileDialog1.SafeFileName, strPath + @"\" + strImageName);
                        //Messages.SavedMessage();
                        Clear();
                    }
                    else // Update info
                    {
                        string imageName;
                        if (lblFileExtension.Text == "user.png")
                        {
                            imageName = lblImageName.Text;  //Unchange pictures
                        }
                        else  //When change 
                        {
                            imageName = lblImageName.Text;
                        }                   
                       
                        string strSQLUpdate = "UPDATE tbl_User set  name = '" + txtUserFullName.Text + "', " +
                        " address = '" + txtAddress.Text + "', email = '" + txtEmailaddress.Text + "', contact = '" + txtContact.Text + "', " +
                        " dob = '" + dtDOB.Value.ToString("yyyy-MM-dd") + "' , user_name= '" + txtUsername.Text + "', password = '" + txtPassword.Text + "',image_name = '" + imageName + "' ,    " +
                        " user_type    = '" + userRole + "', roleId = " + int.Parse(roleId) + " WHERE (id = '" + lblUid.Text + "' )";
                        DataAccess.ExecuteSQL(strSQLUpdate);        

                        //Update image
                        if (lblFileExtension.Text != "user.png")
                        {
                            pbxUserImage.InitialImage.Dispose();
                            string path = Application.StartupPath + @"\Images\";
                            System.IO.File.Delete(path + @"\" + lblImageName.Text);
                            if (!System.IO.Directory.Exists(path))
                                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Images\");
                            string filename = path + @"\" + openFileDialog1.SafeFileName;
                            pbxUserImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        }

                        //Messages.UpdatedMessage();
                        Clear();
                    }
 
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }

        // Reset  
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
          

        private void btnBrowse_Click(object sender, EventArgs e)
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
                //lblImageName.Text = openFileDialog1.FileName;
                pbxUserImage.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        private void txtEmailaddress_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmailaddress.Text.Length > 0 && txtEmailaddress.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txtEmailaddress.Text.Trim()))
                {
                    lblEmailerrormsg.Visible = true;
                    lblEmailerrormsg.Text = "Invalid Email address";
                    txtEmailaddress.SelectAll();
                }
                else
                {
                    btnSave.Enabled = true;
                    lblEmailerrormsg.Visible = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.DeleteMessage();

            if (result ==true)
            {

                if (lblUid.Text == "-")
                {
                    Messages.InformationMessage("The record could not be deleted.");
                }
                else
                {
                    try
                    {
                        string sql = "DELETE FROM tbl_User WHERE (id = '" + lblUid.Text + "' )";
                        DataAccess.ExecuteSQL(sql);

                        pbxUserImage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\Images\";
                        System.IO.File.Delete(path + @"\" + lblImageName.Text);

                        Messages.DeletedMessage();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        Messages.ExceptionMessage(ex.Message);
                    }
                }
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            LoadUserList(txtSearchUser.Text);
        }

        private void lblUid_TextChanged(object sender, EventArgs e)
        {
            if (lblUid.Text != "-")
            {
                GetUserById(lblUid.Text);
                btnSave.BackgroundImage = cypos.Properties.Resources.update100x45;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pbxUserImage.Image = cypos.Properties.Resources.no_image;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
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

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void btnKbName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtUserFullName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtAddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbContactNo_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtContact);
            frmKeyboard.ShowDialog();
        }

        private void btnKbEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmailaddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbUserName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtUsername);
            frmKeyboard.ShowDialog();
        }

        private void btnKbPassword_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPassword);
            frmKeyboard.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUserAccess frmUserAccess = new frmUserAccess();
            frmUserAccess.ShowDialog();
        }
    }
}
