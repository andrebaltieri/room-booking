using RoomBooking.Core.Models;
using RoomBooking.Infraestructure.Data.Mappings;
using System.Data.Entity;

namespace RoomBooking.Infraestructure.Data.DataContexts
{
    public class RoomBookingDataContext : DbContext
    {
        public RoomBookingDataContext()
            :base("RoomBookingConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<RoomBookingDataContext>(new RoomBookingDataContextInitializer());
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new RoomMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
        }
    }

    public class RoomBookingDataContextInitializer : DropCreateDatabaseAlways<RoomBookingDataContext>
    {
        protected override void Seed(RoomBookingDataContext context)
        {
            context.Roles.Add(new Role("Admin"));
            context.Roles.Add(new Role("User"));
            context.SaveChanges();
        }
    }
}
