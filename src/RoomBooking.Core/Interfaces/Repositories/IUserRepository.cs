using RoomBooking.Core.Models;
using System;

namespace RoomBooking.Core.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User GetByEmail(string email);
        User GetByEmailAndPassword(string email, string password);
        User GetById(Guid id);
        void Create(User user);
        void Update(User user);        
    }
}
