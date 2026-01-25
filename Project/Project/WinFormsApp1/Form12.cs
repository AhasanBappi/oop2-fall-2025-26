using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form12 : Form
    {
        public static Customer? LoggedInCustomer { get; private set; }

        public Form12()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form13 next = new Form13();
            next.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 next = new Form9();
            next.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your email.", "Input Required", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter your password.", "Input Required", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Customer? customer = DatabaseHelper.AuthenticateAndGetCustomer(textBox1.Text.Trim(), textBox2.Text);

            if (customer != null)
            {
                LoggedInCustomer = customer;
                MessageBox.Show($"Congrats, {customer.Name}!", "You successfully purchase this product(s)", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form9 next = new Form9();
                next.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
