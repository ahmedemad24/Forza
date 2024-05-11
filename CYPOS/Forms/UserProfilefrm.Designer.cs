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
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnKbAddress = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnKbEmail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnKbContact = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.btnChangePic = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdbUserRole = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(240, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddress.Location = new System.Drawing.Point(240, 100);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(270, 95);
            this.txtAddress.TabIndex = 5;
            // 
            // btnKbAddress
            // 
            this.btnKbAddress.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKbAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnKbAddress.Image")));
            this.btnKbAddress.Location = new System.Drawing.Point(530, 100);
            this.btnKbAddress.Name = "btnKbAddress";
            this.btnKbAddress.Size = new System.Drawing.Size(40, 30);
            this.btnKbAddress.TabIndex = 6;
            this.btnKbAddress.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(240, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Location = new System.Drawing.Point(240, 220);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtEmail.Size = new System.Drawing.Size(270, 30);
            this.txtEmail.TabIndex = 8;
            // 
            // btnKbEmail
            // 
            this.btnKbEmail.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKbEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnKbEmail.Image")));
            this.btnKbEmail.Location = new System.Drawing.Point(530, 220);
            this.btnKbEmail.Name = "btnKbEmail";
            this.btnKbEmail.Size = new System.Drawing.Size(40, 30);
            this.btnKbEmail.TabIndex = 9;
            this.btnKbEmail.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(240, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Contact";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtContact.Location = new System.Drawing.Point(240, 275);
            this.txtContact.Multiline = true;
            this.txtContact.Name = "txtContact";
            this.txtContact.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtContact.Size = new System.Drawing.Size(270, 30);
            this.txtContact.TabIndex = 11;
            // 
            // btnKbContact
            // 
            this.btnKbContact.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbContact.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKbContact.Image = ((System.Drawing.Image)(resources.GetObject("btnKbContact.Image")));
            this.btnKbContact.Location = new System.Drawing.Point(530, 275);
            this.btnKbContact.Name = "btnKbContact";
            this.btnKbContact.Size = new System.Drawing.Size(40, 30);
            this.btnKbContact.TabIndex = 12;
            this.btnKbContact.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(240, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Date Of Birth";
            // 
            // dtDob
            // 
            this.dtDob.CustomFormat = "31 - Dec - 2010";
            this.dtDob.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDob.Location = new System.Drawing.Point(340, 315);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(168, 26);
            this.dtDob.TabIndex = 14;
            // 
            // btnChangePic
            // 
            this.btnChangePic.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangePic.Location = new System.Drawing.Point(20, 220);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(185, 30);
            this.btnChangePic.TabIndex = 15;
            this.btnChangePic.Text = "Change Picture";
            this.btnChangePic.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(20, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Location = new System.Drawing.Point(20, 275);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtUserName.Size = new System.Drawing.Size(185, 30);
            this.txtUserName.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(20, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(20, 330);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPassword.Size = new System.Drawing.Size(185, 30);
            this.txtPassword.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(20, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Position (User Role)";
            // 
            // rdbUserRole
            // 
            this.rdbUserRole.AutoSize = true;
            this.rdbUserRole.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbUserRole.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdbUserRole.Location = new System.Drawing.Point(20, 385);
            this.rdbUserRole.Name = "rdbUserRole";
            this.rdbUserRole.Size = new System.Drawing.Size(66, 22);
            this.rdbUserRole.TabIndex = 21;
            this.rdbUserRole.TabStop = true;
            this.rdbUserRole.Text = "Admin";
            this.rdbUserRole.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(240, 385);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 50);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(413, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 50);
            this.btnExit.TabIndex = 23;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // UserProfilefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 463);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.rdbUserRole);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnChangePic);
            this.Controls.Add(this.dtDob);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnKbContact);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnKbEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnKbAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnKbAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnKbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Button btnKbContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.Button btnChangePic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdbUserRole;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
    }
}