using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            ToTable("Albums");

            HasKey(c => c.Id);

            Property(c => c.Title);

            Property(c => c.DateOfCreation);

            Property(c => c.Year);

            HasRequired<Artist>(a => a.Artist)
                .WithMany(a => a.Albums)
                .Map(m => m.MapKey("ArtistId"))
                .WillCascadeOnDelete(false);

            HasMany<Track>(c => c.Tracks)
                .WithOptional(c => c.Album)
                .Map(m => m.MapKey("AlbumId"))
                .WillCascadeOnDelete(false);
          

        }
    }

}
