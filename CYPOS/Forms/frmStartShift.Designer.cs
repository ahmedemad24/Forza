
namespace cypos.Forms
{
    partial class frmStartShift
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
            this.pnlLeftInner = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.timeShiftPicker = new System.Windows.Forms.DateTimePicker();
            this.dateShiftPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShiftCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlLeftInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftInner
            // 
            this.pnlLeftInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlLeftInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.label3);
            this.pnlLeftInner.Controls.Add(this.txtAmount);
            this.pnlLeftInner.Controls.Add(this.timeShiftPicker);
            this.pnlLeftInner.Controls.Add(this.dateShiftPicker);
            this.pnlLeftInner.Controls.Add(this.label2);
            this.pnlLeftInner.Controls.Add(this.txtShiftCode);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.txtUserName);
            this.pnlLeftInner.Controls.Add(this.label8);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(324, 311);
            this.pnlLeftInner.TabIndex = 162;
            this.pnlLeftInner.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeftInner_Paint);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(102, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 43);
            this.btnSave.TabIndex = 182;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 177;
            this.label3.Text = "Please enter amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(15, 216);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(293, 23);
            this.txtAmount.TabIndex = 178;
            this.txtAmount.Text = "0";
            // 
            // timeShiftPicker
            // 
            this.timeShiftPicker.Enabled = false;
            this.timeShiftPicker.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.timeShiftPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeShiftPicker.Location = new System.Drawing.Point(169, 154);
            this.timeShiftPicker.Name = "timeShiftPicker";
            this.timeShiftPicker.Size = new System.Drawing.Size(139, 23);
            this.timeShiftPicker.TabIndex = 176;
            // 
            // dateShiftPicker
            // 
            this.dateShiftPicker.Enabled = false;
            this.dateShiftPicker.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dateShiftPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateShiftPicker.Location = new System.Drawing.Point(15, 154);
            this.dateShiftPicker.Name = "dateShiftPicker";
            this.dateShiftPicker.Size = new System.Drawing.Size(146, 23);
            this.dateShiftPicker.TabIndex = 175;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 173;
            this.label2.Text = "Shift Code :";
            // 
            // txtShiftCode
            // 
            this.txtShiftCode.Enabled = false;
            this.txtShiftCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShiftCode.Location = new System.Drawing.Point(15, 39);
            this.txtShiftCode.Name = "txtShiftCode";
            this.txtShiftCode.Size = new System.Drawing.Size(293, 23);
            this.txtShiftCode.TabIndex = 174;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(15, 94);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(293, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Shift Date :";
            // 
            // frmStartShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 311);
            this.Controls.Add(this.pnlLeftInner);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Name = "frmStartShift";
            this.Text = "Start Shift";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStartShift_FormClosing);
            this.Load += new System.EventHandler(this.frmStartShift_Load);
            this.pnlLeftInner.ResumeLayout(false);
            this.pnlLeftInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftInner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker timeShiftPicker;
        private System.Windows.Forms.DateTimePicker dateShiftPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShiftCode;
        private System.Windows.Forms.Button btnSave;
    }
}