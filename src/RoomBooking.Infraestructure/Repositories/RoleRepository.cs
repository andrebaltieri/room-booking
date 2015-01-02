using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Models;
using RoomBooking.Infraestructure.Data.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace RoomBooking.Infraestructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private RoomBookingDataContext _db;

        public RoleRepository(RoomBookingDataContext db)
        {
            this._db = db;
        }

        public IList<Role> GetAll()
        {
            return _db.Roles.ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
