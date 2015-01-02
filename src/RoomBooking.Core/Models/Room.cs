using RoomBooking.Core.Enums;
using System;

namespace RoomBooking.Core.Models
{
    public class Room
    {
        protected Room()
        {
            this.Id = Guid.NewGuid();
        }
        public Room(DateTime startTime, DateTime endTime)
        {
            this.Id = Guid.NewGuid();
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public Guid Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ERoomStatus Status { get; private set; }
        public string Title { get; private set; }

        public void MarkAsInUse()
        {
            this.Status = ERoomStatus.InUse;
        }
    }
}