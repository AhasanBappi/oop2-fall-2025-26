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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string section = GetSectionForForm(1);
            Form3 next = new Form3(section);
            next.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string section = GetSectionForForm(2);
            Form4 next = new Form4(section);
            next.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 next = new Form1();
            next.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string section = GetSectionForForm(3);
            Form5 next = new Form5(section);
            next.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string section = GetSectionForForm(4);
            Form6 next = new Form6(section);
            next.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string section = GetSectionForForm(5);
            Form7 next = new Form7(section);
            next.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                string section = GetSectionForForm(6);
                Form8 next = new Form8(section);
                next.Show();
                next.BringToFront();
                next.Activate();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Form8: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetSectionForForm(int formNumber)
        {
            string[] sections = { 
                "Kidz zone",
                "Racing Zone",
                "AR/VR Zone",
                "Bowling Zone",
                "War Zone",
                "Archade Zone"
            };
            
            if (formNumber >= 1 && formNumber <= sections.Length)
            {
                return sections[formNumber - 1];
            }
            
            return "Default";
        }
    }
}
