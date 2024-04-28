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
using cypos.Reports;
using DevExpress.XtraReports.UI;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using DevExpress.Data.Helpers;
using System.Data.SqlClient;

namespace cypos
{
    public partial class frmLogin : Form
    {
        private TextBox txtFocused = null;
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("E$Pn9Tb6VQ8j#gK1&zXy4Fc7RmW2h5L!");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("Xy2Kp8$9fA!3L7z@Gh");

        #region Taskbar
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }

        [DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        private enum GetWindowCmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        // The taskbar's window handle.
        private IntPtr TaskbarHWnd, StartButtonHWnd;
        #endregion
        public frmLogin()
        {
            InitializeComponent();

            #region Hide Taskbar
            // Get the taskbar's and start button's window handles.
            TaskbarHWnd = FindWindow("Shell_traywnd", "");
            StartButtonHWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);

            // Hide the taskbar and start button.
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);

            // Maximize.
            this.Bounds = Screen.PrimaryScreen.Bounds;
            #endregion

            

            txtPassword.KeyDown += txtPassword_KeyDown;

            //Payment Panel
            Point pt = pnlLogin.PointToScreen(new Point(0, 0));
            pnlLogin.Parent = this;
            pnlLogin.Location = new Point(
            this.ClientSize.Width / 2 - pnlLogin.Size.Width / 2,
            this.ClientSize.Height / 4 - pnlLogin.Size.Height / 4);
            pnlLogin.Anchor = AnchorStyles.None;
            //pnlLogin.Location = this.PointToClient(pt);
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
            else if (txtPassword.Text == "")
            {
                Messages.WarningMessage("Please enter password");
                txtPassword.Focus();
            }
            else
            {
                try
                {

                    var IsValid = CheckActivation();
                    if (IsValid)
                    {

                        string strSQL = "SELECT user_name, password, user_type, id, roleId  FROM  tbl_User " +
                                        "WHERE user_name   = '" + txtUserName.Text + "' and password = '" + txtPassword.Text + "'";

                        DataTable dt = DataAccess.GetDataTable(strSQL);

                        if (dt.Rows.Count != 0)
                        {
                            string strUserName = dt.Rows[0].ItemArray[0].ToString();
                            string strPassword = dt.Rows[0].ItemArray[1].ToString();
                            string strUserType = dt.Rows[0].ItemArray[2].ToString();
                            string strUserId = dt.Rows[0].ItemArray[3].ToString();
                            int strRoleId = int.Parse(dt.Rows[0].ItemArray[4].ToString());

                            if (txtUserName.Text == strUserName && txtPassword.Text == strPassword)
                            {
                                UserInfo.UserName = strUserName;
                                UserInfo.UserType = strUserType;
                                UserInfo.Userid = strUserId;
                                UserInfo.RoleId = strRoleId;

                                string queryForUserRoles = $"SELECT * FROM tbl_RolesDetails rd "
                                                         + $"WHERE rd.role_id = {strRoleId} ";

                                DataTable dtForUserRoles = DataAccess.GetDataTable(queryForUserRoles);
                                if (dtForUserRoles.Rows.Count > 0)
                                {
                                    foreach (DataRow item in dtForUserRoles.Rows)
                                    {
                                        UserInfo.Privilege.Add(int.Parse(item["form_id"].ToString()));
                                    }
                                }
                                if (UserInfo.IsVaild(1)||UserInfo.UserType=="Admin")
                                {
                                    frmLanguagePopUp languagePopUp = new frmLanguagePopUp();
                                    languagePopUp.ShowDialog();
                                    if (StartShift())
                                    {
                                        WriteLoginRecords();
                                        

                                        frmMain frmMain = new frmMain();

                                        var UpdateUSer = UpdateUserNumberOfActiveInLogin(int.Parse(strUserId));
                                        if (UpdateUSer)
                                        {
                                            if (Activation.ChickActivation())
                                            {
                                                frmMain.Show();
                                                this.Hide();
                                            }
                                            else
                                            {
                                                frm_Activation frm = new frm_Activation();
                                                this.Hide();
                                                frm.Show();
                                            }
                                        }
                                        else
                                        {
                                            lblmsg.Visible = true;
                                            lblmsg.Text = "هذا الحساب مستخدم حاليا";
                                        }
                                    }
                                    else
                                    {
                                        lblmsg.Visible = true;
                                        lblmsg.Text = "Sorry, You have to save your shift. Login again ,please.";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, You don't have access to this form");
                                }
                            }
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Username or Password does not match";
                        }
                    }
                    else
                    {
                        Messages.ExceptionMessage("Activation isn't valid");
                    }
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                    frm_DBConnect frm = new frm_DBConnect();
                    frm.ShowDialog();
                }
            }
        }


