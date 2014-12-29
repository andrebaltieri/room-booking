namespace RoomBooking.Core.Interfaces.Services
{
    public interface INotificationService
    {
        void SendNotification(string name, string email);
    }
}
