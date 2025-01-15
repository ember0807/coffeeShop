namespace coffeeShop.Windows
{
    partial class wndAdminPanel
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
            this.dgUsers = new System.Windows.Forms.DataGridView();
            this.dgTickets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCoffeeForFree = new System.Windows.Forms.CheckBox();
            this.btnCreateTicket = new System.Windows.Forms.Button();
            this.txtPointsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTicketSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserPhone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTickets)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgUsers
            // 
            this.dgUsers.AllowUserToAddRows = false;
            this.dgUsers.AllowUserToOrderColumns = true;
            this.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsers.Location = new System.Drawing.Point(203, 21);
            this.dgUsers.Name = "dgUsers";
            this.dgUsers.ReadOnly = true;
            this.dgUsers.Size = new System.Drawing.Size(724, 221);
            this.dgUsers.TabIndex = 0;
            // 
            // dgTickets
            // 
            this.dgTickets.AllowUserToAddRows = false;
            this.dgTickets.AllowUserToOrderColumns = true;
            this.dgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTickets.Location = new System.Drawing.Point(203, 266);
            this.dgTickets.Name = "dgTickets";
            this.dgTickets.ReadOnly = true;
            this.dgTickets.Size = new System.Drawing.Size(724, 221);
            this.dgTickets.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Клиенты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Продажи";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCoffeeForFree);
            this.groupBox1.Controls.Add(this.btnCreateTicket);
            this.groupBox1.Controls.Add(this.txtPointsCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbTicketSum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbUserPhone);
            this.groupBox1.Location = new System.Drawing.Point(14, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 237);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новая продажа";
            // 
            // cbCoffeeForFree
            // 
            this.cbCoffeeForFree.AutoSize = true;
            this.cbCoffeeForFree.Location = new System.Drawing.Point(6, 77);
            this.cbCoffeeForFree.Name = "cbCoffeeForFree";
            this.cbCoffeeForFree.Size = new System.Drawing.Size(121, 17);
            this.cbCoffeeForFree.TabIndex = 7;
            this.cbCoffeeForFree.Text = "За счет заведения";
            this.cbCoffeeForFree.UseVisualStyleBackColor = true;
            // 
            // btnCreateTicket
            // 
            this.btnCreateTicket.Location = new System.Drawing.Point(6, 139);
            this.btnCreateTicket.Name = "btnCreateTicket";
            this.btnCreateTicket.Size = new System.Drawing.Size(154, 55);
            this.btnCreateTicket.TabIndex = 6;
            this.btnCreateTicket.Text = "Создать чек";
            this.btnCreateTicket.UseVisualStyleBackColor = true;
            this.btnCreateTicket.Click += new System.EventHandler(this.btnCreateTicket_Click);
            // 
            // txtPointsCount
            // 
            this.txtPointsCount.AutoSize = true;
            this.txtPointsCount.Location = new System.Drawing.Point(3, 61);
            this.txtPointsCount.Name = "txtPointsCount";
            this.txtPointsCount.Size = new System.Drawing.Size(56, 13);
            this.txtPointsCount.TabIndex = 5;
            this.txtPointsCount.Text = "Баллов: 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Сумма покупки";
            // 
            // tbTicketSum
            // 
            this.tbTicketSum.Location = new System.Drawing.Point(6, 113);
            this.tbTicketSum.Name = "tbTicketSum";
            this.tbTicketSum.Size = new System.Drawing.Size(151, 20);
            this.tbTicketSum.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Номер телефона покупателя";
            // 
            // tbUserPhone
            // 
            this.tbUserPhone.Location = new System.Drawing.Point(6, 38);
            this.tbUserPhone.Name = "tbUserPhone";
            this.tbUserPhone.Size = new System.Drawing.Size(151, 20);
            this.tbUserPhone.TabIndex = 0;
            this.tbUserPhone.TextChanged += new System.EventHandler(this.tbUserPhone_TextChanged);
            // 
            // wndAdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 499);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgTickets);
            this.Controls.Add(this.dgUsers);
            this.Name = "wndAdminPanel";
            this.Text = "wndAdminPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dgUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTickets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.DataGridView dgTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtPointsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTicketSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserPhone;
        private System.Windows.Forms.CheckBox cbCoffeeForFree;
        private System.Windows.Forms.Button btnCreateTicket;
    }
}