using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Interfaces.Repositories
{
    public interface IRoomRepository : IDisposable
    {
        IList<Room> GetRoomsByDateRange(DateTime startDate, DateTime endDate);
        void Save(Room room);
        void Update(Room room);
    }
}
