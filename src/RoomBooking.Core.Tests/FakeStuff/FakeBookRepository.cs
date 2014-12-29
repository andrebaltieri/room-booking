using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Tests.FakeStuff
{
    public class FakeBookRepository : IBookRepository
    {
        private List<Book> _books;

        public FakeBookRepository()
        {
            this._books = new List<Book>();

            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);
            var startRoomTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var endRoomTime = new DateTime(1900, 01, 01, 18, 0, 0);
            var room = new Room(startRoomTime, endRoomTime);

            var book = new Book(room, startTime, endTime);
            _books.Add(book);
        }

        public IList<Book> GetBooksByDateRange(DateTime startDate, DateTime endDate)
        {
            return _books;
        }

        public void Dispose()
        {
        }
    }
}
