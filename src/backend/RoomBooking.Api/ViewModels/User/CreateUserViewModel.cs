namespace RoomBooking.Api.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string[] Roles { get; set; }
    }
}