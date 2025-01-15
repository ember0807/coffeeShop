using System.Windows.Forms;

namespace coffeeShop.Windows
{
    partial class wndUserPanel
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
            this.dgTickets = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrize = new System.Windows.Forms.Label();
            this.txtPoints = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTickets
            // 
            this.dgTickets.AllowUserToAddRows = false;
            this.dgTickets.AllowUserToDeleteRows = false;
            this.dgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTickets.Location = new System.Drawing.Point(12, 25);
            this.dgTickets.Name = "dgTickets";
            this.dgTickets.ReadOnly = true;
            this.dgTickets.Size = new System.Drawing.Size(343, 150);
            this.dgTickets.TabIndex = 0;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "История покупок";
            // 
            // txtPrize
            // 
            this.txtPrize.AutoSize = true;
            this.txtPrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtPrize.Location = new System.Drawing.Point(7, 206);
            this.txtPrize.Name = "txtPrize";
            this.txtPrize.Size = new System.Drawing.Size(210, 29);
            this.txtPrize.TabIndex = 2;
            this.txtPrize.Text = "Coffee for FREE!";
            // 
            // txtPoints
            // 
            this.txtPoints.AutoSize = true;
            this.txtPoints.Location = new System.Drawing.Point(12, 178);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(98, 13);
            this.txtPoints.TabIndex = 3;
            this.txtPoints.Text = "Бонусные баллы: ";
            // 
            // wndUserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 244);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.txtPrize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgTickets);
            this.Name = "wndUserPanel";
            this.Text = "wndUserPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dgTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTickets;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtPrize;
        private System.Windows.Forms.Label txtPoints;
    }
}