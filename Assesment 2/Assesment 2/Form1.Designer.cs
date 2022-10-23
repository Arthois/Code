namespace Assesment_2
{
    partial class MainPage
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
            this.lstCurrentBookings = new System.Windows.Forms.ListBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrentNo = new System.Windows.Forms.TextBox();
            this.lblCurrentNo = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.grpCarType = new System.Windows.Forms.GroupBox();
            this.rdoNoType = new System.Windows.Forms.RadioButton();
            this.rdoSUV = new System.Windows.Forms.RadioButton();
            this.rdoSports = new System.Windows.Forms.RadioButton();
            this.rdoFamily = new System.Windows.Forms.RadioButton();
            this.rdoCityCar = new System.Windows.Forms.RadioButton();
            this.grpFuel = new System.Windows.Forms.GroupBox();
            this.rdoNoFuel = new System.Windows.Forms.RadioButton();
            this.rdoElectric = new System.Windows.Forms.RadioButton();
            this.rdoHybrid = new System.Windows.Forms.RadioButton();
            this.rdoDiesel = new System.Windows.Forms.RadioButton();
            this.rdoPetrol = new System.Windows.Forms.RadioButton();
            this.lblPackage = new System.Windows.Forms.Label();
            this.dtmBirthday = new System.Windows.Forms.DateTimePicker();
            this.lblAge = new System.Windows.Forms.Label();
            this.dtmDayOfBooking = new System.Windows.Forms.DateTimePicker();
            this.dtmEndOfBooking = new System.Windows.Forms.DateTimePicker();
            this.lblStartBooking = new System.Windows.Forms.Label();
            this.lblEndBooking = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblFYI = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkMiles = new System.Windows.Forms.CheckBox();
            this.chkBreakdown = new System.Windows.Forms.CheckBox();
            this.chkNoExtras = new System.Windows.Forms.CheckBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpCarType.SuspendLayout();
            this.grpFuel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCurrentBookings
            // 
            this.lstCurrentBookings.BackColor = System.Drawing.Color.White;
            this.lstCurrentBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCurrentBookings.FormattingEnabled = true;
            this.lstCurrentBookings.ItemHeight = 20;
            this.lstCurrentBookings.Location = new System.Drawing.Point(2, 67);
            this.lstCurrentBookings.Name = "lstCurrentBookings";
            this.lstCurrentBookings.Size = new System.Drawing.Size(249, 440);
            this.lstCurrentBookings.TabIndex = 0;
            this.toolTip1.SetToolTip(this.lstCurrentBookings, "List of current bookiings");
            this.lstCurrentBookings.SelectedIndexChanged += new System.EventHandler(this.lstCurrentBookings_SelectedIndexChanged);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrent.Location = new System.Drawing.Point(2, 28);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(240, 17);
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Text = "Current bookings:";
            // 
            // txtCurrentNo
            // 
            this.txtCurrentNo.BackColor = System.Drawing.Color.White;
            this.txtCurrentNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentNo.Location = new System.Drawing.Point(215, 517);
            this.txtCurrentNo.Name = "txtCurrentNo";
            this.txtCurrentNo.ReadOnly = true;
            this.txtCurrentNo.Size = new System.Drawing.Size(36, 20);
            this.txtCurrentNo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtCurrentNo, "Current booking count");
            // 
            // lblCurrentNo
            // 
            this.lblCurrentNo.AutoSize = true;
            this.lblCurrentNo.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentNo.Location = new System.Drawing.Point(2, 520);
            this.lblCurrentNo.Name = "lblCurrentNo";
            this.lblCurrentNo.Size = new System.Drawing.Size(207, 17);
            this.lblCurrentNo.TabIndex = 3;
            this.lblCurrentNo.Text = "No. of bookings:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 556);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 48);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh Bookings";
            this.toolTip1.SetToolTip(this.btnRefresh, "Refreshes current bookings (Recomended after adding a new booking)");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.Enabled = false;
            this.btnSummary.Location = new System.Drawing.Point(1072, 551);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(134, 53);
            this.btnSummary.TabIndex = 5;
            this.btnSummary.Text = "Booking Summary";
            this.toolTip1.SetToolTip(this.btnSummary, "Current Filled out booking summary");
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(814, 67);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(147, 27);
            this.txtFirstName.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtFirstName, "Customers First Name, Only Letters ");
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.White;
            this.txtSurname.Location = new System.Drawing.Point(814, 114);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(147, 27);
            this.txtSurname.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtSurname, "Customers Surname, Only Letters");
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(814, 160);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(147, 27);
            this.txtAddress.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtAddress, "Customers Address, No Commas (\" , \")");
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.White;
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAge.Location = new System.Drawing.Point(814, 298);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(147, 20);
            this.txtAge.TabIndex = 9;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtAge, "Customers Age");
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // txtLicense
            // 
            this.txtLicense.BackColor = System.Drawing.Color.White;
            this.txtLicense.Location = new System.Drawing.Point(814, 250);
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(147, 27);
            this.txtLicense.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtLicense, "License Number 16 character format, Only Letters and Digits");
            this.txtLicense.TextChanged += new System.EventHandler(this.txtLicense_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(666, 74);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(142, 15);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "* First Name:";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSurname.Location = new System.Drawing.Point(689, 122);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(119, 15);
            this.lblSurname.TabIndex = 12;
            this.lblSurname.Text = "* Surname:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.Location = new System.Drawing.Point(689, 167);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(115, 15);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "* Address:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDOB.Location = new System.Drawing.Point(733, 215);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(66, 15);
            this.lblDOB.TabIndex = 14;
            this.lblDOB.Text = "* DOB:";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLicense.Location = new System.Drawing.Point(657, 257);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(151, 15);
            this.lblLicense.TabIndex = 15;
            this.lblLicense.Text = "* License No. :";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerInfo.Location = new System.Drawing.Point(736, 28);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(249, 17);
            this.lblCustomerInfo.TabIndex = 16;
            this.lblCustomerInfo.Text = "1. Customer Details";
            // 
            // grpCarType
            // 
            this.grpCarType.Controls.Add(this.rdoNoType);
            this.grpCarType.Controls.Add(this.rdoSUV);
            this.grpCarType.Controls.Add(this.rdoSports);
            this.grpCarType.Controls.Add(this.rdoFamily);
            this.grpCarType.Controls.Add(this.rdoCityCar);
            this.grpCarType.Enabled = false;
            this.grpCarType.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpCarType.Location = new System.Drawing.Point(1013, 67);
            this.grpCarType.Name = "grpCarType";
            this.grpCarType.Size = new System.Drawing.Size(193, 125);
            this.grpCarType.TabIndex = 17;
            this.grpCarType.TabStop = false;
            this.grpCarType.Text = "Type of Car *";
            this.toolTip1.SetToolTip(this.grpCarType, "Customers choosen type of car");
            // 
            // rdoNoType
            // 
            this.rdoNoType.AutoSize = true;
            this.rdoNoType.Checked = true;
            this.rdoNoType.Location = new System.Drawing.Point(170, 11);
            this.rdoNoType.Name = "rdoNoType";
            this.rdoNoType.Size = new System.Drawing.Size(17, 16);
            this.rdoNoType.TabIndex = 4;
            this.rdoNoType.TabStop = true;
            this.rdoNoType.UseVisualStyleBackColor = true;
            this.rdoNoType.Visible = false;
            this.rdoNoType.CheckedChanged += new System.EventHandler(this.rdoNoType_CheckedChanged);
            // 
            // rdoSUV
            // 
            this.rdoSUV.AutoSize = true;
            this.rdoSUV.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoSUV.Location = new System.Drawing.Point(6, 100);
            this.rdoSUV.Name = "rdoSUV";
            this.rdoSUV.Size = new System.Drawing.Size(121, 20);
            this.rdoSUV.TabIndex = 3;
            this.rdoSUV.Text = "SUV (+£65)";
            this.rdoSUV.UseVisualStyleBackColor = true;
            this.rdoSUV.CheckedChanged += new System.EventHandler(this.rdoSUV_CheckedChanged);
            // 
            // rdoSports
            // 
            this.rdoSports.AutoSize = true;
            this.rdoSports.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoSports.Location = new System.Drawing.Point(6, 75);
            this.rdoSports.Name = "rdoSports";
            this.rdoSports.Size = new System.Drawing.Size(183, 20);
            this.rdoSports.TabIndex = 2;
            this.rdoSports.Text = "Sports Car (+£75)";
            this.rdoSports.UseVisualStyleBackColor = true;
            this.rdoSports.CheckedChanged += new System.EventHandler(this.rdoSports_CheckedChanged);
            // 
            // rdoFamily
            // 
            this.rdoFamily.AutoSize = true;
            this.rdoFamily.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoFamily.Location = new System.Drawing.Point(6, 50);
            this.rdoFamily.Name = "rdoFamily";
            this.rdoFamily.Size = new System.Drawing.Size(178, 20);
            this.rdoFamily.TabIndex = 1;
            this.rdoFamily.Text = "Family Car (+£50)";
            this.rdoFamily.UseVisualStyleBackColor = true;
            this.rdoFamily.CheckedChanged += new System.EventHandler(this.rdoFamily_CheckedChanged);
            // 
            // rdoCityCar
            // 
            this.rdoCityCar.AutoSize = true;
            this.rdoCityCar.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoCityCar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoCityCar.Location = new System.Drawing.Point(6, 22);
            this.rdoCityCar.Name = "rdoCityCar";
            this.rdoCityCar.Size = new System.Drawing.Size(100, 20);
            this.rdoCityCar.TabIndex = 0;
            this.rdoCityCar.Text = "City Car";
            this.rdoCityCar.UseVisualStyleBackColor = true;
            this.rdoCityCar.CheckedChanged += new System.EventHandler(this.rdoCityCar_CheckedChanged);
            // 
            // grpFuel
            // 
            this.grpFuel.Controls.Add(this.rdoNoFuel);
            this.grpFuel.Controls.Add(this.rdoElectric);
            this.grpFuel.Controls.Add(this.rdoHybrid);
            this.grpFuel.Controls.Add(this.rdoDiesel);
            this.grpFuel.Controls.Add(this.rdoPetrol);
            this.grpFuel.Enabled = false;
            this.grpFuel.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpFuel.Location = new System.Drawing.Point(1013, 206);
            this.grpFuel.Name = "grpFuel";
            this.grpFuel.Size = new System.Drawing.Size(193, 125);
            this.grpFuel.TabIndex = 18;
            this.grpFuel.TabStop = false;
            this.grpFuel.Text = "Fuel Type *";
            this.toolTip1.SetToolTip(this.grpFuel, "Customer choosen Fuel Type");
            // 
            // rdoNoFuel
            // 
            this.rdoNoFuel.AutoSize = true;
            this.rdoNoFuel.Checked = true;
            this.rdoNoFuel.Location = new System.Drawing.Point(170, 11);
            this.rdoNoFuel.Name = "rdoNoFuel";
            this.rdoNoFuel.Size = new System.Drawing.Size(17, 16);
            this.rdoNoFuel.TabIndex = 5;
            this.rdoNoFuel.TabStop = true;
            this.rdoNoFuel.UseVisualStyleBackColor = true;
            this.rdoNoFuel.Visible = false;
            this.rdoNoFuel.CheckedChanged += new System.EventHandler(this.rdoNoFuel_CheckedChanged);
            // 
            // rdoElectric
            // 
            this.rdoElectric.AutoSize = true;
            this.rdoElectric.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoElectric.Location = new System.Drawing.Point(6, 99);
            this.rdoElectric.Name = "rdoElectric";
            this.rdoElectric.Size = new System.Drawing.Size(159, 20);
            this.rdoElectric.TabIndex = 3;
            this.rdoElectric.TabStop = true;
            this.rdoElectric.Text = "Electric (+£50)";
            this.rdoElectric.UseVisualStyleBackColor = true;
            this.rdoElectric.CheckedChanged += new System.EventHandler(this.rdoElectric_CheckedChanged);
            // 
            // rdoHybrid
            // 
            this.rdoHybrid.AutoSize = true;
            this.rdoHybrid.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoHybrid.Location = new System.Drawing.Point(6, 74);
            this.rdoHybrid.Name = "rdoHybrid";
            this.rdoHybrid.Size = new System.Drawing.Size(143, 20);
            this.rdoHybrid.TabIndex = 2;
            this.rdoHybrid.TabStop = true;
            this.rdoHybrid.Text = "Hybrid (+£30)";
            this.rdoHybrid.UseVisualStyleBackColor = true;
            this.rdoHybrid.CheckedChanged += new System.EventHandler(this.rdoHybrid_CheckedChanged);
            // 
            // rdoDiesel
            // 
            this.rdoDiesel.AutoSize = true;
            this.rdoDiesel.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoDiesel.Location = new System.Drawing.Point(6, 48);
            this.rdoDiesel.Name = "rdoDiesel";
            this.rdoDiesel.Size = new System.Drawing.Size(83, 20);
            this.rdoDiesel.TabIndex = 1;
            this.rdoDiesel.TabStop = true;
            this.rdoDiesel.Text = "Diesel";
            this.rdoDiesel.UseVisualStyleBackColor = true;
            this.rdoDiesel.CheckedChanged += new System.EventHandler(this.rdoDiesel_CheckedChanged);
            // 
            // rdoPetrol
            // 
            this.rdoPetrol.AutoSize = true;
            this.rdoPetrol.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoPetrol.Location = new System.Drawing.Point(6, 22);
            this.rdoPetrol.Name = "rdoPetrol";
            this.rdoPetrol.Size = new System.Drawing.Size(88, 20);
            this.rdoPetrol.TabIndex = 0;
            this.rdoPetrol.TabStop = true;
            this.rdoPetrol.Text = "Petrol";
            this.rdoPetrol.UseVisualStyleBackColor = true;
            this.rdoPetrol.CheckedChanged += new System.EventHandler(this.rdoPetrol_CheckedChanged);
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPackage.Location = new System.Drawing.Point(1019, 28);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(183, 17);
            this.lblPackage.TabIndex = 20;
            this.lblPackage.Text = "2. Car Package";
            // 
            // dtmBirthday
            // 
            this.dtmBirthday.Location = new System.Drawing.Point(805, 206);
            this.dtmBirthday.Name = "dtmBirthday";
            this.dtmBirthday.Size = new System.Drawing.Size(156, 27);
            this.dtmBirthday.TabIndex = 21;
            this.toolTip1.SetToolTip(this.dtmBirthday, "Customers Date Of Birth");
            this.dtmBirthday.ValueChanged += new System.EventHandler(this.dtmBirthday_ValueChanged);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAge.Location = new System.Drawing.Point(752, 305);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(56, 15);
            this.lblAge.TabIndex = 22;
            this.lblAge.Text = "Age :";
            // 
            // dtmDayOfBooking
            // 
            this.dtmDayOfBooking.Location = new System.Drawing.Point(805, 350);
            this.dtmDayOfBooking.Name = "dtmDayOfBooking";
            this.dtmDayOfBooking.Size = new System.Drawing.Size(156, 27);
            this.dtmDayOfBooking.TabIndex = 23;
            this.toolTip1.SetToolTip(this.dtmDayOfBooking, "Start date of the rental");
            this.dtmDayOfBooking.ValueChanged += new System.EventHandler(this.dtmDayOfBooking_ValueChanged);
            // 
            // dtmEndOfBooking
            // 
            this.dtmEndOfBooking.Location = new System.Drawing.Point(805, 397);
            this.dtmEndOfBooking.Name = "dtmEndOfBooking";
            this.dtmEndOfBooking.Size = new System.Drawing.Size(156, 27);
            this.dtmEndOfBooking.TabIndex = 24;
            this.toolTip1.SetToolTip(this.dtmEndOfBooking, "End Date of the rental");
            this.dtmEndOfBooking.ValueChanged += new System.EventHandler(this.dtmEndOfBooking_ValueChanged);
            // 
            // lblStartBooking
            // 
            this.lblStartBooking.AutoSize = true;
            this.lblStartBooking.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStartBooking.Location = new System.Drawing.Point(623, 359);
            this.lblStartBooking.Name = "lblStartBooking";
            this.lblStartBooking.Size = new System.Drawing.Size(176, 15);
            this.lblStartBooking.TabIndex = 25;
            this.lblStartBooking.Text = "Day of Booking:";
            // 
            // lblEndBooking
            // 
            this.lblEndBooking.AutoSize = true;
            this.lblEndBooking.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEndBooking.Location = new System.Drawing.Point(614, 404);
            this.lblEndBooking.Name = "lblEndBooking";
            this.lblEndBooking.Size = new System.Drawing.Size(190, 15);
            this.lblEndBooking.TabIndex = 26;
            this.lblEndBooking.Text = "* End of Booking:";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.White;
            this.txtDays.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDays.Location = new System.Drawing.Point(814, 444);
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(147, 20);
            this.txtDays.TabIndex = 27;
            this.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtDays, "Total days for the rental");
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Engravers MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDays.Location = new System.Drawing.Point(678, 451);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(130, 15);
            this.lblDays.TabIndex = 28;
            this.lblDays.Text = "Total Days:";
            // 
            // lblFYI
            // 
            this.lblFYI.AutoSize = true;
            this.lblFYI.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFYI.Location = new System.Drawing.Point(364, 600);
            this.lblFYI.Name = "lblFYI";
            this.lblFYI.Size = new System.Drawing.Size(397, 16);
            this.lblFYI.TabIndex = 31;
            this.lblFYI.Text = "Fields with \' * \' must be changed or filled out.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1019, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Extras";
            this.toolTip1.SetToolTip(this.label1, "Optional Extras");
            // 
            // chkMiles
            // 
            this.chkMiles.AutoSize = true;
            this.chkMiles.Enabled = false;
            this.chkMiles.Font = new System.Drawing.Font("Copperplate Gothic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkMiles.Location = new System.Drawing.Point(1018, 386);
            this.chkMiles.Name = "chkMiles";
            this.chkMiles.Size = new System.Drawing.Size(164, 19);
            this.chkMiles.TabIndex = 33;
            this.chkMiles.Text = "∞ Miles(+£10/Day)";
            this.toolTip1.SetToolTip(this.chkMiles, "Unlimited Daily Mileage");
            this.chkMiles.UseVisualStyleBackColor = true;
            this.chkMiles.CheckedChanged += new System.EventHandler(this.chkMiles_CheckedChanged);
            // 
            // chkBreakdown
            // 
            this.chkBreakdown.AutoSize = true;
            this.chkBreakdown.Enabled = false;
            this.chkBreakdown.Font = new System.Drawing.Font("Copperplate Gothic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBreakdown.Location = new System.Drawing.Point(1019, 427);
            this.chkBreakdown.Name = "chkBreakdown";
            this.chkBreakdown.Size = new System.Drawing.Size(195, 19);
            this.chkBreakdown.TabIndex = 34;
            this.chkBreakdown.Text = "BrkDwn Cvr(+£2/Day)";
            this.toolTip1.SetToolTip(this.chkBreakdown, "Daily Breakdown Cover");
            this.chkBreakdown.UseVisualStyleBackColor = true;
            this.chkBreakdown.CheckedChanged += new System.EventHandler(this.chkBreakdown_CheckedChanged);
            // 
            // chkNoExtras
            // 
            this.chkNoExtras.AutoSize = true;
            this.chkNoExtras.Enabled = false;
            this.chkNoExtras.Font = new System.Drawing.Font("Copperplate Gothic Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkNoExtras.Location = new System.Drawing.Point(1019, 467);
            this.chkNoExtras.Name = "chkNoExtras";
            this.chkNoExtras.Size = new System.Drawing.Size(103, 19);
            this.chkNoExtras.TabIndex = 35;
            this.chkNoExtras.Text = "No Extras";
            this.toolTip1.SetToolTip(this.chkNoExtras, "No extras");
            this.chkNoExtras.UseVisualStyleBackColor = true;
            this.chkNoExtras.CheckedChanged += new System.EventHandler(this.chkNoExtras_CheckedChanged);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.White;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(268, 67);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(300, 444);
            this.txtInfo.TabIndex = 36;
            this.toolTip1.SetToolTip(this.txtInfo, "Selected booking information");
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(922, 551);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(127, 53);
            this.btnClear.TabIndex = 37;
            this.btnClear.Text = "Clear Current Order";
            this.toolTip1.SetToolTip(this.btnClear, "Clears current filled out information");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Engravers MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.Location = new System.Drawing.Point(268, 28);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(175, 17);
            this.lblInfo.TabIndex = 38;
            this.lblInfo.Text = "Booking Info:";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(967, 250);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(28, 27);
            this.txtCount.TabIndex = 39;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtCount, "Character Count");
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1223, 625);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.chkNoExtras);
            this.Controls.Add(this.chkBreakdown);
            this.Controls.Add(this.chkMiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFYI);
            this.Controls.Add(this.lblPackage);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.grpFuel);
            this.Controls.Add(this.grpCarType);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCurrentNo);
            this.Controls.Add(this.lblEndBooking);
            this.Controls.Add(this.txtCurrentNo);
            this.Controls.Add(this.lblCustomerInfo);
            this.Controls.Add(this.lblStartBooking);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.lstCurrentBookings);
            this.Controls.Add(this.dtmEndOfBooking);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtmDayOfBooking);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.dtmBirthday);
            this.Controls.Add(this.txtAge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.grpCarType.ResumeLayout(false);
            this.grpCarType.PerformLayout();
            this.grpFuel.ResumeLayout(false);
            this.grpFuel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstCurrentBookings;
        private Label lblCurrent;
        private TextBox txtCurrentNo;
        private Label lblCurrentNo;
        private Button btnRefresh;
        private Button btnSummary;
        private TextBox txtSurname;
        private TextBox txtAddress;
        private TextBox txtAge;
        private TextBox txtLicense;
        private Label lblName;
        private Label lblSurname;
        private Label lblAddress;
        private Label lblDOB;
        private Label lblLicense;
        private Label lblCustomerInfo;
        private GroupBox grpCarType;
        private RadioButton rdoSUV;
        private RadioButton rdoSports;
        private RadioButton rdoFamily;
        private RadioButton rdoCityCar;
        private GroupBox grpFuel;
        private RadioButton rdoElectric;
        private RadioButton rdoHybrid;
        private RadioButton rdoDiesel;
        private RadioButton rdoPetrol;
        private Label lblPackage;
        private DateTimePicker dtmBirthday;
        private Label lblAge;
        private DateTimePicker dtmDayOfBooking;
        private DateTimePicker dtmEndOfBooking;
        private Label lblStartBooking;
        private Label lblEndBooking;
        private TextBox txtDays;
        private Label lblDays;
        private RadioButton rdoNoType;
        private RadioButton rdoNoFuel;
        private TextBox txtFirstName;
        private Label lblFYI;
        private Label label1;
        private CheckBox chkMiles;
        private CheckBox chkBreakdown;
        private CheckBox chkNoExtras;
        private TextBox txtInfo;
        private Button btnClear;
        private Label lblInfo;
        private TextBox txtCount;
        private ToolTip toolTip1;
    }
}