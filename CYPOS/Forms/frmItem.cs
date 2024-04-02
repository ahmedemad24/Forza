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
using System.Data.SqlClient;

namespace cypos
{
    public partial class frmItem : Form
    {
        private frmMain _frmMain;
        private byte[] BinaryImg;

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
        bool Success = false;
        /*********************************************/
        public frmItem()
        {
            InitializeComponent();
        }
        public frmItem(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
        }

        #region Item List

        public void LoadItemList()
        {
            try
            {
                //Item Category
                string strSQL = "SELECT id,category_name FROM tbl_Category WHERE active = 1 ORDER BY category_name";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCategory = DataAccess.GetDataTable(strSQL);
                cmbSearchCategory.DataSource = dtCategory;
                cmbSearchCategory.ValueMember = "id";
                cmbSearchCategory.DisplayMember = "category_name";

                LoadItemList("");

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        public void LoadItemList(string value)
            {
            floItemList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ItemImages\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
             {
                string strSQL = "SELECT tbl_Item.*, tbl_Category.category_name FROM tbl_Item " +
                              "LEFT JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                              "WHERE tbl_Item.parent_item_id IS NULL " +
                              "AND  (( tbl_Item.item_name LIKE N'" + value + "%' ) " +
                              "OR ( tbl_Item.item_code LIKE '" + value + "%' ) " +
                              ") ";
                int res;
                if (!string.IsNullOrEmpty(value) && int.TryParse(value,out res) )
                {
                    strSQL += "OR (tbl_Category.id = " + value + ") ";
                }
                              

                DataAccess.ExecuteSQL(strSQL);
                DataTable dt = DataAccess.GetDataTable(strSQL);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Items Found";



                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];
                    Button b = new Button();
                    //b.FlatStyle = FlatStyle.Flat;
                    //b.FlatAppearance.BorderSize = 1;
                    //b.FlatAppearance.BorderColor= Color.Gray;
                    //b.BackColor = Color.LightYellow;
                    b.Tag = dataReader["item_code"];
                    b.Click += new EventHandler(btnItem_Click);

                    b.Name = dataReader["id"].ToString(); 

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(32, 32);
                    if(File.Exists(img_directory + dataReader["image_name"]))
                        il.Images.Add(Image.FromFile(img_directory + dataReader["image_name"]));
                    else
                        il.Images.Add(Image.FromFile(img_directory + "item.png"));

                    b.Image = il.Images[0];
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(150, 50);

                    b.Text = " " + dataReader["item_code"] + "\n ";
                    b.Text += dataReader["item_name"].ToString();
                    b.Text += "\n Price: " + dataReader["selling_price"];

                    b.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    floItemList.Controls.Add(b);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.ItemCode = s;
        }

        #endregion

        public string ItemCode
        {
            set { lblItemCode.Text = value; }
            get { return lblItemCode.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region DataBind


        public int Item_id { get; set; }
        public string Item_name { get; set; }


        private void GetItemByCode()
        {
            string strSQL="SELECT id, item_code, item_name, cost_price, selling_price, discount," +
                          "category_id, image_name, tax_apply, show_kitchen, print_kot, show_pos,"+
                          "stock_item,reorder_level,active,sort_order, weightable, IsNull(parent_item_id, 0) parent_item_id FROM tbl_Item " +
                          "WHERE item_code = '" + lblItemCode.Text + "' AND parent_item_id IS NULL";

            DataAccess.ExecuteSQL(strSQL);
            DataTable dtItem = DataAccess.GetDataTable(strSQL);

            Item_id = int.Parse(dtItem.Rows[0]["id"].ToString());
            txtItemCode.Text = dtItem.Rows[0]["item_code"].ToString();
            txtItemName.Text = dtItem.Rows[0]["item_name"].ToString();
            Item_name = dtItem.Rows[0]["item_name"].ToString();
            txtCostPrice.Text = dtItem.Rows[0]["cost_price"].ToString();
            txtSellingPrice.Text = dtItem.Rows[0]["selling_price"].ToString();
            txtDiscount.Text = dtItem.Rows[0]["discount"].ToString();
            cmbCategory.SelectedValue =int.Parse(dtItem.Rows[0]["category_id"].ToString());

            lblImageName.Text = dtItem.Rows[0]["image_name"].ToString();
            string strImagePath = Application.StartupPath + @"\ItemImages\" + dtItem.Rows[0]["image_name"].ToString() + "";
            if (!File.Exists(strImagePath))
                strImagePath = Application.StartupPath + @"\ItemImages\" + "item.png";
            pbxItemImage.ImageLocation = strImagePath;
            pbxItemImage.InitialImage.Dispose();
            
            cbxTaxable.Checked = Convert.ToBoolean(dtItem.Rows[0]["tax_apply"]) ? true : false;
            cbxKitchenDisplay.Checked = Convert.ToBoolean(dtItem.Rows[0]["show_kitchen"]) ? true : false;
            cbxPrintInKot.Checked = Convert.ToBoolean(dtItem.Rows[0]["print_kot"]) ? true : false;
            cbxShowInPOS.Checked = Convert.ToBoolean(dtItem.Rows[0]["show_pos"]) ? true : false;
            cbxStockItem.Checked = Convert.ToBoolean(dtItem.Rows[0]["stock_item"]) ? true : false;
            cbxActive.Checked = Convert.ToBoolean(dtItem.Rows[0]["active"]) ? true : false;
            cbxWieghtable.Checked = Convert.ToBoolean(dtItem.Rows[0]["weightable"]) ? true : false;
            txtSortOrder.Text = dtItem.Rows[0]["sort_order"].ToString();
            txtReOrderLevel.Text = dtItem.Rows[0]["reorder_level"].ToString();

            parent_item_idLbl.Text = dtItem.Rows[0]["parent_item_id"].ToString();
        }


        private void frmItem_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserType != "Admin")
            {
                MessageBox.Show("لا تملك صلاحية للدخول علي هذه الشاشة");
                this.Close();
            }
            try
            {
                //Item Category
                string strSQL = "SELECT id,category_name FROM tbl_Category WHERE active=1 ORDER BY category_name ";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCategory = DataAccess.GetDataTable(strSQL);
                DataRow dr = dtCategory.NewRow();
                dr["id"] = 0;
                dr["category_name"] = "Select";
                dtCategory.Rows.InsertAt(dr, 0);
                cmbCategory.DataSource = dtCategory;
                cmbCategory.ValueMember = "id";
                cmbCategory.DisplayMember = "category_name";
                LoadItemList();
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion

        #region Insert , Update and delete Item
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == string.Empty )
            {
                Messages.InformationMessage("Enter item code");
                txtItemCode.Focus();
            }
            else if (txtItemName.Text == string.Empty)
            {
                Messages.InformationMessage("Enter item name");
                txtItemName.Focus();
            }
            else if (lblItemCode.Text == "-" && DataAccess.RecordExits("tbl_Item", "item_name", txtItemName.Text) > 0)
            {
                Messages.InformationMessage("Item name already exist");

                txtItemName.Focus();
            }
            else if (txtSellingPrice.Text == string.Empty)
            {
                Messages.InformationMessage("Enter selling price");
                txtSellingPrice.Focus();
            }
            else if (cmbCategory.SelectedValue.ToString() =="0")
            {
                Messages.InformationMessage("Select category");
                cmbCategory.Focus();
            }
            else
            {
                if (txtSortOrder.Text == string.Empty)
                {
                    txtSortOrder.Text = "0";
                }
                if (txtDiscount.Text == string.Empty)
                {
                    txtDiscount.Text = "0";
                }
                if (txtCostPrice.Text == string.Empty)
                {
                    txtCostPrice.Text = "0";
                }
                if (txtDiscount.Text == string.Empty)
                {
                    txtDiscount.Text = "0";
                }
                if (txtReOrderLevel.Text == string.Empty)
                {
                    txtReOrderLevel.Text = "0";
                }
                try
                {
                    bool TaxApply = cbxTaxable.Checked ? true : false;
                    bool ShowInKitchen = cbxKitchenDisplay.Checked ? true : false;
                    bool PrintInKot = cbxPrintInKot.Checked ? true : false;
                    bool ShowInPos = cbxShowInPOS.Checked ? true : false;
                    bool StockItem = cbxStockItem.Checked ? true : false;
                    bool Active = cbxActive.Checked ? true : false;
                    bool Weightable = cbxWieghtable.Checked ? true : false;

                    if (lblItemCode.Text == "-")
                    {
                        string imageName = txtItemCode.Text + lblFileExtension.Text;
                        string strSQLInsert = "INSERT INTO tbl_Item (ImgBinary,item_code, item_name,cost_price, selling_price, " +
                                              "discount,category_id, image_name, tax_apply,show_kitchen,print_kot," +
                                              "show_pos,stock_item,reorder_level,stock_quantity,sort_order,active, weightable) " +
                                              "VALUES (@Image, '" + txtItemCode.Text + "', N'" + txtItemName.Text + "','" + Convert.ToDecimal(txtCostPrice.Text) + "', " +
                                              "'" + Convert.ToDecimal(txtSellingPrice.Text) + "', '" + Convert.ToDecimal(txtDiscount.Text) + "', '" + cmbCategory.SelectedValue + "', " +
                                              "'" + imageName + "' , '" + TaxApply + "' , '" + ShowInKitchen + "','" + PrintInKot +
                                              "','" + ShowInPos + "','" + StockItem + "','" + Convert.ToDecimal(txtReOrderLevel.Text) + "','" + Convert.ToDecimal(txtOpeningStock.Text) + "','" + txtSortOrder.Text + "','" + Active + "', '" + Weightable + "')" +
                                              "Select @@identity";
                       
                        var imgParameter = new SqlParameter("@Image", SqlDbType.VarBinary, int.MaxValue);
                        if (BinaryImg == null || BinaryImg.Length == 0)
                            BinaryImg = Convert.FromBase64String("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");

                        imgParameter.Value = BinaryImg;
                        BinaryImg = new byte[0];
                        SqlParameter[] parameters = new SqlParameter[] { imgParameter };
                        var id = DataAccess.ExecuteScalarSQLParameters(strSQLInsert, parameters);
                        this.Item_id = id;
                        lblItemCode.Text = txtItemCode.Text;
                        //Add to Purchase Table
                        SavePurchase("OB",DateTime.Now.ToString(),Convert.ToDouble(txtOpeningStock.Text));
                        string path = Application.StartupPath + @"\ItemImages\";
                        System.IO.File.Delete(path + @"\" + imageName);
                        if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ItemImages\");
                        string filename = path + @"\" + openFileDialog1.SafeFileName;
                        pbxItemImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        //Clear();
                        Success = true;
                        LoadItemList();
                        //Messages.SavedMessage();
                    }
                    else  //Update
                    {
                        
                        string strImageName;
                        if (lblFileExtension.Text == "item.png") //if not select image
                        {
                            strImageName = lblImageName.Text;
                        }
                        else  // select image
                        {
                            strImageName = lblItemCode.Text + lblFileExtension.Text;
                        }
                        string strSQLUpdate = "";

                        strSQLUpdate = $"update tbl_Item" +
                                " set tax_apply = '" + TaxApply + "', " +
                                " show_kitchen = '" + ShowInKitchen + "', " +
                                " print_kot = '" + PrintInKot + "', " +
                                " show_pos = '" + ShowInPos + "', " +
                                " active = '" + Active + "', " +
                                " weightable = '" + Weightable + "'" +
                                $"where parent_item_id = (select id from tbl_Item where item_code='{txtItemCode.Text}')";

                        strSQLUpdate += "\n UPDATE tbl_Item SET item_code = '" + txtItemCode.Text + "', " +
                                    " item_name = N'" + txtItemName.Text + "', " +
                                    " cost_price = '" + txtCostPrice.Text + "', " +
                                    " selling_price = '" + txtSellingPrice.Text + "', " +
                                    " discount = '" + txtDiscount.Text + "', " +
                                    " category_id = '" + cmbCategory.SelectedValue + "', " +
                                    " image_name = '" + strImageName + "', " +
                                    " tax_apply = '" + TaxApply + "', " +
                                    " show_kitchen = '" + ShowInKitchen + "', " +
                                    " print_kot = '" + PrintInKot + "', " +
                                    " show_pos = '" + ShowInPos + "', " +
                                    " stock_item = '" + StockItem + "', " +
                                    " reorder_level = '" + txtReOrderLevel.Text + "', " +
                                    " sort_order = '" + txtSortOrder.Text + "', " +
                                    " active = '" + Active + "', " +
                                    " weightable = '" + Weightable + "'";
                        
                        //UpdateImgBinaryForAllItems();
                        //string strImagePath = Application.StartupPath + @"\ItemImages\" + strImageName + "";

                        //using (FileStream fs = new FileStream(strImagePath, FileMode.Open, FileAccess.Read))
                        //{
                        //    using (BinaryReader br = new BinaryReader(fs))
                        //    {
                        //        BinaryImg = br.ReadBytes((int)fs.Length);
                        //    }
                        //}
                        if (BinaryImg !=null && BinaryImg.Length != 0)
                        {
                            strSQLUpdate += ", ImgBinary = @Image " +
                                            " WHERE item_code = '" + lblItemCode.Text + "'";
                            var imgParameter = new SqlParameter("@Image", SqlDbType.VarBinary, int.MaxValue);
                            imgParameter.Value = BinaryImg;
                            BinaryImg = new byte[0];
                            SqlParameter[] parameters = new SqlParameter[] { imgParameter };
                            DataAccess.ExecuteSQLParameters(strSQLUpdate,parameters);
                        }
                        else
                        {
                            strSQLUpdate += " WHERE item_code = '" + lblItemCode.Text + "'";
                            DataAccess.ExecuteSQL(strSQLUpdate);
                        }



                        //Update Item Image
                        if (lblFileExtension.Text != "item.png") // if select image
                        {
                              pbxItemImage.InitialImage.Dispose();
                              string path = Application.StartupPath + @"\ItemImages\";

                              System.GC.Collect();
                              System.GC.WaitForPendingFinalizers();
                              System.IO.File.Delete(path + @"\" + lblImageName.Text);

                              if (!System.IO.Directory.Exists(path))
                                  System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ItemImages\");
                              string filename = path + @"\" + openFileDialog1.SafeFileName;
                              pbxItemImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                              System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + strImageName);
                          }
                        //Clear();
                        Success = true; 
                        LoadItemList();
                          //Messages.UpdatedMessage();
                          //_frmMain.LoadItems("",0,20);
                    }
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }
        private void UpdateImgBinaryForAllItems()
        {
            // Retrieve all records from tbl_Item
            string selectQuery = "SELECT item_code, image_name FROM tbl_Item";
            DataAccess.ExecuteSQL(selectQuery);
            DataTable dtCategory = DataAccess.GetDataTable(selectQuery);

            // Update the ImgBinary column for each record

            foreach (DataRow row in dtCategory.Rows)
            {

                string itemCode = row["item_code"].ToString();
                string imageName = row["image_name"].ToString();
                string updateQuery = "UPDATE tbl_Item SET ImgBinary = @ImageBinary WHERE item_code = '" +itemCode+"'";
                if (string.IsNullOrEmpty(imageName))
                {
                    imageName = "item.png";
                }
                // Read the image file and convert it to a byte array
                byte[] binaryImg;
                string strImagePath = Application.StartupPath + @"\ItemImages\" + imageName + "";
                using (FileStream fs = new FileStream(strImagePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        binaryImg = br.ReadBytes((int)fs.Length);
                    }
                }

                var imgParameter = new SqlParameter("@ImageBinary", SqlDbType.VarBinary, int.MaxValue);
                imgParameter.Value = binaryImg;
                BinaryImg = new byte[0];
                SqlParameter[] parameters = new SqlParameter[] { imgParameter };

                DataAccess.ExecuteSQLParameters(updateQuery, parameters);
            }
        }

        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        private void Clear()
        {
            Success = false;
            Item_id = 0;
            lblItemCode.Text = "-";
            txtItemCode.Enabled = true;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtSearchItem.Text = string.Empty;
            txtSortOrder.Text = string.Empty;
            txtReOrderLevel.Clear();
            cmbSearchCategory.Text = string.Empty;
            cmbCategory.SelectedValue = 0;
            cbxTaxable.Checked = false;
            cbxKitchenDisplay.Checked = false;
            cbxPrintInKot.Checked = false;
            cbxShowInPOS.Checked = true;
            cbxStockItem.Checked = false;
            cbxActive.Checked = true;
            cbxWieghtable.Checked = false;
            txtOpeningStock.Enabled = true;
            lblImageName.Text = "-";
            pbxItemImage.Image = Properties.Resources.no_image;
            btnSave.BackgroundImage = Properties.Resources.save100x45;

            if (Settings.AutoItemNo)
            {
                txtItemCode.ReadOnly = true;
                int nextNo = Settings.LastItemAutoNo + 1;
                txtItemCode.Text = nextNo.ToString();
            }
            else
            {
                txtItemCode.ReadOnly = false;
                txtItemCode.Clear();
            }

            txtItemCode.Focus();
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
            while (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((File.ReadAllBytes(openFileDialog1.FileName)).Length >= 500 * 1024)
                    MessageBox.Show("Please select image less than 500 KB ");
                else
                {
                    BinaryImg = File.ReadAllBytes(openFileDialog1.FileName);// image in bytes

                    pbxItemImage.ImageLocation = openFileDialog1.FileName;
                    lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
                    break;
                }
            }
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{

            //    BinaryImg = File.ReadAllBytes(openFileDialog1.FileName);// image in bytes

            //    pbxItemImage.ImageLocation = openFileDialog1.FileName;
            //    lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            //}
        }

        
        #endregion

     
        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtSellingPrice.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscount.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
      
       
        #region Purchase 

        public void SavePurchase(string strType,string strDate , double dblQty)
        {          
            string strItemId = txtItemCode.Text;      
            double dblPrice = Convert.ToDouble(txtSellingPrice.Text);

            string strSQLInsert = "INSERT INTO tbl_Purchase (purchase_date, ref_no, supplier_id, product_id,quantity, price, purchase_type) " +
                                  "VALUES ('" + strDate + "', '" + "" + "','" + 0 + "', '" + strItemId + "', '" + dblQty + "','"  + dblPrice + "' ,'" + strType + "' )";
            DataAccess.ExecuteSQL(strSQLInsert);
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.QuestionMessage("Do you want to Delete?");

            if (result == true)
            {

                if (lblItemCode.Text == "-")
                {
                    Messages.InformationMessage("The record could not be deleted.");
                }
                else
                {
                    try
                    {
                        string sql = "DELETE FROM tbl_Item WHERE item_code ='" + lblItemCode.Text + "'";
                        DataAccess.ExecuteSQL(sql);

                        pbxItemImage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\ItemImages\";
                        System.IO.File.Delete(path + @"\" + lblImageName.Text);
                        //Messages.InformationMessage("Successfully deleted");
                        Clear();
                        LoadItemList();
                    }
                    catch (Exception ex)
                    {
                        Messages.ExceptionMessage(ex.Message);
                    }
                }
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

        private void lblItemCode_TextChanged(object sender, EventArgs e)
        {
                if (lblItemCode.Text != "-")
                {
                    GetItemByCode();
                    txtItemCode.Enabled = false;
                    txtOpeningStock.Enabled = false;
                    btnSave.BackgroundImage = cypos.Properties.Resources.update100x45;
                    btnDelete.Visible = true;
                }
            //if (parent_item_idLbl.Text == "")
            //{
            //}
            //else
            //{
            //    MessageBox.Show("This item is already a side item and must not have any side items!");
            //}
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pbxItemImage.Image = cypos.Properties.Resources.no_image;
                BinaryImg =Convert.FromBase64String("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");
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string sqlitemcode = "SELECT item_code FROM tbl_Item WHERE item_code = '" + txtItemCode.Text + "' AND parent_item_id IS NULL ";
                DataAccess.ExecuteSQL(sqlitemcode);
                DataTable dtitemcode = DataAccess.GetDataTable(sqlitemcode);
                if (dtitemcode.Rows.Count > 0)
                {
                    this.ItemCode = txtItemCode.Text;
                    btnKbItemCode.Enabled = false;
                }
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

        private void btnKbSearchProduct_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchItem);
            frmKeyboard.ShowDialog(); 
        }


        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadItemList(txtSearchItem.Text);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void cmbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSearchCategory.SelectedIndex != -1 && cmbSearchCategory.SelectedIndex != 0)
                    LoadItemList(cmbSearchCategory.SelectedValue.ToString());
                else
                    LoadItemList("");

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtCostPrice.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
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

        private void txtReOrderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtReOrderLevel.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbItemCode_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtItemCode);
            frmKeyboard.ShowDialog();
        }

        private void btnKbSortOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtSortOrder);
            frmNumberboard.ShowDialog();
        }

        private void btnKbItemName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtItemName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbReOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtReOrderLevel);
            frmNumberboard.ShowDialog();
        }

        private void btnKbOpStock_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtOpeningStock);
            frmNumberboard.ShowDialog();
        }

        private void btnKbCost_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtCostPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbPrice_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtSellingPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbDiscount_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtDiscount);
            frmCurrencyboard.ShowDialog();
        }

        private void additionItemBtn_Click(object sender, EventArgs e)
        {
            if (this.Item_id == 0)
            {
                btnSave_Click(sender, e);
                if (!Success)
                    return;
            }
            frmSideItems frmSideItems = new frmSideItems(this);
            frmSideItems.ShowDialog();
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Save/Edit Item", btnSave);
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Clear All", btnClear);
        }

        private void additionItemBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add Sub Item", additionItemBtn);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Delete Item", btnDelete);
        }

        private void btnRemove_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Remove Image", btnRemove);
        }

        private void btnBrowse_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Show in File Exeplorer", btnBrowse);
        }
    }
}
