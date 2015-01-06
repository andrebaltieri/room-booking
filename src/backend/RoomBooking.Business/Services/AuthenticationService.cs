using RoomBooking.Business.Security;
using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Interfaces.Services;
using RoomBooking.Core.Models;
using RoomBooking.Infraestructure.Repositories;

namespace RoomBooking.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {        
        public User Authenticate(string email, string password)
        {
            // Encrypta a senha
            var pass = EncryptHelper.Encrypt(password);

            var user = new User("name", "email@email.com");
            using (IAuthenticationRepository repository = new AuthenticationRepository())
            {
                user = repository.Authenticate(email, pass);
            }

            return user;
        }

        public void Dispose()
        {
            
        }
    }
}
