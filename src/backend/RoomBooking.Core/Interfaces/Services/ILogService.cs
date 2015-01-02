using System;

namespace RoomBooking.Core.Interfaces.Services
{
    public interface ILogService : IDisposable
    {
        void Log(string message);
        void Log(Exception ex);
    }
}
