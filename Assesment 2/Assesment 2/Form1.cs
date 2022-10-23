namespace Assesment_2
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            string sFile = "BOOKINGS.TXT";
            String file = File.ReadAllText(sFile);
            int iRows = GetArrayRows(sFile);
            int iCols = GetArrayCols(sFile, iRows);
            int i = 0, j = 0;
            string[,] bkgArray = new string[iRows, iCols];

            foreach (var row in file.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(','))
                {
                    bkgArray[i, j] = col.Trim();
                    j++;
                }
                i++;
            }

            for (int row = 0; row < iRows; row++)
            { 
                lstCurrentBookings.Items.Add($"{bkgArray[row, 0]} {bkgArray[row, 1]}");
                txtCurrentNo.Text = row.ToString();
            }


        }

        public static string sFirstName;
        public static string sSurname;
        public static string sAddress;
        public static string sAge;
        public static string sLicense;
        public static string sStartDate;
        public static string sEndDate;
        public static string sDOB;
        public static string sDays;
        public static int iTotal;
        public static string sMiles;
        public static string sBreakdown;
        public static string sCarType;
        public static string sFuelType;

        public int GetArrayRows(string psFile)
        {
            String file = File.ReadAllText(psFile);
            int iRows = 0;
            foreach (var row in file.Split('\n'))
            {
                iRows++;
            }
            return iRows;
        }

        public int GetArrayCols(String psFile, int piRows)
        {
            string sCreds = psFile;
            String file = File.ReadAllText(sCreds);
            int iRows = 0, iCol = 0;
            foreach (var row in file.Split('\n'))
            {
                foreach (var col in row.Trim().Split(','))
                {
                    iCol++;
                }
                iRows++;
            }
            return iCol;
        }
        private void SelectionsMade()
        {
            if (txtFirstName.Text.Length != 0 && txtSurname.Text.Length != 0 && txtAddress.Text.Length != 0 && txtAge.Text.Length != 0 && txtLicense.Text.Length == 16 && rdoNoType.Checked != true && rdoNoFuel.Checked != true && txtDays.Text != "")
            {
                btnSummary.Enabled = true;
            }
            else
            {
                btnSummary.Enabled = false;
            }
        }

        private void FirstInfoDone()
        {
            if (txtFirstName.Text.Length != 0 && txtSurname.Text.Length != 0 && txtAddress.Text.Length != 0 && txtAge.Text.Length != 0 && txtLicense.Text.Length != 0 && Convert.ToInt32(txtDays.Text) > 0 && Convert.ToInt32(txtDays.Text) < 28)
            {
                grpCarType.Enabled = true;
                grpFuel.Enabled = true;
                chkNoExtras.Enabled = true;
                chkMiles.Enabled = true;
                chkBreakdown.Enabled = true;
            }
            else
            {
                DisableOptions();
            }

        }

        private void dtmBirthday_ValueChanged(object sender, EventArgs e)
        {
            int iAge = DateTime.Today.Year - dtmBirthday.Value.Year; // CurrentYear - BirthDate

            if (iAge < 18)
            {
                MessageBox.Show("The customer can not be younger than 18 years old", "Underage", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            if (CurrentDate.Month < dtmBirthday.Value.Month)
            {
                iAge--;
                txtAge.Text = iAge.ToString();
            }
            else if ((CurrentDate.Month >= dtmBirthday.Value.Month) && (CurrentDate.Day < dtmBirthday.Value.Day))
            {
                iAge--;
                txtAge.Text = iAge.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstCurrentBookings.Items.Clear();
            string sFile = "BOOKINGS.TXT";
            String file = File.ReadAllText(sFile);
            int iRows = GetArrayRows(sFile);
            int iCols = GetArrayCols(sFile, iRows);
            int i = 0, j = 0;
            string[,] bkgArray = new string[iRows, iCols];

            foreach (var row in file.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(','))
                {
                    bkgArray[i, j] = col.Trim();
                    j++;
                }
                i++;
            }

            for (int row = 0; row < iRows; row++)
            {
                lstCurrentBookings.Items.Add($"{bkgArray[row, 0]} {bkgArray[row, 1]}");
                txtCurrentNo.Text = row.ToString();
            }
            lstCurrentBookings.Refresh();
        }

        public void LogInPage()
        {

        }
        private void DisableOptions()
        {
            grpCarType.Enabled = false;
            grpFuel.Enabled = false;
            chkNoExtras.Enabled = false;
            chkMiles.Enabled = false;
            chkBreakdown.Enabled = false;
            btnSummary.Enabled = false;
        }

        private void dtmEndOfBooking_ValueChanged(object sender, EventArgs e)
        {
            DateTime DayOfBooking = dtmDayOfBooking.Value.Date;
            DateTime EndOfBooking = dtmEndOfBooking.Value.Date;


            if (DayOfBooking > EndOfBooking)
            {
                MessageBox.Show("Dates selected are incorect", "Incorrect Dates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableOptions();
            }
            else if (DayOfBooking == EndOfBooking)
            {
                MessageBox.Show("Bookings for atleast 1 day are accepted", "Under 1 Day", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableOptions();
            }
            else if (DayOfBooking < EndOfBooking)
            {
                TimeSpan DaysForBooking = EndOfBooking - DayOfBooking;
                int iDaysForBooking = DaysForBooking.Days;

                if (Convert.ToInt32(iDaysForBooking) > 28)
                {
                    MessageBox.Show("Max days for a booking is 28 days", "Above 28 Days Limit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDays.Clear();
                    DisableOptions();
                }
                else if (Convert.ToInt32(iDaysForBooking) <= 28)
                {
                    txtDays.Text = iDaysForBooking.ToString();
                    FirstInfoDone();
                    if (txtLicense.Text.Length < 16 || txtLicense.Text.Length > 16)
                    {
                        MessageBox.Show($"The License number must be 16 characters long!\nCurrent license number has {txtLicense.Text.Length} characters", "Invalid License Number", MessageBoxButtons.OK);
                        txtDays.Clear();
                        DisableOptions();
                    }
                    else if (txtAddress.Text == "" || txtFirstName.Text == "" || txtSurname.Text == "" || txtLicense.Text == "")
                    {
                        MessageBox.Show("Please fill in all the required fields!", "Empty Fields", MessageBoxButtons.OK);
                        DisableOptions();
                    }
                    
                }
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            SelectionsMade();
            if (txtFirstName.Text.All(Char.IsLetter) == false)
            {
                MessageBox.Show("The First Name must contain only letters!", "Invalid input", MessageBoxButtons.OK);
                txtFirstName.Clear();
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            SelectionsMade();
            if (txtSurname.Text.All(Char.IsLetter) == false)
            {
                MessageBox.Show("The Surname must contain only letters!", "Invalid input", MessageBoxButtons.OK);
                txtSurname.Clear();
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            SelectionsMade();
            if (txtAddress.Text.Contains(',') == true)
            {
                MessageBox.Show("The addres can not contain ',' ", "Invalid input", MessageBoxButtons.OK);
                txtAddress.Clear();
            }
        }

        private void txtLicense_TextChanged(object sender, EventArgs e)
        {
            SelectionsMade();
            if (txtLicense.Text.All(Char.IsLetterOrDigit) == false)
            {
                MessageBox.Show("The License number can not contain any symbols!", "Invalid input", MessageBoxButtons.OK);
                txtLicense.Clear();
            }
            txtCount.Text = txtLicense.Text.Length.ToString();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            SelectionsMade();
        }

        private void rdoNoType_CheckedChanged(object sender, EventArgs e)
        {
            SelectionsMade();
        }

        private void rdoNoFuel_CheckedChanged(object sender, EventArgs e)
        {
            SelectionsMade();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {

            Customer Customer = new Customer($"{txtFirstName.Text}", $"{txtSurname.Text}", $"{txtAddress}", Convert.ToInt32(txtAge.Text), $"{txtLicense.Text}", dtmBirthday.Value);

            sFirstName = Customer.GetFirstName();
            sSurname = Customer.GetSurName();
            sAddress = txtAddress.Text;
            sLicense = Customer.GetLicense();
            sAge = Customer.GetAge().ToString();
            sStartDate = dtmDayOfBooking.Value.ToString();
            sEndDate = dtmEndOfBooking.Value.ToString();
            sDOB = dtmBirthday.Value.ToString();
            sDays = txtDays.Text;
            iTotal += (Convert.ToInt32(txtDays.Text) * 25);

            if (chkMiles.Checked == true)
            {
                iTotal += Convert.ToInt32(txtDays.Text) * 10;
            }

            if (chkBreakdown.Checked == true)
            {
                iTotal += Convert.ToInt32(txtDays.Text) * 2;
            }

            Form4 form4 = new Form4();
            form4.ShowDialog();




        }

        private void rdoFamily_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFamily.Checked == true)
            {
                iTotal += 50;
                sCarType = "Family";
            }
            else if (rdoFamily.Checked == false)
            {
                iTotal -= 50;
                sCarType = "";
            }
        }

        private void rdoSports_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSports.Checked == true)
            {
                iTotal += 75;
                sCarType = "Sports";
            }
            else if (rdoSports.Checked == false)
            {
                iTotal -= 75;
                sCarType = "";
            }
        }

        private void rdoSUV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSUV.Checked == true)
            {
                iTotal += 65;
                sCarType = "SUV";
            }
            else if (rdoSUV.Checked == false)
            {
                iTotal -= 65;
                sCarType = "";
            }
        }

        private void rdoHybrid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHybrid.Checked == true)
            {
                iTotal += 30;
                sFuelType = "Hybrid";
            }
            else if (rdoHybrid.Checked == false)
            {
                iTotal -= 30;
                sFuelType = "";
            }
            else if (rdoNoType.Checked == true)
            {
                MessageBox.Show("The Car Type must be selected as well!", "No Car type!", MessageBoxButtons.OK);
            }
        }

        private void rdoElectric_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoElectric.Checked == true)
            {
                iTotal += 50;
                sFuelType = "Electric";
            }
            else if (rdoElectric.Checked == false)
            {
                iTotal -= 50;
                sFuelType = "";
            }
            else if (rdoNoType.Checked == true)
            {
                MessageBox.Show("The Car Type must be selected as well!", "No Car type!", MessageBoxButtons.OK);
            }
        }

        private void rdoCityCar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCityCar.Checked == true)
            {
                sCarType = "City";
            }
            else if (rdoCityCar.Checked == false)
            {
                sCarType = "";
            }
        }

        private void rdoPetrol_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPetrol.Checked == true)
            {
                sFuelType = "Petrol";
            }
            else if (rdoPetrol.Checked == false)
            {
                sFuelType = "";
            }
            else if (rdoNoType.Checked == true)
            {
                MessageBox.Show("The Car Type must be selected as well!", "No Car type!", MessageBoxButtons.OK);
            }
        }

        private void rdoDiesel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDiesel.Checked == true)
            {
                sFuelType = "Diesel";
            }
            else if (rdoDiesel.Checked == false)
            {
                sFuelType = "";
            }
            else if (rdoNoType.Checked == true)
            {
                MessageBox.Show("The Car Type must be selected as well!", "No Car type!", MessageBoxButtons.OK);
            }
        }

        private void chkMiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMiles.Checked == true)
            {
                sMiles = "Yes";
                chkNoExtras.Checked = false;
            }
            else if (chkMiles.Checked == false)
            {
                sMiles = "No";
            }
        }

        private void chkBreakdown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBreakdown.Checked == true)
            {
                sBreakdown = "Yes";
                chkNoExtras.Checked = false;
            }
            else if (chkBreakdown.Checked == false)
            {
                sBreakdown = "No";
            }
        }

        private void chkNoExtras_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoExtras.Checked == true)
            {
                chkMiles.Checked = false;
                chkBreakdown.Checked = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtSurname.Clear();
            txtAddress.Clear();
            txtLicense.Clear();
            txtAge.Clear();
            txtDays.Clear();
            rdoNoType.Checked = true;
            rdoNoFuel.Checked = true;
            chkNoExtras.Checked = true;
            grpCarType.Enabled = false;
            grpFuel.Enabled = false;
            chkBreakdown.Enabled = false;
            chkMiles.Enabled = false;
            chkNoExtras.Enabled = false;
            iTotal = 0;
        }

        private void lstCurrentBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sFile = "BOOKINGS.TXT";
            String file = File.ReadAllText(sFile);
            int iRows = GetArrayRows(sFile);
            int iCols = GetArrayCols(sFile, iRows);
            int i = 0, j = 0;
            string[,] bkgArray = new string[iRows, iCols];

            foreach (var row in file.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(','))
                {
                    bkgArray[i, j] = col.Trim();
                    j++;
                }
                i++;
            }

            if (lstCurrentBookings.SelectedIndex != -1)
            {
                int iIndex = lstCurrentBookings.SelectedIndex;
                txtInfo.Text = $"First Name: {bkgArray[iIndex, 0]}\r\nSurname: {bkgArray[iIndex, 1]}\r\nDOB: {bkgArray[iIndex, 2]}\r\nAddress: {bkgArray[iIndex, 3]}\r\nAge: {bkgArray[iIndex, 4]}\r\nLicense No. : {bkgArray[iIndex, 5]}\r\n\r\nBooking date: {bkgArray[iIndex, 6]}\r\nEnd of Booking: {bkgArray[iIndex, 7]}\r\n\r\nDays: {bkgArray[iIndex, 8]}\r\n\r\nCar type: {bkgArray[iIndex, 9]}\r\nFuel type: {bkgArray[iIndex, 10]}\r\nBreakdown cover: {bkgArray[iIndex, 11]}\r\nUnlimited miles: {bkgArray[iIndex, 12]}\r\nBooking Price: {bkgArray[iIndex, 13]}{bkgArray[iIndex, 14]}";
            }
        }

        private void dtmDayOfBooking_ValueChanged(object sender, EventArgs e)
        {
            DateTime DayOfBooking = dtmDayOfBooking.Value.Date;
            DateTime EndOfBooking = dtmEndOfBooking.Value.Date;


            if (DayOfBooking > EndOfBooking)
            {
                MessageBox.Show("Dates selected are incorect", "Incorrect Dates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableOptions();
            }
            else if (DayOfBooking == EndOfBooking)
            {
                MessageBox.Show("Bookings for atleast 1 day are accepted", "Under 1 Day", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DisableOptions();
            }
            else if (DayOfBooking < EndOfBooking)
            {
                TimeSpan DaysForBooking = EndOfBooking - DayOfBooking;
                int iDaysForBooking = DaysForBooking.Days;

                if (Convert.ToInt32(iDaysForBooking) > 28)
                {
                    MessageBox.Show("Max days for a booking is 28 days", "Above 28 Days Limit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDays.Clear();
                    DisableOptions();
                }
                else if (Convert.ToInt32(iDaysForBooking) <= 28)
                {
                    txtDays.Text = iDaysForBooking.ToString();
                    FirstInfoDone();
                    if (txtAddress.Text == "" || txtFirstName.Text == "" || txtSurname.Text == "" || txtLicense.Text == "")
                    {
                        MessageBox.Show("Please fill in all the required fields!", "Empty Fields", MessageBoxButtons.OK);
                        DisableOptions();
                    }

                }
            }
        }
    }
}
