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
    public partial class frmCategory : Form
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

        public frmCategory(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }
	


        public string CategoryID
        {
            set { lblCategoryId.Text = value;} 
            get{return lblCategoryId.Text;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtCategoryName.Text == "") 
                 { 
                     Messages.InformationMessage("Enter category name"); 
                     txtCategoryName.Focus(); 
                 }
                else
                 {
                     if (lblCategoryId.Text == "-")
                     {
                         string strSQLInsert = " INSERT INTO tbl_Category (category_name,sort_order,back_color,fore_color,active) VALUES ('" + txtCategoryName.Text + "','" + txtSortOrder.Text + "','" + crpBackColor.Value.ToArgb() + "','" + crpForeColor.Value.ToArgb() + "','" + true + "')";
                         DataAccess.ExecuteSQL(strSQLInsert);
                         LoadCategoryList("");
                         Clear();
                     }
                     else 
                     {
                         string strSQLUpdate = "UPDATE tbl_Category SET category_name = '" + txtCategoryName.Text + "'," +
                              " sort_order= '" + txtSortOrder.Text + "', " +
                              " back_color= '" + crpBackColor.Value.ToArgb() + "', " +
                              " fore_color= '" + crpForeColor.Value.ToArgb() + "'," +
                              " active= '" + true + "'" +
                              " WHERE id = '" + lblCategoryId.Text + "'";
                         DataAccess.ExecuteSQL(strSQLUpdate);
                         LoadCategoryList("");
                         Clear();
                     }
                     _frmMain.LoadCategories();
                 }         
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserType != "Admin")
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
            try
            {
                LoadCategoryList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void Clear()
        {
            txtCategoryName.Clear();
            lblCategoryId.Text = "-";
            txtSortOrder.Clear();
            crpBackColor.Value = Color.White;
            crpForeColor.Value = Color.Black;
            txtCategoryName.Focus();
        }

        public void LoadCategoryList(string value="")
        {
            floCategoryList.Controls.Clear();

            try
            {
                string strSQL = "SELECT * FROM tbl_Category WHERE (category_name like '" + value + "%' ) ORDER BY sort_order";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Categories Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnCategory = new Button();
                    btnCategory.FlatStyle = FlatStyle.Flat;
                    btnCategory.FlatAppearance.BorderSize=0;
                    btnCategory.Name = dataReader["category_name"].ToString();
                    btnCategory.Tag = dataReader["id"];
                    btnCategory.Text = dataReader["category_name"].ToString();
                    btnCategory.BackColor = Color.FromArgb(int.Parse(dataReader["back_color"].ToString()));
                    btnCategory.ForeColor = Color.FromArgb(int.Parse(dataReader["fore_color"].ToString()));
                    btnCategory.Margin = new Padding(3, 3, 3, 3);
                    btnCategory.Size = new Size(125, 50);

                    btnCategory.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    btnCategory.TextAlign = ContentAlignment.MiddleCenter;
                    btnCategory.Click += new EventHandler(btnCategory_Click);
                    floCategoryList.Controls.Add(btnCategory);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.CategoryID = s;
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
                if (lblCategoryId.Text != "-")
                {
                    string sqldel = "DELETE FROM tbl_Category WHERE id = '" + lblCategoryId.Text.ToString() + "'";
                    DataAccess.ExecuteSQL(sqldel);
                    Messages.DeletedMessage();
                    LoadCategoryList("");
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

        private void lblCategoryId_TextChanged(object sender, EventArgs e)
        {
            if (lblCategoryId.Text != "-")
            {
                GetCategoryById(lblCategoryId.Text);
                btnDelete.Visible = true;
            }
        }

        private void GetCategoryById(string CategoryId)
        {
            string strSQL = "SELECT * FROM tbl_Category WHERE (id ='" + CategoryId + "' )";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtTable = DataAccess.GetDataTable(strSQL);

            //lblCategoryId.Text = dtTable.Rows[0].ItemArray[0].ToString();
            txtCategoryName.Text = dtTable.Rows[0]["category_name"].ToString();
            txtSortOrder.Text = dtTable.Rows[0]["sort_order"].ToString();
            crpBackColor.Value = Color.FromArgb(int.Parse(dtTable.Rows[0]["back_color"].ToString()));
            crpForeColor.Value = Color.FromArgb(int.Parse(dtTable.Rows[0]["fore_color"].ToString()));
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

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCategoryList(txtSearchCategory.Text.ToString());
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnKbCategory_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCategoryName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbSortOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtSortOrder);
            frmNumberboard.ShowDialog();
        }

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchCategory);
            frmKeyboard.ShowDialog();
        }
    }
}
