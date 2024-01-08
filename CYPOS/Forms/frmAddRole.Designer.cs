
namespace cypos.Forms
{
    partial class frmAddRole
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.roleIdLbl = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.log_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roleNameTxt = new System.Windows.Forms.TextBox();
            this.ArrowDwnBtn = new System.Windows.Forms.Button();
            this.ArrowUpBtn = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlRight.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.roleIdLbl);
            this.pnlRight.Controls.Add(this.editBtn);
            this.pnlRight.Controls.Add(this.deleteBtn);
            this.pnlRight.Controls.Add(this.panel1);
            this.pnlRight.Controls.Add(this.refreshBtn);
            this.pnlRight.Controls.Add(this.AddBtn);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.roleNameTxt);
            this.pnlRight.Controls.Add(this.ArrowDwnBtn);
            this.pnlRight.Controls.Add(this.ArrowUpBtn);
            this.pnlRight.Controls.Add(this.pnlTitle);
            this.pnlRight.Location = new System.Drawing.Point(5, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(607, 376);
            this.pnlRight.TabIndex = 164;
            // 
            // roleIdLbl
            // 
            this.roleIdLbl.AutoSize = true;
            this.roleIdLbl.Location = new System.Drawing.Point(649, -24);
            this.roleIdLbl.Name = "roleIdLbl";
            this.roleIdLbl.Size = new System.Drawing.Size(18, 20);
            this.roleIdLbl.TabIndex = 216;
            this.roleIdLbl.Text = "_";
            this.roleIdLbl.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.BackgroundImage = global::cypos.Properties.Resources.edit24x24;
            this.editBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editBtn.Location = new System.Drawing.Point(418, 114);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 54);
            this.editBtn.TabIndex = 215;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            this.editBtn.MouseHover += new System.EventHandler(this.editBtn_MouseHover);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackgroundImage = global::cypos.Properties.Resources.delete24x24;
            this.deleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteBtn.Location = new System.Drawing.Point(499, 114);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 54);
            this.deleteBtn.TabIndex = 214;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            this.deleteBtn.MouseHover += new System.EventHandler(this.deleteBtn_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRoles);
            this.panel1.Location = new System.Drawing.Point(24, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 251);
            this.panel1.TabIndex = 213;
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AllowUserToResizeRows = false;
            this.dgvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoles.ColumnHeadersHeight = 32;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.roleName,
            this.log_date});
            this.dgvRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoles.Location = new System.Drawing.Point(0, 0);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.RowHeadersWidth = 51;
            this.dgvRoles.RowTemplate.Height = 28;
            this.dgvRoles.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(355, 251);
            this.dgvRoles.TabIndex = 0;
            this.dgvRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // roleName
            // 
            this.roleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.roleName.DataPropertyName = "name";
            this.roleName.HeaderText = "Name";
            this.roleName.MinimumWidth = 8;
            this.roleName.Name = "roleName";
            this.roleName.ReadOnly = true;
            // 
            // log_date
            // 
            this.log_date.DataPropertyName = "log_date";
            this.log_date.HeaderText = "Log Date";
            this.log_date.MinimumWidth = 8;
            this.log_date.Name = "log_date";
            this.log_date.ReadOnly = true;
            this.log_date.Width = 150;
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackgroundImage = global::cypos.Properties.Resources.refresh;
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refreshBtn.Location = new System.Drawing.Point(499, 55);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 53);
            this.refreshBtn.TabIndex = 208;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            this.refreshBtn.MouseHover += new System.EventHandler(this.refreshBtn_MouseHover);
            // 
            // AddBtn
            // 
            this.AddBtn.BackgroundImage = global::cypos.Properties.Resources.add24x24;
            this.AddBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddBtn.Location = new System.Drawing.Point(418, 55);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 53);
            this.AddBtn.TabIndex = 205;
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            this.AddBtn.MouseHover += new System.EventHandler(this.AddBtn_MouseHover);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 211;
            this.label1.Text = "Name:";
            // 
            // roleNameTxt
            // 
            this.roleNameTxt.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.roleNameTxt.Location = new System.Drawing.Point(99, 55);
            this.roleNameTxt.Name = "roleNameTxt";
            this.roleNameTxt.Size = new System.Drawing.Size(280, 42);
            this.roleNameTxt.TabIndex = 209;
            this.roleNameTxt.TextChanged += new System.EventHandler(this.roleNameTxt_TextChanged);
            // 
            // ArrowDwnBtn
            // 
            this.ArrowDwnBtn.BackgroundImage = global::cypos.Properties.Resources.down_arrow;
            this.ArrowDwnBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ArrowDwnBtn.Location = new System.Drawing.Point(385, 273);
            this.ArrowDwnBtn.Name = "ArrowDwnBtn";
            this.ArrowDwnBtn.Size = new System.Drawing.Size(75, 65);
            this.ArrowDwnBtn.TabIndex = 206;
            this.ArrowDwnBtn.UseVisualStyleBackColor = true;
            this.ArrowDwnBtn.Click += new System.EventHandler(this.ArrowDwnBtn_Click_1);
            this.ArrowDwnBtn.MouseHover += new System.EventHandler(this.ArrowDwnBtn_MouseHover);
            // 
            // ArrowUpBtn
            // 
            this.ArrowUpBtn.BackgroundImage = global::cypos.Properties.Resources.up_arrow;
            this.ArrowUpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ArrowUpBtn.Location = new System.Drawing.Point(385, 199);
            this.ArrowUpBtn.Name = "ArrowUpBtn";
            this.ArrowUpBtn.Size = new System.Drawing.Size(75, 68);
            this.ArrowUpBtn.TabIndex = 207;
            this.ArrowUpBtn.UseVisualStyleBackColor = true;
            this.ArrowUpBtn.Click += new System.EventHandler(this.ArrowUpBtn_Click_1);
            this.ArrowUpBtn.MouseHover += new System.EventHandler(this.ArrowUpBtn_MouseHover);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.pnlTitle.Size = new System.Drawing.Size(607, 38);
            this.pnlTitle.TabIndex = 161;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(572, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(115, 28);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Add Role";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(620, 384);
            this.pnlMain.TabIndex = 165;
            // 
            // frmAddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 384);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddRole";
            this.Text = "frmAddRole";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddRole_FormClosed);
            this.Load += new System.EventHandler(this.frmAddRole_Load);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label roleIdLbl;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox roleNameTxt;
        private System.Windows.Forms.Button ArrowDwnBtn;
        private System.Windows.Forms.Button ArrowUpBtn;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn log_date;
    }
}