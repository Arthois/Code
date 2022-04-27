namespace BookShop
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
            this.lblShopLabel = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.lblBooks = new System.Windows.Forms.Label();
            this.lblDetailsLabel = new System.Windows.Forms.Label();
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblShopLabel
            // 
            this.lblShopLabel.AutoSize = true;
            this.lblShopLabel.Location = new System.Drawing.Point(37, 63);
            this.lblShopLabel.Name = "lblShopLabel";
            this.lblShopLabel.Size = new System.Drawing.Size(90, 20);
            this.lblShopLabel.TabIndex = 0;
            this.lblShopLabel.Text = "Shop Name:";
            // 
            // lblShopName
            // 
            this.lblShopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShopName.Location = new System.Drawing.Point(37, 83);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(196, 39);
            this.lblShopName.TabIndex = 1;
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Location = new System.Drawing.Point(37, 163);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(108, 20);
            this.lblBooks.TabIndex = 2;
            this.lblBooks.Text = "Books In Stock:";
            // 
            // lblDetailsLabel
            // 
            this.lblDetailsLabel.AutoSize = true;
            this.lblDetailsLabel.Location = new System.Drawing.Point(350, 163);
            this.lblDetailsLabel.Name = "lblDetailsLabel";
            this.lblDetailsLabel.Size = new System.Drawing.Size(102, 20);
            this.lblDetailsLabel.TabIndex = 3;
            this.lblDetailsLabel.Text = "Books Details:";
            // 
            // lstBooks
            // 
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.ItemHeight = 20;
            this.lstBooks.Location = new System.Drawing.Point(37, 200);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(284, 144);
            this.lstBooks.TabIndex = 4;
            this.lstBooks.SelectedIndexChanged += new System.EventHandler(this.lstBooks_SelectedIndexChanged);
            // 
            // lstDetails
            // 
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.ItemHeight = 20;
            this.lstDetails.Location = new System.Drawing.Point(350, 200);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(227, 144);
            this.lstDetails.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 390);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.lstBooks);
            this.Controls.Add(this.lblDetailsLabel);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.lblShopName);
            this.Controls.Add(this.lblShopLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblShopLabel;
        private Label lblShopName;
        private Label lblBooks;
        private Label lblDetailsLabel;
        private ListBox lstBooks;
        private ListBox lstDetails;
    }
}