        private bool UpdateUserNumberOfActiveInLogin(int userId)
        {

            string strSQL = "SELECT Active,LoggedDeviceId  FROM  tbl_User WHERE id   = '" + userId + "'";

            DataTable dt = DataAccess.GetDataTable(strSQL);
            if (dt.Rows.Count != 0)
            {
                var IsActive = dt.Rows[0].ItemArray[0];
                var LoggedDeviceId = dt.Rows[0].ItemArray[1];
                string DeviceId = UserInfo.GetDeviceId();
                if(IsActive != DBNull.Value && (bool)IsActive == true && (LoggedDeviceId == DBNull.Value || LoggedDeviceId.ToString() != DeviceId)) 
                {
                    return false;
                }

                string strSQLStock = $"update tbl_User set Active = 1 ,LoggedDeviceId= '{DeviceId}' where id = '{userId}' ";
                DataAccess.ExecuteSQL(strSQLStock);
            }
            return true;
        }

        

        private bool CheckActivation()
        {
            string strSQL = "SELECT top(1) ExpireDate  FROM  SettingTable ";
            DataAccess._ConnectionString = Properties.Settings.Default.CYPOSConnectionString;
            DataTable dt = DataAccess.GetDataTable(strSQL);

            if (dt.Rows.Count != 0)
            {
                byte[] ExpireDate = (byte[])dt.Rows[0].ItemArray[0] ;

                var Activation = DecryptData(ExpireDate);

                string strSQL2 = "SELECT Count(*) NumberOfActive  FROM  tbl_User Where Active = 1 ";

                DataTable dt2 = DataAccess.GetDataTable(strSQL2);
                if (dt.Rows.Count != 0)
                {
                    int NumberOfActive = (int)dt2.Rows[0].ItemArray[0] ;
                    if (NumberOfActive >= Activation.NumberDevices)
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "لا يوجد اجهزة متاحة للاتصال الرجاء التواصل مع البائع لتفعيل البرنامج";
                        return false;
                    }
                }

                if (IsDateExpired(Activation.EndDate.Value))
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "لقد انتهت مدة الاشتراك";
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public class DecryptDataResult
        {
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int? NumberDevices { get; set; }
        }
         
        public DecryptDataResult DecryptData(byte[] encryptedValue )
        {
            DecryptDataResult result = new DecryptDataResult();
            string passphrase = "E$Pn9Tb6VQ8j#gK1&zXy4Fc7RmW2h5L!";

            // Define the parameters
            SqlParameter[] parameters = {
            new SqlParameter("@EncryptedValue", SqlDbType.VarBinary) { Value = encryptedValue },
            new SqlParameter("@EncryptedKey", SqlDbType.NVarChar, 100) { Value = passphrase }};

            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();
                    // Create a SqlCommand object for the stored procedure
                    using (SqlCommand command = new SqlCommand("DecryptData", connection))
                    {
                        // Set the command type as stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        // Add the parameters to the command
                        command.Parameters.AddRange(parameters);
                        // Execute the stored procedure
                        SqlDataReader reader = command.ExecuteReader();
                        // Process the results if needed
                        if (reader.Read())
                        {
                            result.StartDate = reader["StartDate"] as DateTime?;
                            result.EndDate = reader["EndDate"] as DateTime?;
                            result.NumberDevices = reader["NumberDevices"] as int?;
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during database access
                lblmsg.Visible = true;
                lblmsg.Text = ex.Message;
            }
            return result;
        }

        public  bool IsDateExpired(DateTime targetDate)
        {
            DateTime currentDate = DateTime.Now;
            return targetDate < currentDate;
        }

        private SettingConfigurationDto DecryptDates(byte[] encryptedDates)
        {
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.KeySize = 256;
                rijndael.BlockSize = 128;
                rijndael.Key = Key.Take(32).ToArray(); // Use the first 32 bytes for the key
                rijndael.IV = IV.Take(16).ToArray(); // Use the first 16 bytes for the IV
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;

                using (var decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV))
                using (var ms = new MemoryStream(encryptedDates))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    string decryptedString = sr.ReadToEnd();
                    string[] dateStrings = decryptedString.Split(new[] { "#|||#" }, StringSplitOptions.RemoveEmptyEntries);

                    DateTime startDate = DateTime.ParseExact(dateStrings[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(dateStrings[1], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                    int NumberDevices = int.Parse(dateStrings[2]);

                    return new SettingConfigurationDto() { StartDate = startDate.Date, EndDate = endDate.Date, NumberDevices = NumberDevices };
                }
            }
        }

        public bool StartShift()
        {
            string sqlQuery = "select id from tbl_userShifts where end_ShiftDate is null And userId=" + UserInfo.Userid;
            DataTable dt = DataAccess.GetDataTable(sqlQuery);

            if (dt.Rows.Count == 0)
            {
                // Start new shift
                ShiftStartFrm frmStartShift = new ShiftStartFrm();
                frmStartShift.userId = UserInfo.Userid;
                frmStartShift.ShowDialog();
                if (frmStartShift.userId == null)
                { //user rejected to save the shift
                    return false;
                }
                else
                { // Start the shift
                    sqlQuery = "Insert into tbl_UserShifts (id,userId,start_ShiftDate,StartAmount) " + " values (" +frmStartShift.ShiftCode+" , "+
                        frmStartShift.userId + ", '" + frmStartShift.startDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' , " + frmStartShift.Amount+" )";
                    int success = DataAccess.ExecuteSQL(sqlQuery);
                    UserInfo.UserShiftCode = frmStartShift.ShiftCode.ToString();
                    return true;
                }
            }
            else
            { // the shift is already opened
                UserInfo.UserShiftCode = dt.Rows[0].ItemArray[0].ToString();
                return true;
            }
        }

        public void WriteLoginRecords()
        {
            string logdate = DateTime.Now.ToString("yyyy-MM-dd");
            string logtime = DateTime.Now.ToString("HH:mm:ss");
            string logdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string strSQL = "INSERT INTO tbl_UserLogs (user_name, log_type, log_date, log_time) " +
                            " values ('" + UserInfo.UserName + "' , 'IN' , '" + logdate + "' , " +
                            " '" + logtime + "')";
            DataAccess.ExecuteSQL(strSQL);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            UserInfo.Privilege.Clear();
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
            SetWindowPosFlags.SWP_SHOWWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
            SetWindowPosFlags.SWP_SHOWWINDOW);
            Environment.Exit(0);
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



        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                SqlHelper Helper = new SqlHelper(Properties.Settings.Default.CYPOSConnectionString);
                if (!Helper.isConnection)
                {
                    frm_DBConnect frm = new frm_DBConnect();
                    frm.ShowDialog();
                }
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var X = config.ConnectionStrings.ConnectionStrings["Connection"].ConnectionString;
                //if (Properties.Settings.Default.CYPOSConnectionString.Length == 0)
                //{
                //    frm_DBConnect frm = new frm_DBConnect();
                //    frm.ShowDialog();
                //}
            }
            catch
            {
                Messages.ExceptionMessage("Error In Connection");
                frm_DBConnect frm = new frm_DBConnect();
                frm.ShowDialog();
            }
            
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            keyPad1.KeyPadReturnValue = txtPassword.Text;
            txtFocused = (TextBox)txtPassword;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformLogin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_DBConnect frm = new frm_DBConnect();
            frm.ShowDialog();
        }

        private void PerformLogin()
        {
            btnLogin_Click(null, EventArgs.Empty);
        }

    }
}
