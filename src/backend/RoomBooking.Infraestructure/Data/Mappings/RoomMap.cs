using RoomBooking.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomBooking.Infraestructure.Data.Mappings
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            ToTable("Room");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasMaxLength(60).IsRequired();
        }
    }
}
