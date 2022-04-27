namespace BankAccount
{
    partial class SummaryForm
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
            this.lblWithdrawals = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.txtWithDrawn = new System.Windows.Forms.TextBox();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.lblNoWithdrawn = new System.Windows.Forms.Label();
            this.lblNoDeposits = new System.Windows.Forms.Label();
            this.txtNoWithdrawn = new System.Windows.Forms.TextBox();
            this.txtNoDeposit = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblService = new System.Windows.Forms.Label();
            this.txtServices = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblWithdrawals
            // 
            this.lblWithdrawals.AutoSize = true;
            this.lblWithdrawals.Location = new System.Drawing.Point(12, 155);
            this.lblWithdrawals.Name = "lblWithdrawals";
            this.lblWithdrawals.Size = new System.Drawing.Size(160, 20);
            this.lblWithdrawals.TabIndex = 0;
            this.lblWithdrawals.Text = "Total money taken out:";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(12, 245);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(167, 20);
            this.lblDeposit.TabIndex = 1;
            this.lblDeposit.Text = "Total money brought in:";
            // 
            // txtWithDrawn
            // 
            this.txtWithDrawn.Location = new System.Drawing.Point(178, 152);
            this.txtWithDrawn.Name = "txtWithDrawn";
            this.txtWithDrawn.ReadOnly = true;
            this.txtWithDrawn.Size = new System.Drawing.Size(125, 27);
            this.txtWithDrawn.TabIndex = 2;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(185, 242);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.ReadOnly = true;
            this.txtDeposit.Size = new System.Drawing.Size(118, 27);
            this.txtDeposit.TabIndex = 3;
            // 
            // lblNoWithdrawn
            // 
            this.lblNoWithdrawn.AutoSize = true;
            this.lblNoWithdrawn.Location = new System.Drawing.Point(12, 197);
            this.lblNoWithdrawn.Name = "lblNoWithdrawn";
            this.lblNoWithdrawn.Size = new System.Drawing.Size(201, 20);
            this.lblNoWithdrawn.TabIndex = 4;
            this.lblNoWithdrawn.Text = "Total number of withdrawals:";
            // 
            // lblNoDeposits
            // 
            this.lblNoDeposits.AutoSize = true;
            this.lblNoDeposits.Location = new System.Drawing.Point(12, 290);
            this.lblNoDeposits.Name = "lblNoDeposits";
            this.lblNoDeposits.Size = new System.Drawing.Size(178, 20);
            this.lblNoDeposits.TabIndex = 5;
            this.lblNoDeposits.Text = "Total number of deposits:";
            // 
            // txtNoWithdrawn
            // 
            this.txtNoWithdrawn.Location = new System.Drawing.Point(219, 197);
            this.txtNoWithdrawn.Name = "txtNoWithdrawn";
            this.txtNoWithdrawn.ReadOnly = true;
            this.txtNoWithdrawn.Size = new System.Drawing.Size(84, 27);
            this.txtNoWithdrawn.TabIndex = 6;
            // 
            // txtNoDeposit
            // 
            this.txtNoDeposit.Location = new System.Drawing.Point(196, 287);
            this.txtNoDeposit.Name = "txtNoDeposit";
            this.txtNoDeposit.ReadOnly = true;
            this.txtNoDeposit.Size = new System.Drawing.Size(107, 27);
            this.txtNoDeposit.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(331, 387);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 58);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Close Summary";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(124, 58);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear Summary Info";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(12, 325);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(178, 20);
            this.lblService.TabIndex = 10;
            this.lblService.Text = "Services amount charged:";
            // 
            // txtServices
            // 
            this.txtServices.Location = new System.Drawing.Point(196, 325);
            this.txtServices.Name = "txtServices";
            this.txtServices.ReadOnly = true;
            this.txtServices.Size = new System.Drawing.Size(107, 27);
            this.txtServices.TabIndex = 11;
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 457);
            this.Controls.Add(this.txtServices);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtNoDeposit);
            this.Controls.Add(this.txtNoWithdrawn);
            this.Controls.Add(this.lblNoDeposits);
            this.Controls.Add(this.lblNoWithdrawn);
            this.Controls.Add(this.txtDeposit);
            this.Controls.Add(this.txtWithDrawn);
            this.Controls.Add(this.lblDeposit);
            this.Controls.Add(this.lblWithdrawals);
            this.Name = "SummaryForm";
            this.Text = "Bank Account Summary";
            this.Load += new System.EventHandler(this.SummaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblWithdrawals;
        private Label lblDeposit;
        private TextBox txtWithDrawn;
        private TextBox txtDeposit;
        private Label lblNoWithdrawn;
        private Label lblNoDeposits;
        private TextBox txtNoWithdrawn;
        private TextBox txtNoDeposit;
        private Button btnExit;
        private Button btnClear;
        private Label lblService;
        private TextBox txtServices;
    }
}