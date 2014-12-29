using RoomBooking.Core.Enums;
using System;

namespace RoomBooking.Core.Models
{
    public class Book
    {
        public Book(Room room, DateTime startDate, DateTime endDate)
        {
            if (startDate.TimeOfDay < room.StartTime.TimeOfDay)
            {
                throw new Exception("Hora inválida");
            }

            this.Room = room;
            this.Status = EBookStatus.InProgress;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public Room Room { get; private set; }
        public EBookStatus Status { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
