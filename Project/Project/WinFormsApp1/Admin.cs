namespace WinFormsApp1
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Admin()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}
