using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Interfaces.Repositories
{
    public interface IRoleRepository : IDisposable
    {
        IList<Role> GetAll();
    }
}
