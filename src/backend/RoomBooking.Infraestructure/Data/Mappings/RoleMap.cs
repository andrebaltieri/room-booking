using RoomBooking.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomBooking.Infraestructure.Data.Mappings
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            ToTable("Role");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(60).IsRequired();
        }
    }
}
