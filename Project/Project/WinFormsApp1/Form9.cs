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
        private int? productIdToSelect = null;
        private string? productNameToSelect = null;

        public Form9()
        {
            InitializeComponent();
            InitializeProductDetailsPanel();
            LoadCartData();
        }

        public Form9(int productIdToHighlight)
        {
            InitializeComponent();
            InitializeProductDetailsPanel();
            productIdToSelect = productIdToHighlight;
            LoadCartData();
        }

        public Form9(string productNameToHighlight)
        {
            InitializeComponent();
            InitializeProductDetailsPanel();
            productNameToSelect = productNameToHighlight;
            LoadCartData();
        }

        private void InitializeProductDetailsPanel()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void LoadCartData()
        {
            try
            {
                if (dataGridView1 == null) return;
                try
                {
                    dataGridView1.Rows.Clear();
                }
                catch
                {
                }
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("ProductID", "Product ID");
                    dataGridView1.Columns.Add("ProductName", "Product Name");
                    dataGridView1.Columns.Add("Section", "Section");
                    dataGridView1.Columns.Add("Quantity", "Quantity");
                    dataGridView1.Columns.Add("Price", "Price");
                    dataGridView1.Columns.Add("TotalPrice", "Total Price");
                    if (dataGridView1.Columns["ProductID"] != null) dataGridView1.Columns["ProductID"]!.Width = 100;
                    if (dataGridView1.Columns["ProductName"] != null) dataGridView1.Columns["ProductName"]!.Width = 250;
                    if (dataGridView1.Columns["Section"] != null) dataGridView1.Columns["Section"]!.Width = 150;
                    if (dataGridView1.Columns["Quantity"] != null) dataGridView1.Columns["Quantity"]!.Width = 100;
                    if (dataGridView1.Columns["Price"] != null) dataGridView1.Columns["Price"]!.Width = 120;
                    if (dataGridView1.Columns["TotalPrice"] != null) dataGridView1.Columns["TotalPrice"]!.Width = 120;
                    if (dataGridView1.Columns["Price"] != null) dataGridView1.Columns["Price"]!.DefaultCellStyle.Format = "C2";
                    if (dataGridView1.Columns["TotalPrice"] != null) dataGridView1.Columns["TotalPrice"]!.DefaultCellStyle.Format = "C2";
                }
                var cartProducts = CartManager.GetCart();
                if (productIdToSelect.HasValue && productIdToSelect.Value > 0)
                {
                    int selectedProductId = productIdToSelect.Value;
                    CartProduct? cartProduct = cartProducts.FirstOrDefault(p => p.ProductId == selectedProductId);
                    if (cartProduct == null)
                    {
                        try
                        {
                            var dbProducts = DatabaseHelper.GetSelectedProductsFromDatabase();
                            cartProduct = dbProducts.FirstOrDefault(p => p.ProductId == selectedProductId);
                        }
                        catch
                        {
                        }
                    }
                    if (cartProduct != null)
                    {
                        Product dbProduct = DatabaseHelper.GetProductById(selectedProductId);

                        if (dbProduct != null)
                        {
                            decimal productPrice = (decimal)dbProduct.Price;
                            dataGridView1.Rows.Add(
                                dbProduct.Pid,
                                dbProduct.Pname,
                                dbProduct.Section,
                                cartProduct.Quantity,
                                productPrice,
                                cartProduct.Quantity * productPrice
                            );
                        }
                        else
                        {
                            dataGridView1.Rows.Add(
                                cartProduct.ProductId > 0 ? cartProduct.ProductId.ToString() : "N/A",
                                cartProduct.ProductName,
                                !string.IsNullOrEmpty(cartProduct.Section) ? cartProduct.Section : "N/A",
                                cartProduct.Quantity,
                                cartProduct.Price,
                                cartProduct.TotalPrice
                            );
                        }
                    }
                    else
                    {
                        Product dbProduct = DatabaseHelper.GetProductById(selectedProductId);
                        if (dbProduct != null)
                        {
                            decimal productPrice = (decimal)dbProduct.Price;
                            dataGridView1.Rows.Add(
                                dbProduct.Pid,
                                dbProduct.Pname,
                                dbProduct.Section,
                                1,
                                productPrice,
                                productPrice
                            );
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(productNameToSelect))
                {
                    CartProduct? cartProduct = cartProducts
                        .Where(p => string.Equals(p.ProductName, productNameToSelect, StringComparison.OrdinalIgnoreCase))
                        .LastOrDefault();

                    if (cartProduct != null)
                    {
                        Product? dbProduct = null;
                        if (cartProduct.ProductId > 0)
                        {
                            dbProduct = DatabaseHelper.GetProductById(cartProduct.ProductId);
                        }

                        if (dbProduct == null)
                        {
                            dbProduct = DatabaseHelper.GetProductByName(cartProduct.ProductName);
                        }

                        if (dbProduct != null)
                        {
                            decimal productPrice = (decimal)dbProduct.Price;
                            dataGridView1.Rows.Add(
                                dbProduct.Pid,
                                dbProduct.Pname,
                                dbProduct.Section,
                                cartProduct.Quantity,
                                productPrice,
                                cartProduct.Quantity * productPrice
                            );
                        }
                        else
                        {
                            dataGridView1.Rows.Add(
                                cartProduct.ProductId > 0 ? cartProduct.ProductId.ToString() : "N/A",
                                cartProduct.ProductName,
                                !string.IsNullOrEmpty(cartProduct.Section) ? cartProduct.Section : "N/A",
                                cartProduct.Quantity,
                                cartProduct.Price,
                                cartProduct.TotalPrice
                            );
                        }
                    }
                    else
                    {
                        Product? dbProduct = DatabaseHelper.GetProductByName(productNameToSelect);
                        if (dbProduct != null)
                        {
                            decimal productPrice = (decimal)dbProduct.Price;
                            dataGridView1.Rows.Add(
                                dbProduct.Pid,
                                dbProduct.Pname,
                                dbProduct.Section,
                                1,
                                productPrice,
                                productPrice
                            );
                        }
                        else
                        {
                            UpdateTotalPrice();
                            return;
                        }
                    }
                }
                else
                {
                    if (cartProducts.Count > 0)
                    {
                        foreach (var cartProduct in cartProducts)
                        {
                            Product? dbProduct = null;
                            if (cartProduct.ProductId > 0)
                            {
                                dbProduct = DatabaseHelper.GetProductById(cartProduct.ProductId);
                            }

                            if (dbProduct == null && !string.IsNullOrEmpty(cartProduct.ProductName))
                            {
                                dbProduct = DatabaseHelper.GetProductByName(cartProduct.ProductName);
                            }

                            if (dbProduct != null)
                            {
                                decimal productPrice = (decimal)dbProduct.Price;
                                dataGridView1.Rows.Add(
                                    dbProduct.Pid,
                                    dbProduct.Pname,
                                    dbProduct.Section,
                                    cartProduct.Quantity,
                                    productPrice,
                                    cartProduct.Quantity * productPrice
                                );
                            }
                            else
                            {
                                dataGridView1.Rows.Add(
                                    cartProduct.ProductId > 0 ? cartProduct.ProductId.ToString() : "N/A",
                                    cartProduct.ProductName,
                                    !string.IsNullOrEmpty(cartProduct.Section) ? cartProduct.Section : "N/A",
                                    cartProduct.Quantity,
                                    cartProduct.Price,
                                    cartProduct.TotalPrice
                                );
                            }
                        }
                        if (dataGridView1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[0].Selected = true;
                            DisplayProductDetails(dataGridView1.Rows[0]);
                        }
                    }
                    else
                    {
                        UpdateTotalPrice();
                        return;
                    }
                }
                UpdateTotalPrice();
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    DisplayProductDetails(dataGridView1.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectProductById(int productId)
        {
            try
            {
                if (dataGridView1 == null) return;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["ProductID"] != null && row.Cells["ProductID"].Value != null)
                    {
                        string cellValue = row.Cells["ProductID"].Value.ToString();
                        if (int.TryParse(cellValue, out int rowProductId) && rowProductId == productId)
                        {
                            row.Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                            DisplayProductDetails(row);
                            return;
                        }
                    }
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    DisplayProductDetails(dataGridView1.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error selecting product by ID: {ex.Message}");
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                DisplayProductDetails(selectedRow);
            }
        }

        private void DisplayProductDetails(DataGridViewRow row)
        {
            string productIdStr = row.Cells["ProductID"].Value?.ToString() ?? "N/A";
            string productName = row.Cells["ProductName"].Value?.ToString() ?? "";
            string section = row.Cells["Section"].Value?.ToString() ?? "N/A";
            string quantity = row.Cells["Quantity"].Value?.ToString() ?? "0";
            string price = row.Cells["Price"].Value?.ToString() ?? "0";
            string totalPrice = row.Cells["TotalPrice"].Value?.ToString() ?? "0";
            if (int.TryParse(productIdStr, out int productId) && productId > 0)
            {
                Product dbProduct = DatabaseHelper.GetProductById(productId);
                if (dbProduct != null)
                {
                    lblProductIDValue.Text = dbProduct.Pid.ToString();
                    lblProductNameValue.Text = dbProduct.Pname;
                    lblSectionValue.Text = dbProduct.Section;
                    lblQuantityValue.Text = quantity;
                    lblPriceValue.Text = $"{dbProduct.Price:C2}";
                    if (int.TryParse(quantity, out int qty))
                    {
                        decimal total = qty * dbProduct.Price;
                        lblTotalPriceValue.Text = $"{total:C2}";
                    }
                    else
                    {
                        lblTotalPriceValue.Text = totalPrice;
                    }
                    return;
                }
            }
            lblProductIDValue.Text = productIdStr;
            lblProductNameValue.Text = productName;
            lblSectionValue.Text = section;
            lblQuantityValue.Text = quantity;
            lblPriceValue.Text = price;
            lblTotalPriceValue.Text = totalPrice;
        }

        private void UpdateTotalPrice()
        {
            try
            {
                decimal total = 0;
                if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        try
                        {
                            if (row.Cells["TotalPrice"] != null && row.Cells["TotalPrice"].Value != null)
                            {
                                string valueStr = row.Cells["TotalPrice"].Value.ToString();
                                if (!string.IsNullOrEmpty(valueStr))
                                {
                                    valueStr = valueStr.Replace("$", "").Replace(",", "").Trim();
                                    if (decimal.TryParse(valueStr, System.Globalization.NumberStyles.Currency,
                                        System.Globalization.CultureInfo.InvariantCulture, out decimal rowTotal))
                                    {
                                        total += rowTotal;
                                    }
                                    else if (decimal.TryParse(valueStr, out decimal rowTotal2))
                                    {
                                        total += rowTotal2;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                if (labelTotal != null)
                {
                    labelTotal.Text = $"Total Cost: {total:C2}";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating total price: {ex.Message}");
                if (labelTotal != null)
                {
                    labelTotal.Text = "Total Cost: $0.00";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 next = new Form2();
            next.Show();
            this.Hide();
        }

        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                string productIdStr = selectedRow.Cells["ProductID"].Value?.ToString() ?? "";
                string productName = selectedRow.Cells["ProductName"].Value?.ToString() ?? "";
                string section = selectedRow.Cells["Section"].Value?.ToString() ?? "";

                if (int.TryParse(productIdStr, out int productId) && productId > 0)
                {
                    Product dbProduct = DatabaseHelper.GetProductById(productId);
                    if (dbProduct != null)
                    {
                        CartManager.AddProduct(dbProduct.Pid, dbProduct.Pname, dbProduct.Section, 1, (decimal)dbProduct.Price);
                        LoadCartData();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["ProductID"].Value?.ToString() == productIdStr)
                            {
                                row.Selected = true;
                                DisplayProductDetails(row);
                                break;
                            }
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(productName))
                {
                    Product dbProduct = DatabaseHelper.GetProductByName(productName);
                    if (dbProduct != null)
                    {
                        CartManager.AddProduct(dbProduct.Pid, dbProduct.Pname, dbProduct.Section, 1, (decimal)dbProduct.Price);
                        LoadCartData();
                    }
                    else
                    {
                        string priceStr = selectedRow.Cells["Price"].Value?.ToString() ?? "0";
                        if (decimal.TryParse(priceStr.Replace("$", "").Replace(",", ""), out decimal price))
                        {
                            CartManager.AddProduct(productName, 1, price);
                            LoadCartData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error increasing quantity: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product first.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedRow = dataGridView1.SelectedRows[0];
                string productIdStr = selectedRow.Cells["ProductID"].Value?.ToString() ?? "";
                string productName = selectedRow.Cells["ProductName"].Value?.ToString() ?? "";
                string section = selectedRow.Cells["Section"].Value?.ToString() ?? "";
                string quantityStr = selectedRow.Cells["Quantity"].Value?.ToString() ?? "0";

                if (!int.TryParse(quantityStr, out int currentQuantity) || currentQuantity <= 1)
                {
                    if (int.TryParse(productIdStr, out int productId) && productId > 0)
                    {
                        var cartProducts = CartManager.GetCart();
                        var productToRemove = cartProducts.FirstOrDefault(p => p.ProductId == productId);
                        if (productToRemove != null)
                        {
                            CartManager.RemoveProduct(productToRemove.ProductName);
                        }
                    }
                    else if (!string.IsNullOrEmpty(productName))
                    {
                        CartManager.RemoveProduct(productName);
                    }
                }
                else
                {
                    if (int.TryParse(productIdStr, out int productId) && productId > 0)
                    {
                        Product dbProduct = DatabaseHelper.GetProductById(productId);
                        if (dbProduct != null)
                        {
                            var cartProducts = CartManager.GetCart();
                            var productToUpdate = cartProducts.FirstOrDefault(p => p.ProductId == productId);
                            if (productToUpdate != null)
                            {
                                CartManager.RemoveProduct(productToUpdate.ProductName);
                                CartManager.AddProduct(dbProduct.Pid, dbProduct.Pname, dbProduct.Section, currentQuantity - 1, (decimal)dbProduct.Price);
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(productName))
                    {
                        CartManager.RemoveProduct(productName);
                        string priceStr = selectedRow.Cells["Price"].Value?.ToString() ?? "0";
                        if (decimal.TryParse(priceStr.Replace("$", "").Replace(",", ""), out decimal price))
                        {
                            CartManager.AddProduct(productName, currentQuantity - 1, price);
                        }
                    }
                }
                LoadCartData();
                if (int.TryParse(productIdStr, out int pid) && pid > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["ProductID"].Value?.ToString() == productIdStr)
                        {
                            row.Selected = true;
                            DisplayProductDetails(row);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decreasing quantity: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                LoadCartData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form12.LoggedInCustomer == null)
            {
                MessageBox.Show("Please login first to complete your purchase.", "Login Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form12 loginForm = new Form12();
                loginForm.Show();
                this.Hide();
                return;
            }
            var cartProducts = CartManager.GetCart();
            if (cartProducts.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items before purchasing.", "Empty Cart",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal total = cartProducts.Sum(p => p.TotalPrice);
            DialogResult result = MessageBox.Show(
                $"Customer: {Form12.LoggedInCustomer.Name}\n" +
                $"Email: {Form12.LoggedInCustomer.Email}\n" +
                $"Total Amount: {total:C2}\n\n" +
                $"Do you want to proceed with the purchase?",
                "Confirm Purchase",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CartManager.ClearCart();
                MessageBox.Show("Purchase completed successfully! Thank you for your order.", "Purchase Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCartData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBoxProductDetails_Enter(object sender, EventArgs e)
        {

        }
    }
}
