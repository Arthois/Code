namespace Assesment_2
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.White;
            this.lblWelcome.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(181, 81);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(343, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Hello and Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(235, 404);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(205, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "WeAreCars";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Assesment_2.Properties.Resources.CarRental;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 519);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblWelcome);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblWelcome;
        private Label lblName;
        private System.Windows.Forms.Timer timer1;
    }
}