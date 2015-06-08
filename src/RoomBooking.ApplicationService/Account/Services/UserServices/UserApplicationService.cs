using RoomBooking.Domain.Account.Commands.UserCommands;
using RoomBooking.Domain.Account.Events.UserEvents;
using RoomBooking.Domain.Account.Models;
using RoomBooking.Domain.Account.Repositories;
using RoomBooking.Domain.Account.Services;
using RoomBooking.SharedKernel.Events;
using RoomBooking.SharedKernel.Repositories.Contracts;

namespace RoomBooking.ApplicationService.Account.Services.UserServices
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Username, command.Password);
            user.Register();
            _repository.Register(user);

            if (Commit())
            {
                DomainEvent.Raise(new UserRegistered(user));
                return user;
            }

            return null;
        }

        public bool Authenticate(string username, string password)
        {
            _repository.Authenticate(username, password);
            return true;
        }
    }
}
