using RoomBooking.Domain.Account.Models;
using RoomBooking.Domain.Account.Repositories;
using RoomBooking.Domain.Account.Specs;
using RoomBooking.Infrastructure.ORM.Contexts;
using System.Linq;

namespace RoomBooking.Infrastructure.Repositories.Account
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private RoomBookingDataContext _context;

        public UserRepository(RoomBookingDataContext context)
            : base(context)
        {
            this._context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users
                .Where(UserSpecs.AuthenticateUser(username, password))
                .FirstOrDefault();
        }
    }
}
