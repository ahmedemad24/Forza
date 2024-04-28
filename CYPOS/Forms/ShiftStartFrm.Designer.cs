
namespace cypos.Forms
{
    partial class ShiftStartFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftStartFrm));
            this.ShiftCodeLbl = new DevExpress.XtraEditors.LabelControl();
            this.UserNameLbl = new DevExpress.XtraEditors.LabelControl();
            this.ShiftDate = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.startBtn = new DevExpress.XtraEditors.SimpleButton();
            this.ShiftCodeTxt = new DevExpress.XtraEditors.TextEdit();
            this.UserName = new DevExpress.XtraEditors.TextEdit();
            this.StartDatePicker = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.amountTxt = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftCodeTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDatePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTxt.Properties)).BeginInit();
            this.SuspendLayout();
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
            // ShiftDate
            // 
            this.ShiftDate.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ShiftDate.Appearance.Font")));
            this.ShiftDate.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.ShiftDate, "ShiftDate");
            this.ShiftDate.Name = "ShiftDate";
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
            this.panelControl2.Controls.Add(this.StartDatePicker);
            this.panelControl2.Controls.Add(this.ShiftDate);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
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
            // startBtn
            // 
            this.startBtn.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("startBtn.Appearance.Font")));
            this.startBtn.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.startBtn, "startBtn");
            this.startBtn.Name = "startBtn";
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // ShiftCodeTxt
            // 
            resources.ApplyResources(this.ShiftCodeTxt, "ShiftCodeTxt");
            this.ShiftCodeTxt.Name = "ShiftCodeTxt";
            this.ShiftCodeTxt.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ShiftCodeTxt.Properties.Appearance.Font")));
            this.ShiftCodeTxt.Properties.Appearance.Options.UseFont = true;
            // 
            // UserName
            // 
            resources.ApplyResources(this.UserName, "UserName");
            this.UserName.Name = "UserName";
            this.UserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.UserName.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("UserName.Properties.Appearance.Font")));
            this.UserName.Properties.Appearance.Options.UseBackColor = true;
            this.UserName.Properties.Appearance.Options.UseFont = true;
            // 
            // StartDatePicker
            // 
            resources.ApplyResources(this.StartDatePicker, "StartDatePicker");
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("StartDatePicker.Properties.Appearance.Font")));
            this.StartDatePicker.Properties.Appearance.Options.UseFont = true;
            this.StartDatePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StartDatePicker.Properties.Buttons"))))});
            this.StartDatePicker.Properties.MaskSettings.Set("mask", "f");
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
            // ShiftStartFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ShiftStartFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartShiftFrm_FormClosing);
            this.Load += new System.EventHandler(this.StartShiftFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftCodeTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDatePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountTxt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit ShiftCodeTxt;
        private DevExpress.XtraEditors.LabelControl ShiftCodeLbl;
        private DevExpress.XtraEditors.LabelControl UserNameLbl;
        private DevExpress.XtraEditors.TextEdit UserName;
        private DevExpress.XtraEditors.LabelControl ShiftDate;
        private DevExpress.XtraEditors.DateTimeOffsetEdit StartDatePicker;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit amountTxt;
        private DevExpress.XtraEditors.SimpleButton startBtn;
    }
}