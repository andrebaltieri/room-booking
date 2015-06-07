using RoomBooking.Infrastructure.ORM.Contexts;
using RoomBooking.SharedKernel.Repositories.Contracts;

namespace RoomBooking.Infrastructure.Transaction
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private RoomBookingDataContext _context;

        public UnitOfWork(RoomBookingDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
