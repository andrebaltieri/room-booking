using RoomBooking.Core.Enums;
using RoomBooking.Core.Helpers;
using RoomBooking.Core.Interfaces.Repositories;
using System;

namespace RoomBooking.Core.Models
{
    public class Book
    {
        public Book(Room room, DateTime startDate, DateTime endDate)
        {
            ValidatorHelper.EnsureTimeIsGreaterOrEqualThan(startDate, room.StartTime, "Error");
            ValidatorHelper.EnsureTotalHourIsLessThan(startDate.Hour, endDate.Hour, 2, "Error");
            ValidatorHelper.EnsureDateIsGreaterOrEqualThan(startDate, DateTime.Now, "Error");
            ValidatorHelper.EnsureTimeIsLessOrEqualThan(endDate, room.EndTime, "Error");
            ValidatorHelper.EnsureDayOfWeekIsNotWeekend(startDate, "Error");
            ValidatorHelper.EnsureIsNotNull(room, "Error");

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
