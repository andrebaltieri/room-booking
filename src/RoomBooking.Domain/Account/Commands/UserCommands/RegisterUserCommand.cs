namespace RoomBooking.Domain.Account.Commands.UserCommands
{
    public class RegisterUserCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
