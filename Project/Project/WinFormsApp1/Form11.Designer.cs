namespace WinFormsApp1
{
    partial class Form11
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
            label1 = new Label();
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblId = new Label();
            lblIdValue = new Label();
            lblSection = new Label();
            lblSectionValue = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 57);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Product list";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(66, 92);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(107, 20);
            lblProductName.TabIndex = 20;
            lblProductName.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(176, 89);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 27);
            txtProductName.TabIndex = 21;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(66, 128);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(44, 20);
            lblPrice.TabIndex = 22;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(176, 125);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(120, 27);
            txtPrice.TabIndex = 23;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(66, 165);
            lblId.Name = "lblId";
            lblId.Size = new Size(27, 20);
            lblId.TabIndex = 24;
            lblId.Text = "ID:";
            // 
            // lblIdValue
            // 
            lblIdValue.AutoSize = true;
            lblIdValue.Location = new Point(176, 165);
            lblIdValue.Name = "lblIdValue";
            lblIdValue.Size = new Size(15, 20);
            lblIdValue.TabIndex = 25;
            lblIdValue.Text = "-";
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(66, 192);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(62, 20);
            lblSection.TabIndex = 26;
            lblSection.Text = "Section:";
            // 
            // lblSectionValue
            // 
            lblSectionValue.AutoSize = true;
            lblSectionValue.Location = new Point(176, 192);
            lblSectionValue.Name = "lblSectionValue";
            lblSectionValue.Size = new Size(15, 20);
            lblSectionValue.TabIndex = 27;
            lblSectionValue.Text = "-";
            // 
            // button1
            // 
            button1.Location = new Point(66, 225);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(66, 268);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 2;
            button2.Text = "Insert";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(66, 311);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 3;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(66, 354);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(86, 31);
            button4.TabIndex = 4;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(66, 397);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(86, 31);
            button5.TabIndex = 5;
            button5.Text = "Read";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(12, 541);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(99, 45);
            button6.TabIndex = 6;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(801, 541);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(86, 31);
            button7.TabIndex = 7;
            button7.Text = "Submit";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(272, 515);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(104, 57);
            button8.TabIndex = 8;
            button8.Text = "Refresh";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(602, 521);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(94, 45);
            button9.TabIndex = 9;
            button9.Text = "Clear";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(602, 128);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(181, 28);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(255, 190);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(647, 317);
            dataGridView1.TabIndex = 14;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(556, 199);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(331, 299);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // Form11
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pictureBox1);
            Controls.Add(lblSectionValue);
            Controls.Add(lblSection);
            Controls.Add(lblIdValue);
            Controls.Add(lblId);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblProductName);
            Controls.Add(txtProductName);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form11";
            Text = "Form11";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblId;
        private Label lblIdValue;
        private Label lblSection;
        private Label lblSectionValue;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
    }
}