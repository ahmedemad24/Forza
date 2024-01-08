
namespace cypos
{
    partial class frmSideItems
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCodeClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellingPriceClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountClm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.DiscountTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SellingPriceTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CostPriceTxt = new System.Windows.Forms.TextBox();
            this.itemCodeLbl = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(129, 152);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 36);
            this.txtName.TabIndex = 194;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(350, 152);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 18);
            this.label24.TabIndex = 196;
            this.label24.Text = "Cost Price:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.DeleteBtn);
            this.pnlButtons.Controls.Add(this.btnUp);
            this.pnlButtons.Controls.Add(this.EditBtn);
            this.pnlButtons.Controls.Add(this.btnDown);
            this.pnlButtons.Location = new System.Drawing.Point(600, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(85, 329);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::cypos.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(3, 2);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(76, 60);
            this.btnRefresh.TabIndex = 104;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseHover += new System.EventHandler(this.btnRefresh_MouseHover);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackgroundImage = global::cypos.Properties.Resources.delete24x24;
            this.DeleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteBtn.Location = new System.Drawing.Point(3, 261);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(76, 62);
            this.DeleteBtn.TabIndex = 105;
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            this.DeleteBtn.MouseHover += new System.EventHandler(this.DeleteBtn_MouseHover);
            // 
            // btnUp
            // 
            this.btnUp.Image = global::cypos.Properties.Resources.row_up;
            this.btnUp.Location = new System.Drawing.Point(3, 66);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(76, 59);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            this.btnUp.MouseHover += new System.EventHandler(this.btnCustomerUp_MouseHover);
            // 
            // EditBtn
            // 
            this.EditBtn.BackgroundImage = global::cypos.Properties.Resources.edit24x24;
            this.EditBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EditBtn.Location = new System.Drawing.Point(3, 195);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(76, 62);
            this.EditBtn.TabIndex = 215;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            this.EditBtn.MouseHover += new System.EventHandler(this.EditBtn_MouseHover);
            // 
            // btnDown
            // 
            this.btnDown.Image = global::cypos.Properties.Resources.row_down;
            this.btnDown.Location = new System.Drawing.Point(3, 129);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(76, 62);
            this.btnDown.TabIndex = 3;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            this.btnDown.MouseHover += new System.EventHandler(this.btnCustomerDown_MouseHover);
            // 
            // button1
            // 
            this.button1.Image = global::cypos.Properties.Resources.add24x24;
            this.button1.Location = new System.Drawing.Point(621, 268);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 62);
            this.button1.TabIndex = 105;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.ColumnHeadersHeight = 40;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.itemCodeClm,
            this.name,
            this.costPriceClm,
            this.sellingPriceClm,
            this.discountClm});
            this.dgvItems.Location = new System.Drawing.Point(0, 0);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 32;
            this.dgvItems.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(597, 319);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegions_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // itemCodeClm
            // 
            this.itemCodeClm.DataPropertyName = "item_code";
            this.itemCodeClm.HeaderText = "Item Code";
            this.itemCodeClm.MinimumWidth = 6;
            this.itemCodeClm.Name = "itemCodeClm";
            this.itemCodeClm.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "item_name";
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // costPriceClm
            // 
            this.costPriceClm.DataPropertyName = "cost_price";
            this.costPriceClm.HeaderText = "Cost Price";
            this.costPriceClm.MinimumWidth = 6;
            this.costPriceClm.Name = "costPriceClm";
            this.costPriceClm.ReadOnly = true;
            // 
            // sellingPriceClm
            // 
            this.sellingPriceClm.DataPropertyName = "selling_price";
            this.sellingPriceClm.HeaderText = "Selling Price";
            this.sellingPriceClm.MinimumWidth = 6;
            this.sellingPriceClm.Name = "sellingPriceClm";
            this.sellingPriceClm.ReadOnly = true;
            // 
            // discountClm
            // 
            this.discountClm.DataPropertyName = "discount";
            this.discountClm.HeaderText = "Discount";
            this.discountClm.MinimumWidth = 6;
            this.discountClm.Name = "discountClm";
            this.discountClm.ReadOnly = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvItems);
            this.pnlGrid.Controls.Add(this.pnlButtons);
            this.pnlGrid.Location = new System.Drawing.Point(21, 332);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(688, 326);
            this.pnlGrid.TabIndex = 210;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(2, 2);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(7, 0, 7, 6);
            this.pnlMain.Size = new System.Drawing.Size(727, 683);
            this.pnlMain.TabIndex = 215;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.DiscountTxt);
            this.pnlInner.Controls.Add(this.label4);
            this.pnlInner.Controls.Add(this.SellingPriceTxt);
            this.pnlInner.Controls.Add(this.label3);
            this.pnlInner.Controls.Add(this.label2);
            this.pnlInner.Controls.Add(this.CostPriceTxt);
            this.pnlInner.Controls.Add(this.itemCodeLbl);
            this.pnlInner.Controls.Add(this.button1);
            this.pnlInner.Controls.Add(this.pnlTitle);
            this.pnlInner.Controls.Add(this.label24);
            this.pnlInner.Controls.Add(this.pnlGrid);
            this.pnlInner.Controls.Add(this.txtName);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(7, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(713, 677);
            this.pnlInner.TabIndex = 16;
            // 
            // DiscountTxt
            // 
            this.DiscountTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DiscountTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscountTxt.Location = new System.Drawing.Point(129, 192);
            this.DiscountTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiscountTxt.Name = "DiscountTxt";
            this.DiscountTxt.Size = new System.Drawing.Size(168, 36);
            this.DiscountTxt.TabIndex = 223;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 222;
            this.label4.Text = "Dicsount:";
            // 
            // SellingPriceTxt
            // 
            this.SellingPriceTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SellingPriceTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellingPriceTxt.Location = new System.Drawing.Point(450, 192);
            this.SellingPriceTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SellingPriceTxt.Name = "SellingPriceTxt";
            this.SellingPriceTxt.Size = new System.Drawing.Size(168, 36);
            this.SellingPriceTxt.TabIndex = 221;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 220;
            this.label3.Text = "Selling Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 219;
            this.label2.Text = "Item Name:";
            // 
            // CostPriceTxt
            // 
            this.CostPriceTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CostPriceTxt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostPriceTxt.Location = new System.Drawing.Point(450, 152);
            this.CostPriceTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CostPriceTxt.Name = "CostPriceTxt";
            this.CostPriceTxt.Size = new System.Drawing.Size(168, 36);
            this.CostPriceTxt.TabIndex = 218;
            // 
            // itemCodeLbl
            // 
            this.itemCodeLbl.AutoSize = true;
            this.itemCodeLbl.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCodeLbl.ForeColor = System.Drawing.Color.Red;
            this.itemCodeLbl.Location = new System.Drawing.Point(19, 81);
            this.itemCodeLbl.Name = "itemCodeLbl";
            this.itemCodeLbl.Size = new System.Drawing.Size(0, 25);
            this.itemCodeLbl.TabIndex = 215;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(4);
            this.pnlTitle.Size = new System.Drawing.Size(713, 44);
            this.pnlTitle.TabIndex = 200;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(666, 4);
            this.pbxClose.Margin = new System.Windows.Forms.Padding(4);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(43, 36);
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
            this.lblTitle.Location = new System.Drawing.Point(8, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(113, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Side Items";
            // 
            // frmSideItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(732, 687);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSideItems";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddRegion";
            this.Load += new System.EventHandler(this.frmSideItems_Load);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
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
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Label itemCodeLbl;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CostPriceTxt;
        private System.Windows.Forms.TextBox SellingPriceTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DiscountTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCodeClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellingPriceClm;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountClm;
    }
}