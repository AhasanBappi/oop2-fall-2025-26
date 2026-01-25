using System;

namespace WinFormsApp1
{
    public class Customer
    {
        public int Cid { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public Customer()
        {
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Gender = string.Empty;
            Password = string.Empty;
        }
    }
}
