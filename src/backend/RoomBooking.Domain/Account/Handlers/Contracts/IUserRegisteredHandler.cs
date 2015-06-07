using RoomBooking.Domain.Account.Events.UserEvents;
using RoomBooking.SharedKernel.Helpers.Contracts;

namespace RoomBooking.Domain.Account.Handlers.Contracts
{
    public interface IUserRegisteredHandler : IHandler<UserRegistered>
    {
    }
}
