using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    public static class CartManager
    {
        private static List<CartProduct> cart = new List<CartProduct>();

        public static void AddProduct(string productName, int quantity, decimal price)
        {
            var existingProduct = cart.FirstOrDefault(p => p.ProductName == productName);
            
            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartProduct(productName, quantity, price));
            }
        }

        public static void AddProduct(int productId, string productName, string section, int quantity, decimal price)
        {
            if (productId > 0)
            {
                var existingProduct = cart.FirstOrDefault(p => p.ProductId == productId && p.ProductId > 0);
                
                if (existingProduct != null)
                {
                    existingProduct.Quantity += quantity;
                    try
                    {
                        DatabaseHelper.SaveSelectedProduct(productId, productName, section, existingProduct.Quantity, price);
                    }
                    catch
                    {
                    }
                    return;
                }
            }
            var existingByName = cart.FirstOrDefault(p => 
                string.Equals(p.ProductName, productName, StringComparison.OrdinalIgnoreCase));
            
            if (existingByName != null)
            {
                existingByName.Quantity += quantity;
                if (existingByName.ProductId > 0)
                {
                    try
                    {
                        DatabaseHelper.SaveSelectedProduct(existingByName.ProductId, productName, section, existingByName.Quantity, price);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                cart.Add(new CartProduct(productId, productName, section, quantity, price));
                if (productId > 0)
                {
                    try
                    {
                        DatabaseHelper.SaveSelectedProduct(productId, productName, section, quantity, price);
                    }
                    catch
                    {
                    }
                }
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
            DatabaseHelper.ClearSelectedProducts();
        }
        public static void LoadCartFromDatabase()
        {
            try
            {
                cart.Clear();
                var dbProducts = DatabaseHelper.GetSelectedProductsFromDatabase();
                if (dbProducts != null)
                {
                    foreach (var product in dbProducts)
                    {
                        if (product != null)
                        {
                            cart.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading cart from database: {ex.Message}");
            }
        }

        public static List<CartProduct> GetCart()
        {
            return new List<CartProduct>(cart);
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
