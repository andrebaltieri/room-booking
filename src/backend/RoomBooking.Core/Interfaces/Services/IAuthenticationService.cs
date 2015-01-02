using RoomBooking.Core.Models;
using System;

namespace RoomBooking.Core.Interfaces.Services
{
    public interface IAuthenticationService : IDisposable
    {
        User Authenticate(string email, string password);
    }
}
