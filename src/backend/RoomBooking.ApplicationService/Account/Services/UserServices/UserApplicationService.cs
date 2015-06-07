using RoomBooking.Domain.Account.Commands.UserCommands;
using RoomBooking.Domain.Account.Entities;
using RoomBooking.Domain.Account.Events.UserEvents;
using RoomBooking.Domain.Account.Repositories;
using RoomBooking.Domain.Account.Scopes;
using RoomBooking.Domain.Account.Services;
using RoomBooking.SharedKernel.Events;
using RoomBooking.SharedKernel.Repositories.Contracts;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RoomBooking.ApplicationService.Account.Services.UserServices
{
    public class UserApplicationService : IUserApplicationService
    {
        private IUserRepository _repository;
        private IUnitOfWork _unitOfWork;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Username, command.Password);
            user.Register();

            if (!user.RegisterUserScopeIsValid())
                return null;

            try
            {
                _repository.Register(user);
                _unitOfWork.Commit();

                DomainEvent.Raise(new UserRegistered(user));
                return user;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("IX_USER_USERNAME"))
                    DomainEvent.Raise<DomainNotification>(new DomainNotification("User", "Este nome de usuário já está sendo utilizado."));
                else
                    DomainEvent.Raise<DomainNotification>(new DomainNotification("User", "Falha ao cadastrar usuário"));

                return null;
            }
        }

        public bool Authenticate(string username, string password)
        {
            _repository.Authenticate(username, password);
            return true;
        }
    }
}
