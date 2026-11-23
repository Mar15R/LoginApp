namespace LoginApp.Forms
{
    partial class UserUpdate
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
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Surname = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lb_Username = new System.Windows.Forms.Label();
            this.lb_Error = new System.Windows.Forms.Label();
            this.ckb_Enabled = new System.Windows.Forms.CheckBox();
            this.cb_Roles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_GetRndPwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Update:";
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(17, 230);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(194, 33);
            this.btn_Update.TabIndex = 21;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Surname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(111, 92);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(100, 20);
            this.txt_Password.TabIndex = 15;
            // 
            // txt_Surname
            // 
            this.txt_Surname.Location = new System.Drawing.Point(111, 66);
            this.txt_Surname.Name = "txt_Surname";
            this.txt_Surname.Size = new System.Drawing.Size(100, 20);
            this.txt_Surname.TabIndex = 14;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(111, 40);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(100, 20);
            this.txt_Name.TabIndex = 13;
            // 
            // lb_Username
            // 
            this.lb_Username.AutoSize = true;
            this.lb_Username.Location = new System.Drawing.Point(108, 9);
            this.lb_Username.Name = "lb_Username";
            this.lb_Username.Size = new System.Drawing.Size(55, 13);
            this.lb_Username.TabIndex = 24;
            this.lb_Username.Text = "Username";
            // 
            // lb_Error
            // 
            this.lb_Error.AutoSize = true;
            this.lb_Error.Location = new System.Drawing.Point(14, 278);
            this.lb_Error.Name = "lb_Error";
            this.lb_Error.Size = new System.Drawing.Size(0, 13);
            this.lb_Error.TabIndex = 25;
            // 
            // ckb_Enabled
            // 
            this.ckb_Enabled.AutoSize = true;
            this.ckb_Enabled.Location = new System.Drawing.Point(146, 152);
            this.ckb_Enabled.Name = "ckb_Enabled";
            this.ckb_Enabled.Size = new System.Drawing.Size(65, 17);
            this.ckb_Enabled.TabIndex = 26;
            this.ckb_Enabled.Text = "Enabled";
            this.ckb_Enabled.UseVisualStyleBackColor = true;
            // 
            // cb_Roles
            // 
            this.cb_Roles.FormattingEnabled = true;
            this.cb_Roles.Location = new System.Drawing.Point(90, 175);
            this.cb_Roles.Name = "cb_Roles";
            this.cb_Roles.Size = new System.Drawing.Size(121, 21);
            this.cb_Roles.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Role";
            // 
            // btn_GetRndPwd
            // 
            this.btn_GetRndPwd.Location = new System.Drawing.Point(136, 118);
            this.btn_GetRndPwd.Name = "btn_GetRndPwd";
            this.btn_GetRndPwd.Size = new System.Drawing.Size(75, 23);
            this.btn_GetRndPwd.TabIndex = 29;
            this.btn_GetRndPwd.Text = "Generate";
            this.btn_GetRndPwd.UseVisualStyleBackColor = true;
            this.btn_GetRndPwd.Click += new System.EventHandler(this.btn_GetRndPwd_Click);
            // 
            // UserUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 341);
            this.Controls.Add(this.btn_GetRndPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_Roles);
            this.Controls.Add(this.ckb_Enabled);
            this.Controls.Add(this.lb_Error);
            this.Controls.Add(this.lb_Username);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Surname);
            this.Controls.Add(this.txt_Name);
            this.Name = "UserUpdate";
            this.Text = "UserUpdate";
            this.Load += new System.EventHandler(this.UserUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Surname;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lb_Username;
        private System.Windows.Forms.Label lb_Error;
        private System.Windows.Forms.CheckBox ckb_Enabled;
        private System.Windows.Forms.ComboBox cb_Roles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_GetRndPwd;
    }
}