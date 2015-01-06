using RoomBooking.Core.Models;
using System;

namespace RoomBooking.Core.Interfaces.Repositories
{
    public interface IAuthenticationRepository : IDisposable
    {
        User Authenticate(string email, string password);
    }
}
