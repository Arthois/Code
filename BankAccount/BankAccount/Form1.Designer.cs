namespace BankAccount
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBank = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtTransaction = new System.Windows.Forms.TextBox();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.rdoNoTransaction = new System.Windows.Forms.RadioButton();
            this.rdoWithdrawal = new System.Windows.Forms.RadioButton();
            this.rdoDeposit = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSummary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBank)).BeginInit();
            this.grpType.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBank
            // 
            this.picBank.Image = global::BankAccount.Properties.Resources.Python;
            this.picBank.Location = new System.Drawing.Point(12, 12);
            this.picBank.Name = "picBank";
            this.picBank.Size = new System.Drawing.Size(117, 101);
            this.picBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBank.TabIndex = 0;
            this.picBank.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(12, 217);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(203, 20);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Enter the transaction amount:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBalance.Location = new System.Drawing.Point(149, 273);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(66, 22);
            this.lblBalance.TabIndex = 99;
            this.lblBalance.Text = "Balance:";
            this.toolTip4.SetToolTip(this.lblBalance, "Your Balance");
            this.lblBalance.Visible = false;
            // 
            // txtTransaction
            // 
            this.txtTransaction.Location = new System.Drawing.Point(221, 214);
            this.txtTransaction.Name = "txtTransaction";
            this.txtTransaction.Size = new System.Drawing.Size(125, 27);
            this.txtTransaction.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtTransaction, "Enter amount of money to Deposit/Withdraw");
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.rdoNoTransaction);
            this.grpType.Controls.Add(this.rdoWithdrawal);
            this.grpType.Controls.Add(this.rdoDeposit);
            this.grpType.Location = new System.Drawing.Point(193, 12);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(187, 173);
            this.grpType.TabIndex = 4;
            this.grpType.TabStop = false;
            this.grpType.Text = "Choose transaction type:";
            // 
            // rdoNoTransaction
            // 
            this.rdoNoTransaction.AutoSize = true;
            this.rdoNoTransaction.Checked = true;
            this.rdoNoTransaction.Location = new System.Drawing.Point(28, 85);
            this.rdoNoTransaction.Name = "rdoNoTransaction";
            this.rdoNoTransaction.Size = new System.Drawing.Size(17, 16);
            this.rdoNoTransaction.TabIndex = 2;
            this.rdoNoTransaction.TabStop = true;
            this.rdoNoTransaction.UseVisualStyleBackColor = true;
            this.rdoNoTransaction.Visible = false;
            // 
            // rdoWithdrawal
            // 
            this.rdoWithdrawal.AutoSize = true;
            this.rdoWithdrawal.Location = new System.Drawing.Point(28, 115);
            this.rdoWithdrawal.Name = "rdoWithdrawal";
            this.rdoWithdrawal.Size = new System.Drawing.Size(106, 24);
            this.rdoWithdrawal.TabIndex = 1;
            this.rdoWithdrawal.Text = "&Withdrawal";
            this.toolTip1.SetToolTip(this.rdoWithdrawal, "Check to Withdraw money");
            this.rdoWithdrawal.UseVisualStyleBackColor = true;
            // 
            // rdoDeposit
            // 
            this.rdoDeposit.AutoSize = true;
            this.rdoDeposit.Location = new System.Drawing.Point(28, 43);
            this.rdoDeposit.Name = "rdoDeposit";
            this.rdoDeposit.Size = new System.Drawing.Size(82, 24);
            this.rdoDeposit.TabIndex = 0;
            this.rdoDeposit.Text = "&Deposit";
            this.toolTip1.SetToolTip(this.rdoDeposit, "Check to Deposit money");
            this.rdoDeposit.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 312);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 67);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Update Balance";
            this.toolTip4.SetToolTip(this.btnUpdate, "Update Balance");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(346, 332);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 47);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "&Exit";
            this.toolTip4.SetToolTip(this.btnExit, "Closes the Program");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(346, 278);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 48);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "&Clear";
            this.toolTip4.SetToolTip(this.btnClear, "Clears everything");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Enabled = false;
            this.btnSummary.Location = new System.Drawing.Point(246, 331);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(94, 48);
            this.btnSummary.TabIndex = 100;
            this.btnSummary.Text = "Summary";
            this.toolTip4.SetToolTip(this.btnSummary, "Show summary\r\n");
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(466, 391);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.txtTransaction);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.picBank);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Account";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBank)).EndInit();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picBank;
        private Label lblText;
        private Label lblBalance;
        private TextBox txtTransaction;
        private GroupBox grpType;
        private RadioButton rdoWithdrawal;
        private RadioButton rdoDeposit;
        private Button btnUpdate;
        private Button btnExit;
        private Button btnClear;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip4;
        private ToolTip toolTip3;
        private RadioButton rdoNoTransaction;
        private Button btnSummary;
    }
}