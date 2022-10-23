using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assesment_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            txtFirstName.Text = MainPage.sFirstName;
            txtSurname.Text = MainPage.sSurname;
            txtAddress.Text = MainPage.sAddress;
            txtAge.Text = MainPage.sAge;
            txtLicense.Text = MainPage.sLicense;
            txtStartDate.Text = MainPage.sStartDate;
            txtEndDate.Text = MainPage.sEndDate;
            txtDOB.Text = MainPage.sDOB;
            txtDays.Text = MainPage.sDays;
            txtTotal.Text = MainPage.iTotal.ToString("C");
            txtCarType.Text = MainPage.sCarType;
            txtFuelType.Text = MainPage.sFuelType;
            txtBrkCvr.Text = MainPage.sBreakdown;
            txtMileage.Text = MainPage.sMiles;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("BOOKINGS.TXT", true);
            sw.WriteLine($"{txtFirstName.Text},{txtSurname.Text},{txtDOB.Text},{txtAddress.Text},{txtAge.Text},{txtLicense.Text},{txtStartDate.Text},{txtEndDate.Text},{txtDays.Text},{txtCarType.Text},{txtFuelType.Text},{txtBrkCvr.Text},{txtMileage.Text},{txtTotal.Text}");
            sw.Dispose();
            sw.Close();
            MessageBox.Show("The order has been added to the system", "Order Added", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
