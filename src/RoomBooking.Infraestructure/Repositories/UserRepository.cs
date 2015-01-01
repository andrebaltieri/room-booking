using RoomBooking.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Core.Models;
using RoomBooking.Infraestructure.Data.DataContexts;

namespace RoomBooking.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private RoomBookingDataContext _db;

        public UserRepository(RoomBookingDataContext db)
        {
            this._db = db;
        }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
