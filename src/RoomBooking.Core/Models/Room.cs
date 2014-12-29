using RoomBooking.Core.Helpers;
using RoomBooking.Core.Interfaces.Services;
using RoomBooking.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomBooking.Core.Models
{
    public class Room
    {
        private IList<Book> _books { get; set; }
        private INotificationService _notificationService;

        public Room(INotificationService notificationService, DateTime startTime, DateTime endTime, string title)
        {
            ValidatorHelper.EnsureDateIsGreaterThan(startTime, endTime, ErrorMessages.RoomStartTimeMustBeFuture);
            ValidatorHelper.EnsureHourIsGreaterThan(startTime.Hour, 8, ErrorMessages.RoomMustOpensAfter);
            ValidatorHelper.EnsureHourIsLessThan(startTime.Hour, 18, ErrorMessages.RoomMustClosesBefore);

            this._notificationService = notificationService;
            this.Id = new Guid();
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Title = title;
            this._books = new List<Book>();
        }

        protected Room()
        {
            this._books = new List<Book>();
        }

        public Guid Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string Title { get; private set; }
        public ICollection<Book> Books
        {
            get { return _books; }
            private set { _books = new List<Book>(value); }
        }

        public int TotalBooksByDateRange(DateTime startDate, DateTime endDate)
        {
            return _books.Where(x => x.StartTime >= startDate && x.EndTime <= endDate).Count();
        }

        public void PlaceBook(Book book)
        {
            ValidatorHelper.EnsureDateIsGreaterThan(book.StartTime, this.StartTime, String.Format(ErrorMessages.RoomOpensAt, this.StartTime.ToString("hh:mm")));
            ValidatorHelper.EnsureDateIsLessThan(book.EndTime, this.EndTime, String.Format(ErrorMessages.RoomClosesAt, this.EndTime.ToString("hh:mm")));
            ValidatorHelper.EnsureDateIsGreaterOrEqualThan(book.StartTime, book.EndTime, ErrorMessages.BookStartTimeMustBeFuture);

            if (this._books != null && this._books.Where(x => x.StartTime >= book.StartTime && x.EndTime <= book.EndTime).Any())
                throw new Exception(ErrorMessages.RoomAlreadyBookedAtThisTime);

            this._books.Add(book);
            _notificationService.SendNotification(book.Name, book.Email);
        }
    }
}
