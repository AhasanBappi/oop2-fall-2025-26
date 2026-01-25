using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form14 : Form
    {
        private List<Employee> _employees = new List<Employee>();
        private int? _selectedEmployeeId;

        public Form14()
        {
            InitializeComponent();
            SetupForm();
            LoadEmployees();
        }

        private void SetupForm()
        {
            if (textBox6 != null)
                textBox6.PasswordChar = '*';
            if (dataGridView1 != null)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                SetupGridColumns();
            }
            if (button1 != null) button1.Click += Button1_Click;
            if (button2 != null) button2.Click += Button2_Click;
            if (button10 != null) button10.Click += Button10_Click;
            if (checkBox1 != null) checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            if (dataGridView1 != null) dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void SetupGridColumns()
        {
            if (dataGridView1 == null) return;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Eid", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Phone", "Phone");
            dataGridView1.Columns.Add("DOB", "DOB");
            dataGridView1.Columns.Add("Gender", "Gender");
        }

        private void LoadEmployees()
        {
            if (dataGridView1 == null) return;
            try
            {
                _employees = DatabaseHelper.GetAllEmployees();
                dataGridView1.Rows.Clear();
                foreach (var emp in _employees)
                {
                    dataGridView1.Rows.Add(
                        emp.Eid,
                        emp.Name ?? "",
                        emp.Email ?? "",
                        emp.Phone ?? "",
                        emp.DOB == DateTime.MinValue ? "" : emp.DOB.ToString("yyyy-MM-dd"),
                        ""
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1?.Text?.Trim() ?? "";
            string phone = textBox2?.Text?.Trim() ?? "";
            string email = textBox3?.Text?.Trim() ?? "";
            string gender = comboBox1?.SelectedItem?.ToString() ?? "";
            string password = textBox6?.Text?.Trim() ?? "";
            DateTime dob = dateTimePicker1?.Value ?? DateTime.Now;
            DateTime joiningDate = dateTimePicker2?.Value ?? DateTime.Now;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter employee name.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Enter email.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter password (numeric).", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(password, out _))
            {
                MessageBox.Show("Password must be numeric.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.RegisterEmployee(name, dob, phone, email, gender, password, joiningDate))
            {
                ClearFields();
                LoadEmployees();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var f10 = new Form10();
            f10.Show();
            Hide();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox6 != null && checkBox1 != null)
                textBox6.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.SelectedRows.Count == 0)
            {
                ClearFields();
                return;
            }

            int idx = dataGridView1.SelectedRows[0].Index;
            if (idx < 0 || idx >= _employees.Count) return;

            var emp = _employees[idx];
            _selectedEmployeeId = emp.Eid;

            if (textBox1 != null) textBox1.Text = emp.Name ?? "";
            if (textBox2 != null) textBox2.Text = emp.Phone ?? "";
            if (textBox3 != null) textBox3.Text = emp.Email ?? "";
            if (textBox6 != null) textBox6.Text = emp.Password ?? "";
            if (dateTimePicker1 != null) dateTimePicker1.Value = emp.DOB == DateTime.MinValue ? DateTime.Now : emp.DOB;
            if (comboBox1 != null)
            {
                comboBox1.SelectedIndex = -1;
            }
        }

        private void ClearFields()
        {
            if (textBox1 != null) textBox1.Clear();
            if (textBox2 != null) textBox2.Clear();
            if (textBox3 != null) textBox3.Clear();
            if (textBox6 != null) textBox6.Clear();
            if (comboBox1 != null) comboBox1.SelectedIndex = -1;
            if (dateTimePicker1 != null) dateTimePicker1.Value = DateTime.Now;
            if (dateTimePicker2 != null) dateTimePicker2.Value = DateTime.Now;
            _selectedEmployeeId = null;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (!_selectedEmployeeId.HasValue)
            {
                MessageBox.Show("Select an employee to fire.", "Fire Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var emp = _employees.FirstOrDefault(e => e.Eid == _selectedEmployeeId.Value);
            if (emp == null)
            {
                MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Fire '{emp.Name}' (ID: {emp.Eid}, Email: {emp.Email})?", "Fire Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (DatabaseHelper.DeleteEmployee(_selectedEmployeeId.Value))
                {
                    ClearFields();
                    LoadEmployees();
                }
            }
        }
    }
}
