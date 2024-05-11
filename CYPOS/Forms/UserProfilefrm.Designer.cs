namespace cypos.Forms
{
    partial class UserProfilefrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfilefrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.btnKbName = new System.Windows.Forms.Button();
            this.PicUserPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicUserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(240, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Full Name";
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserFullName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserFullName.Location = new System.Drawing.Point(240, 45);
            this.txtUserFullName.Multiline = true;
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtUserFullName.Size = new System.Drawing.Size(270, 30);
            this.txtUserFullName.TabIndex = 2;
            // 
            // btnKbName
            // 
            this.btnKbName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKbName.Image = ((System.Drawing.Image)(resources.GetObject("btnKbName.Image")));
            this.btnKbName.Location = new System.Drawing.Point(530, 45);
            this.btnKbName.Name = "btnKbName";
            this.btnKbName.Size = new System.Drawing.Size(40, 30);
            this.btnKbName.TabIndex = 3;
            this.btnKbName.UseVisualStyleBackColor = true;
            // 
            // PicUserPhoto
            // 
            this.PicUserPhoto.Image = ((System.Drawing.Image)(resources.GetObject("PicUserPhoto.Image")));
            this.PicUserPhoto.Location = new System.Drawing.Point(20, 20);
            this.PicUserPhoto.Name = "PicUserPhoto";
            this.PicUserPhoto.Size = new System.Drawing.Size(185, 175);
            this.PicUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicUserPhoto.TabIndex = 0;
            this.PicUserPhoto.TabStop = false;
            // 
            // UserProfilefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 392);
            this.Controls.Add(this.btnKbName);
            this.Controls.Add(this.txtUserFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PicUserPhoto);
            this.Name = "UserProfilefrm";
            this.Text = "User Profile";
            ((System.ComponentModel.ISupportInitialize)(this.PicUserPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicUserPhoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Button btnKbName;
    }
}