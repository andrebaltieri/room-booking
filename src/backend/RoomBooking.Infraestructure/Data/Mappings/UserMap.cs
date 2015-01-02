using RoomBooking.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomBooking.Infraestructure.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Email).HasMaxLength(160).IsRequired();
            Property(x => x.Name).HasMaxLength(60).IsRequired();
            Property(x => x.Password).HasMaxLength(36).IsRequired();

            HasMany(x => x.Roles).WithMany(x => x.Users).Map(x => x.ToTable("UserRoles"));
        }
    }
}
