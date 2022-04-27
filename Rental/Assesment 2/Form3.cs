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
    public partial class LogIn : Form
    {
        string sFile = "CREDENTIALS.TXT";
        public LogIn()
        {
            InitializeComponent();
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult drReply;
            drReply = MessageBox.Show("Are you Sure?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drReply == DialogResult.Yes)
            { 
                Application.Exit();
            }
        }

        private void TextInputed()
        {
            if (txtPass.Text.Length != 0 && txtUser.Text.Length != 0)
            {
                btnLogIn.Enabled = true;
            }
            else
            {
                btnLogIn.Enabled = false;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            TextInputed();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            TextInputed();
        }

        public String SetFile(String psFile)
        {
            return psFile;
        }

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
            iCol = iCol / iRows;
            return iCol;
        }

        public String GetUser()
        {
            string sUser = txtUser.Text.ToString();
            return sUser;
        }

        public void ValidateUser(string psUser, string psPass)
        {
            psUser = txtUser.Text;
            String file = File.ReadAllText(sFile);
            int iRows = GetArrayRows(sFile);
            int iCols = GetArrayCols(sFile, iRows);
            int i = 0, j = 0;
            string[,] crdArray = new string[iRows, iCols];

            foreach (var row in file.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(','))
                {
                    crdArray[i, j] = col.Trim();
                    j++;
                }
                i++;
            }
            

            for (int n = 0; n <= iRows - 1; n += 1)
            {
                string sTestUser = crdArray[n, 0];
                if (sTestUser == psUser)
                {
                    for (int m = n; m <= iRows - 1; m += 1)
                    {
                        string sTestPass = crdArray[m, 1];
                        if (sTestPass == psPass && sTestUser == psUser)
                        {
                            MessageBox.Show($"Hello {psUser}", "Login Succesful", MessageBoxButtons.OK);
                            this.Close();
                            break;
                        }
                        else if (sTestPass != psPass || m >= iRows)
                        {
                            MessageBox.Show("Invalid credentials", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUser.Clear();
                            txtPass.Clear();
                            txtUser.Focus();
                            break;
                        }

                    }

                }
                else if (sTestUser != psUser && (n + 1) >= iRows)
                {
                    MessageBox.Show("Invalid credentials", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Clear();
                    txtPass.Clear();
                    txtUser.Focus();
                    break;
                }
            }
            
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string sUser, sPass;
            sUser = txtUser.Text;    
            sPass = txtPass.Text;
            ValidateUser(sUser, sPass);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
