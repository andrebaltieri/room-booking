using RoomBooking.Domain.Account.Scopes;
using System;

namespace RoomBooking.Domain.Account.Models
{
    public class User
    {
        protected User() { }
        public User(string username, string password)
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
            this.Password = password;
            this.MustResetPassword = false;
            this.IsActive = false;
        }

        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool MustResetPassword { get; private set; }
        public bool IsActive { get; private set; }

        public void Authenticate(string username, string password)
        {
            if (this.AuthenticateUserScopeIsValid(username, password))
                return;
        }

        public void Register()
        {
            if (this.RegisterUserScopeIsValid())
                return;
        }
    }
}
