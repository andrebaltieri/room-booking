using RoomBooking.ApplicationService.Account.Handlers;
using RoomBooking.SharedKernel.Events;
using RoomBooking.SharedKernel.Helpers.Contracts;
using RoomBooking.SharedKernel.Repositories.Contracts;
using System;

namespace RoomBooking.ApplicationService.Account.Services
{
    public class ApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;
        private UserRegisteredHandler _userRegisteredHandler;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            this._userRegisteredHandler = DomainEvent.Container.GetService<UserRegisteredHandler>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;
            
            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("IX_USER_USERNAME"))
                    DomainEvent.Raise<DomainNotification>(new DomainNotification("User", "Este nome de usuário já está sendo utilizado."));
                else
                    DomainEvent.Raise<DomainNotification>(new DomainNotification("User", "Falha ao cadastrar usuário"));

                return false;
            }
        }
    }
}
