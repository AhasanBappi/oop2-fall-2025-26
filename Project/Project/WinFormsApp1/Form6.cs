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
    public partial class Form6 : Form
    {
        private string zoneTableName = "bowling_zone";

        public Form6() : this("")
        {
        }

        public Form6(string section)
        {
            InitializeComponent();
            zoneTableName = "bowling_zone";
            LoadProductsFromDatabase();
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                var products = DatabaseHelper.GetProductsFromZoneTable(zoneTableName);
                System.Diagnostics.Debug.WriteLine($"Loaded {products.Count} products from {zoneTableName}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading products from {zoneTableName}: {ex.Message}");
            }
        }
        private (string productName, decimal price) ParseProductInfo(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return ("Unknown Product", 0);
            }
            text = text.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Trim();
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            int tkIndex = text.LastIndexOf("tk", StringComparison.OrdinalIgnoreCase);
            if (tkIndex <= 0)
            {
                return ("Unknown Product", 0);
            }
            string beforeTk = text.Substring(0, tkIndex).Trim();
            if (beforeTk.Contains("Price:", StringComparison.OrdinalIgnoreCase))
            {
                int priceIndex = beforeTk.LastIndexOf("Price:", StringComparison.OrdinalIgnoreCase);
                string productName = beforeTk.Substring(0, priceIndex).Trim();
                string priceStr = beforeTk.Substring(priceIndex + 6).Trim();

                if (decimal.TryParse(priceStr, out decimal price) && price > 0 && !string.IsNullOrWhiteSpace(productName))
                {
                    return (productName, price);
                }
            }
            string[] parts = beforeTk.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                string lastPart = parts[parts.Length - 1];
                if (decimal.TryParse(lastPart, out decimal price) && price > 0)
                {
                    string productName = string.Join(" ", parts, 0, parts.Length - 1).Trim();
                    if (!string.IsNullOrWhiteSpace(productName))
                    {
                        return (productName, price);
                    }
                }
            }

            return ("Unknown Product", 0);
        }
        private void HandleProductClick(string productName, decimal price)
        {
            Product dbProduct = DatabaseHelper.GetProductFromZoneTableByName(zoneTableName, productName);

            int addedProductId = 0;
            if (dbProduct != null)
            {
                CartManager.AddProduct(dbProduct.Pid, dbProduct.Pname, dbProduct.Section, 1, (decimal)dbProduct.Price);
                addedProductId = dbProduct.Pid;
            }
            else
            {
                CartManager.AddProduct(productName, 1, price);
            }
            MessageBox.Show($"{productName} added to cart!", "Product Added",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Label4_Click(object? sender, EventArgs e)
        {
            if (label4 == null || string.IsNullOrWhiteSpace(label4.Text))
            {
                MessageBox.Show("Product information not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string labelText = label4.Text;
            var (productName, price) = ParseProductInfo(labelText);

            if (productName == "Unknown Product" || price == 0)
            {
                MessageBox.Show($"Could not parse product information.\n\nLabel Text: '{labelText}'\nParsed Name: '{productName}'\nParsed Price: {price}",
                    "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HandleProductClick(productName, price);
        }

        private void Label1_Click(object? sender, EventArgs e)
        {
            if (label1 == null || string.IsNullOrWhiteSpace(label1.Text))
            {
                MessageBox.Show("Product information not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string labelText = label1.Text;
            var (productName, price) = ParseProductInfo(labelText);

            if (productName == "Unknown Product" || price == 0)
            {
                MessageBox.Show($"Could not parse product information.\n\nLabel Text: '{labelText}'\nParsed Name: '{productName}'\nParsed Price: {price}",
                    "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HandleProductClick(productName, price);
        }

        private void Label5_Click(object? sender, EventArgs e)
        {
            if (label5 == null || string.IsNullOrWhiteSpace(label5.Text))
            {
                MessageBox.Show("Product information not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string labelText = label5.Text;
            var (productName, price) = ParseProductInfo(labelText);

            if (productName == "Unknown Product" || price == 0)
            {
                MessageBox.Show($"Could not parse product information.\n\nLabel Text: '{labelText}'\nParsed Name: '{productName}'\nParsed Price: {price}",
                    "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HandleProductClick(productName, price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 next = new Form9();
            next.Show();
            this.Hide();
        }
        public void AddProductToCart(string productName, int quantity, decimal price)
        {
            CartManager.AddProduct(productName, quantity, price);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 next = new Form9();
            next.Show();
            this.Hide();
        }
    }
}
