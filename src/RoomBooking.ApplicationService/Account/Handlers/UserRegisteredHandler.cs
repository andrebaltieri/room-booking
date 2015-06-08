using RoomBooking.Domain.Account.Events.UserEvents;
using RoomBooking.Domain.Account.Handlers.Contracts;
using RoomBooking.SharedKernel.Helpers.Contracts;
using System.Collections.Generic;
using System;

namespace RoomBooking.ApplicationService.Account.Handlers
{
    public class UserRegisteredHandler : IHandler<UserRegistered>
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
