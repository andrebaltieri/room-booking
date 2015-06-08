using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Domain.Account.Models;
using RoomBooking.Domain.Account.Scopes;

namespace RoomBooking.Domain.Tests.Account.Models
{
    [TestClass]
    public class GivenANewUser
    {
        [TestMethod]
        [TestCategory("Account/User - Given a new user")]
        public void IsActiveShouldBeFalse()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(false, user.IsActive);
        }

        [TestMethod]
        [TestCategory("Account/User - Given a new user")]
        public void MustResetPasswordShouldBeFalse()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(false, user.MustResetPassword);
        }
    }

    [TestClass]
    public class OnUserAuthentication
    {
        [TestMethod]
        [TestCategory("Account/User - Authenticate")]
        public void ItShouldAuthenticate()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(true, user.AuthenticateUserScopeIsValid("andrebaltieri", "andrebaltieri"));
        }

        [TestMethod]
        [TestCategory("Account/User - Authenticate")]
        public void ItShouldNotAuthenticate()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(false, user.AuthenticateUserScopeIsValid("andrebaltieri2", "andrebaltieri2"));
        }
    }

    [TestClass]
    public class OnUserRegistration
    {
        [TestMethod]
        [TestCategory("Account/User - Register")]
        public void ItShouldRegister()
        {
            var user = new User("andrebaltieri", "andrebaltieri");
            Assert.AreEqual(true, user.RegisterUserScopeIsValid());
        }

        [TestMethod]
        [TestCategory("Account/User - Register")]
        public void ItShouldNotRegister()
        {
            var user = new User("", "andrebaltieri");
            Assert.AreEqual(false, user.RegisterUserScopeIsValid());
        }
    }
}
