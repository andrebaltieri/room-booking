using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Domain.Account.Models;

namespace RoomBooking.Domain.Tests.Account.Models
{
    [TestClass]
    public class GivenANewUser
    {
        [TestMethod]
        [TestCategory("Given a new user")]
        public void IsActiveShouldBeFalse()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(false, user.IsActive);
        }

        [TestMethod]
        [TestCategory("Given a new user")]
        public void MustResetPasswordShouldBeFalse()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(false, user.MustResetPassword);
        }
    }
}
