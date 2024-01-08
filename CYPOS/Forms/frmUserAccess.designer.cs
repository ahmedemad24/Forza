namespace cypos
{
    partial class frmUserAccess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserAccess));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UncheckAllBtn = new System.Windows.Forms.Button();
            this.CollapseAllBtn = new System.Windows.Forms.Button();
            this.ExpandAllBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rolesTreeView = new System.Windows.Forms.TreeView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.addNewRoleBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rolesCmbbox = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(894, 496);
            this.pnlMain.TabIndex = 162;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.panel1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(5, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(884, 491);
            this.pnlRight.TabIndex = 163;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UncheckAllBtn);
            this.panel1.Controls.Add(this.CollapseAllBtn);
            this.panel1.Controls.Add(this.ExpandAllBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.addNewRoleBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rolesCmbbox);
            this.panel1.Location = new System.Drawing.Point(7, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 476);
            this.panel1.TabIndex = 0;
            // 
            // UncheckAllBtn
            // 
            this.UncheckAllBtn.Location = new System.Drawing.Point(645, 9);
            this.UncheckAllBtn.Name = "UncheckAllBtn";
            this.UncheckAllBtn.Size = new System.Drawing.Size(127, 30);
            this.UncheckAllBtn.TabIndex = 9;
            this.UncheckAllBtn.Text = "Uncheck All";
            this.UncheckAllBtn.UseVisualStyleBackColor = true;
            this.UncheckAllBtn.Click += new System.EventHandler(this.UncheckAllBtn_Click);
            // 
            // CollapseAllBtn
            // 
            this.CollapseAllBtn.Location = new System.Drawing.Point(477, 9);
            this.CollapseAllBtn.Name = "CollapseAllBtn";
            this.CollapseAllBtn.Size = new System.Drawing.Size(127, 30);
            this.CollapseAllBtn.TabIndex = 8;
            this.CollapseAllBtn.Text = "Collapse All";
            this.CollapseAllBtn.UseVisualStyleBackColor = true;
            this.CollapseAllBtn.Click += new System.EventHandler(this.CollapseAllBtn_Click);
            // 
            // ExpandAllBtn
            // 
            this.ExpandAllBtn.Location = new System.Drawing.Point(344, 9);
            this.ExpandAllBtn.Name = "ExpandAllBtn";
            this.ExpandAllBtn.Size = new System.Drawing.Size(127, 30);
            this.ExpandAllBtn.TabIndex = 7;
            this.ExpandAllBtn.Text = "Expand All";
            this.ExpandAllBtn.UseVisualStyleBackColor = true;
            this.ExpandAllBtn.Click += new System.EventHandler(this.ExpandAllBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rolesTreeView);
            this.panel2.Location = new System.Drawing.Point(7, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 408);
            this.panel2.TabIndex = 6;
            // 
            // rolesTreeView
            // 
            this.rolesTreeView.CausesValidation = false;
            this.rolesTreeView.CheckBoxes = true;
            this.rolesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolesTreeView.Location = new System.Drawing.Point(0, 0);
            this.rolesTreeView.Name = "rolesTreeView";
            this.rolesTreeView.Size = new System.Drawing.Size(765, 408);
            this.rolesTreeView.TabIndex = 5;
            this.rolesTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rolesTreeView_NodeMouseClick);
            // 
            // saveBtn
            // 
            this.saveBtn.BackgroundImage = global::cypos.Properties.Resources.save24x24;
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveBtn.Location = new System.Drawing.Point(778, 403);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(79, 50);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            this.saveBtn.MouseHover += new System.EventHandler(this.saveBtn_MouseHover);
            // 
            // addNewRoleBtn
            // 
            this.addNewRoleBtn.BackgroundImage = global::cypos.Properties.Resources.add24x24;
            this.addNewRoleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addNewRoleBtn.Location = new System.Drawing.Point(269, 9);
            this.addNewRoleBtn.Name = "addNewRoleBtn";
            this.addNewRoleBtn.Size = new System.Drawing.Size(54, 30);
            this.addNewRoleBtn.TabIndex = 2;
            this.addNewRoleBtn.UseVisualStyleBackColor = true;
            this.addNewRoleBtn.Click += new System.EventHandler(this.addNewRoleBtn_Click);
            this.addNewRoleBtn.MouseHover += new System.EventHandler(this.addNewRoleBtn_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Role:";
            // 
            // rolesCmbbox
            // 
            this.rolesCmbbox.FormattingEnabled = true;
            this.rolesCmbbox.Location = new System.Drawing.Point(112, 9);
            this.rolesCmbbox.Name = "rolesCmbbox";
            this.rolesCmbbox.Size = new System.Drawing.Size(141, 26);
            this.rolesCmbbox.TabIndex = 0;
            this.rolesCmbbox.SelectedIndexChanged += new System.EventHandler(this.rolesCmbbox_SelectedIndexChanged);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.pnlTitle.Size = new System.Drawing.Size(894, 38);
            this.pnlTitle.TabIndex = 160;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(859, 3);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(32, 32);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxClose.TabIndex = 9;
            this.pbxClose.TabStop = false;
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            this.pbxClose.MouseHover += new System.EventHandler(this.pbxClose_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(123, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "User Access";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 534);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserAccess";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Register";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addNewRoleBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rolesCmbbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView rolesTreeView;
        private System.Windows.Forms.Button UncheckAllBtn;
        private System.Windows.Forms.Button CollapseAllBtn;
        private System.Windows.Forms.Button ExpandAllBtn;
    }
}