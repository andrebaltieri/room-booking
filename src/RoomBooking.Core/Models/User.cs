using RoomBooking.Core.Helpers;
using RoomBooking.Core.Resources;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Models
{
    public class User
    {
        private IList<Role> _roles { get; set; }

        public User(string name, string email)
        {
            this.Name = name;
            this.Email = email;
            this._roles = new List<Role>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<Role> Roles
        {
            get { return _roles; }
            protected set { _roles = new List<Role>(value); }
        }

        public void SetPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword)
                throw new Exception(ErrorMessages.PasswordNotMatch);

            this.Password = password;
        }
        public void AddRole(Role role)
        {
            ValidatorHelper.EnsureIsNotNull(role, ErrorMessages.UserHasANullRole);
            ValidatorHelper.EnsureIsNotNull(_roles, ErrorMessages.UserHasANullRoleList);

            this._roles.Add(role);
        }
    }
}
