using System;
using System.Collections.Generic;
using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Models;

namespace RoomBooking.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {        
        public IList<Book> GetBooksByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
