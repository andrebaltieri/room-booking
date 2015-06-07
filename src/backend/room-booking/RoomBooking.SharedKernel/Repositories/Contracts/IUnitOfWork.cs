using System;

namespace RoomBooking.SharedKernel.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
