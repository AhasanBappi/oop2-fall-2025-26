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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            LoadCartData();
        }

        private void LoadCartData()
        {
            // Clear existing data
            dataGridView1.Rows.Clear();

            // Get products from cart
            var products = CartManager.GetCart();

            // Add columns if they don't exist
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ProductName", "Product Name");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns.Add("Price", "Price");
                dataGridView1.Columns.Add("TotalPrice", "Total Price");

                // Set column widths
                dataGridView1.Columns["ProductName"].Width = 300;
                dataGridView1.Columns["Quantity"].Width = 150;
                dataGridView1.Columns["Price"].Width = 150;
                dataGridView1.Columns["TotalPrice"].Width = 150;

                // Format Price and Total Price columns as currency
                dataGridView1.Columns["Price"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["TotalPrice"].DefaultCellStyle.Format = "C2";
            }

            // Add products to DataGridView
            foreach (var product in products)
            {
                dataGridView1.Rows.Add(
                    product.ProductName,
                    product.Quantity,
                    product.Price,
                    product.TotalPrice
                );
            }

            // Update total price label
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            decimal total = CartManager.GetTotalPrice();
            labelTotal.Text = $"Total: {total:C2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 next = new Form2();
            next.Show();
            this.Hide();
        }

        // Method to refresh cart when form is shown again
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                LoadCartData();
            }
        }
    }
}
