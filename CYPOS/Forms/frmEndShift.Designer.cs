
namespace cypos.Forms
{
    partial class frmEndShift
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
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.enddatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
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
            this.pnlLeftInner.Controls.Add(this.EndTimePicker);
            this.pnlLeftInner.Controls.Add(this.enddatePicker);
            this.pnlLeftInner.Controls.Add(this.label4);
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.label3);
            this.pnlLeftInner.Controls.Add(this.txtAmount);
            this.pnlLeftInner.Controls.Add(this.StartTimePicker);
            this.pnlLeftInner.Controls.Add(this.startDatePicker);
            this.pnlLeftInner.Controls.Add(this.label2);
            this.pnlLeftInner.Controls.Add(this.txtShiftCode);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.txtUserName);
            this.pnlLeftInner.Controls.Add(this.label8);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(324, 362);
            this.pnlLeftInner.TabIndex = 162;
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Enabled = false;
            this.EndTimePicker.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTimePicker.Location = new System.Drawing.Point(165, 203);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.Size = new System.Drawing.Size(139, 23);
            this.EndTimePicker.TabIndex = 198;
            // 
            // enddatePicker
            // 
            this.enddatePicker.Enabled = false;
            this.enddatePicker.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.enddatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.enddatePicker.Location = new System.Drawing.Point(11, 203);
            this.enddatePicker.Name = "enddatePicker";
            this.enddatePicker.Size = new System.Drawing.Size(146, 23);
            this.enddatePicker.TabIndex = 197;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 196;
            this.label4.Text = "End Date :";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(97, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 43);
            this.btnSave.TabIndex = 195;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 16);
            this.label3.TabIndex = 193;
            this.label3.Text = "Please enter close amount:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(11, 264);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(293, 23);
            this.txtAmount.TabIndex = 194;
            this.txtAmount.Text = "0";
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.Enabled = false;
            this.StartTimePicker.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTimePicker.Location = new System.Drawing.Point(165, 149);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.Size = new System.Drawing.Size(139, 23);
            this.StartTimePicker.TabIndex = 192;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Enabled = false;
            this.startDatePicker.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(11, 149);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(146, 23);
            this.startDatePicker.TabIndex = 191;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 189;
            this.label2.Text = "Shift Code :";
            // 
            // txtShiftCode
            // 
            this.txtShiftCode.Enabled = false;
            this.txtShiftCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShiftCode.Location = new System.Drawing.Point(11, 37);
            this.txtShiftCode.Name = "txtShiftCode";
            this.txtShiftCode.Size = new System.Drawing.Size(293, 23);
            this.txtShiftCode.TabIndex = 190;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 186;
            this.label1.Text = "User Name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(11, 92);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(293, 23);
            this.txtUserName.TabIndex = 187;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 188;
            this.label8.Text = "Start Date :";
            // 
            // frmEndShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 362);
            this.Controls.Add(this.pnlLeftInner);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Name = "frmEndShift";
            this.Text = "End Shift";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEndShift_FormClosing);
            this.Load += new System.EventHandler(this.frmEndShift_Load);
            this.pnlLeftInner.ResumeLayout(false);
            this.pnlLeftInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeftInner;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.DateTimePicker enddatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShiftCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
    }
}