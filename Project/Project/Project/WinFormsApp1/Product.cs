namespace WinFormsApp1
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;

        public Product(string productName, int quantity, decimal price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
