namespace Bagels
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstBagel = new System.Windows.Forms.ListBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblBagel = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(447, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(129, 58);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Bagel Type";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(447, 199);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(129, 58);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Bagel Type";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(447, 281);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 58);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear Bagel List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(447, 366);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(129, 58);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstBagel
            // 
            this.lstBagel.FormattingEnabled = true;
            this.lstBagel.ItemHeight = 20;
            this.lstBagel.Location = new System.Drawing.Point(26, 116);
            this.lstBagel.Name = "lstBagel";
            this.lstBagel.Size = new System.Drawing.Size(231, 304);
            this.lstBagel.Sorted = true;
            this.lstBagel.TabIndex = 4;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(263, 116);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(178, 27);
            this.txtType.TabIndex = 5;
            // 
            // lblBagel
            // 
            this.lblBagel.AutoSize = true;
            this.lblBagel.Location = new System.Drawing.Point(26, 93);
            this.lblBagel.Name = "lblBagel";
            this.lblBagel.Size = new System.Drawing.Size(91, 20);
            this.lblBagel.TabIndex = 6;
            this.lblBagel.Text = "Bagel Types:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(263, 93);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(162, 20);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Add Bagel Type Below:";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(263, 393);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(43, 27);
            this.txtCount.TabIndex = 8;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(263, 168);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 27);
            this.txtSearch.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(263, 201);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(178, 36);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(26, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 58);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save List";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(177, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(129, 58);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load List";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 448);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblBagel);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lstBagel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAdd;
        private Button btnRemove;
        private Button btnClear;
        private Button btnExit;
        private ListBox lstBagel;
        private TextBox txtType;
        private Label lblBagel;
        private Label lblType;
        private TextBox txtCount;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnSave;
        private Button btnLoad;
    }
}