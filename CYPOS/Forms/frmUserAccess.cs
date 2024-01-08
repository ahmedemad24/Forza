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
using cypos.Forms;

namespace cypos
{
    public partial class frmUserAccess : Form
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

        public frmUserAccess()
        {
            InitializeComponent();
        }

        List<int> CheckedNodes = new List<int>();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmUser_Load(object sender, EventArgs e)
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

        private void addNewRoleBtn_Click(object sender, EventArgs e)
        {
            frmAddRole frmAddRole = new frmAddRole(this);
            frmAddRole.ShowDialog();
        }

        private void addNewRoleBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add New Role", addNewRoleBtn);
        }

        private void saveBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Save Changes", saveBtn);
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pbxClose);
        }

        private void rolesCmbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeFill();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //this function to add all checked value to list of int call CheckedNodes 
                CheckedIds(rolesTreeView.Nodes);

                 var roleId = rolesCmbbox.SelectedValue.ToString();
               
                string queryForDelete = $"DELETE FROM tbl_RolesDetails WHERE  role_id = {roleId} ";
                DataAccess.ExecuteSQL(queryForDelete);
                foreach (var item in CheckedNodes)
                {
                    string queryForInsert = $"INSERT INTO tbl_RolesDetails VALUES ({roleId} , {item})";
                    DataAccess.ExecuteSQL(queryForInsert);
                }
                MessageBox.Show("Successfull Changes");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                this.Close();
            }
        }
        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
        private void CheckedIds(System.Windows.Forms.TreeNodeCollection theNodes)
        {
            foreach (TreeNode node in rolesTreeView.Nodes)
            {
                if (node.Checked)
                {
                    CheckedNodes.Add(int.Parse(node.Tag.ToString()));
                 }
                GetSelectedNodes(node);
            }
        }
        private void GetSelectedNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked)
                {
                    CheckedNodes.Add(int.Parse(childNode.Tag.ToString()));
                }
                GetSelectedNodes(childNode);
            }
        }
        public void treeFill()
        {

            if (rolesCmbbox.SelectedIndex == 0)
            {

            }
            else
            {
            //var roleId = rolesCmbbox.SelectedValue.ToString();
            var roleId = rolesCmbbox.SelectedValue != null ? rolesCmbbox.SelectedValue.ToString() : "0";
                string query = $"select fs.id, fs.name, fs.title, rd.role_id , "
                         + $"case  when rd.form_id is null then  0 else 1 end checkbox   "
                         + $"from tbl_Forms fs "
                         + $"left join tbl_RolesDetails rd on  rd.form_id = fs.id and rd.role_id = {roleId} "
                         + $"where fs.parent_id is null ";
                DataTable dt = DataAccess.GetDataTable(query);

                rolesTreeView.Nodes.Clear();


                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode node = new TreeNode(dr["name"].ToString());
                    node.Tag = dr["id"].ToString();
                    if (dr["checkbox"].ToString() == "1")
                    {
                        node.Checked = true;
                    }
                    else
                    {
                        node.Checked = false;
                    }

                    string querys = $"select fs.id, fs.name, fs.title, rd.role_id , "
                                    + $"case  when rd.form_id is null then  0 else 1 end checkbox  "
                                    + $"from tbl_Forms fs "
                                    + $"left join tbl_RolesDetails rd on  rd.form_id = fs.id and rd.role_id = {roleId} "
                                    + $"where fs.parent_id = {int.Parse(dr["id"].ToString())} ";

                    DataTable dts = DataAccess.GetDataTable(querys);
                    if (dts.Rows.Count > 0)
                    {
                        foreach (DataRow item in dts.Rows)
                        {
                            var secondNode = new TreeNode();

                            if (item["checkbox"].ToString() == "1")
                            {
                                secondNode = node.Nodes.Add(item["title"].ToString());
                                secondNode.Tag = item["id"].ToString();
                                secondNode.Checked = true;
                            }
                            else
                            {
                                secondNode = node.Nodes.Add(item["title"].ToString());
                                secondNode.Tag = item["id"].ToString();
                                secondNode.Checked = false;
                            }

                            string thirdNodeQuery = $"select fs.id, fs.name, fs.title, rd.role_id , "
                                   + $"case  when rd.form_id is null then  0 else 1 end checkbox  "
                                   + $"from tbl_Forms fs "
                                   + $"left join tbl_RolesDetails rd on  rd.form_id = fs.id and rd.role_id = {roleId} "
                                   + $"where fs.parent_id = {int.Parse(item["id"].ToString())} ";

                            DataTable dts2 = DataAccess.GetDataTable(thirdNodeQuery);

                            if (dts2.Rows.Count > 0)
                            {
                                foreach (DataRow thirdNode in dts2.Rows)
                                {
                                    if (thirdNode["checkbox"].ToString() == "1")
                                    {
                                        var second = secondNode.Nodes.Add(thirdNode["title"].ToString());
                                        second.Tag = thirdNode["id"].ToString();
                                        second.Checked = true;
                                    }
                                    else
                                    {
                                        var second = secondNode.Nodes.Add(thirdNode["title"].ToString());
                                        second.Tag = thirdNode["id"].ToString();
                                        second.Checked = false;
                                    }
                                }
                            }
                        }
                    }
                    rolesTreeView.Nodes.Add(node);
                }
            }
        }
        public void Clear()
        {
            string sqlQuery = "SELECT id,name FROM tbl_Roles WHERE IsDeleted = 0 ";
            DataTable dt = DataAccess.GetDataTable(sqlQuery);
            DataRow dataRow = dt.NewRow();
            dataRow["id"] = 0;
            dataRow["name"] = "--Select UserType--";
            dt.Rows.InsertAt(dataRow, 0);
            rolesCmbbox.DataSource = dt;
            rolesCmbbox.DisplayMember = "name";
            rolesCmbbox.ValueMember = "id";
        }
        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            var parent = node.Parent;

            if (parent == null)
                return;

            if (!isChecked && HasCheckedNode(parent))
                return;

            parent.Checked = isChecked;
            SelectParents(parent, isChecked);
        }
        private bool HasCheckedNode(TreeNode node)
        {
            return node.Nodes.Cast<TreeNode>().Any(n => n.Checked);
        }

        private void ExpandAllBtn_Click(object sender, EventArgs e)
        {
            rolesTreeView.ExpandAll();
        }

        private void CollapseAllBtn_Click(object sender, EventArgs e)
        {
           rolesTreeView.CollapseAll();
        }

        private void UncheckAllBtn_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in rolesTreeView.Nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void rolesTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                CheckChildren(e.Node, e.Node.Checked);
                SelectParents(e.Node, e.Node.Checked);
            }
            else
            {
                SelectParents(e.Node, e.Node.Checked);
            }
        }

        //private void CheckAllChildNodes(TreeNode parentNode, bool nodeChecked)
        //{
        //    foreach (TreeNode node in parentNode.Nodes)
        //    {
        //        node.Checked = nodeChecked;

        //        if (node.Nodes.Count > 0)
        //        {
        //            // If the current node has child nodes, call the CheckAllChildNodes method recursively.
        //            this.CheckAllChildNodes(node, nodeChecked);
        //        }
        //    }
        //}

    }
}
