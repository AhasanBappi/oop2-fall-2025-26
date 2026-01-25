namespace WinFormsApp1
{
    public class Product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int Price { get; set; }
        public string Section { get; set; }
        public Product()
        {
            Pname = string.Empty;
            Section = string.Empty;
        }
        public Product(int pid, string pname, int price, string section)
        {
            Pid = pid;
            Pname = pname;
            Price = price;
            Section = section;
        }
    }
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Section { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;

        public CartProduct(string productName, int quantity, decimal price)
        {
            ProductId = 0;
            ProductName = productName;
            Section = string.Empty;
            Quantity = quantity;
            Price = price;
        }

        public CartProduct(int productId, string productName, string section, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Section = section;
            Quantity = quantity;
            Price = price;
        }
    }
}
