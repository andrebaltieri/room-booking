using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Models;
using System.Data.SqlClient;

namespace RoomBooking.Infraestructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private SqlConnection _conn;

        public AuthenticationRepository()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RoomBookingConnectionString"].ConnectionString;
            _conn = new SqlConnection(connectionString);
            _conn.Open();
        }

        public User Authenticate(string email, string password)
        {
            SqlCommand selectUserCommand = new SqlCommand("select top 1 [Id], [Name], [Email] from [User] u where u.[Email] = @Email AND u.[Password] = @Password", _conn);
            selectUserCommand.Parameters.AddWithValue("@Email", email);
            selectUserCommand.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = selectUserCommand.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
                return null;

            User user = new User(reader.GetGuid(0), reader.GetString(1), reader.GetString(2));
            reader.Close();

            SqlCommand selectRoleCommand = new SqlCommand("select r.Name from [UserRoles] ur inner join [Role] r on ur.[Role_Id] = r.Id where ur.[User_Id] = @UserId", _conn);
            selectRoleCommand.Parameters.AddWithValue("@UserId", user.Id);

            reader = selectRoleCommand.ExecuteReader();
            while (reader.Read())
            {
                user.AddRole(new Role(reader.GetString(0)));
            }
            reader.Close();

            return user;
        }

        public void Dispose()
        {
            _conn.Close();
        }
    }
}
