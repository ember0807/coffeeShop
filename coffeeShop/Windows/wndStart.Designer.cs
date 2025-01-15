namespace coffeeShop.Windows
{
    partial class wndStart
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
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSignUpAdmin = new System.Windows.Forms.Button();
            this.btnReqUserPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(12, 115);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(164, 23);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Войти";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(12, 144);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(164, 23);
            this.btnSignUp.TabIndex = 1;
            this.btnSignUp.Text = "Регистрация";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(12, 26);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(164, 20);
            this.tbUserName.TabIndex = 2;
            // 
            // tbPassWord
            // 
            this.tbPassWord.Location = new System.Drawing.Point(12, 69);
            this.tbPassWord.Name = "tbPassWord";
            this.tbPassWord.Size = new System.Drawing.Size(164, 20);
            this.tbPassWord.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Номер телефона";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // btnSignUpAdmin
            // 
            this.btnSignUpAdmin.Location = new System.Drawing.Point(12, 186);
            this.btnSignUpAdmin.Name = "btnSignUpAdmin";
            this.btnSignUpAdmin.Size = new System.Drawing.Size(164, 23);
            this.btnSignUpAdmin.TabIndex = 6;
            this.btnSignUpAdmin.Text = "Reg As Admin";
            this.btnSignUpAdmin.UseVisualStyleBackColor = true;
            this.btnSignUpAdmin.Click += new System.EventHandler(this.btnSignUpAdmin_Click);
            // 
            // btnReqUserPass
            // 
            this.btnReqUserPass.Location = new System.Drawing.Point(12, 215);
            this.btnReqUserPass.Name = "btnReqUserPass";
            this.btnReqUserPass.Size = new System.Drawing.Size(164, 23);
            this.btnReqUserPass.TabIndex = 7;
            this.btnReqUserPass.Text = "Req User Pass";
            this.btnReqUserPass.UseVisualStyleBackColor = true;
            this.btnReqUserPass.Click += new System.EventHandler(this.btnReqUserPass_Click);
            // 
            // wndStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 262);
            this.Controls.Add(this.btnReqUserPass);
            this.Controls.Add(this.btnSignUpAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassWord);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnSignIn);
            this.Name = "wndStart";
            this.Text = "wndStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSignUpAdmin;
        private System.Windows.Forms.Button btnReqUserPass;
    }
}