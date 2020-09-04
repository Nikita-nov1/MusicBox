using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
