namespace BankAccount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (cleared == true)
            {
                btnSummary.Enabled = false;
            }
            else
            {
                btnSummary.Enabled = true; 
            }
        }

        public static double dBalance = 100;
        public static double dAmount;
        public static double dService;
        public static int iDeposits;
        public static int iWithdrawn;
        public static double dTotalCharge;
        public static double dtotalWithdrawn;
        public static double dTotalDeposit;
        public static bool cleared = true;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

            if (rdoNoTransaction.Checked == true)
            {
                MessageBox.Show("Please select an operation first!", "No valid operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                dAmount = Convert.ToDouble(txtTransaction.Text);
                if (rdoDeposit.Checked)
                {
                    dAmount = Convert.ToDouble(txtTransaction.Text);
                    dTotalDeposit += dAmount;
                    dService = (dAmount * 5) / 100;
                    dBalance += dAmount - dService;
                    dTotalCharge += dService;
                    iDeposits += 1;
                    cleared = false;


                }
                if (rdoWithdrawal.Checked)
                {
                    dAmount = Convert.ToDouble(txtTransaction.Text);
                    if (dAmount > dBalance)
                    {
                        MessageBox.Show("Not enough money in Account", "Exceeding Amount", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        dtotalWithdrawn += dAmount;
                        dBalance -= dAmount + dService;
                        dTotalCharge += dService;
                        iWithdrawn += 1;
                        cleared = false;
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("Amount entered must be a number", "Not a NUMBER!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            lblBalance.Text = "Balance: " + dBalance.ToString("C");
            lblBalance.Visible = true;
            rdoNoTransaction.Checked = true;
            if (iDeposits != 0 || iWithdrawn != 0 || cleared != true)
            {
                btnSummary.Enabled = true;
            }
            else
            { 
                btnSummary.Enabled=false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTransaction.Clear();
            lblBalance.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult drReply;

            drReply = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drReply == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (drReply == DialogResult.No)
            {
                txtTransaction.Focus();
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            SummaryForm summaryForm = new SummaryForm();
            summaryForm.ShowDialog();
        }
    }
}