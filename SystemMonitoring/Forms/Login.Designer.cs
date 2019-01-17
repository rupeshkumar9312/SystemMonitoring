namespace SystemMonitoring.Forms
{
    partial class Login
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
            this.groupLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblForgotPwd = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPRN = new System.Windows.Forms.TextBox();
            this.lblPRN = new System.Windows.Forms.Label();
            this.lbl_egister = new System.Windows.Forms.LinkLabel();
            this.groupLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLogin
            // 
            this.groupLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupLogin.Controls.Add(this.lbl_egister);
            this.groupLogin.Controls.Add(this.btnLogin);
            this.groupLogin.Controls.Add(this.lblForgotPwd);
            this.groupLogin.Controls.Add(this.txtPassword);
            this.groupLogin.Controls.Add(this.lblPassword);
            this.groupLogin.Controls.Add(this.txtPRN);
            this.groupLogin.Controls.Add(this.lblPRN);
            this.groupLogin.Location = new System.Drawing.Point(24, 27);
            this.groupLogin.Name = "groupLogin";
            this.groupLogin.Size = new System.Drawing.Size(445, 304);
            this.groupLogin.TabIndex = 0;
            this.groupLogin.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.Location = new System.Drawing.Point(225, 141);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblForgotPwd
            // 
            this.lblForgotPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblForgotPwd.AutoSize = true;
            this.lblForgotPwd.Location = new System.Drawing.Point(223, 175);
            this.lblForgotPwd.Name = "lblForgotPwd";
            this.lblForgotPwd.Size = new System.Drawing.Size(86, 13);
            this.lblForgotPwd.TabIndex = 12;
            this.lblForgotPwd.TabStop = true;
            this.lblForgotPwd.Text = "Forgot Password";
            this.lblForgotPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblForgotPwd_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(225, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(193, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(28, 104);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(81, 22);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // txtPRN
            // 
            this.txtPRN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPRN.Location = new System.Drawing.Point(225, 67);
            this.txtPRN.Name = "txtPRN";
            this.txtPRN.Size = new System.Drawing.Size(193, 20);
            this.txtPRN.TabIndex = 9;
            // 
            // lblPRN
            // 
            this.lblPRN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPRN.AutoSize = true;
            this.lblPRN.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPRN.Location = new System.Drawing.Point(27, 66);
            this.lblPRN.Name = "lblPRN";
            this.lblPRN.Size = new System.Drawing.Size(74, 22);
            this.lblPRN.TabIndex = 8;
            this.lblPRN.Text = "PRN No.";
            // 
            // lbl_egister
            // 
            this.lbl_egister.AutoSize = true;
            this.lbl_egister.Location = new System.Drawing.Point(161, 251);
            this.lbl_egister.Name = "lbl_egister";
            this.lbl_egister.Size = new System.Drawing.Size(72, 13);
            this.lbl_egister.TabIndex = 14;
            this.lbl_egister.TabStop = true;
            this.lbl_egister.Text = "Register Here";
            this.lbl_egister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_egister_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 378);
            this.Controls.Add(this.groupLogin);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.groupLogin.ResumeLayout(false);
            this.groupLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPRN;
        private System.Windows.Forms.Label lblPRN;
        private System.Windows.Forms.LinkLabel lblForgotPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lbl_egister;
    }
}