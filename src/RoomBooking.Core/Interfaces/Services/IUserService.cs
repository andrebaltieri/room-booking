using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Interfaces.Services
{
    public interface IUserService : IDisposable
    {
        void CreateNewUser(string name, string email, IList<string> roles);
        string ResetPassword(string email);
        void ChangePassword(string currentPassword, string newPassword, string confirmPassword, string email);
        void UpdateProfile(string name, string email);
        User Authenticate(string email, string password);
    }
}
