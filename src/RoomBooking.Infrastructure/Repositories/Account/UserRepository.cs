using RoomBooking.Domain.Account.Models;
using RoomBooking.Domain.Account.Repositories;
using RoomBooking.Domain.Account.Specs;
using RoomBooking.Infrastructure.ORM.Contexts;
using RoomBooking.SharedKernel.Events;
using System;
using System.Linq;

namespace RoomBooking.Infrastructure.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        private RoomBookingDataContext _context;

        public UserRepository(RoomBookingDataContext context)
        {
            this._context = context;
        }

        public void Register(User user)
        {
            try
            {
                _context.Users.Add(user);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("IX_USER_USERNAME"))
                    DomainEvent.Raise<DomainNotification>(new DomainNotification("User", "Este nome de usuário já está sendo utilizado."));
                else
                    DomainEvent.Raise<DomainNotification>(new DomainNotification("User", "Falha ao cadastrar usuário"));
            }
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users
                .Where(UserSpecs.AuthenticateUser(username, password))
                .FirstOrDefault();
        }
    }
}
