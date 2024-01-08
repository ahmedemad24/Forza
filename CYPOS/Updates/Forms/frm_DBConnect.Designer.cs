
namespace cypos.Updates.Forms
{
    partial class frm_DBConnect
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combServerName = new System.Windows.Forms.ComboBox();
            this.lblLoadServer = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 34);
            this.button1.TabIndex = 462;
            this.button1.Text = "إنشاء قاعدة البيانات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txt_password);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.txt_name);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox4.Location = new System.Drawing.Point(12, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(445, 120);
            this.groupBox4.TabIndex = 461;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "صلاحيات الاتصال بالسيرفر";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.comboBox1.Location = new System.Drawing.Point(15, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(291, 23);
            this.comboBox1.TabIndex = 28;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label22.Location = new System.Drawing.Point(317, 58);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 17);
            this.label22.TabIndex = 3;
            this.label22.Text = "اسم المستخدم :";
            // 
            // txt_password
            // 
            this.txt_password.Enabled = false;
            this.txt_password.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(15, 85);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(291, 24);
            this.txt_password.TabIndex = 9;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label24.Location = new System.Drawing.Point(317, 28);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 17);
            this.label24.TabIndex = 29;
            this.label24.Text = "نوع الاتصال :";
            // 
            // txt_name
            // 
            this.txt_name.Enabled = false;
            this.txt_name.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(15, 54);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(291, 24);
            this.txt_name.TabIndex = 8;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label23.Location = new System.Drawing.Point(317, 88);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 17);
            this.label23.TabIndex = 4;
            this.label23.Text = "كلمة المرور :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combServerName);
            this.groupBox1.Controls.Add(this.lblLoadServer);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(445, 71);
            this.groupBox1.TabIndex = 460;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اختر السيرفر";
            // 
            // combServerName
            // 
            this.combServerName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combServerName.FormattingEnabled = true;
            this.combServerName.Location = new System.Drawing.Point(15, 28);
            this.combServerName.Name = "combServerName";
            this.combServerName.Size = new System.Drawing.Size(291, 23);
            this.combServerName.TabIndex = 450;
            // 
            // lblLoadServer
            // 
            this.lblLoadServer.AutoSize = true;
            this.lblLoadServer.Location = new System.Drawing.Point(317, 31);
            this.lblLoadServer.Name = "lblLoadServer";
            this.lblLoadServer.Size = new System.Drawing.Size(93, 17);
            this.lblLoadServer.TabIndex = 454;
            this.lblLoadServer.TabStop = true;
            this.lblLoadServer.Text = "اسم السيرفر :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 463;
            this.label1.Text = "ادارة قواعد البيانات";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 34);
            this.button2.TabIndex = 462;
            this.button2.Text = "حفظ بيانات الاتصال";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_DBConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_DBConnect";
            this.Text = "frm_DBConnect";
            this.Load += new System.EventHandler(this.frm_DBConnect_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txt_password;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.TextBox txt_name;
        internal System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox combServerName;
        private System.Windows.Forms.LinkLabel lblLoadServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}