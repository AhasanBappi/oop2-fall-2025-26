using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            try
            {
                InitializeComponent();
                if (lblMessage != null)
                {
                    lblMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing Form10: {ex.Message}", "Initialization Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblMessage.Text = "Please enter your email or name.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.Text = "Please enter your password.";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            string input = txtEmail.Text.Trim();
            string pwd = txtPassword.Text;
            if (DatabaseHelper.AuthenticateEmployee(input, pwd))
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Login Successful!";
                lblMessage.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                MessageBox.Show("Login successful!", "Employee Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Form11 f11 = new Form11();
                    f11.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening Form11: {ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            if (DatabaseHelper.AuthenticateAdmin(input, pwd))
            {
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Login Successful!";
                lblMessage.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                MessageBox.Show("Login successful!", "Admin Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form14 f14 = new Form14();
                f14.Show();
                this.Hide();
                return;
            }

            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "Invalid email/name or password. Please try again.";
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtPassword.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1 != null && txtPassword != null)
            {
                txtPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
            }
        }

    }
}
