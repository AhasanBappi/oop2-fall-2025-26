namespace WinFormsApp1
{
    partial class Form8
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBox2 = new TextBox();
            pictureBox3 = new PictureBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(1, 689);
            button1.Name = "button1";
            button1.Size = new Size(106, 29);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 192);
            button2.Location = new Point(1287, 689);
            button2.Name = "button2";
            button2.Size = new Size(106, 29);
            button2.TabIndex = 1;
            button2.Text = "Next";
            button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._3D_sonic;
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(451, 587);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.WhatsApp_Image_2026_01_23_at_8_20_13_PM;
            pictureBox2.Location = new Point(459, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(431, 587);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Gray;
            textBox2.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox2.Location = new Point(594, 594);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(160, 52);
            textBox2.TabIndex = 5;
            textBox2.Text = "Barrel Of Monkey Price:500tk";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.images__5_;
            pictureBox3.Location = new Point(889, 1);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(504, 587);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(255, 192, 128);
            textBox3.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic);
            textBox3.Location = new Point(1093, 594);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(121, 52);
            textBox3.TabIndex = 7;
            textBox3.Text = "Candy Car Price:1000tk";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Red;
            textBox1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(91, 594);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 52);
            textBox1.TabIndex = 3;
            textBox1.Text = "3D Sonic Price:300tk";
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 0);
            ClientSize = new Size(1394, 719);
            Controls.Add(textBox3);
            Controls.Add(pictureBox3);
            Controls.Add(textBox2);
            Controls.Add(pictureBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form8";
            Text = "Form8";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBox2;
        private PictureBox pictureBox3;
        private TextBox textBox3;
        private TextBox textBox1;
    }
}