using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    public static class CartManager
    {
        private static List<Product> cart = new List<Product>();

        public static void AddProduct(string productName, int quantity, decimal price)
        {
            // Check if product already exists in cart
            var existingProduct = cart.FirstOrDefault(p => p.ProductName == productName);
            
            if (existingProduct != null)
            {
                // Update quantity if product already exists
                existingProduct.Quantity += quantity;
            }
            else
            {
                // Add new product
                cart.Add(new Product(productName, quantity, price));
            }
        }

        public static void RemoveProduct(string productName)
        {
            var product = cart.FirstOrDefault(p => p.ProductName == productName);
            if (product != null)
            {
                cart.Remove(product);
            }
        }

        public static void ClearCart()
        {
            cart.Clear();
        }

        public static List<Product> GetCart()
        {
            return new List<Product>(cart);
        }

        public static decimal GetTotalPrice()
        {
            return cart.Sum(p => p.TotalPrice);
        }

        public static int GetItemCount()
        {
            return cart.Count;
        }
    }
}
