using System;

namespace WinFormsApp1
{
    public class Employee
    {
        public int Eid { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Employee()
        {
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
