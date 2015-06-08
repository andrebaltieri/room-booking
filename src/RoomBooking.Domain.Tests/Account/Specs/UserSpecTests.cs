using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Domain.Account.Models;
using RoomBooking.Domain.Account.Specs;
using System.Collections.Generic;
using System.Linq;

namespace RoomBooking.Domain.Tests.Account.Specs
{
    [TestClass]
    public class UserSpecTests
    {
        private IQueryable<User> _users;

        public UserSpecTests()
        {
            var users = new List<User>();
            users.Add(new User("andrebaltieri", "andrebaltieri"));

            _users = users.AsQueryable();
        }

        [TestMethod]
        [TestCategory("Account/User - Specifications")]
        public void AuthenticateUserSpecShouldReturnOne()
        {
            var query = UserSpecs.AuthenticateUser("andrebaltieri", "andrebaltieri");
            var count = _users.Where(query).Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        [TestCategory("Account/User - Specifications")]
        public void AuthenticateUserSpecShouldReturnZero()
        {
            var query = UserSpecs.AuthenticateUser("andrebaltieri222", "andrebaltieri");
            var count = _users.Where(query).Count();

            Assert.AreEqual(0, count);
        }
    }
}
