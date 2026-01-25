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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            textBox6.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 next = new Form12();
            next.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter your name.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter your phone number.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter your email.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedItem == null || string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select your gender.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please enter a password.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!textBox3.Text.Contains("@") || !textBox3.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool success = DatabaseHelper.RegisterCustomer(
                textBox1.Text.Trim(),
                textBox2.Text.Trim(),
                textBox3.Text.Trim(),
                comboBox1.SelectedItem.ToString() ?? "",
                textBox6.Text
            );

            if (success)
            {
                MessageBox.Show("Registration successful! You can now login.", "Registration Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form12 next = new Form12();
                next.Show();
                this.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox6.PasswordChar = '\0';
            }
            else
            {
                textBox6.PasswordChar = '*';
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}
