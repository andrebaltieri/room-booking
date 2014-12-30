using RoomBooking.Core.Enums;
using RoomBooking.Core.Helpers;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Models
{
    public class Book
    {
        public Book(Room room, DateTime startDate, DateTime endDate, User user)
        {
            ValidatorHelper.EnsureTimeIsGreaterOrEqualThan(startDate, room.StartTime, "Error");
            ValidatorHelper.EnsureTotalHourIsLessThan(startDate.Hour, endDate.Hour, 2, "Error");
            ValidatorHelper.EnsureDateIsGreaterOrEqualThan(startDate, DateTime.Now, "Error");
            ValidatorHelper.EnsureTimeIsLessOrEqualThan(endDate, room.EndTime, "Error");
            ValidatorHelper.EnsureDayOfWeekIsNotWeekend(startDate, "Error");
            ValidatorHelper.EnsureIsNotNull(room, "Error");
            ValidatorHelper.EnsureIsNotNull(user, "Error");

            this.Room = room;
            this.Status = EBookStatus.InProgress;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.User = user;
        }

        public Room Room { get; private set; }
        public EBookStatus Status { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public User User { get; private set; }

        public void Confirm(IList<DateTime> holidays, IList<DateTime> booksForThisPeriod)
        {
            ValidatorHelper.EnrureListDontHaveDate(holidays, this.StartDate, "Error");
            ValidatorHelper.EnrureListDontHaveDateAndTime(booksForThisPeriod, this.StartDate, "Error");

            if (this.Status != EBookStatus.InProgress)
                throw new Exception("Error");

            this.Status = EBookStatus.Reserved;
        }

        public void MarkAsInProgress()
        {
            this.Room.MarkAsInUse();
            this.Status = EBookStatus.InUse;
        }

        public void Cancel()
        {
            if ((this.StartDate - DateTime.Now).Hours < 2)
                throw new Exception("Error");

            this.Status = EBookStatus.Canceled;
        }

        public void MarkAsCompleted()
        {
            this.Status = EBookStatus.Completed;
        }
    }
}
