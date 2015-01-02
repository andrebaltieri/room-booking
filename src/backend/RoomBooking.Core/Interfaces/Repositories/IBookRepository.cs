using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Interfaces.Repositories
{
    public interface IBookRepository : IDisposable
    {
        IList<Book> GetBooksByDateRange(DateTime startDate, DateTime endDate);
    }
}
