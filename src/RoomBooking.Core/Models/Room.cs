using RoomBooking.Core.Enums;
using System;

namespace RoomBooking.Core.Models
{
    public class Room
    {
        public Room(DateTime startTime, DateTime endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ERoomStatus Status { get; private set; }

        public void MarkAsInUse()
        {
            this.Status = ERoomStatus.InUse;
        }
    }
}