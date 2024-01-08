
namespace cypos.Forms
{
    partial class frmAddDeliveryman
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
            this.label1 = new System.Windows.Forms.Label();
            this.DeliveryNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DeliveryPhnTxt = new System.Windows.Forms.TextBox();
            this.dgvDeliveryMen = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ArrowDwnBtn = new System.Windows.Forms.Button();
            this.ArrowUpBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.deliveryIdLbl = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryMen)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(35, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 196;
            this.label1.Text = "Name:";
            // 
            // DeliveryNameTxt
            // 
            this.DeliveryNameTxt.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.DeliveryNameTxt.Location = new System.Drawing.Point(38, 81);
            this.DeliveryNameTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeliveryNameTxt.Name = "DeliveryNameTxt";
            this.DeliveryNameTxt.Size = new System.Drawing.Size(188, 30);
            this.DeliveryNameTxt.TabIndex = 194;
            this.DeliveryNameTxt.TextChanged += new System.EventHandler(this.DeliveryNameTxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(271, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 14);
            this.label2.TabIndex = 199;
            this.label2.Text = "Phone number:";
            // 
            // DeliveryPhnTxt
            // 
            this.DeliveryPhnTxt.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.DeliveryPhnTxt.Location = new System.Drawing.Point(274, 81);
            this.DeliveryPhnTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeliveryPhnTxt.Name = "DeliveryPhnTxt";
            this.DeliveryPhnTxt.Size = new System.Drawing.Size(188, 30);
            this.DeliveryPhnTxt.TabIndex = 194;
            // 
            // dgvDeliveryMen
            // 
            this.dgvDeliveryMen.AllowUserToAddRows = false;
            this.dgvDeliveryMen.AllowUserToDeleteRows = false;
            this.dgvDeliveryMen.AllowUserToResizeRows = false;
            this.dgvDeliveryMen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeliveryMen.ColumnHeadersHeight = 32;
            this.dgvDeliveryMen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeliveryMen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Del_Name,
            this.phone_num});
            this.dgvDeliveryMen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeliveryMen.Location = new System.Drawing.Point(0, 0);
            this.dgvDeliveryMen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDeliveryMen.MultiSelect = false;
            this.dgvDeliveryMen.Name = "dgvDeliveryMen";
            this.dgvDeliveryMen.ReadOnly = true;
            this.dgvDeliveryMen.RowHeadersVisible = false;
            this.dgvDeliveryMen.RowHeadersWidth = 51;
            this.dgvDeliveryMen.RowTemplate.Height = 28;
            this.dgvDeliveryMen.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDeliveryMen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliveryMen.Size = new System.Drawing.Size(451, 242);
            this.dgvDeliveryMen.TabIndex = 0;
            this.dgvDeliveryMen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryMen_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 150;
            // 
            // Del_Name
            // 
            this.Del_Name.DataPropertyName = "name";
            this.Del_Name.HeaderText = "Name";
            this.Del_Name.MinimumWidth = 8;
            this.Del_Name.Name = "Del_Name";
            this.Del_Name.ReadOnly = true;
            this.Del_Name.Width = 150;
            // 
            // phone_num
            // 
            this.phone_num.DataPropertyName = "phone_num";
            this.phone_num.HeaderText = "Phone Number";
            this.phone_num.MinimumWidth = 8;
            this.phone_num.Name = "phone_num";
            this.phone_num.ReadOnly = true;
            this.phone_num.Width = 150;
            // 
            // AddBtn
            // 
            this.AddBtn.BackgroundImage = global::cypos.Properties.Resources.add24x24;
            this.AddBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddBtn.Location = new System.Drawing.Point(493, 77);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(50, 42);
            this.AddBtn.TabIndex = 5;
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            this.AddBtn.MouseHover += new System.EventHandler(this.AddBtn_MouseHover);
            // 
            // ArrowDwnBtn
            // 
            this.ArrowDwnBtn.BackgroundImage = global::cypos.Properties.Resources.down_arrow;
            this.ArrowDwnBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ArrowDwnBtn.Location = new System.Drawing.Point(493, 272);
            this.ArrowDwnBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ArrowDwnBtn.Name = "ArrowDwnBtn";
            this.ArrowDwnBtn.Size = new System.Drawing.Size(50, 42);
            this.ArrowDwnBtn.TabIndex = 6;
            this.ArrowDwnBtn.UseVisualStyleBackColor = true;
            this.ArrowDwnBtn.Click += new System.EventHandler(this.ArrowDwnBtn_Click);
            this.ArrowDwnBtn.MouseHover += new System.EventHandler(this.ArrowDwnBtn_MouseHover);
            // 
            // ArrowUpBtn
            // 
            this.ArrowUpBtn.BackgroundImage = global::cypos.Properties.Resources.up_arrow;
            this.ArrowUpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ArrowUpBtn.Location = new System.Drawing.Point(493, 224);
            this.ArrowUpBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ArrowUpBtn.Name = "ArrowUpBtn";
            this.ArrowUpBtn.Size = new System.Drawing.Size(50, 44);
            this.ArrowUpBtn.TabIndex = 7;
            this.ArrowUpBtn.UseVisualStyleBackColor = true;
            this.ArrowUpBtn.Click += new System.EventHandler(this.ArrowUpBtn_Click);
            this.ArrowUpBtn.MouseHover += new System.EventHandler(this.ArrowUpBtn_MouseHover);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::cypos.Properties.Resources.refresh;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(493, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 42);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(589, 398);
            this.pnlMain.TabIndex = 200;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.deliveryIdLbl);
            this.pnlInner.Controls.Add(this.button3);
            this.pnlInner.Controls.Add(this.button2);
            this.pnlInner.Controls.Add(this.panel1);
            this.pnlInner.Controls.Add(this.pnlTitle);
            this.pnlInner.Controls.Add(this.button1);
            this.pnlInner.Controls.Add(this.AddBtn);
            this.pnlInner.Controls.Add(this.label1);
            this.pnlInner.Controls.Add(this.DeliveryNameTxt);
            this.pnlInner.Controls.Add(this.label2);
            this.pnlInner.Controls.Add(this.DeliveryPhnTxt);
            this.pnlInner.Controls.Add(this.ArrowDwnBtn);
            this.pnlInner.Controls.Add(this.ArrowUpBtn);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(579, 393);
            this.pnlInner.TabIndex = 16;
            // 
            // deliveryIdLbl
            // 
            this.deliveryIdLbl.AutoSize = true;
            this.deliveryIdLbl.Location = new System.Drawing.Point(455, 44);
            this.deliveryIdLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deliveryIdLbl.Name = "deliveryIdLbl";
            this.deliveryIdLbl.Size = new System.Drawing.Size(13, 13);
            this.deliveryIdLbl.TabIndex = 204;
            this.deliveryIdLbl.Text = "_";
            this.deliveryIdLbl.Visible = false;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::cypos.Properties.Resources.edit24x24;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Location = new System.Drawing.Point(493, 126);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 42);
            this.button3.TabIndex = 203;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseHover += new System.EventHandler(this.button3_MouseHover);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::cypos.Properties.Resources.delete24x24;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(493, 323);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 45);
            this.button2.TabIndex = 202;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDeliveryMen);
            this.panel1.Location = new System.Drawing.Point(38, 126);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 242);
            this.panel1.TabIndex = 201;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pnlTitle.Size = new System.Drawing.Size(579, 38);
            this.pnlTitle.TabIndex = 200;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(544, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(14, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Add Delivery Man";
            // 
            // frmAddDeliveryman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(589, 398);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAddDeliveryman";
            this.Text = "Add Deliveryman";
            this.Load += new System.EventHandler(this.frmAddDeliveryman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryMen)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DeliveryNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DeliveryPhnTxt;
        private System.Windows.Forms.DataGridView dgvDeliveryMen;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ArrowDwnBtn;
        private System.Windows.Forms.Button ArrowUpBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Del_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone_num;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label deliveryIdLbl;
    }
}