using RoomBooking.Core.Helpers;
using System;

namespace RoomBooking.Core.Models
{
    public class User
    {
        public User(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
                throw new Exception("Error");

            this.Password = password;
        }
    }
}
