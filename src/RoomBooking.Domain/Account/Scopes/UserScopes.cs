using RoomBooking.Domain.Account.Models;
using RoomBooking.SharedKernel.Validation;

namespace RoomBooking.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserScopeIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(user.Username, "O usuário é obrigatório"),
                AssertionConcern.AssertNotEmpty(user.Password, "A senha é obrigatória")
            );
        }

        public static bool AuthenticateUserScopeIsValid(this User user, string username, string password)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(username, "O usuário é obrigatório"),
                AssertionConcern.AssertNotEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertAreEquals(user.Username, username, "Usuário ou senha inválidos"),
                AssertionConcern.AssertAreEquals(user.Password, password, "Usuário ou senha inválidos")
            );
        }
    }
}
