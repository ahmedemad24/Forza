namespace cypos.Forms.EmployeeFrms
{
    partial class FrmEmployeesCRUD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployeesCRUD));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.spSalary = new DevExpress.XtraEditors.SpinEdit();
            this.txtIdNum = new DevExpress.XtraEditors.TextEdit();
            this.dtHireDate = new DevExpress.XtraEditors.DateEdit();
            this.cmbxJobTitle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtPhoneNum = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbldatePick = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPhoneNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblIDNumber = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblJobtitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblSalary = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.empsGrp = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHireDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHireDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbxJobTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbldatePick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhoneNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIDNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobtitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empsGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.saveBtn);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.spSalary);
            this.layoutControl1.Controls.Add(this.txtIdNum);
            this.layoutControl1.Controls.Add(this.dtHireDate);
            this.layoutControl1.Controls.Add(this.cmbxJobTitle);
            this.layoutControl1.Controls.Add(this.txtPhoneNum);
            this.layoutControl1.Controls.Add(this.txtAddress);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(782, 648);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(24, 185);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(734, 429);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // spSalary
            // 
            this.spSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spSalary.Location = new System.Drawing.Point(107, 116);
            this.spSalary.Name = "spSalary";
            this.spSalary.Properties.Appearance.Options.UseTextOptions = true;
            this.spSalary.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.spSalary.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spSalary.Properties.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.spSalary.Properties.IsFloatValue = false;
            this.spSalary.Properties.MaskSettings.Set("mask", "N00");
            this.spSalary.Size = new System.Drawing.Size(264, 24);
            this.spSalary.StyleController = this.layoutControl1;
            this.spSalary.TabIndex = 10;
            // 
            // txtIdNum
            // 
            this.txtIdNum.Location = new System.Drawing.Point(470, 38);
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(290, 22);
            this.txtIdNum.StyleController = this.layoutControl1;
            this.txtIdNum.TabIndex = 9;
            // 
            // dtHireDate
            // 
            this.dtHireDate.EditValue = null;
            this.dtHireDate.Location = new System.Drawing.Point(107, 90);
            this.dtHireDate.Name = "dtHireDate";
            this.dtHireDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtHireDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtHireDate.Size = new System.Drawing.Size(264, 22);
            this.dtHireDate.StyleController = this.layoutControl1;
            this.dtHireDate.TabIndex = 8;
            // 
            // cmbxJobTitle
            // 
            this.cmbxJobTitle.Location = new System.Drawing.Point(470, 90);
            this.cmbxJobTitle.Name = "cmbxJobTitle";
            this.cmbxJobTitle.Properties.AutoComplete = false;
            this.cmbxJobTitle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbxJobTitle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbxJobTitle.Size = new System.Drawing.Size(290, 22);
            this.cmbxJobTitle.StyleController = this.layoutControl1;
            this.cmbxJobTitle.TabIndex = 7;
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(107, 38);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(264, 22);
            this.txtPhoneNum.StyleController = this.layoutControl1;
            this.txtPhoneNum.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(107, 64);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(653, 22);
            this.txtAddress.StyleController = this.layoutControl1;
            this.txtAddress.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(653, 22);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.lblAddress,
            this.lbldatePick,
            this.lblPhoneNum,
            this.lblIDNumber,
            this.emptySpaceItem5,
            this.lblJobtitle,
            this.lblSalary,
            this.emptySpaceItem6,
            this.empsGrp,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(782, 648);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(752, 26);
            this.layoutControlItem1.Text = "Full Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(83, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 618);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(762, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lblAddress
            // 
            this.lblAddress.Control = this.txtAddress;
            this.lblAddress.Location = new System.Drawing.Point(0, 52);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(752, 26);
            this.lblAddress.Text = "Address";
            this.lblAddress.TextSize = new System.Drawing.Size(83, 16);
            // 
            // lbldatePick
            // 
            this.lbldatePick.Control = this.dtHireDate;
            this.lbldatePick.Location = new System.Drawing.Point(0, 78);
            this.lbldatePick.Name = "lbldatePick";
            this.lbldatePick.Size = new System.Drawing.Size(363, 26);
            this.lbldatePick.Text = "Hire date";
            this.lbldatePick.TextSize = new System.Drawing.Size(83, 16);
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.Control = this.txtPhoneNum;
            this.lblPhoneNum.Location = new System.Drawing.Point(0, 26);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(363, 26);
            this.lblPhoneNum.Text = "Phone number";
            this.lblPhoneNum.TextSize = new System.Drawing.Size(83, 16);
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.Control = this.txtIdNum;
            this.lblIDNumber.Location = new System.Drawing.Point(363, 26);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(389, 26);
            this.lblIDNumber.Text = "ID Number";
            this.lblIDNumber.TextSize = new System.Drawing.Size(83, 16);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(752, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(10, 104);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lblJobtitle
            // 
            this.lblJobtitle.Control = this.cmbxJobTitle;
            this.lblJobtitle.Location = new System.Drawing.Point(363, 78);
            this.lblJobtitle.Name = "lblJobtitle";
            this.lblJobtitle.Size = new System.Drawing.Size(389, 26);
            this.lblJobtitle.Text = "Job title";
            this.lblJobtitle.TextSize = new System.Drawing.Size(83, 16);
            // 
            // lblSalary
            // 
            this.lblSalary.Control = this.spSalary;
            this.lblSalary.Location = new System.Drawing.Point(0, 104);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(363, 31);
            this.lblSalary.Text = "Salary";
            this.lblSalary.TextSize = new System.Drawing.Size(83, 16);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(460, 104);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(302, 31);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // empsGrp
            // 
            this.empsGrp.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.empsGrp.Location = new System.Drawing.Point(0, 135);
            this.empsGrp.Name = "empsGrp";
            this.empsGrp.Size = new System.Drawing.Size(762, 483);
            this.empsGrp.Text = "Employees List";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(738, 433);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // saveBtn
            // 
            this.saveBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Save.ImageOptions.SvgImage")));
            this.saveBtn.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.saveBtn.Location = new System.Drawing.Point(375, 116);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(93, 27);
            this.saveBtn.StyleController = this.layoutControl1;
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.saveBtn;
            this.layoutControlItem3.Location = new System.Drawing.Point(363, 104);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(97, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmEmployeesCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 648);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEmployeesCRUD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.FrmEmployeesCRUD_Load);
            this.Shown += new System.EventHandler(this.FrmEmployeesCRUD_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHireDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHireDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbxJobTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbldatePick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhoneNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIDNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobtitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empsGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraLayout.LayoutControlItem lblAddress;
        private DevExpress.XtraEditors.ComboBoxEdit cmbxJobTitle;
        private DevExpress.XtraEditors.TextEdit txtPhoneNum;
        private DevExpress.XtraLayout.LayoutControlItem lblPhoneNum;
        private DevExpress.XtraLayout.LayoutControlItem lblJobtitle;
        private DevExpress.XtraEditors.DateEdit dtHireDate;
        private DevExpress.XtraLayout.LayoutControlItem lbldatePick;
        private DevExpress.XtraEditors.SpinEdit spSalary;
        private DevExpress.XtraEditors.TextEdit txtIdNum;
        private DevExpress.XtraLayout.LayoutControlItem lblSalary;
        private DevExpress.XtraLayout.LayoutControlItem lblIDNumber;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup empsGrp;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}