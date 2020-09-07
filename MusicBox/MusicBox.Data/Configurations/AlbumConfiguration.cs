using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            //ToTable("Users");

            //HasKey(s => s.Id);

            //Property(p => p.FirstName);
            //Property(p => p.LastName);

            //HasOptional(s => s.Role)
            //   .WithMany(c => c.Users)
            //   .Map(m => m.MapKey("RoleId")).WillCascadeOnDelete(true);
        }
    }

}
