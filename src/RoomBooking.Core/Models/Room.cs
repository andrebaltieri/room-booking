using RoomBooking.Core.Enums;
using System;

namespace RoomBooking.Core.Models
{
    public class Room
    {
        protected Room() { }
        public Room(DateTime startTime, DateTime endTime)
        {
            this.Id = new Guid();
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public Guid Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ERoomStatus Status { get; private set; }

        public void MarkAsInUse()
        {
            this.Status = ERoomStatus.InUse;
        }
    }
}