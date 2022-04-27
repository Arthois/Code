namespace Bagels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("Bagels.TXT"))
            {
                while (sr.Peek() != -1)
                {
                    lstBagel.Items.Add(sr.ReadLine());
                }
                txtCount.Text = lstBagel.Items.Count.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult drReply;

            drReply = MessageBox.Show("Are you sure?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (drReply == DialogResult.Yes)
            { 
                Application.Exit();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstBagel.Items.Add(txtType.Text.ToString());
            txtCount.Text = lstBagel.Items.Count.ToString();
            txtType.Clear();
            txtType.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstBagel.Items.Clear();
            txtCount.Text = lstBagel.Items.Count.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBagel.SelectedIndex == -1)
            {
                if (lstBagel.Items.Count == 0)
                {
                    MessageBox.Show("The list is empty!", "Nothing to Remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    lstBagel.Items.RemoveAt(0);
                    txtCount.Text = lstBagel.Items.Count.ToString();
                }
            }
            else
            {
                lstBagel.Items.RemoveAt(lstBagel.SelectedIndex);
                txtCount.Text = lstBagel.Items.Count.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstBagel.Items.Contains(txtSearch.Text.ToString()))
            {
                MessageBox.Show($"{txtSearch.Text.ToString()} was found!", "Search Results", MessageBoxButtons.OK);
                txtSearch.Clear();
                txtSearch.Focus();
            }
            else
            {
                MessageBox.Show($"{txtSearch.Text.ToString()} is not in the list..", "Search Results", MessageBoxButtons.OK);
                txtSearch.Clear();
                txtSearch.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("Bagels.TXT"))
            {
                for (int iCount = 0; iCount < lstBagel.Items.Count; iCount++)
                {
                    sw.WriteLine(lstBagel.Items[iCount]);
                }
                MessageBox.Show("The list has been saved!", "File Saved", MessageBoxButtons.OK);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("Bagels.TXT"))
            {
                while (sr.Peek() != -1)
                { 
                    lstBagel.Items.Add(sr.ReadLine());
                }
                txtCount.Text = lstBagel.Items.Count.ToString();
            }
        }
    }
}