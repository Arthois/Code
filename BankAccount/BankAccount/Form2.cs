using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccount
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            txtDeposit.Text = Form1.dTotalDeposit.ToString("C");
            txtWithDrawn.Text = Form1.dtotalWithdrawn.ToString("C");
            txtNoDeposit.Text = Form1.iDeposits.ToString();
            txtNoWithdrawn.Text = Form1.iWithdrawn.ToString();
            txtServices.Text = Form1.dService.ToString("C");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult drReply;

            drReply = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drReply == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult drReply;
            drReply = MessageBox.Show("Are you sure you want to wipe all the summary info?", "Confirm Wipe", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (drReply == DialogResult.Yes)
            {
                Form1.iDeposits = 0;
                Form1.iWithdrawn = 0;
                Form1.dService = 0;
                Form1.dTotalDeposit = 0;
                Form1.dtotalWithdrawn = 0;
                txtDeposit.Text = Form1.dTotalDeposit.ToString("C");
                txtWithDrawn.Text = Form1.dtotalWithdrawn.ToString("C");
                txtNoDeposit.Text = Form1.iDeposits.ToString();
                txtNoWithdrawn.Text = Form1.iWithdrawn.ToString();
                txtServices.Text = Form1.dService.ToString("C");
                Form1.cleared = true;
                
            }

        }
    }
}
