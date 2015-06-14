using RoomBooking.Domain.Account.Models;
using RoomBooking.SharedKernel.Repositories.Contracts;

namespace RoomBooking.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);
        User Authenticate(string username, string password);
    }
}
