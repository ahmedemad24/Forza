namespace cypos
{
    partial class frmRecallInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecallInvoices));
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.floDineIn = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.floTakeAway = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.floDeliveryOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.floPickupOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.clmDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrintInKot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmKotQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblKotNo = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblHoldId = new System.Windows.Forms.Label();
            this.lblWaiterId = new System.Windows.Forms.Label();
            this.lblTableId = new System.Windows.Forms.Label();
            this.lblOrderTypeId = new System.Windows.Forms.Label();
            this.lblWaiterName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGuests = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rejectBtn = new System.Windows.Forms.Button();
            this.PrntOnlyBtn = new System.Windows.Forms.Button();
            this.filterByUser = new System.Windows.Forms.CheckBox();
            this.btnPrintKot = new System.Windows.Forms.Button();
            this.btnRecall = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Controls.Add(this.tabPage3);
            this.tbMain.Controls.Add(this.tabPage4);
            this.tbMain.Controls.Add(this.tabPage5);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMain.ItemSize = new System.Drawing.Size(135, 45);
            this.tbMain.Location = new System.Drawing.Point(7, 6);
            this.tbMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(772, 551);
            this.tbMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbMain.TabIndex = 6;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.floDineIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage1.Size = new System.Drawing.Size(764, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dine-In";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // floDineIn
            // 
            this.floDineIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floDineIn.Location = new System.Drawing.Point(7, 6);
            this.floDineIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.floDineIn.Name = "floDineIn";
            this.floDineIn.Size = new System.Drawing.Size(750, 486);
            this.floDineIn.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.floTakeAway);
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(764, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Take Away";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // floTakeAway
            // 
            this.floTakeAway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floTakeAway.Location = new System.Drawing.Point(4, 4);
            this.floTakeAway.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.floTakeAway.Name = "floTakeAway";
            this.floTakeAway.Size = new System.Drawing.Size(756, 490);
            this.floTakeAway.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.floDeliveryOrder);
            this.tabPage3.Location = new System.Drawing.Point(4, 49);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(765, 498);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delivery Order";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // floDeliveryOrder
            // 
            this.floDeliveryOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floDeliveryOrder.Location = new System.Drawing.Point(0, 0);
            this.floDeliveryOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.floDeliveryOrder.Name = "floDeliveryOrder";
            this.floDeliveryOrder.Size = new System.Drawing.Size(765, 498);
            this.floDeliveryOrder.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.floPickupOrder);
            this.tabPage4.Location = new System.Drawing.Point(4, 49);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(765, 498);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Pickup Order";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // floPickupOrder
            // 
            this.floPickupOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floPickupOrder.Location = new System.Drawing.Point(0, 0);
            this.floPickupOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.floPickupOrder.Name = "floPickupOrder";
            this.floPickupOrder.Size = new System.Drawing.Size(765, 498);
            this.floPickupOrder.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.flowLayoutPanel1);
            this.tabPage5.Location = new System.Drawing.Point(4, 49);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(764, 498);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Pending Orders";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(752, 489);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 46);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(7, 0, 7, 6);
            this.pnlMain.Size = new System.Drawing.Size(1200, 569);
            this.pnlMain.TabIndex = 164;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.tbMain);
            this.pnlInner.Controls.Add(this.pnlDetail);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(7, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlInner.Size = new System.Drawing.Size(1186, 563);
            this.pnlInner.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.dgvItems);
            this.pnlDetail.Controls.Add(this.panel4);
            this.pnlDetail.Controls.Add(this.panel1);
            this.pnlDetail.Controls.Add(this.panel3);
            this.pnlDetail.Controls.Add(this.panel2);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Location = new System.Drawing.Point(779, 6);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.pnlDetail.Size = new System.Drawing.Size(400, 551);
            this.pnlDetail.TabIndex = 7;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.ColumnHeadersHeight = 26;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDetailId,
            this.clmItemCode,
            this.clmItemName,
            this.clmQty,
            this.clmTotal,
            this.clmPrintInKot,
            this.clmKotQty});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.Location = new System.Drawing.Point(5, 230);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 62;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(393, 288);
            this.dgvItems.TabIndex = 0;
            // 
            // clmDetailId
            // 
            this.clmDetailId.DataPropertyName = "detail_id";
            this.clmDetailId.HeaderText = "Detail Id";
            this.clmDetailId.MinimumWidth = 8;
            this.clmDetailId.Name = "clmDetailId";
            this.clmDetailId.ReadOnly = true;
            this.clmDetailId.Visible = false;
            // 
            // clmItemCode
            // 
            this.clmItemCode.DataPropertyName = "item_code";
            this.clmItemCode.HeaderText = "Code";
            this.clmItemCode.MinimumWidth = 8;
            this.clmItemCode.Name = "clmItemCode";
            this.clmItemCode.ReadOnly = true;
            this.clmItemCode.Visible = false;
            // 
            // clmItemName
            // 
            this.clmItemName.DataPropertyName = "item_name";
            this.clmItemName.HeaderText = "Item";
            this.clmItemName.MinimumWidth = 8;
            this.clmItemName.Name = "clmItemName";
            this.clmItemName.ReadOnly = true;
            // 
            // clmQty
            // 
            this.clmQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmQty.DataPropertyName = "qty";
            this.clmQty.HeaderText = "Qty";
            this.clmQty.MinimumWidth = 8;
            this.clmQty.Name = "clmQty";
            this.clmQty.ReadOnly = true;
            this.clmQty.Width = 50;
            // 
            // clmTotal
            // 
            this.clmTotal.DataPropertyName = "total";
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.MinimumWidth = 8;
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            this.clmTotal.Visible = false;
            // 
            // clmPrintInKot
            // 
            this.clmPrintInKot.DataPropertyName = "print_kot";
            this.clmPrintInKot.HeaderText = "Print In Kot ?";
            this.clmPrintInKot.MinimumWidth = 8;
            this.clmPrintInKot.Name = "clmPrintInKot";
            this.clmPrintInKot.ReadOnly = true;
            this.clmPrintInKot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmPrintInKot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmPrintInKot.Visible = false;
            // 
            // clmKotQty
            // 
            this.clmKotQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmKotQty.DataPropertyName = "kot_qty";
            this.clmKotQty.HeaderText = "Kot Qty";
            this.clmKotQty.MinimumWidth = 8;
            this.clmKotQty.Name = "clmKotQty";
            this.clmKotQty.ReadOnly = true;
            this.clmKotQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmKotQty.ToolTipText = "Printed / Unprinted ";
            this.clmKotQty.Visible = false;
            this.clmKotQty.Width = 50;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(7, 297);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel4.Size = new System.Drawing.Size(393, 230);
            this.panel4.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblKotNo);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblHoldId);
            this.panel1.Controls.Add(this.lblWaiterId);
            this.panel1.Controls.Add(this.lblTableId);
            this.panel1.Controls.Add(this.lblOrderTypeId);
            this.panel1.Controls.Add(this.lblWaiterName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblGuests);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTable);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblOrderType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 92);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblKotNo
            // 
            this.lblKotNo.AutoSize = true;
            this.lblKotNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblKotNo.Location = new System.Drawing.Point(252, 68);
            this.lblKotNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKotNo.Name = "lblKotNo";
            this.lblKotNo.Size = new System.Drawing.Size(16, 17);
            this.lblKotNo.TabIndex = 18;
            this.lblKotNo.Text = "0";
            this.lblKotNo.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Green;
            this.lblUser.Location = new System.Drawing.Point(249, 46);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(133, 18);
            this.lblUser.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(196, 46);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "User:";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Green;
            this.lblTime.Location = new System.Drawing.Point(249, 26);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(133, 18);
            this.lblTime.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(196, 27);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Time:";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Green;
            this.lblDate.Location = new System.Drawing.Point(249, 6);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(133, 18);
            this.lblDate.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(196, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Date:";
            // 
            // lblHoldId
            // 
            this.lblHoldId.AutoSize = true;
            this.lblHoldId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblHoldId.Location = new System.Drawing.Point(280, 68);
            this.lblHoldId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoldId.Name = "lblHoldId";
            this.lblHoldId.Size = new System.Drawing.Size(16, 17);
            this.lblHoldId.TabIndex = 11;
            this.lblHoldId.Text = "0";
            this.lblHoldId.Visible = false;
            // 
            // lblWaiterId
            // 
            this.lblWaiterId.AutoSize = true;
            this.lblWaiterId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblWaiterId.Location = new System.Drawing.Point(360, 68);
            this.lblWaiterId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaiterId.Name = "lblWaiterId";
            this.lblWaiterId.Size = new System.Drawing.Size(16, 17);
            this.lblWaiterId.TabIndex = 8;
            this.lblWaiterId.Text = "0";
            this.lblWaiterId.Visible = false;
            // 
            // lblTableId
            // 
            this.lblTableId.AutoSize = true;
            this.lblTableId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTableId.Location = new System.Drawing.Point(333, 68);
            this.lblTableId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTableId.Name = "lblTableId";
            this.lblTableId.Size = new System.Drawing.Size(16, 17);
            this.lblTableId.TabIndex = 7;
            this.lblTableId.Text = "0";
            this.lblTableId.Visible = false;
            // 
            // lblOrderTypeId
            // 
            this.lblOrderTypeId.AutoSize = true;
            this.lblOrderTypeId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblOrderTypeId.Location = new System.Drawing.Point(307, 68);
            this.lblOrderTypeId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderTypeId.Name = "lblOrderTypeId";
            this.lblOrderTypeId.Size = new System.Drawing.Size(16, 17);
            this.lblOrderTypeId.TabIndex = 6;
            this.lblOrderTypeId.Text = "0";
            this.lblOrderTypeId.Visible = false;
            // 
            // lblWaiterName
            // 
            this.lblWaiterName.BackColor = System.Drawing.Color.Transparent;
            this.lblWaiterName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiterName.ForeColor = System.Drawing.Color.Green;
            this.lblWaiterName.Location = new System.Drawing.Point(60, 66);
            this.lblWaiterName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaiterName.Name = "lblWaiterName";
            this.lblWaiterName.Size = new System.Drawing.Size(133, 18);
            this.lblWaiterName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Waiter:";
            // 
            // lblGuests
            // 
            this.lblGuests.BackColor = System.Drawing.Color.Transparent;
            this.lblGuests.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuests.ForeColor = System.Drawing.Color.Green;
            this.lblGuests.Location = new System.Drawing.Point(60, 46);
            this.lblGuests.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(133, 18);
            this.lblGuests.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Guests:";
            // 
            // lblTable
            // 
            this.lblTable.BackColor = System.Drawing.Color.Transparent;
            this.lblTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.Green;
            this.lblTable.Location = new System.Drawing.Point(60, 26);
            this.lblTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(133, 18);
            this.lblTable.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Table:";
            // 
            // lblOrderType
            // 
            this.lblOrderType.BackColor = System.Drawing.Color.Transparent;
            this.lblOrderType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.ForeColor = System.Drawing.Color.Green;
            this.lblOrderType.Location = new System.Drawing.Point(60, 6);
            this.lblOrderType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(133, 18);
            this.lblOrderType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblTotal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(7, 528);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.panel3.Size = new System.Drawing.Size(393, 23);
            this.panel3.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(274, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotal.Location = new System.Drawing.Point(322, 4);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(68, 17);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "13452.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rejectBtn);
            this.panel2.Controls.Add(this.PrntOnlyBtn);
            this.panel2.Controls.Add(this.filterByUser);
            this.panel2.Controls.Add(this.btnPrintKot);
            this.panel2.Controls.Add(this.btnRecall);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(7, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 123);
            this.panel2.TabIndex = 2;
            // 
            // rejectBtn
            // 
            this.rejectBtn.BackgroundImage = global::cypos.Properties.Resources.Reject;
            this.rejectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rejectBtn.Location = new System.Drawing.Point(119, 2);
            this.rejectBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rejectBtn.Name = "rejectBtn";
            this.rejectBtn.Size = new System.Drawing.Size(133, 59);
            this.rejectBtn.TabIndex = 12;
            this.rejectBtn.UseVisualStyleBackColor = true;
            this.rejectBtn.Click += new System.EventHandler(this.rejectBtn_Click);
            // 
            // PrntOnlyBtn
            // 
            this.PrntOnlyBtn.BackgroundImage = global::cypos.Properties.Resources.print100x40;
            this.PrntOnlyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrntOnlyBtn.Location = new System.Drawing.Point(260, 63);
            this.PrntOnlyBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrntOnlyBtn.Name = "PrntOnlyBtn";
            this.PrntOnlyBtn.Size = new System.Drawing.Size(133, 60);
            this.PrntOnlyBtn.TabIndex = 11;
            this.PrntOnlyBtn.UseVisualStyleBackColor = true;
            this.PrntOnlyBtn.Click += new System.EventHandler(this.PrntOnlyBtn_Click);
            // 
            // filterByUser
            // 
            this.filterByUser.AutoSize = true;
            this.filterByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.filterByUser.Location = new System.Drawing.Point(-1, 16);
            this.filterByUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterByUser.Name = "filterByUser";
            this.filterByUser.Size = new System.Drawing.Size(107, 26);
            this.filterByUser.TabIndex = 10;
            this.filterByUser.Text = "UserOnly";
            this.filterByUser.UseVisualStyleBackColor = true;
            this.filterByUser.CheckedChanged += new System.EventHandler(this.filterByUser_CheckedChanged);
            // 
            // btnPrintKot
            // 
            this.btnPrintKot.BackgroundImage = global::cypos.Properties.Resources.print_kot100x50;
            this.btnPrintKot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrintKot.Location = new System.Drawing.Point(119, 2);
            this.btnPrintKot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintKot.Name = "btnPrintKot";
            this.btnPrintKot.Size = new System.Drawing.Size(133, 59);
            this.btnPrintKot.TabIndex = 9;
            this.btnPrintKot.UseVisualStyleBackColor = true;
            this.btnPrintKot.Click += new System.EventHandler(this.btnPrintKot_Click);
            // 
            // btnRecall
            // 
            this.btnRecall.BackgroundImage = global::cypos.Properties.Resources.recall125x55;
            this.btnRecall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecall.Location = new System.Drawing.Point(260, 2);
            this.btnRecall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRecall.Name = "btnRecall";
            this.btnRecall.Size = new System.Drawing.Size(133, 59);
            this.btnRecall.TabIndex = 0;
            this.btnRecall.UseVisualStyleBackColor = true;
            this.btnRecall.Click += new System.EventHandler(this.btnRecall_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(3, 4, 4, 4);
            this.pnlTitle.Size = new System.Drawing.Size(1200, 46);
            this.pnlTitle.TabIndex = 163;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(1153, 4);
            this.pbxClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(43, 38);
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
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(472, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Recall Invoice (Invoices on Hold or Incomplete)";
            // 
            // frmRecallInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 615);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRecallInvoices";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recall Invoices";
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.FlowLayoutPanel floDineIn;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRecall;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel floTakeAway;
        private System.Windows.Forms.FlowLayoutPanel floDeliveryOrder;
        private System.Windows.Forms.FlowLayoutPanel floPickupOrder;
        private System.Windows.Forms.Label lblWaiterId;
        private System.Windows.Forms.Label lblTableId;
        private System.Windows.Forms.Label lblOrderTypeId;
        private System.Windows.Forms.Label lblWaiterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHoldId;
        private System.Windows.Forms.Button btnPrintKot;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblKotNo;
        private System.Windows.Forms.CheckBox filterByUser;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmPrintInKot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKotQty;
        private System.Windows.Forms.Button PrntOnlyBtn;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button rejectBtn;
    }
}