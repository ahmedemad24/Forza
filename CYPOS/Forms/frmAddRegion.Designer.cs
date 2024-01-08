
namespace cypos
{
    partial class frmAddRegion
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnKbCusName = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.btnCustomerUp = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.btnCustomerDown = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvRegions = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.testID = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegions)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // amount
            // 
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount.Location = new System.Drawing.Point(400, 98);
            this.amount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(212, 40);
            this.amount.TabIndex = 214;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(396, 71);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(139, 22);
            this.label27.TabIndex = 199;
            this.label27.Text = "Service Amount:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(30, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 42);
            this.txtName.TabIndex = 194;
            // 
            // btnKbCusName
            // 
            this.btnKbCusName.FlatAppearance.BorderSize = 0;
            this.btnKbCusName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCusName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCusName.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCusName.Location = new System.Drawing.Point(315, 95);
            this.btnKbCusName.Name = "btnKbCusName";
            this.btnKbCusName.Size = new System.Drawing.Size(66, 48);
            this.btnKbCusName.TabIndex = 204;
            this.btnKbCusName.UseVisualStyleBackColor = true;
            this.btnKbCusName.Click += new System.EventHandler(this.btnKbCusName_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(26, 71);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(61, 22);
            this.label24.TabIndex = 196;
            this.label24.Text = "Name:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.DeleteBtn);
            this.pnlButtons.Controls.Add(this.btnCustomerUp);
            this.pnlButtons.Controls.Add(this.EditBtn);
            this.pnlButtons.Controls.Add(this.btnCustomerDown);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(586, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(104, 449);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlButtons_Paint);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::cypos.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(18, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 77);
            this.btnRefresh.TabIndex = 104;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseHover += new System.EventHandler(this.btnRefresh_MouseHover);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackgroundImage = global::cypos.Properties.Resources.delete24x24;
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteBtn.Location = new System.Drawing.Point(18, 372);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(86, 77);
            this.DeleteBtn.TabIndex = 105;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            this.DeleteBtn.MouseHover += new System.EventHandler(this.DeleteBtn_MouseHover);
            // 
            // btnCustomerUp
            // 
            this.btnCustomerUp.Image = global::cypos.Properties.Resources.row_up;
            this.btnCustomerUp.Location = new System.Drawing.Point(18, 98);
            this.btnCustomerUp.Name = "btnCustomerUp";
            this.btnCustomerUp.Size = new System.Drawing.Size(86, 77);
            this.btnCustomerUp.TabIndex = 2;
            this.btnCustomerUp.UseVisualStyleBackColor = true;
            this.btnCustomerUp.Click += new System.EventHandler(this.btnCustomerUp_Click);
            this.btnCustomerUp.MouseHover += new System.EventHandler(this.btnCustomerUp_MouseHover);
            // 
            // EditBtn
            // 
            this.EditBtn.BackgroundImage = global::cypos.Properties.Resources.edit24x24;
            this.EditBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EditBtn.Location = new System.Drawing.Point(18, 289);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(86, 77);
            this.EditBtn.TabIndex = 215;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            this.EditBtn.MouseHover += new System.EventHandler(this.EditBtn_MouseHover);
            // 
            // btnCustomerDown
            // 
            this.btnCustomerDown.Image = global::cypos.Properties.Resources.row_down;
            this.btnCustomerDown.Location = new System.Drawing.Point(18, 182);
            this.btnCustomerDown.Name = "btnCustomerDown";
            this.btnCustomerDown.Size = new System.Drawing.Size(86, 77);
            this.btnCustomerDown.TabIndex = 3;
            this.btnCustomerDown.UseVisualStyleBackColor = true;
            this.btnCustomerDown.Click += new System.EventHandler(this.btnCustomerDown_Click);
            this.btnCustomerDown.MouseHover += new System.EventHandler(this.btnCustomerDown_MouseHover);
            // 
            // button1
            // 
            this.button1.Image = global::cypos.Properties.Resources.add24x24;
            this.button1.Location = new System.Drawing.Point(630, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 77);
            this.button1.TabIndex = 105;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // dgvRegions
            // 
            this.dgvRegions.AllowUserToAddRows = false;
            this.dgvRegions.AllowUserToDeleteRows = false;
            this.dgvRegions.AllowUserToResizeRows = false;
            this.dgvRegions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegions.ColumnHeadersHeight = 32;
            this.dgvRegions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmName,
            this.clmAmount});
            this.dgvRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegions.Location = new System.Drawing.Point(0, 0);
            this.dgvRegions.MultiSelect = false;
            this.dgvRegions.Name = "dgvRegions";
            this.dgvRegions.ReadOnly = true;
            this.dgvRegions.RowHeadersVisible = false;
            this.dgvRegions.RowHeadersWidth = 51;
            this.dgvRegions.RowTemplate.Height = 32;
            this.dgvRegions.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRegions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegions.Size = new System.Drawing.Size(586, 449);
            this.dgvRegions.TabIndex = 0;
            this.dgvRegions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegions_CellClick);
            this.dgvRegions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegions_CellContentClick);
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "RegionId";
            this.clmId.HeaderText = "Id";
            this.clmId.MinimumWidth = 6;
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "RegionName";
            this.clmName.HeaderText = "Region";
            this.clmName.MinimumWidth = 6;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmAmount
            // 
            this.clmAmount.DataPropertyName = "ServiceAmount";
            this.clmAmount.HeaderText = "Service Amount";
            this.clmAmount.MinimumWidth = 6;
            this.clmAmount.Name = "clmAmount";
            this.clmAmount.ReadOnly = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvRegions);
            this.pnlGrid.Controls.Add(this.pnlButtons);
            this.pnlGrid.Location = new System.Drawing.Point(26, 178);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(690, 449);
            this.pnlGrid.TabIndex = 210;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(66, 74);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(15, 20);
            this.lblCustomerId.TabIndex = 213;
            this.lblCustomerId.Text = "-";
            this.lblCustomerId.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 3);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.pnlMain.Size = new System.Drawing.Size(749, 666);
            this.pnlMain.TabIndex = 215;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.testID);
            this.pnlInner.Controls.Add(this.button1);
            this.pnlInner.Controls.Add(this.pnlTitle);
            this.pnlInner.Controls.Add(this.amount);
            this.pnlInner.Controls.Add(this.label24);
            this.pnlInner.Controls.Add(this.lblCustomerId);
            this.pnlInner.Controls.Add(this.label27);
            this.pnlInner.Controls.Add(this.pnlGrid);
            this.pnlInner.Controls.Add(this.txtName);
            this.pnlInner.Controls.Add(this.btnKbCusName);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(8, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(733, 658);
            this.pnlInner.TabIndex = 16;
            // 
            // testID
            // 
            this.testID.AutoSize = true;
            this.testID.Location = new System.Drawing.Point(26, 152);
            this.testID.Name = "testID";
            this.testID.Size = new System.Drawing.Size(12, 20);
            this.testID.TabIndex = 215;
            this.testID.Text = "\'";
            this.testID.Visible = false;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.Size = new System.Drawing.Size(733, 58);
            this.pnlTitle.TabIndex = 200;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(681, 5);
            this.pbxClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(48, 48);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxClose.TabIndex = 9;
            this.pbxClose.TabStop = false;
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(21, 17);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 28);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Add Region";
            // 
            // frmAddRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(754, 672);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddRegion";
            this.Padding = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddRegion";
            this.Load += new System.EventHandler(this.frmAddRegion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegions)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnKbCusName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCustomerUp;
        private System.Windows.Forms.Button btnCustomerDown;
        private System.Windows.Forms.DataGridView dgvRegions;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAmount;
        private System.Windows.Forms.Label testID;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip6;
    }
}