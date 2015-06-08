using RoomBooking.Domain.Account.Models;
using RoomBooking.Infrastructure.ORM.Mapping.Account;
using System.Data.Entity;

namespace RoomBooking.Infrastructure.ORM.Contexts
{
    public class RoomBookingDataContext : DbContext
    {
        public RoomBookingDataContext() :
            base("RoomBookingConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
