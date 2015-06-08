using RoomBooking.Domain.Account.Events.UserEvents;
using RoomBooking.Domain.Account.Handlers.Contracts;
using System.Collections.Generic;

namespace RoomBooking.ApplicationService.Account.Handlers
{
    public class UserRegisteredHandler : IUserRegisteredHandler
    {
        private List<UserRegistered> _notifications;        

        public void Handle(UserRegistered args)
        {
            // Enviar Email   
            string emailForBreakPoint = "";
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public IEnumerable<UserRegistered> Notify()
        {
            return GetValue();
        }

        private List<UserRegistered> GetValue()
        {
            return _notifications;
        }

        public void Dispose()
        {
            this._notifications = new List<UserRegistered>();
        }
    }
}
