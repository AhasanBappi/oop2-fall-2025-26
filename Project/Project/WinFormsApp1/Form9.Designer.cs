namespace WinFormsApp1
{
    partial class Form9
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            labelTotal = new Label();
            groupBoxProductDetails = new GroupBox();
            btnDecreaseQuantity = new Button();
            btnIncreaseQuantity = new Button();
            lblTotalPriceValue = new Label();
            lblTotalPrice = new Label();
            lblPriceValue = new Label();
            lblPrice = new Label();
            lblQuantityValue = new Label();
            lblQuantity = new Label();
            lblSectionValue = new Label();
            lblSection = new Label();
            lblProductNameValue = new Label();
            lblProductName = new Label();
            lblProductIDValue = new Label();
            lblProductID = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxProductDetails.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(-2, 653);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(594, 157);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 1;
            label1.Text = "Cart";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 181);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1211, 347);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTotal.ForeColor = Color.DarkGreen;
            labelTotal.Location = new Point(26, 531);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(231, 37);
            labelTotal.TabIndex = 3;
            labelTotal.Text = "Total Cost: $0.00";
            // 
            // groupBoxProductDetails
            // 
            groupBoxProductDetails.Controls.Add(btnDecreaseQuantity);
            groupBoxProductDetails.Controls.Add(btnIncreaseQuantity);
            groupBoxProductDetails.Controls.Add(lblTotalPriceValue);
            groupBoxProductDetails.Controls.Add(lblTotalPrice);
            groupBoxProductDetails.Controls.Add(lblPriceValue);
            groupBoxProductDetails.Controls.Add(lblPrice);
            groupBoxProductDetails.Controls.Add(lblQuantityValue);
            groupBoxProductDetails.Controls.Add(lblQuantity);
            groupBoxProductDetails.Controls.Add(lblSectionValue);
            groupBoxProductDetails.Controls.Add(lblSection);
            groupBoxProductDetails.Controls.Add(lblProductNameValue);
            groupBoxProductDetails.Controls.Add(lblProductName);
            groupBoxProductDetails.Controls.Add(lblProductIDValue);
            groupBoxProductDetails.Controls.Add(lblProductID);
            groupBoxProductDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxProductDetails.Location = new Point(26, 29);
            groupBoxProductDetails.Name = "groupBoxProductDetails";
            groupBoxProductDetails.Size = new Size(1211, 120);
            groupBoxProductDetails.TabIndex = 4;
            groupBoxProductDetails.TabStop = false;
            groupBoxProductDetails.Text = "Product Details (Click on a product above to view details)";
            groupBoxProductDetails.Enter += groupBoxProductDetails_Enter;
            // 
            // btnDecreaseQuantity
            // 
            btnDecreaseQuantity.BackColor = Color.FromArgb(192, 0, 0);
            btnDecreaseQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDecreaseQuantity.ForeColor = Color.White;
            btnDecreaseQuantity.Location = new Point(126, 64);
            btnDecreaseQuantity.Margin = new Padding(3, 4, 3, 4);
            btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            btnDecreaseQuantity.Size = new Size(40, 33);
            btnDecreaseQuantity.TabIndex = 13;
            btnDecreaseQuantity.Text = "-";
            btnDecreaseQuantity.UseVisualStyleBackColor = false;
            btnDecreaseQuantity.Click += btnDecreaseQuantity_Click;
            // 
            // btnIncreaseQuantity
            // 
            btnIncreaseQuantity.BackColor = Color.FromArgb(0, 192, 0);
            btnIncreaseQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIncreaseQuantity.ForeColor = Color.White;
            btnIncreaseQuantity.Location = new Point(171, 64);
            btnIncreaseQuantity.Margin = new Padding(3, 4, 3, 4);
            btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            btnIncreaseQuantity.Size = new Size(40, 33);
            btnIncreaseQuantity.TabIndex = 12;
            btnIncreaseQuantity.Text = "+";
            btnIncreaseQuantity.UseVisualStyleBackColor = false;
            btnIncreaseQuantity.Click += btnIncreaseQuantity_Click;
            // 
            // lblTotalPriceValue
            // 
            lblTotalPriceValue.AutoSize = true;
            lblTotalPriceValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalPriceValue.ForeColor = Color.Green;
            lblTotalPriceValue.Location = new Point(696, 69);
            lblTotalPriceValue.Name = "lblTotalPriceValue";
            lblTotalPriceValue.Size = new Size(27, 20);
            lblTotalPriceValue.TabIndex = 11;
            lblTotalPriceValue.Text = "---";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalPrice.Location = new Point(600, 69);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(86, 20);
            lblTotalPrice.TabIndex = 10;
            lblTotalPrice.Text = "Total Price:";
            // 
            // lblPriceValue
            // 
            lblPriceValue.AutoSize = true;
            lblPriceValue.Font = new Font("Segoe UI", 9F);
            lblPriceValue.Location = new Point(304, 69);
            lblPriceValue.Name = "lblPriceValue";
            lblPriceValue.Size = new Size(27, 20);
            lblPriceValue.TabIndex = 9;
            lblPriceValue.Text = "---";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.Location = new Point(250, 69);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(47, 20);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price:";
            // 
            // lblQuantityValue
            // 
            lblQuantityValue.AutoSize = true;
            lblQuantityValue.Font = new Font("Segoe UI", 9F);
            lblQuantityValue.Location = new Point(101, 69);
            lblQuantityValue.Name = "lblQuantityValue";
            lblQuantityValue.Size = new Size(27, 20);
            lblQuantityValue.TabIndex = 7;
            lblQuantityValue.Text = "---";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQuantity.Location = new Point(21, 69);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(74, 20);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity:";
            // 
            // lblSectionValue
            // 
            lblSectionValue.AutoSize = true;
            lblSectionValue.Font = new Font("Segoe UI", 9F);
            lblSectionValue.Location = new Point(671, 29);
            lblSectionValue.Name = "lblSectionValue";
            lblSectionValue.Size = new Size(27, 20);
            lblSectionValue.TabIndex = 5;
            lblSectionValue.Text = "---";
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSection.Location = new Point(600, 29);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(64, 20);
            lblSection.TabIndex = 4;
            lblSection.Text = "Section:";
            // 
            // lblProductNameValue
            // 
            lblProductNameValue.AutoSize = true;
            lblProductNameValue.Font = new Font("Segoe UI", 9F);
            lblProductNameValue.Location = new Point(363, 29);
            lblProductNameValue.Name = "lblProductNameValue";
            lblProductNameValue.Size = new Size(27, 20);
            lblProductNameValue.TabIndex = 3;
            lblProductNameValue.Text = "---";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductName.Location = new Point(250, 29);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(114, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name:";
            // 
            // lblProductIDValue
            // 
            lblProductIDValue.AutoSize = true;
            lblProductIDValue.Font = new Font("Segoe UI", 9F);
            lblProductIDValue.Location = new Point(107, 29);
            lblProductIDValue.Name = "lblProductIDValue";
            lblProductIDValue.Size = new Size(27, 20);
            lblProductIDValue.TabIndex = 1;
            lblProductIDValue.Text = "---";
            // 
            // lblProductID
            // 
            lblProductID.AutoSize = true;
            lblProductID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductID.Location = new Point(21, 29);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(88, 20);
            lblProductID.TabIndex = 0;
            lblProductID.Text = "Product ID:";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(1121, 663);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Purchase";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 719);
            Controls.Add(button2);
            Controls.Add(groupBoxProductDetails);
            Controls.Add(labelTotal);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form9";
            Text = "Cart & Product Details";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxProductDetails.ResumeLayout(false);
            groupBoxProductDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private DataGridView dataGridView1;
        private Label labelTotal;
        private GroupBox groupBoxProductDetails;
        private Label lblProductID;
        private Label lblProductIDValue;
        private Label lblProductName;
        private Label lblProductNameValue;
        private Label lblSection;
        private Label lblSectionValue;
        private Label lblQuantity;
        private Label lblQuantityValue;
        private Label lblPrice;
        private Label lblPriceValue;
        private Label lblTotalPrice;
        private Label lblTotalPriceValue;
        private Button btnIncreaseQuantity;
        private Button btnDecreaseQuantity;
        private Button button2;
    }
}