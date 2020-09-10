using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class AlbumImageConfiguration : EntityTypeConfiguration<AlbumImage>
    {
        public AlbumImageConfiguration()
        {
            ToTable("AlbumImage");

            HasKey(c => c.Id);

            Property(c => c.Image);
            

            HasRequired<Album>(c => c.Album)
                .WithRequiredPrincipal(c => c.AlbumImage)
                .Map(m => m.MapKey("AlbumImageId"))
                .WillCascadeOnDelete(true);
        }
    }
}
