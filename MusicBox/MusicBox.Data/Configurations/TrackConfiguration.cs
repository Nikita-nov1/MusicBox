using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

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

            HasRequired(c => c.Artist)
                .WithMany(c => c.Tracks)
                .Map(m => m.MapKey("ArtistId"))
                .WillCascadeOnDelete(true);
        }
    }
}
