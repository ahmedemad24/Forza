
namespace cypos.Forms
{
    partial class frmInvoiceReceipts
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
            this.dgvInvoiceReceipts = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.header_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.change_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.due_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.log_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prntInvBtn = new System.Windows.Forms.Button();
            this.AvoidInvBtn = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.filterBoxPnl = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.UsernameComb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.rowsCountLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnArrowDwn = new System.Windows.Forms.Button();
            this.BtnArrowUp = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceReceipts)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.filterBoxPnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInvoiceReceipts
            // 
            this.dgvInvoiceReceipts.AllowUserToAddRows = false;
            this.dgvInvoiceReceipts.AllowUserToDeleteRows = false;
            this.dgvInvoiceReceipts.AllowUserToResizeRows = false;
            this.dgvInvoiceReceipts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceReceipts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceReceipts.ColumnHeadersHeight = 40;
            this.dgvInvoiceReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInvoiceReceipts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.header_id,
            this.invoice_no,
            this.CustomerName,
            this.customer_id,
            this.order_type,
            this.invoice_time,
            this.invoice_date,
            this.payment_type,
            this.invoice_status,
            this.user_name,
            this.discount_rate,
            this.payment_amount,
            this.paid_amount,
            this.change_amount,
            this.due_amount,
            this.shift_id,
            this.log_date,
            this.note});
            this.dgvInvoiceReceipts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceReceipts.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceReceipts.MultiSelect = false;
            this.dgvInvoiceReceipts.Name = "dgvInvoiceReceipts";
            this.dgvInvoiceReceipts.ReadOnly = true;
            this.dgvInvoiceReceipts.RowHeadersVisible = false;
            this.dgvInvoiceReceipts.RowHeadersWidth = 51;
            this.dgvInvoiceReceipts.RowTemplate.Height = 32;
            this.dgvInvoiceReceipts.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvInvoiceReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceReceipts.Size = new System.Drawing.Size(1098, 484);
            this.dgvInvoiceReceipts.TabIndex = 0;
            this.dgvInvoiceReceipts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceReceipts_CellClick);
            this.dgvInvoiceReceipts.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInvoiceReceipts_ColumnHeaderMouseClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "invoice_id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // header_id
            // 
            this.header_id.DataPropertyName = "id";
            this.header_id.HeaderText = "header_id";
            this.header_id.MinimumWidth = 8;
            this.header_id.Name = "header_id";
            this.header_id.ReadOnly = true;
            this.header_id.Visible = false;
            // 
            // invoice_no
            // 
            this.invoice_no.DataPropertyName = "invoice_no";
            this.invoice_no.HeaderText = "INV_NO";
            this.invoice_no.MinimumWidth = 8;
            this.invoice_no.Name = "invoice_no";
            this.invoice_no.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // customer_id
            // 
            this.customer_id.DataPropertyName = "customer_id";
            this.customer_id.HeaderText = "customer_id";
            this.customer_id.MinimumWidth = 6;
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            this.customer_id.Visible = false;
            // 
            // order_type
            // 
            this.order_type.DataPropertyName = "order_type";
            this.order_type.HeaderText = "Order Type";
            this.order_type.MinimumWidth = 8;
            this.order_type.Name = "order_type";
            this.order_type.ReadOnly = true;
            this.order_type.Visible = false;
            // 
            // invoice_time
            // 
            this.invoice_time.DataPropertyName = "invoice_time";
            this.invoice_time.HeaderText = "Invoice Time";
            this.invoice_time.MinimumWidth = 8;
            this.invoice_time.Name = "invoice_time";
            this.invoice_time.ReadOnly = true;
            // 
            // invoice_date
            // 
            this.invoice_date.DataPropertyName = "invoice_date";
            this.invoice_date.HeaderText = "Invoice Date";
            this.invoice_date.MinimumWidth = 8;
            this.invoice_date.Name = "invoice_date";
            this.invoice_date.ReadOnly = true;
            // 
            // payment_type
            // 
            this.payment_type.DataPropertyName = "payment_type";
            this.payment_type.HeaderText = "Payment Type";
            this.payment_type.MinimumWidth = 8;
            this.payment_type.Name = "payment_type";
            this.payment_type.ReadOnly = true;
            // 
            // invoice_status
            // 
            this.invoice_status.DataPropertyName = "invoice_status";
            this.invoice_status.HeaderText = "Status";
            this.invoice_status.MinimumWidth = 8;
            this.invoice_status.Name = "invoice_status";
            this.invoice_status.ReadOnly = true;
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "user_name";
            this.user_name.HeaderText = "Username";
            this.user_name.MinimumWidth = 8;
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            // 
            // discount_rate
            // 
            this.discount_rate.DataPropertyName = "discount_rate";
            this.discount_rate.HeaderText = "Discount%";
            this.discount_rate.MinimumWidth = 8;
            this.discount_rate.Name = "discount_rate";
            this.discount_rate.ReadOnly = true;
            // 
            // payment_amount
            // 
            this.payment_amount.DataPropertyName = "payment_amount";
            this.payment_amount.HeaderText = "Total";
            this.payment_amount.MinimumWidth = 8;
            this.payment_amount.Name = "payment_amount";
            this.payment_amount.ReadOnly = true;
            // 
            // paid_amount
            // 
            this.paid_amount.DataPropertyName = "paid_amount";
            this.paid_amount.HeaderText = "paid_amount";
            this.paid_amount.MinimumWidth = 8;
            this.paid_amount.Name = "paid_amount";
            this.paid_amount.ReadOnly = true;
            this.paid_amount.Visible = false;
            // 
            // change_amount
            // 
            this.change_amount.DataPropertyName = "change_amount";
            this.change_amount.HeaderText = "change_amount";
            this.change_amount.MinimumWidth = 8;
            this.change_amount.Name = "change_amount";
            this.change_amount.ReadOnly = true;
            this.change_amount.Visible = false;
            // 
            // due_amount
            // 
            this.due_amount.DataPropertyName = "due_amount";
            this.due_amount.HeaderText = "Due Amount";
            this.due_amount.MinimumWidth = 8;
            this.due_amount.Name = "due_amount";
            this.due_amount.ReadOnly = true;
            // 
            // shift_id
            // 
            this.shift_id.DataPropertyName = "shift_id";
            this.shift_id.HeaderText = "Shift ID";
            this.shift_id.MinimumWidth = 8;
            this.shift_id.Name = "shift_id";
            this.shift_id.ReadOnly = true;
            // 
            // log_date
            // 
            this.log_date.DataPropertyName = "log_date";
            this.log_date.HeaderText = "log_date";
            this.log_date.MinimumWidth = 8;
            this.log_date.Name = "log_date";
            this.log_date.ReadOnly = true;
            this.log_date.Visible = false;
            // 
            // note
            // 
            this.note.DataPropertyName = "note";
            this.note.HeaderText = "note";
            this.note.MinimumWidth = 8;
            this.note.Name = "note";
            this.note.ReadOnly = true;
            // 
            // prntInvBtn
            // 
            this.prntInvBtn.Location = new System.Drawing.Point(873, 617);
            this.prntInvBtn.Name = "prntInvBtn";
            this.prntInvBtn.Size = new System.Drawing.Size(115, 56);
            this.prntInvBtn.TabIndex = 9;
            this.prntInvBtn.Text = "Print";
            this.prntInvBtn.UseVisualStyleBackColor = true;
            this.prntInvBtn.Click += new System.EventHandler(this.prntInvBtn_Click);
            this.prntInvBtn.MouseHover += new System.EventHandler(this.prntInvBtn_MouseHover);
            // 
            // AvoidInvBtn
            // 
            this.AvoidInvBtn.Location = new System.Drawing.Point(757, 617);
            this.AvoidInvBtn.Name = "AvoidInvBtn";
            this.AvoidInvBtn.Size = new System.Drawing.Size(110, 56);
            this.AvoidInvBtn.TabIndex = 13;
            this.AvoidInvBtn.Text = "Avoid";
            this.AvoidInvBtn.UseVisualStyleBackColor = true;
            this.AvoidInvBtn.Click += new System.EventHandler(this.AvoidInvBtn_Click);
            this.AvoidInvBtn.MouseHover += new System.EventHandler(this.AvoidInvBtn_MouseHover);
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
            this.pnlInner.AutoScroll = true;
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.button2);
            this.pnlInner.Controls.Add(this.filterBoxPnl);
            this.pnlInner.Controls.Add(this.rowsCountLbl);
            this.pnlInner.Controls.Add(this.label1);
            this.pnlInner.Controls.Add(this.textBox2);
            this.pnlInner.Controls.Add(this.panel1);
            this.pnlInner.Controls.Add(this.BtnArrowDwn);
            this.pnlInner.Controls.Add(this.AvoidInvBtn);
            this.pnlInner.Controls.Add(this.BtnArrowUp);
            this.pnlInner.Controls.Add(this.pnlTitle);
            this.pnlInner.Controls.Add(this.prntInvBtn);
            this.pnlInner.Controls.Add(this.button1);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(8, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(1194, 706);
            this.pnlInner.TabIndex = 16;
            this.pnlInner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInner_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(994, 615);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 56);
            this.button2.TabIndex = 215;
            this.button2.Text = "Pay_Due";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // filterBoxPnl
            // 
            this.filterBoxPnl.Controls.Add(this.label2);
            this.filterBoxPnl.Controls.Add(this.cmbCustomer);
            this.filterBoxPnl.Controls.Add(this.label9);
            this.filterBoxPnl.Controls.Add(this.textBox1);
            this.filterBoxPnl.Controls.Add(this.label6);
            this.filterBoxPnl.Controls.Add(this.fromDate);
            this.filterBoxPnl.Controls.Add(this.label8);
            this.filterBoxPnl.Controls.Add(this.UsernameComb);
            this.filterBoxPnl.Controls.Add(this.label7);
            this.filterBoxPnl.Controls.Add(this.ToDate);
            this.filterBoxPnl.Location = new System.Drawing.Point(11, 55);
            this.filterBoxPnl.Name = "filterBoxPnl";
            this.filterBoxPnl.Size = new System.Drawing.Size(1044, 66);
            this.filterBoxPnl.TabIndex = 214;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(767, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 212;
            this.label2.Text = "Customer Name";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(771, 34);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(206, 22);
            this.cmbCustomer.TabIndex = 211;
            this.cmbCustomer.TextChanged += new System.EventHandler(this.cmbCustomer_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 14);
            this.label9.TabIndex = 209;
            this.label9.Text = "Shift ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 210;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 14);
            this.label6.TabIndex = 204;
            this.label6.Text = "From Date";
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd-MM-yyyy";
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(131, 34);
            this.fromDate.Name = "fromDate";
            this.fromDate.ShowCheckBox = true;
            this.fromDate.Size = new System.Drawing.Size(200, 22);
            this.fromDate.TabIndex = 202;
            this.fromDate.ValueChanged += new System.EventHandler(this.fromDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(551, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 14);
            this.label8.TabIndex = 207;
            this.label8.Text = "Username";
            // 
            // UsernameComb
            // 
            this.UsernameComb.DropDownWidth = 206;
            this.UsernameComb.FormattingEnabled = true;
            this.UsernameComb.ItemHeight = 14;
            this.UsernameComb.Location = new System.Drawing.Point(555, 34);
            this.UsernameComb.Name = "UsernameComb";
            this.UsernameComb.Size = new System.Drawing.Size(206, 22);
            this.UsernameComb.TabIndex = 206;
            this.UsernameComb.SelectedIndexChanged += new System.EventHandler(this.UsernameComb_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 14);
            this.label7.TabIndex = 205;
            this.label7.Text = "To Date";
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "dd-MM-yyyy";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(339, 34);
            this.ToDate.Name = "ToDate";
            this.ToDate.ShowCheckBox = true;
            this.ToDate.Size = new System.Drawing.Size(200, 22);
            this.ToDate.TabIndex = 203;
            this.ToDate.ValueChanged += new System.EventHandler(this.ToDate_ValueChanged);
            // 
            // rowsCountLbl
            // 
            this.rowsCountLbl.AutoSize = true;
            this.rowsCountLbl.Location = new System.Drawing.Point(631, 639);
            this.rowsCountLbl.Name = "rowsCountLbl";
            this.rowsCountLbl.Size = new System.Drawing.Size(0, 14);
            this.rowsCountLbl.TabIndex = 213;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 638);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 212;
            this.label1.Text = "Note For Avoid:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(144, 631);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(323, 22);
            this.textBox2.TabIndex = 211;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvInvoiceReceipts);
            this.panel1.Location = new System.Drawing.Point(11, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 484);
            this.panel1.TabIndex = 201;
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
            this.pbxClose.Location = new System.Drawing.Point(1155, 5);
            this.pbxClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(35, 37);
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
            this.lblTitle.Size = new System.Drawing.Size(133, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Invoice Reciepts";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::cypos.Properties.Resources.refresh;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(1061, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 42);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // frmInvoiceReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1210, 714);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoiceReceipts";
            this.Text = "Delivery Orders";
            this.Load += new System.EventHandler(this.frmDeliveryOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceReceipts)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.filterBoxPnl.ResumeLayout(false);
            this.filterBoxPnl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoiceReceipts;
        private System.Windows.Forms.Button prntInvBtn;
        private System.Windows.Forms.Button BtnArrowUp;
        private System.Windows.Forms.Button BtnArrowDwn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AvoidInvBtn;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox UsernameComb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rowsCountLbl;
        private System.Windows.Forms.Panel filterBoxPnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn header_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn change_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn due_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn log_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cmbCustomer;
        private System.Windows.Forms.Button button2;
    }
}