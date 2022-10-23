namespace Assesment_2
{
    partial class LogIn
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.Location = new System.Drawing.Point(24, 175);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(140, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "User Name:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.White;
            this.lblPass.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPass.Location = new System.Drawing.Point(29, 258);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(135, 17);
            this.lblPass.TabIndex = 1;
            this.lblPass.Text = "Password:";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(165, 170);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(154, 27);
            this.txtUser.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtUser, "Enter Your Username");
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(165, 253);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(154, 27);
            this.txtPass.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtPass, "Enter Your Psssword");
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogIn.Enabled = false;
            this.btnLogIn.ForeColor = System.Drawing.Color.Black;
            this.btnLogIn.Location = new System.Drawing.Point(190, 402);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(111, 41);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "Login";
            this.toolTip1.SetToolTip(this.btnLogIn, "Press To Log In");
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::Assesment_2.Properties.Resources.CarRental;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(319, 1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(489, 490);
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 402);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 41);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.toolTip1.SetToolTip(this.btnExit, "Exits The Program");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGreeting.Location = new System.Drawing.Point(49, 66);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(252, 34);
            this.lblGreeting.TabIndex = 7;
            this.lblGreeting.Text = "Hello, please login \r\nusing your details";
            this.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // LogIn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(809, 490);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUsername);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.Load += new System.EventHandler(this.LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUsername;
        private Label lblPass;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogIn;
        private PictureBox picLogo;
        private Button btnExit;
        private Label lblGreeting;
        private ToolTip toolTip1;
    }
}