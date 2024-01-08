
namespace cypos.Forms
{
    partial class frmSplitChecksPopup
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.disSelectAll = new System.Windows.Forms.Button();
            this.disSelectOne = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.selectOneBtn = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
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
            this.pnlInner.Controls.Add(this.disSelectAll);
            this.pnlInner.Controls.Add(this.disSelectOne);
            this.pnlInner.Controls.Add(this.saveBtn);
            this.pnlInner.Controls.Add(this.selectAllBtn);
            this.pnlInner.Controls.Add(this.selectOneBtn);
            this.pnlInner.Controls.Add(this.listBox2);
            this.pnlInner.Controls.Add(this.listBox1);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlInner.Size = new System.Drawing.Size(727, 438);
            this.pnlInner.TabIndex = 0;
            // 
            // disSelectAll
            // 
            this.disSelectAll.Location = new System.Drawing.Point(244, 302);
            this.disSelectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.disSelectAll.Name = "disSelectAll";
            this.disSelectAll.Size = new System.Drawing.Size(43, 39);
            this.disSelectAll.TabIndex = 12;
            this.disSelectAll.Text = "<<";
            this.disSelectAll.UseVisualStyleBackColor = true;
            this.disSelectAll.Click += new System.EventHandler(this.disSelectAll_Click);
            // 
            // disSelectOne
            // 
            this.disSelectOne.Location = new System.Drawing.Point(244, 256);
            this.disSelectOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.disSelectOne.Name = "disSelectOne";
            this.disSelectOne.Size = new System.Drawing.Size(43, 39);
            this.disSelectOne.TabIndex = 11;
            this.disSelectOne.Text = "<";
            this.disSelectOne.UseVisualStyleBackColor = true;
            this.disSelectOne.Click += new System.EventHandler(this.disSelectOne_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackgroundImage = global::cypos.Properties.Resources.save24x24;
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveBtn.Location = new System.Drawing.Point(639, 364);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(79, 50);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Location = new System.Drawing.Point(244, 165);
            this.selectAllBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(43, 38);
            this.selectAllBtn.TabIndex = 3;
            this.selectAllBtn.Text = ">>";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // selectOneBtn
            // 
            this.selectOneBtn.Location = new System.Drawing.Point(244, 119);
            this.selectOneBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectOneBtn.Name = "selectOneBtn";
            this.selectOneBtn.Size = new System.Drawing.Size(43, 39);
            this.selectOneBtn.TabIndex = 2;
            this.selectOneBtn.Text = ">";
            this.selectOneBtn.UseVisualStyleBackColor = true;
            this.selectOneBtn.Click += new System.EventHandler(this.selectOneBtn_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(292, 42);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(224, 372);
            this.listBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(15, 42);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 372);
            this.listBox1.TabIndex = 0;
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
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
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
            this.lblTitle.Location = new System.Drawing.Point(11, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Transfer Items";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmSplitChecksPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 442);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSplitChecksPopup";
            this.Text = "SelectDeliveryMan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSplitChecksPopup_FormClosed);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button selectOneBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button disSelectOne;
        private System.Windows.Forms.Button disSelectAll;
    }
}