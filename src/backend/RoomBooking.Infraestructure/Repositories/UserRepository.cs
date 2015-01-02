using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Models;
using RoomBooking.Infraestructure.Data.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;

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
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _db.Users.Include("Roles").Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _db.Users.Include("Roles").Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();
        }

        public User GetById(Guid id)
        {
            return _db.Users.Include("Roles").Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(User user)
        {
            _db.Entry<User>(user).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
