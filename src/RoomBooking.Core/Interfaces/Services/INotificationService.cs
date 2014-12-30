using System;

namespace RoomBooking.Core.Interfaces.Services
{
    public interface INotificationService : IDisposable
    {
        void SendNotification(string name, string email);
    }
}
