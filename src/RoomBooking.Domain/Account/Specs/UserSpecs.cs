using RoomBooking.Domain.Account.Models;
using System;
using System.Linq.Expressions;

namespace RoomBooking.Domain.Account.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string username, string password)
        {
            return x => x.Username == username && x.Password == password;
        }

        public static Expression<Func<User, bool>> IsActive()
        {
            return x => x.IsActive;
        }
    }
}
