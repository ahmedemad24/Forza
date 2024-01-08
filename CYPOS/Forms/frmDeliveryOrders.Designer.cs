
namespace cypos.Forms
{
    partial class frmDeliveryOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDelivery = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ChooseDlv = new System.Windows.Forms.Button();
            this.AddDeliveryman = new System.Windows.Forms.Button();
            this.BtnArrowUp = new System.Windows.Forms.Button();
            this.BtnArrowDwn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.FinishOrderBtn = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivery)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDelivery
            // 
            this.dgvDelivery.AllowUserToAddRows = false;
            this.dgvDelivery.AllowUserToDeleteRows = false;
            this.dgvDelivery.AllowUserToResizeRows = false;
            this.dgvDelivery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelivery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDelivery.ColumnHeadersHeight = 40;
            this.dgvDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDelivery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.id,
            this.logDate,
            this.custname,
            this.custPhone,
            this.custAddress,
            this.payment_amount,
            this.delName,
            this.delDate});
            this.dgvDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDelivery.Location = new System.Drawing.Point(0, 0);
            this.dgvDelivery.MultiSelect = false;
            this.dgvDelivery.Name = "dgvDelivery";
            this.dgvDelivery.ReadOnly = true;
            this.dgvDelivery.RowHeadersVisible = false;
            this.dgvDelivery.RowHeadersWidth = 51;
            this.dgvDelivery.RowTemplate.Height = 32;
            this.dgvDelivery.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDelivery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDelivery.Size = new System.Drawing.Size(1098, 484);
            this.dgvDelivery.TabIndex = 0;
            this.dgvDelivery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chk
            // 
            this.chk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chk.FillWeight = 511.3636F;
            this.chk.HeaderText = "Select";
            this.chk.MinimumWidth = 8;
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 70;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.FillWeight = 48.57955F;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // logDate
            // 
            this.logDate.DataPropertyName = "log_date";
            this.logDate.FillWeight = 48.57955F;
            this.logDate.HeaderText = "Log Date";
            this.logDate.MinimumWidth = 8;
            this.logDate.Name = "logDate";
            this.logDate.ReadOnly = true;
            // 
            // custname
            // 
            this.custname.DataPropertyName = "name";
            this.custname.FillWeight = 48.57955F;
            this.custname.HeaderText = "Customer";
            this.custname.MinimumWidth = 8;
            this.custname.Name = "custname";
            this.custname.ReadOnly = true;
            // 
            // custPhone
            // 
            this.custPhone.DataPropertyName = "phone";
            this.custPhone.FillWeight = 48.57955F;
            this.custPhone.HeaderText = "Phone";
            this.custPhone.MinimumWidth = 8;
            this.custPhone.Name = "custPhone";
            this.custPhone.ReadOnly = true;
            // 
            // custAddress
            // 
            this.custAddress.DataPropertyName = "address";
            this.custAddress.FillWeight = 48.57955F;
            this.custAddress.HeaderText = "Address";
            this.custAddress.MinimumWidth = 8;
            this.custAddress.Name = "custAddress";
            this.custAddress.ReadOnly = true;
            // 
            // payment_amount
            // 
            this.payment_amount.DataPropertyName = "payment_amount";
            this.payment_amount.FillWeight = 48.57955F;
            this.payment_amount.HeaderText = "Payment Amount";
            this.payment_amount.MinimumWidth = 8;
            this.payment_amount.Name = "payment_amount";
            this.payment_amount.ReadOnly = true;
            // 
            // delName
            // 
            this.delName.DataPropertyName = "NameDelivery";
            this.delName.FillWeight = 48.57955F;
            this.delName.HeaderText = "Delivery Man";
            this.delName.MinimumWidth = 8;
            this.delName.Name = "delName";
            this.delName.ReadOnly = true;
            // 
            // delDate
            // 
            this.delDate.DataPropertyName = "delivery_date";
            this.delDate.FillWeight = 48.57955F;
            this.delDate.HeaderText = "Delivery Date";
            this.delDate.MinimumWidth = 8;
            this.delDate.Name = "delDate";
            this.delDate.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Delivery Man";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(200, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 42);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(143, 617);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 22);
            this.label3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(143, 644);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 22);
            this.label4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 617);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pendding Orders:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 644);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Delivered Orders:";
            // 
            // ChooseDlv
            // 
            this.ChooseDlv.Location = new System.Drawing.Point(994, 617);
            this.ChooseDlv.Name = "ChooseDlv";
            this.ChooseDlv.Size = new System.Drawing.Size(115, 56);
            this.ChooseDlv.TabIndex = 9;
            this.ChooseDlv.Text = "Choose Delivery";
            this.ChooseDlv.UseVisualStyleBackColor = true;
            this.ChooseDlv.Click += new System.EventHandler(this.ChooseDlv_Click);
            this.ChooseDlv.MouseHover += new System.EventHandler(this.ChooseDlv_MouseHover);
            // 
            // AddDeliveryman
            // 
            this.AddDeliveryman.Image = global::cypos.Properties.Resources.add24x24;
            this.AddDeliveryman.Location = new System.Drawing.Point(488, 75);
            this.AddDeliveryman.Name = "AddDeliveryman";
            this.AddDeliveryman.Size = new System.Drawing.Size(48, 42);
            this.AddDeliveryman.TabIndex = 1;
            this.AddDeliveryman.UseVisualStyleBackColor = true;
            this.AddDeliveryman.Click += new System.EventHandler(this.AddDeliveryman_Click);
            this.AddDeliveryman.MouseHover += new System.EventHandler(this.AddDeliveryman_MouseHover);
            // 
            // BtnArrowUp
            // 
            this.BtnArrowUp.BackgroundImage = global::cypos.Properties.Resources.row_up;
            this.BtnArrowUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnArrowUp.Location = new System.Drawing.Point(1113, 309);
            this.BtnArrowUp.Name = "BtnArrowUp";
            this.BtnArrowUp.Size = new System.Drawing.Size(75, 56);
            this.BtnArrowUp.TabIndex = 10;
            this.BtnArrowUp.UseVisualStyleBackColor = true;
            this.BtnArrowUp.Click += new System.EventHandler(this.BtnArrowUp_Click);
            this.BtnArrowUp.MouseHover += new System.EventHandler(this.BtnArrowUp_MouseHover);
            // 
            // BtnArrowDwn
            // 
            this.BtnArrowDwn.BackgroundImage = global::cypos.Properties.Resources.row_down;
            this.BtnArrowDwn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnArrowDwn.Location = new System.Drawing.Point(1113, 388);
            this.BtnArrowDwn.Name = "BtnArrowDwn";
            this.BtnArrowDwn.Size = new System.Drawing.Size(75, 61);
            this.BtnArrowDwn.TabIndex = 11;
            this.BtnArrowDwn.UseVisualStyleBackColor = true;
            this.BtnArrowDwn.Click += new System.EventHandler(this.BtnArrowDwn_Click);
            this.BtnArrowDwn.MouseHover += new System.EventHandler(this.BtnArrowDwn_MouseHover);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::cypos.Properties.Resources.refresh;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(542, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 42);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // FinishOrderBtn
            // 
            this.FinishOrderBtn.Location = new System.Drawing.Point(878, 617);
            this.FinishOrderBtn.Name = "FinishOrderBtn";
            this.FinishOrderBtn.Size = new System.Drawing.Size(110, 56);
            this.FinishOrderBtn.TabIndex = 13;
            this.FinishOrderBtn.Text = "Finish Order/s";
            this.FinishOrderBtn.UseVisualStyleBackColor = true;
            this.FinishOrderBtn.Click += new System.EventHandler(this.FinishOrderBtn_Click);
            this.FinishOrderBtn.MouseHover += new System.EventHandler(this.FinishOrderBtn_MouseHover);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.pnlMain.Size = new System.Drawing.Size(1210, 714);
            this.pnlMain.TabIndex = 201;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.label4);
            this.pnlInner.Controls.Add(this.panel1);
            this.pnlInner.Controls.Add(this.label3);
            this.pnlInner.Controls.Add(this.BtnArrowDwn);
            this.pnlInner.Controls.Add(this.FinishOrderBtn);
            this.pnlInner.Controls.Add(this.BtnArrowUp);
            this.pnlInner.Controls.Add(this.pnlTitle);
            this.pnlInner.Controls.Add(this.ChooseDlv);
            this.pnlInner.Controls.Add(this.button1);
            this.pnlInner.Controls.Add(this.AddDeliveryman);
            this.pnlInner.Controls.Add(this.textBox1);
            this.pnlInner.Controls.Add(this.label5);
            this.pnlInner.Controls.Add(this.label1);
            this.pnlInner.Controls.Add(this.label2);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(8, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(1194, 706);
            this.pnlInner.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDelivery);
            this.panel1.Location = new System.Drawing.Point(11, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 484);
            this.panel1.TabIndex = 201;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.Size = new System.Drawing.Size(1194, 47);
            this.pnlTitle.TabIndex = 200;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(1152, 5);
            this.pbxClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(38, 37);
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
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 28);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Delivery Orders";
            // 
            // frmDeliveryOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1210, 714);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeliveryOrders";
            this.Text = "Delivery Orders";
            this.Load += new System.EventHandler(this.frmDeliveryOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivery)).EndInit();
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

        private System.Windows.Forms.DataGridView dgvDelivery;
        private System.Windows.Forms.Button AddDeliveryman;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ChooseDlv;
        private System.Windows.Forms.Button BtnArrowUp;
        private System.Windows.Forms.Button BtnArrowDwn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button FinishOrderBtn;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn custname;
        private System.Windows.Forms.DataGridViewTextBoxColumn custPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn custAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn delName;
        private System.Windows.Forms.DataGridViewTextBoxColumn delDate;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}