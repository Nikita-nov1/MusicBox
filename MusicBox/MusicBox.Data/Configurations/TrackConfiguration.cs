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

            Property(c => c.Title).IsRequired().HasMaxLength(30);

            Property(c => c.DateOfCreation).IsOptional();

            Property(c => c.DurationSong).IsOptional().HasMaxLength(10);

            HasRequired<Artist>(c => c.Artist)
                .WithMany(c => c.Tracks)
                .Map(m => m.MapKey("ArtistId"))
                .WillCascadeOnDelete(false);

        }
    }
}
