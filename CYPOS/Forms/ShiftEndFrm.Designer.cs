
namespace cypos.Forms
{
    partial class ShiftEndFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftEndFrm));
            this.ShiftCodeTxt = new DevExpress.XtraEditors.TextEdit();
            this.ShiftCodeLbl = new DevExpress.XtraEditors.LabelControl();
            this.UserNameLbl = new DevExpress.XtraEditors.LabelControl();
            this.UserName = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ShiftDate = new DevExpress.XtraEditors.LabelControl();
            this.StartDatePicker = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.EndDatePicker = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.amountTxt = new DevExpress.XtraEditors.TextEdit();
            this.EndBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftCodeTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountTxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ShiftCodeTxt
            // 
            resources.ApplyResources(this.ShiftCodeTxt, "ShiftCodeTxt");
            this.ShiftCodeTxt.Name = "ShiftCodeTxt";
            this.ShiftCodeTxt.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ShiftCodeTxt.Properties.Appearance.Font")));
            this.ShiftCodeTxt.Properties.Appearance.Options.UseFont = true;
            // 
            // ShiftCodeLbl
            // 
            this.ShiftCodeLbl.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ShiftCodeLbl.Appearance.Font")));
            this.ShiftCodeLbl.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.ShiftCodeLbl, "ShiftCodeLbl");
            this.ShiftCodeLbl.Name = "ShiftCodeLbl";
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("UserNameLbl.Appearance.Font")));
            this.UserNameLbl.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.UserNameLbl, "UserNameLbl");
            this.UserNameLbl.Name = "UserNameLbl";
            // 
            // UserName
            // 
            resources.ApplyResources(this.UserName, "UserName");
            this.UserName.Name = "UserName";
            this.UserName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("UserName.Properties.Appearance.Font")));
            this.UserName.Properties.Appearance.Options.UseFont = true;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Manager = this.barManager1;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Manager = this.barManager1;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Manager = this.barManager1;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Manager = this.barManager1;
            // 
            // ShiftDate
            // 
            this.ShiftDate.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ShiftDate.Appearance.Font")));
            this.ShiftDate.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.ShiftDate, "ShiftDate");
            this.ShiftDate.Name = "ShiftDate";
            // 
            // StartDatePicker
            // 
            resources.ApplyResources(this.StartDatePicker, "StartDatePicker");
            this.StartDatePicker.MenuManager = this.barManager1;
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("StartDatePicker.Properties.Appearance.Font")));
            this.StartDatePicker.Properties.Appearance.Options.UseFont = true;
            this.StartDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StartDatePicker.Properties.Buttons"))))});
            this.StartDatePicker.Properties.MaskSettings.Set("mask", "f");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ShiftCodeLbl);
            this.panelControl1.Controls.Add(this.ShiftCodeTxt);
            this.panelControl1.Controls.Add(this.UserNameLbl);
            this.panelControl1.Controls.Add(this.UserName);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.EndDatePicker);
            this.panelControl2.Controls.Add(this.StartDatePicker);
            this.panelControl2.Controls.Add(this.ShiftDate);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // EndDatePicker
            // 
            resources.ApplyResources(this.EndDatePicker, "EndDatePicker");
            this.EndDatePicker.MenuManager = this.barManager1;
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("EndDatePicker.Properties.Appearance.Font")));
            this.EndDatePicker.Properties.Appearance.Options.UseFont = true;
            this.EndDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EndDatePicker.Properties.Buttons"))))});
            this.EndDatePicker.Properties.MaskSettings.Set("mask", "f");
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.amountTxt);
            resources.ApplyResources(this.panelControl3, "panelControl3");
            this.panelControl3.Name = "panelControl3";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // amountTxt
            // 
            resources.ApplyResources(this.amountTxt, "amountTxt");
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("amountTxt.Properties.Appearance.Font")));
            this.amountTxt.Properties.Appearance.Options.UseFont = true;
            this.amountTxt.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.amountTxt.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.amountTxt.Properties.MaskSettings.Set("mask", "f");
            // 
            // EndBtn
            // 
            this.EndBtn.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("EndBtn.Appearance.Font")));
            this.EndBtn.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.EndBtn, "EndBtn");
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // ShiftEndFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ShiftEndFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShiftEndFrm_FormClosing);
            this.Load += new System.EventHandler(this.ShiftEndFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShiftCodeTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountTxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit ShiftCodeTxt;
        private DevExpress.XtraEditors.LabelControl ShiftCodeLbl;
        private DevExpress.XtraEditors.LabelControl UserNameLbl;
        private DevExpress.XtraEditors.TextEdit UserName;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl ShiftDate;
        private DevExpress.XtraEditors.DateTimeOffsetEdit StartDatePicker;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit amountTxt;
        private DevExpress.XtraEditors.SimpleButton EndBtn;
        private DevExpress.XtraEditors.DateTimeOffsetEdit EndDatePicker;
    }
}