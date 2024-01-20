
namespace cypos.Forms
{
    partial class frmSelectDeliveryMan
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
            this.deliverymanDD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setDeliveryBtn = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.cmbDXSelectDeliveryMan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDXSelectDeliveryMan.Properties)).BeginInit();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deliverymanDD
            // 
            this.deliverymanDD.DropDownWidth = 220;
            this.deliverymanDD.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.deliverymanDD.FormattingEnabled = true;
            this.deliverymanDD.Location = new System.Drawing.Point(250, 63);
            this.deliverymanDD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deliverymanDD.Name = "deliverymanDD";
            this.deliverymanDD.Size = new System.Drawing.Size(196, 37);
            this.deliverymanDD.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.45F);
            this.label1.Location = new System.Drawing.Point(245, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.TabIndex = 194;
            this.label1.Text = "Select Delivery man";
            // 
            // setDeliveryBtn
            // 
            this.setDeliveryBtn.Font = new System.Drawing.Font("Tahoma", 9F);
            this.setDeliveryBtn.Location = new System.Drawing.Point(292, 225);
            this.setDeliveryBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setDeliveryBtn.Name = "setDeliveryBtn";
            this.setDeliveryBtn.Size = new System.Drawing.Size(102, 36);
            this.setDeliveryBtn.TabIndex = 195;
            this.setDeliveryBtn.Text = "Save";
            this.setDeliveryBtn.UseVisualStyleBackColor = true;
            this.setDeliveryBtn.Click += new System.EventHandler(this.setDeliveryBtn_Click);
            this.setDeliveryBtn.MouseHover += new System.EventHandler(this.setDeliveryBtn_MouseHover);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 4);
            this.pnlMain.Size = new System.Drawing.Size(737, 442);
            this.pnlMain.TabIndex = 196;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.comboBoxEdit1);
            this.pnlInner.Controls.Add(this.cmbDXSelectDeliveryMan);
            this.pnlInner.Controls.Add(this.label1);
            this.pnlInner.Controls.Add(this.setDeliveryBtn);
            this.pnlInner.Controls.Add(this.deliverymanDD);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInner.Size = new System.Drawing.Size(727, 438);
            this.pnlInner.TabIndex = 0;
            // 
            // cmbDXSelectDeliveryMan
            // 
            this.cmbDXSelectDeliveryMan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDXSelectDeliveryMan.Location = new System.Drawing.Point(233, 146);
            this.cmbDXSelectDeliveryMan.MaximumSize = new System.Drawing.Size(0, 100);
            this.cmbDXSelectDeliveryMan.MinimumSize = new System.Drawing.Size(0, 40);
            this.cmbDXSelectDeliveryMan.Name = "cmbDXSelectDeliveryMan";
            this.cmbDXSelectDeliveryMan.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.cmbDXSelectDeliveryMan.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.cmbDXSelectDeliveryMan.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbDXSelectDeliveryMan.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.cmbDXSelectDeliveryMan.Properties.Appearance.Options.UseBackColor = true;
            this.cmbDXSelectDeliveryMan.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbDXSelectDeliveryMan.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cmbDXSelectDeliveryMan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDXSelectDeliveryMan.Size = new System.Drawing.Size(0, 22);
            this.cmbDXSelectDeliveryMan.TabIndex = 196;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.pnlTitle.Size = new System.Drawing.Size(737, 30);
            this.pnlTitle.TabIndex = 197;
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(706, 2);
            this.pbxClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(28, 26);
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
            this.lblTitle.Location = new System.Drawing.Point(11, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(198, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Select Delivery Man";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxEdit1.Location = new System.Drawing.Point(250, 159);
            this.comboBoxEdit1.MaximumSize = new System.Drawing.Size(200, 100);
            this.comboBoxEdit1.MinimumSize = new System.Drawing.Size(100, 37);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.comboBoxEdit1.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.comboBoxEdit1.Properties.AdvancedModeOptions.LabelAppearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comboBoxEdit1.Properties.AdvancedModeOptions.LabelAppearance.Options.UseFont = true;
            this.comboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit1.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.IndianRed;
            this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.ContextButtonOptions.AnimationType = DevExpress.Utils.ContextAnimationType.OutAnimation;
            this.comboBoxEdit1.Properties.ContextImageOptions.AllowChangeAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.comboBoxEdit1.Properties.Sorted = true;
            this.comboBoxEdit1.Size = new System.Drawing.Size(196, 37);
            this.comboBoxEdit1.TabIndex = 197;
            // 
            // frmSelectDeliveryMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 442);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSelectDeliveryMan";
            this.Text = "SelectDeliveryMan";
            this.Load += new System.EventHandler(this.frmSelectDeliveryMan_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDXSelectDeliveryMan.Properties)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox deliverymanDD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setDeliveryBtn;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDXSelectDeliveryMan;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
    }
}