﻿
namespace YourSound
{
    public class Account
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }

        public Account() 
        { 
            ID = 0;
            FullName = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Image = new byte[0];
        }
    }
}
