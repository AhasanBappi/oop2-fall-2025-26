using System;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
                CartManager.ClearCart();
                try
                {
                    TestDatabaseConnection();
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing Form1: {ex.Message}", "Initialization Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TestDatabaseConnection()
        {
            try
            {
                if (DatabaseHelper.TestConnection())
                {
                    DatabaseHelper.CreateSelectedProductsTable();
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 next = new Form2();
            next.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (label1 != null)
                {
                    label1.Parent = this;
                    label1.BackColor = Color.Transparent;
                }
            }
            catch
            {
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form10 next = new Form10();
            next.Show();
            this.Hide();
        }
    }
}
