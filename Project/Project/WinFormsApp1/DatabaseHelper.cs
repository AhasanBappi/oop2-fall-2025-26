using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=LAPTOP-U3P85N2K\SQLEXPRESS;Initial Catalog=Game;Integrated Security=True;TrustServerCertificate=True";

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static List<string> GetAllSections()
        {
            return new List<string> { "kidz_zone", "racing_zone", "AR/VR_zone", "bowling_zone", "war_zone", "archade_zone" };
        }

        public static List<Product> GetProductsBySection(string section)
        {
            List<Product> products = new List<Product>();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT pid, pname, price, section FROM product WHERE section = @Section";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Section", section);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    Pid = reader.GetInt32("pid"),
                                    Pname = reader.IsDBNull("pname") ? string.Empty : reader.GetString("pname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = reader.IsDBNull("section") ? string.Empty : reader.GetString("section")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return products;
        }
        public static List<Product> GetProductsFromZoneTable(string tableName)
        {
            List<Product> products = new List<Product>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error connecting to load products from {tableName}: {ex.Message}");
                    return products;
                }
                try
                {
                    string query = $"SELECT rid, rname, price FROM [{tableName}]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Pid = reader.GetInt32("rid"),
                                Pname = reader.IsDBNull("rname") ? string.Empty : reader.GetString("rname"),
                                Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                Section = tableName
                            });
                        }
                    }
                    if (products.Count > 0) return products;
                }
                catch
                {
                }
                try
                {
                    string query = $"SELECT pid, pname, price, section FROM [{tableName}]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Pid = reader.GetInt32("pid"),
                                Pname = reader.IsDBNull("pname") ? string.Empty : reader.GetString("pname"),
                                Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                Section = reader.IsDBNull("section") ? tableName : reader.GetString("section")
                            });
                        }
                    }
                    if (products.Count > 0) return products;
                }
                catch
                {
                }
                try
                {
                    string query = $"SELECT bid, bname, price FROM [{tableName}]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Pid = reader.GetInt32("bid"),
                                Pname = reader.IsDBNull("bname") ? string.Empty : reader.GetString("bname"),
                                Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                Section = tableName
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error loading products from {tableName}: {ex.Message}");
                }
            }
            
            return products;
        }
        public static Product GetProductFromZoneTableById(string tableName, int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT pid, pname, price, section FROM [{tableName}] WHERE pid = @ProductId";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                try
                                {
                                    return new Product
                                    {
                                        Pid = reader.GetInt32("pid"),
                                        Pname = reader.IsDBNull("pname") ? string.Empty : reader.GetString("pname"),
                                        Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                        Section = reader.IsDBNull("section") ? tableName : reader.GetString("section")
                                    };
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    query = $"SELECT rid, rname, price FROM [{tableName}] WHERE rid = @ProductId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                try
                                {
                                    return new Product
                                    {
                                        Pid = reader.GetInt32("rid"),
                                        Pname = reader.IsDBNull("rname") ? string.Empty : reader.GetString("rname"),
                                        Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                        Section = tableName
                                    };
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    query = $"SELECT rid, rname, price FROM [{tableName}] WHERE rid = @ProductId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                try
                                {
                                    return new Product
                                    {
                                        Pid = reader.GetInt32("rid"),
                                        Pname = reader.IsDBNull("rname") ? string.Empty : reader.GetString("rname"),
                                        Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                        Section = tableName
                                    };
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    query = $"SELECT bid, bname, price FROM [{tableName}] WHERE bid = @ProductId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Product
                                {
                                    Pid = reader.GetInt32("bid"),
                                    Pname = reader.IsDBNull("bname") ? string.Empty : reader.GetString("bname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = tableName
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading product from {tableName}: {ex.Message}");
            }
            
            return null;
        }
        public static Product GetProductFromZoneTableByName(string tableName, string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error connecting for GetProductFromZoneTableByName: {ex.Message}");
                    return null;
                }
                
                string name = productName.Trim();
                string nameLike = "%" + name + "%";
                try
                {
                    string query = $"SELECT rid, rname, price FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(rname))) = LOWER(LTRIM(RTRIM(@ProductName)))";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Product
                                {
                                    Pid = reader.GetInt32("rid"),
                                    Pname = reader.IsDBNull("rname") ? string.Empty : reader.GetString("rname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = tableName
                                };
                        }
                    }
                    query = $"SELECT TOP 1 rid, rname, price FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(rname))) LIKE LOWER(@ProductName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", nameLike);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Product
                                {
                                    Pid = reader.GetInt32("rid"),
                                    Pname = reader.IsDBNull("rname") ? string.Empty : reader.GetString("rname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = tableName
                                };
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    string query = $"SELECT pid, pname, price, section FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(pname))) = LOWER(LTRIM(RTRIM(@ProductName)))";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Product
                                {
                                    Pid = reader.GetInt32("pid"),
                                    Pname = reader.IsDBNull("pname") ? string.Empty : reader.GetString("pname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = reader.IsDBNull("section") ? tableName : reader.GetString("section")
                                };
                        }
                    }
                    query = $"SELECT TOP 1 pid, pname, price, section FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(pname))) LIKE LOWER(@ProductName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", nameLike);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Product
                                {
                                    Pid = reader.GetInt32("pid"),
                                    Pname = reader.IsDBNull("pname") ? string.Empty : reader.GetString("pname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = reader.IsDBNull("section") ? tableName : reader.GetString("section")
                                };
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    string query = $"SELECT bid, bname, price FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(bname))) = LOWER(LTRIM(RTRIM(@ProductName)))";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Product
                                {
                                    Pid = reader.GetInt32("bid"),
                                    Pname = reader.IsDBNull("bname") ? string.Empty : reader.GetString("bname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = tableName
                                };
                        }
                    }
                    query = $"SELECT TOP 1 bid, bname, price FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(bname))) LIKE LOWER(@ProductName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", nameLike);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                return new Product
                                {
                                    Pid = reader.GetInt32("bid"),
                                    Pname = reader.IsDBNull("bname") ? string.Empty : reader.GetString("bname"),
                                    Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                    Section = tableName
                                };
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error loading product from {tableName}: {ex.Message}");
                }
            }
            
            return null;
        }

        public static bool InsertProduct(string pname, int price, string section)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO product (pname, price, section) VALUES (@Pname, @Price, @Section)";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Pname", pname ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Section", section ?? (object)DBNull.Value);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool UpdateProduct(int pid, string pname, int price, string section)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE product SET pname = @Pname, price = @Price, section = @Section WHERE pid = @Pid";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Pid", pid);
                        command.Parameters.AddWithValue("@Pname", pname ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Section", section ?? (object)DBNull.Value);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteProduct(int pid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM product WHERE pid = @Pid";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Pid", pid);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private static (string idCol, string nameCol, bool hasSection) GetZoneSchema(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName)) return ("pid", "pname", false);
            string t = tableName.Trim();
            if (t.Equals("kidz_zone", StringComparison.OrdinalIgnoreCase)) return ("pid", "pname", true);
            if (t.Equals("racing_zone", StringComparison.OrdinalIgnoreCase)) return ("rid", "rname", false);
            return ("bid", "bname", false);
        }

        public static bool InsertProductIntoZoneTable(string tableName, string productName, int price)
        {
            if (string.IsNullOrWhiteSpace(tableName)) return false;
            var (idCol, nameCol, hasSection) = GetZoneSchema(tableName);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string cols = hasSection ? $"[{nameCol}], [price], [section]" : $"[{nameCol}], [price]";
                    string vals = hasSection ? "@Name, @Price, @Section" : "@Name, @Price";
                    string sql = $"INSERT INTO [{tableName}] ({cols}) VALUES ({vals})";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", productName ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Price", price);
                        if (hasSection) cmd.Parameters.AddWithValue("@Section", tableName);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool UpdateProductInZoneTable(string tableName, int productId, string productName, int price)
        {
            if (string.IsNullOrWhiteSpace(tableName)) return false;
            var (idCol, nameCol, hasSection) = GetZoneSchema(tableName);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string set = hasSection
                        ? $"[{nameCol}] = @Name, [price] = @Price, [section] = @Section"
                        : $"[{nameCol}] = @Name, [price] = @Price";
                    string sql = $"UPDATE [{tableName}] SET {set} WHERE [{idCol}] = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", productId);
                        cmd.Parameters.AddWithValue("@Name", productName ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Price", price);
                        if (hasSection) cmd.Parameters.AddWithValue("@Section", tableName);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteProductFromZoneTable(string tableName, int productId)
        {
            if (string.IsNullOrWhiteSpace(tableName)) return false;
            var (idCol, _, _) = GetZoneSchema(tableName);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = $"DELETE FROM [{tableName}] WHERE [{idCol}] = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", productId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Product GetProductById(int pid)
        {
            string[] zoneTables = { "kidz_zone", "racing_zone", "AR/VR_zone", "bowling_zone", "war_zone", "archade_zone" };
            
            foreach (string tableName in zoneTables)
            {
                try
                {
                    Product product = GetProductFromZoneTableById(tableName, pid);
                    if (product != null)
                    {
                        return product;
                    }
                }
                catch
                {
                }
            }
            
            return null;
        }

        public static Product GetProductByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return null;
            string[] zoneTables = { "kidz_zone", "racing_zone", "AR/VR_zone", "bowling_zone", "war_zone", "archade_zone" };
            
            string cleanName = productName.Trim();
            cleanName = System.Text.RegularExpressions.Regex.Replace(cleanName, @"\s*\d+\s*tk\s*$", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            cleanName = System.Text.RegularExpressions.Regex.Replace(cleanName, @"Price:\s*\d+\s*tk\s*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            cleanName = cleanName.Trim();
            foreach (string tableName in zoneTables)
            {
                try
                {
                    Product product = GetProductFromZoneTableByName(tableName, cleanName);
                    if (product != null)
                    {
                        return product;
                    }
                }
                catch
                {
                }
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    foreach (string tableName in zoneTables)
                    {
                        try
                        {
                            string query = $"SELECT TOP 1 bid, bname, price FROM [{tableName}] WHERE LOWER(LTRIM(RTRIM(bname))) LIKE LOWER(@Bname)";
                            
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Bname", "%" + cleanName + "%");
                                
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        return new Product
                                        {
                                            Pid = reader.GetInt32("bid"),
                                            Pname = reader.IsDBNull("bname") ? string.Empty : reader.GetString("bname"),
                                            Price = reader.IsDBNull("price") ? 0 : reader.GetInt32("price"),
                                            Section = tableName
                                        };
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading product by name: {ex.Message}");
            }
            
            return null;
        }
        public static bool AuthenticateEmployee(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM employee WHERE email = @Email AND password = @Password";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email ?? string.Empty);
                        if (!int.TryParse(password ?? string.Empty, out int passwordInt))
                            return false;
                        command.Parameters.AddWithValue("@Password", passwordInt);
                        
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error authenticating employee: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Employee GetEmployeeByEmail(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT eid, name, DOB, phone, email, password FROM employee WHERE email = @Email";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email ?? string.Empty);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string phoneValue = string.Empty;
                                if (!reader.IsDBNull("phone"))
                                {
                                    try
                                    {
                                        int phoneOrdinal = reader.GetOrdinal("phone");
                                        if (reader.GetFieldType(phoneOrdinal) == typeof(int) || 
                                            reader.GetFieldType(phoneOrdinal) == typeof(Int64))
                                        {
                                            phoneValue = reader.GetInt32("phone").ToString();
                                        }
                                        else
                                        {
                                            phoneValue = reader.GetString("phone");
                                        }
                                    }
                                    catch
                                    {
                                        try
                                        {
                                            object phoneObj = reader["phone"];
                                            phoneValue = phoneObj?.ToString() ?? string.Empty;
                                        }
                                        catch
                                        {
                                            phoneValue = string.Empty;
                                        }
                                    }
                                }
                                string pwd = reader.IsDBNull(5) ? "0" : reader.GetInt32(5).ToString();
                                return new Employee
                                {
                                    Eid = reader.GetInt32("eid"),
                                    Name = reader.IsDBNull("name") ? string.Empty : reader.GetString("name"),
                                    DOB = reader.IsDBNull("DOB") ? DateTime.MinValue : reader.GetDateTime("DOB"),
                                    Phone = phoneValue,
                                    Email = reader.IsDBNull("email") ? string.Empty : reader.GetString("email"),
                                    Password = pwd
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading employee: {ex.Message}");
            }
            
            return null;
        }
        public static bool RegisterEmployee(string name, DateTime dob, string phone, string email, string gender, string password, DateTime joiningDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM employee WHERE email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email?.Trim() ?? "");
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Email already exists. Please use a different email.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (!int.TryParse(password?.Trim() ?? "", out int passwordInt))
                    {
                        MessageBox.Show("Password must be numeric.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    string insertQuery;
                    try
                    {
                        insertQuery = "INSERT INTO employee (name, DOB, phone, email, gender, password, joining_date) VALUES (@Name, @DOB, @Phone, @Email, @Gender, @Password, @JoiningDate)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name", name?.Trim() ?? "");
                            command.Parameters.AddWithValue("@DOB", dob);
                            command.Parameters.AddWithValue("@Phone", phone?.Trim() ?? "");
                            command.Parameters.AddWithValue("@Email", email?.Trim() ?? "");
                            command.Parameters.AddWithValue("@Gender", gender?.Trim() ?? "");
                            command.Parameters.AddWithValue("@Password", passwordInt);
                            command.Parameters.AddWithValue("@JoiningDate", joiningDate);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Employee registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                    }
                    catch (Microsoft.Data.SqlClient.SqlException sqlEx)
                    {
                        if (sqlEx.Number == 207)
                        {
                            insertQuery = "INSERT INTO employee (name, DOB, phone, email, password) VALUES (@Name, @DOB, @Phone, @Email, @Password)";
                            using (SqlCommand command = new SqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Name", name?.Trim() ?? "");
                                command.Parameters.AddWithValue("@DOB", dob);
                                command.Parameters.AddWithValue("@Phone", phone?.Trim() ?? "");
                                command.Parameters.AddWithValue("@Email", email?.Trim() ?? "");
                                command.Parameters.AddWithValue("@Password", passwordInt);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Employee registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering employee: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT eid, name, DOB, phone, email, password FROM employee ORDER BY eid";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string phoneValue = string.Empty;
                            if (!reader.IsDBNull("phone"))
                            {
                                try
                                {
                                    int phoneOrd = reader.GetOrdinal("phone");
                                    if (reader.GetFieldType(phoneOrd) == typeof(int) || 
                                        reader.GetFieldType(phoneOrd) == typeof(Int64))
                                    {
                                        phoneValue = reader.GetInt32("phone").ToString();
                                    }
                                    else
                                    {
                                        phoneValue = reader.GetString("phone");
                                    }
                                }
                                catch
                                {
                                    phoneValue = reader["phone"]?.ToString() ?? "";
                                }
                            }

                            string pwd = reader.IsDBNull("password") ? "0" : reader.GetInt32("password").ToString();
                            
                            employees.Add(new Employee
                            {
                                Eid = reader.GetInt32("eid"),
                                Name = reader.IsDBNull("name") ? "" : reader.GetString("name"),
                                DOB = reader.IsDBNull("DOB") ? DateTime.MinValue : reader.GetDateTime("DOB"),
                                Phone = phoneValue,
                                Email = reader.IsDBNull("email") ? "" : reader.GetString("email"),
                                Password = pwd
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return employees;
        }
        public static bool DeleteEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM employee WHERE eid = @Eid";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Eid", employeeId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee fired successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error firing employee: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool AuthenticateAdmin(string nameOrEmail, string password)
        {
            try
            {
                if (!int.TryParse(password ?? string.Empty, out int passwordInt))
                    return false;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM admin WHERE (name = @Input OR email = @Input) AND password = @Password";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Input", nameOrEmail ?? string.Empty);
                        command.Parameters.AddWithValue("@Password", passwordInt);
                        
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error authenticating admin: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool AuthenticateCustomer(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM customer WHERE email = @Email AND password = @Password";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email ?? string.Empty);
                        if (!int.TryParse(password ?? string.Empty, out int passwordInt))
                        {
                            return false;
                        }
                        command.Parameters.AddWithValue("@Password", passwordInt);
                        
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error authenticating customer: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static Customer? AuthenticateAndGetCustomer(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT cid, name, phone, email, gender, password FROM customer WHERE email = @Email AND password = @Password";
                    
                    System.Diagnostics.Debug.WriteLine($"Login attempt: email='{email}', password length={password.Length}");
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email.Trim());
                        if (!int.TryParse(password, out int passwordInt))
                        {
                            MessageBox.Show("Password must be numeric. Please enter a valid password.", "Invalid Password", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                        cmd.Parameters.AddWithValue("@Password", passwordInt);

                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                System.Diagnostics.Debug.WriteLine("No matching customer found");
                                return null;
                            }

                            System.Diagnostics.Debug.WriteLine("Customer found, reading data...");
                            
                            try
                            {
                                int cid = 0;
                                if (!r.IsDBNull(0))
                                    cid = r.GetInt32(0);

                                string GetStr(int i) => r.IsDBNull(i) ? string.Empty : r.GetString(i);
                                string passwordStr = r.IsDBNull(5) ? "0" : r.GetInt32(5).ToString();
                                
                                Customer customer = new Customer
                                {
                                    Cid = cid,
                                    Name = GetStr(1),
                                    Phone = GetStr(2),
                                    Email = GetStr(3),
                                    Gender = GetStr(4),
                                    Password = passwordStr
                                };
                                
                                System.Diagnostics.Debug.WriteLine($"Successfully loaded customer: ID={customer.Cid}, Name={customer.Name}");
                                return customer;
                            }
                            catch (Exception readEx)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error reading customer data: {readEx.Message}");
                                MessageBox.Show($"Error reading customer data: {readEx.Message}\n\nPlease check the customer table structure.", "Data Read Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error during login: {sqlEx.Message} (Number: {sqlEx.Number})");
                string errorMsg = $"Database error during login:\n{sqlEx.Message}";
                if (sqlEx.Number == 207)
                {
                    errorMsg += "\n\nPossible issue: Column names don't match. Expected: cid, name, phone, email, gender, password";
                }
                else if (sqlEx.Number == 208)
                {
                    errorMsg += "\n\nPossible issue: The 'customer' table doesn't exist or isn't accessible.";
                }
                MessageBox.Show(errorMsg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"General error during login: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static Customer? GetCustomerByEmail(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT [cid], [name], [phone], [email], [gender], [password] FROM [customer] WHERE [email] = @Email";
                    
                    System.Diagnostics.Debug.WriteLine($"Attempting to get customer with email: '{email}'");
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email?.Trim() ?? string.Empty);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                System.Diagnostics.Debug.WriteLine("Customer record found, reading data...");
                                
                                try
                                {
                                    string passwordStr = reader.IsDBNull(5) ? string.Empty : reader.GetInt32(5).ToString();
                                    
                                    Customer customer = new Customer
                                    {
                                        Cid = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                        Phone = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                        Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                        Gender = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                        Password = passwordStr
                                    };
                                    
                                    System.Diagnostics.Debug.WriteLine($"Successfully loaded customer: ID={customer.Cid}, Name={customer.Name}");
                                    return customer;
                                }
                                catch (Exception readEx)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Error reading customer data: {readEx.Message}");
                                    MessageBox.Show($"Error reading customer data: {readEx.Message}", "Data Read Error", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return null;
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"No customer found with email: '{email}'");
                                MessageBox.Show($"No customer record found with email: {email}. Please try registering again.", "Customer Not Found", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error loading customer: {sqlEx.Message} (Error Number: {sqlEx.Number})");
                string errorDetails = $"SQL Error: {sqlEx.Message}\nError Number: {sqlEx.Number}";
                if (sqlEx.Number == 207)
                {
                    errorDetails += "\n\nPossible issue: Column name mismatch. Please check the customer table structure.";
                }
                MessageBox.Show(errorDetails, "Database Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading customer: {ex.Message}\nStack Trace: {ex.StackTrace}");
                MessageBox.Show($"Error retrieving customer information: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static bool RegisterCustomer(string name, string phone, string email, string gender, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT COUNT(*) FROM customer WHERE email = @Email";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email?.Trim() ?? string.Empty);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Email already registered. Please use a different email.", "Registration Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    string query = "INSERT INTO [customer] ([name], [phone], [email], [gender], [password]) VALUES (@Name, @Phone, @Email, @Gender, @Password)";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        string nameValue = string.IsNullOrWhiteSpace(name) ? string.Empty : name.Trim();
                        string phoneValue = string.IsNullOrWhiteSpace(phone) ? string.Empty : phone.Trim();
                        string emailValue = string.IsNullOrWhiteSpace(email) ? string.Empty : email.Trim();
                        string genderValue = string.IsNullOrWhiteSpace(gender) ? string.Empty : gender.Trim();
                        if (!int.TryParse(password, out int passwordInt))
                        {
                            MessageBox.Show("Password must be numeric. Please enter a valid numeric password.", "Invalid Password", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        
                        command.Parameters.AddWithValue("@Name", nameValue);
                        command.Parameters.AddWithValue("@Phone", phoneValue);
                        command.Parameters.AddWithValue("@Email", emailValue);
                        command.Parameters.AddWithValue("@Gender", genderValue);
                        command.Parameters.AddWithValue("@Password", passwordInt);
                        
                        System.Diagnostics.Debug.WriteLine($"Registering customer: Name='{nameValue}', Phone='{phoneValue}', Email='{emailValue}', Gender='{genderValue}', Password={passwordInt}");
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Rows affected: {rowsAffected}");
                        
                        if (rowsAffected > 0)
                        {
                            string verifyQuery = "SELECT COUNT(*) FROM [customer] WHERE [email] = @Email";
                            using (SqlCommand verifyCommand = new SqlCommand(verifyQuery, connection))
                            {
                                verifyCommand.Parameters.AddWithValue("@Email", emailValue);
                                int verifyCount = Convert.ToInt32(verifyCommand.ExecuteScalar());
                                System.Diagnostics.Debug.WriteLine($"Verification: Found {verifyCount} record(s) with email '{emailValue}'");
                                
                                if (verifyCount > 0)
                                {
                                    System.Diagnostics.Debug.WriteLine("Customer registered and verified successfully!");
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Registration appeared to succeed, but the record was not found. Please try again.", "Verification Error", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Registration failed: No rows were inserted. Please check your input and try again.", "Registration Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error registering customer: {sqlEx.Message}");
                MessageBox.Show($"Database error during registration: {sqlEx.Message}\n\nError Number: {sqlEx.Number}", "Database Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error registering customer: {ex.Message}");
                MessageBox.Show($"Error registering customer: {ex.Message}", "Registration Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static Admin? GetAdminByName(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, email, password FROM admin WHERE name = @Name";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name ?? string.Empty);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string pwd = reader.IsDBNull(3) ? "0" : reader.GetInt32(3).ToString();
                                return new Admin
                                {
                                    Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                    Password = pwd
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading admin: {ex.Message}");
            }
            
            return null;
        }

        public static Admin? GetAdminByEmail(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, email, password FROM admin WHERE email = @Email";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email ?? string.Empty);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string pwd = reader.IsDBNull(3) ? "0" : reader.GetInt32(3).ToString();
                                return new Admin
                                {
                                    Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                    Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                    Password = pwd
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading admin by email: {ex.Message}");
            }
            
            return null;
        }
        public static void CreateSelectedProductsTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[selected_products]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[selected_products] (
                                [id] INT IDENTITY(1,1) PRIMARY KEY,
                                [pid] INT NOT NULL,
                                [pname] NVARCHAR(255) NOT NULL,
                                [section] NVARCHAR(100),
                                [quantity] INT NOT NULL DEFAULT 1,
                                [price] DECIMAL(18,2) NOT NULL,
                                [total_price] DECIMAL(18,2) NOT NULL,
                                [selected_date] DATETIME DEFAULT GETDATE()
                            )
                        END";
                    
                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating selected_products table: {ex.Message}");
            }
        }
        public static bool SaveSelectedProduct(int pid, string pname, string section, int quantity, decimal price)
        {
            try
            {
                CreateSelectedProductsTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string checkQuery = "SELECT id FROM selected_products WHERE pid = @Pid";
                    int existingId = 0;
                    
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Pid", pid);
                        object result = checkCommand.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            existingId = Convert.ToInt32(result);
                        }
                    }
                    
                    if (existingId > 0)
                    {
                        decimal totalPrice = quantity * price;
                        string updateQuery = "UPDATE selected_products SET quantity = @Quantity, total_price = @TotalPrice, selected_date = GETDATE() WHERE id = @Id";
                        
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", existingId);
                            updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                            updateCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                            
                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                    else
                    {
                        decimal totalPrice = quantity * price;
                        string insertQuery = "INSERT INTO selected_products (pid, pname, section, quantity, price, total_price) VALUES (@Pid, @Pname, @Section, @Quantity, @Price, @TotalPrice)";
                        
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@Pid", pid);
                            insertCommand.Parameters.AddWithValue("@Pname", pname ?? string.Empty);
                            insertCommand.Parameters.AddWithValue("@Section", section ?? string.Empty);
                            insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                            insertCommand.Parameters.AddWithValue("@Price", price);
                            insertCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                            
                            int rowsAffected = insertCommand.ExecuteNonQuery();
                            return rowsAffected > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving selected product: {ex.Message}");
                return false;
            }
        }
        public static List<CartProduct> GetSelectedProductsFromDatabase()
        {
            List<CartProduct> selectedProducts = new List<CartProduct>();
            
            try
            {
                CreateSelectedProductsTable();
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT pid, pname, section, quantity, price, total_price FROM selected_products ORDER BY selected_date DESC";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    int pid = reader.GetInt32("pid");
                                    string pname = reader.IsDBNull("pname") ? string.Empty : reader.GetString("pname");
                                    string section = reader.IsDBNull("section") ? string.Empty : reader.GetString("section");
                                    int quantity = reader.GetInt32("quantity");
                                    decimal price = Convert.ToDecimal(reader["price"]);
                                    
                                    selectedProducts.Add(new CartProduct(pid, pname, section, quantity, price));
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Error reading product row: {ex.Message}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading selected products: {ex.Message}");
            }
            
            return selectedProducts;
        }
        public static bool ClearSelectedProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM selected_products";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error clearing selected products: {ex.Message}");
                return false;
            }
        }
    }
}
