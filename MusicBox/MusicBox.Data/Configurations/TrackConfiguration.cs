using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class TrackConfiguration : EntityTypeConfiguration<Track>
    {
        public TrackConfiguration()
        {
            ToTable("Tracks");

            HasKey(c => c.Id);

            Property(c => c.Title);

            Property(c => c.DateOfCreation);

            Property(c => c.DurationSong);

            HasRequired<Artist>(c => c.Artist)
                .WithMany(c => c.Tracks)
                .Map(m => m.MapKey("ArtistId"))
                .WillCascadeOnDelete(false);

        }
    }
}
