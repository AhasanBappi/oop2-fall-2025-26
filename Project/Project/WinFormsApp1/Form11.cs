using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form11 : Form
    {
        private static readonly (string Display, string Table)[] ZoneMap =
        {
            ("Kidz zone", "kidz_zone"),
            ("Racing zone", "racing_zone"),
            ("AR/VR zone", "AR/VR_zone"),
            ("Bowling zone", "bowling_zone"),
            ("War Zone", "war_zone"),
            ("Archade zone", "archade_zone")
        };

        private static string GetDisplayNameForTable(string table)
        {
            if (string.IsNullOrWhiteSpace(table)) return "-";
            var t = table.Trim();
            foreach (var z in ZoneMap)
                if (string.Equals(z.Table, t, StringComparison.OrdinalIgnoreCase))
                    return z.Display;
            return t;
        }

        private List<Product> _products = new List<Product>();
        private int? _editingProductId;
        private bool _loadingProducts;
        private bool _initializing;

        public Form11()
        {
            _initializing = true;
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Form11: {ex.Message}\n\n{ex.StackTrace}", "Form11 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            _editingProductId = null;
            try
            {
                SetupGridColumns();
                PopulateSectionCombo();
                if (comboBox1 != null && comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up Form11: {ex.Message}\n\n{ex.StackTrace}", "Form11 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _initializing = false;
            }
        }

        private void SetupGridColumns()
        {
            if (dataGridView1 == null) return;
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;
            var col = new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            };
            dataGridView1.Columns.Add(col);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void PopulateSectionCombo()
        {
            if (comboBox1 == null) return;
            comboBox1.Items.Clear();
            foreach (var z in ZoneMap)
                comboBox1.Items.Add(z.Display);
        }

        private string GetSelectedTableName()
        {
            var item = comboBox1?.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(item)) return ZoneMap[0].Table;
            var pair = ZoneMap.FirstOrDefault(z => string.Equals(z.Display, item.Trim(), StringComparison.OrdinalIgnoreCase));
            return pair.Table ?? ZoneMap[0].Table;
        }

        private void LoadProducts()
        {
            if (dataGridView1 == null) return;
            _loadingProducts = true;
            try
            {
                string table = GetSelectedTableName();
                _products = DatabaseHelper.GetProductsFromZoneTable(table);
                dataGridView1.Rows.Clear();
                foreach (var p in _products)
                    dataGridView1.Rows.Add(p?.Pname ?? "");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Load Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _products = new List<Product>();
            }
            finally
            {
                _loadingProducts = false;
            }
        }

        private static Image TryGetProductImage(string section, string productName, int productIndex)
        {
            var n = (productName ?? "").Trim().ToLowerInvariant();
            var s = (section ?? "").Trim().ToLowerInvariant();

            try
            {
                if (!string.IsNullOrEmpty(n))
                {
                    if (s.Contains("racing"))
                    {
                        if (n.Contains("f1") || n.Contains("racer") || n.Contains("race")) return Resources.F1;
                        if (n.Contains("max") || n.Contains("formula")) return Resources.max;
                        if (n.Contains("simulator") || n.Contains("sim")) return Resources.simulator;
                        if (n.Contains("car")) return Resources.car;
                    }
                    if (s.Contains("ar") || s.Contains("vr"))
                    {
                        if (n.Contains("3d") && n.Contains("sonic")) return Resources._3D_sonic;
                        if (n.Contains("hado")) return Resources.hado;
                        if (n.Contains("hologate") || n.Contains("hologram")) return Resources.hologate;
                        if (n.Contains("3d") || n.Contains("sonic")) return Resources._3D;
                    }
                    if (s.Contains("bowling"))
                    {
                        if (n.Contains("cj") || n.Contains("bowling")) return Resources.cj_s_bowling;
                        if (n.Contains("max") || n.Contains("lane")) return Resources.maxresdefault;
                        if (n.Contains("vip")) return Resources.vip;
                    }
                    if (s.Contains("war"))
                    {
                        if (n.Contains("ee") || n.Contains("escape")) return Resources.ee;
                        if (n.Contains("overtake") || n.Contains("vr")) return Resources.Overtake_VR;
                        if (n.Contains("paint") || n.Contains("ball") || n.Contains("pb")) return Resources.painball;
                    }
                    if (s.Contains("kidz"))
                        return Resources.Kidz_Zone_Logo_orng;
                    if (s.Contains("archade"))
                        return Resources.Gemini_Generated_Image_at2y2kat2y2kat2y_1__1_;
                }
                return GetSectionImageByIndex(section, productIndex);
            }
            catch { }
            return GetSectionImageByIndex(section, 0);
        }

        private static Image GetSectionImageByIndex(string section, int index)
        {
            var s = (section ?? "").Trim().ToLowerInvariant();
            try
            {
                if (s.Contains("kidz"))
                    return Resources.Kidz_Zone_Logo_orng;
                if (s.Contains("racing"))
                {
                    var imgs = new[] { Resources.F1, Resources.max, Resources.simulator };
                    return imgs[Math.Abs(index) % imgs.Length];
                }
                if (s.Contains("ar") || s.Contains("vr"))
                {
                    var imgs = new[] { Resources._3D, Resources.hado, Resources.hologate };
                    return imgs[Math.Abs(index) % imgs.Length];
                }
                if (s.Contains("bowling"))
                {
                    var imgs = new[] { Resources.cj_s_bowling, Resources.maxresdefault, Resources.vip };
                    return imgs[Math.Abs(index) % imgs.Length];
                }
                if (s.Contains("war"))
                {
                    var imgs = new[] { Resources.ee, Resources.Overtake_VR, Resources.painball };
                    return imgs[Math.Abs(index) % imgs.Length];
                }
                if (s.Contains("archade"))
                    return Resources.Gemini_Generated_Image_at2y2kat2y2kat2y_1__1_;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetSectionImageByIndex error: {ex.Message}");
            }
            try
            {
                return Resources.Kidz_Zone_Logo_orng;
            }
            catch
            {
                return null;
            }
        }

        private void ClearDetailBoxes()
        {
            txtProductName?.Clear();
            txtPrice?.Clear();
            if (lblIdValue != null) lblIdValue.Text = "-";
            if (lblSectionValue != null) lblSectionValue.Text = "-";
            if (pictureBox1 != null) pictureBox1.Image = null;
            _editingProductId = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _editingProductId = null;
            ClearDetailBoxes();
            if (dataGridView1?.SelectedRows.Count > 0)
                dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtProductName?.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter product name.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtPrice?.Text?.Trim(), out int price) || price < 0)
            {
                MessageBox.Show("Enter a valid price (non-negative integer).", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string table = GetSelectedTableName();
            if (DatabaseHelper.InsertProductIntoZoneTable(table, name, price))
            {
                MessageBox.Show("Product added.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDetailBoxes();
                LoadProducts();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1?.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idx = dataGridView1.SelectedRows[0].Index;
            if (idx < 0 || idx >= _products.Count) return;
            var p = _products[idx];
            _editingProductId = p.Pid;
            if (txtProductName != null) txtProductName.Text = p.Pname;
            if (txtPrice != null) txtPrice.Text = p.Price.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1?.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a product to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idx = dataGridView1.SelectedRows[0].Index;
            if (idx < 0 || idx >= _products.Count) return;
            var p = _products[idx];
            if (MessageBox.Show($"Delete '{p.Pname}'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            if (DatabaseHelper.DeleteProductFromZoneTable(GetSelectedTableName(), p.Pid))
            {
                MessageBox.Show("Product deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDetailBoxes();
                LoadProducts();
            }
        }

        private void button5_Click(object sender, EventArgs e) => LoadProducts();

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new Form10();
            f.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!_editingProductId.HasValue)
            {
                MessageBox.Show("Select a product first, then edit and Submit.", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = txtProductName?.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter product name.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtPrice?.Text?.Trim(), out int price) || price < 0)
            {
                MessageBox.Show("Enter a valid price (non-negative integer).", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string table = GetSelectedTableName();
            if (DatabaseHelper.UpdateProductInZoneTable(table, _editingProductId.Value, name, price))
            {
                MessageBox.Show("Product updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDetailBoxes();
                LoadProducts();
            }
        }

        private void button8_Click(object sender, EventArgs e) => LoadProducts();

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1?.Rows.Clear();
            _products.Clear();
            ClearDetailBoxes();
            if (dataGridView1?.SelectedRows.Count > 0)
                dataGridView1.ClearSelection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            LoadProducts();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_loadingProducts) return;
            try
            {
                if (dataGridView1 == null || dataGridView1.SelectedRows.Count == 0)
                {
                    ClearDetailBoxes();
                    return;
                }

                int idx = dataGridView1.SelectedRows[0].Index;
                if (idx < 0 || idx >= _products.Count)
                {
                    ClearDetailBoxes();
                    return;
                }

                var p = _products[idx];
                _editingProductId = p.Pid;

                if (txtProductName != null) txtProductName.Text = p.Pname ?? "";
                if (txtPrice != null) txtPrice.Text = p.Price.ToString();
                if (lblIdValue != null) lblIdValue.Text = p.Pid.ToString();
                if (lblSectionValue != null) lblSectionValue.Text = GetDisplayNameForTable(p.Section ?? "");

                var img = TryGetProductImage(p.Section ?? "", p.Pname ?? "", idx);
                if (pictureBox1 != null)
                    pictureBox1.Image = img;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing details: {ex.Message}", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
