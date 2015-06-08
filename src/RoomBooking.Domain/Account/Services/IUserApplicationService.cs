using RoomBooking.Domain.Account.Commands.UserCommands;
using RoomBooking.Domain.Account.Models;

namespace RoomBooking.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
        bool Authenticate(string username, string password);
    }
}
