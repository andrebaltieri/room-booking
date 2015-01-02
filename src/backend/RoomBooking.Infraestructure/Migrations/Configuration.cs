namespace RoomBooking.Infraestructure.Migrations
{
    using RoomBooking.Core.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RoomBooking.Infraestructure.Data.DataContexts.RoomBookingDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomBooking.Infraestructure.Data.DataContexts.RoomBookingDataContext context)
        {
            var adminRole = new Role("Admin");
            var userRole = new Role("User");

            context.Roles.Add(new Role("Admin"));
            context.Roles.Add(new Role("User"));
            context.SaveChanges();
        }
    }
}
