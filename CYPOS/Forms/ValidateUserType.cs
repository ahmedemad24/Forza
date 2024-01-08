using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using cypos.Updates.Forms;
using cypos.Forms;
using cypos.Class;
using System.Configuration;

namespace cypos
{
    public partial class ValidateUserType : Form
    {
        private TextBox txtFocused = null;
        public string userId;
        public string userType;
        public ValidateUserType()
        {
            InitializeComponent();

            //Payment Panel
            Point pt = pnlLogin.PointToScreen(new Point(0, 0));
            pnlLogin.Parent = this;
            pnlLogin.Location = this.PointToClient(pt);
            pnlLogin.BringToFront();

            btnExit.Enabled = false;
            WireAllControls(keyPad1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                Messages.WarningMessage("Please enter username");
                txtUserName.Focus();
                
            }
            else if ( txtPassword.Text == "")
            {
                Messages.WarningMessage("Please enter password");
                txtPassword.Focus();               
            }
            else
            {
                try
                {
                    string strSQL = "SELECT id, user_type FROM  tbl_User  " + 
                                    "WHERE user_name   = '" + txtUserName.Text + "' and password = '" + txtPassword.Text + "'";
                    DataTable dt = DataAccess.GetDataTable(strSQL);

                    if (dt.Rows.Count != 0)
                    {
                        userId = dt.Rows[0].ItemArray[0].ToString();
                        userType = dt.Rows[0].ItemArray[1].ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "Username or Password does not match";
                    }
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ValidateUserType ValidateUserType = new ValidateUserType();
            ValidateUserType.Show();
            this.Hide();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Progress(); 
        }

        public void Progress()
        { 

            progressBar1.Increment(5);
            lblProgress.Text = " " + progressBar1.Value.ToString() + "%";
            if (lblProgress.Text == " 100%")
            {
                timer1.Stop();
                btnExit.Enabled = true;
                btnLogin.Enabled = true;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }


        #region KeyPad

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctrl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
            //to get the Textbox Focused
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Enter += textBox_Enter;
            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            txtFocused = (TextBox)sender;
            keyPad1.KeyPadReturnValue = txtFocused.Text;
        }

        private void ctrl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);

            if (txtFocused != null)
            {
                // put something in textbox
                txtFocused.Text = keyPad1.KeyPadReturnValue;
            }
        }

        #endregion

        private void btnFocusPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnFocusUser_Click(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            keyPad1.KeyPadReturnValue = txtUserName.Text;
            txtFocused = (TextBox)txtUserName;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            keyPad1.KeyPadReturnValue = txtPassword.Text;
            txtFocused = (TextBox)txtPassword;
        }

        private void ValidateUserType_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                userId = userType = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
