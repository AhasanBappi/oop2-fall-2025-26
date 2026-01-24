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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            // Add click event handlers to picture boxes
            pictureBox1.Click += PictureBox1_Click;
            pictureBox2.Click += PictureBox2_Click;
            pictureBox3.Click += PictureBox3_Click;
        }

        // Helper method to parse product name and price from textBox
        private (string productName, decimal price) ParseProductInfo(string text)
        {
            // Remove "tk" and extract price
            string[] parts = text.Split(new[] { "tk" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 1)
            {
                string lastPart = parts[parts.Length - 1].Trim();
                if (decimal.TryParse(lastPart, out decimal price))
                {
                    string productName = text.Replace(lastPart + "tk", "").Trim();
                    return (productName, price);
                }
            }
            return ("Unknown Product", 0);
        }

        // Helper method to handle product click
        private void HandleProductClick(string productName, decimal price)
        {
            // Add product to cart (quantity will increment if product already exists)
            CartManager.AddProduct(productName, 1, price);

            // Get current quantity from cart
            var products = CartManager.GetCart();
            var product = products.FirstOrDefault(p => p.ProductName == productName);
            int currentQuantity = product?.Quantity ?? 1;

            // Show product information
            MessageBox.Show($"Product: {productName}\nPrice: {price:C2}\nQuantity: {currentQuantity}\nTotal: {price * currentQuantity:C2}", 
                "Product Added to Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            var (productName, price) = ParseProductInfo(textBox1.Text);
            HandleProductClick(productName, price);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            var (productName, price) = ParseProductInfo(textBox2.Text);
            HandleProductClick(productName, price);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            var (productName, price) = ParseProductInfo(textBox3.Text);
            HandleProductClick(productName, price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 next = new Form2();
            next.Show();
            this.Hide();
        }

        // Method to add product to cart - call this when user selects a product
        public void AddProductToCart(string productName, int quantity, decimal price)
        {
            CartManager.AddProduct(productName, quantity, price);
        }
    }
}
