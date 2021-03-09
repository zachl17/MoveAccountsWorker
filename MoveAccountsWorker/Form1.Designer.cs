namespace MoveAccountsWorker
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtActionDate = new System.Windows.Forms.TextBox();
            this.txtDebtor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemainingTotalCount = new System.Windows.Forms.Label();
            this.lblRemainingTotal = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(22, 84);
            this.label1.Name = "lblActionDate";
            this.label1.Size = new System.Drawing.Size(153, 31);
            this.label1.TabIndex = 45;
            this.label1.Text = "Action Date";
            // 
            // txtActionDate
            // 
            this.txtActionDate.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtActionDate.Location = new System.Drawing.Point(209, 85);
            this.txtActionDate.Name = "txtActionDate";
            this.txtActionDate.Size = new System.Drawing.Size(136, 30);
            this.txtActionDate.TabIndex = 44;
            // 
            // txtDebtor
            // 
            this.txtDebtor.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.txtDebtor.Location = new System.Drawing.Point(209, 22);
            this.txtDebtor.Name = "txtDebtor";
            this.txtDebtor.Size = new System.Drawing.Size(136, 30);
            this.txtDebtor.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 31);
            this.label2.TabIndex = 42;
            this.label2.Text = "Debtor";
            // 
            // lblRemainingTotalCount
            // 
            this.lblRemainingTotalCount.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingTotalCount.Location = new System.Drawing.Point(237, 262);
            this.lblRemainingTotalCount.Name = "lblRemainingTotalCount";
            this.lblRemainingTotalCount.Size = new System.Drawing.Size(133, 31);
            this.lblRemainingTotalCount.TabIndex = 41;
            // 
            // lblRemainingTotal
            // 
            this.lblRemainingTotal.AutoSize = true;
            this.lblRemainingTotal.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.lblRemainingTotal.Location = new System.Drawing.Point(22, 262);
            this.lblRemainingTotal.Name = "lblRemainingTotal";
            this.lblRemainingTotal.Size = new System.Drawing.Size(218, 31);
            this.lblRemainingTotal.TabIndex = 40;
            this.lblRemainingTotal.Text = "Remaining Total:";
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDone.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(100, 183);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(187, 60);
            this.btnDone.TabIndex = 39;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 324);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActionDate);
            this.Controls.Add(this.txtDebtor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRemainingTotalCount);
            this.Controls.Add(this.lblRemainingTotal);
            this.Controls.Add(this.btnDone);
            this.Name = "Form1";
            this.Text = "Move Accounts Worker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActionDate;
        private System.Windows.Forms.TextBox txtDebtor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRemainingTotalCount;
        private System.Windows.Forms.Label lblRemainingTotal;
        private System.Windows.Forms.Button btnDone;
    }
}

