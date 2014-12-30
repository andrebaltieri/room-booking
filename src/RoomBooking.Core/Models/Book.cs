using RoomBooking.Core.Enums;
using RoomBooking.Core.Helpers;
using RoomBooking.Core.Resources;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Models
{
    public class Book
    {
        public Book(Room room, DateTime startTime, DateTime endDate, User user)
        {
            ValidatorHelper.EnsureIsNotNull(room, ErrorMessages.BookHasANullRoom);
            ValidatorHelper.EnsureIsNotNull(user, ErrorMessages.BookHasANullUser);
            ValidatorHelper.EnsureTimeIsGreaterOrEqualThan(startTime, room.StartTime, String.Format(ErrorMessages.BookStartTimeMustBeGreaterThanRoomStartTime, startTime, room.StartTime));
            ValidatorHelper.EnsureTotalHourIsLessThan(startTime.Hour, endDate.Hour, 2, String.Format(ErrorMessages.BookTimeTotalShouldBeLessThan, 2));
            ValidatorHelper.EnsureDateIsGreaterOrEqualThan(startTime, DateTime.Now, String.Format(ErrorMessages.BookStartTimeMustBeInFuture));
            ValidatorHelper.EnsureTimeIsLessOrEqualThan(endDate, room.EndTime, String.Format(ErrorMessages.BookEndTimeMustBeLessThanRoomEndTime, startTime, room.EndTime));
            ValidatorHelper.EnsureDayOfWeekIsNotWeekend(startTime, ErrorMessages.BookDateIsWeekend);            

            this.Room = room;
            this.Status = EBookStatus.InProgress;
            this.StartTime = startTime;
            this.EndTime = endDate;
            this.User = user;
        }

        public Room Room { get; private set; }
        public EBookStatus Status { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public User User { get; private set; }

        public void Confirm(IList<DateTime> holidays, IList<DateTime> booksForThisPeriod)
        {
            ValidatorHelper.EnrureListDontHaveDate(holidays, this.StartTime, "Error");
            ValidatorHelper.EnrureListDontHaveDateAndTime(booksForThisPeriod, this.StartTime, "Error");

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
            if ((this.StartTime - DateTime.Now).Hours < 2)
                throw new Exception("Error");

            this.Status = EBookStatus.Canceled;
        }

        public void MarkAsCompleted()
        {
            this.Status = EBookStatus.Completed;
        }
    }
}
