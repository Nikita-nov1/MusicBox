using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class PlaylistConfiguration : EntityTypeConfiguration<Playlist>
    {
        public PlaylistConfiguration()
        {
            ToTable("Playlists");

            HasKey(c => c.Id);

            Property(c => c.Title).HasMaxLength(30).IsRequired();

            HasMany(c => c.Tracks)
                .WithMany(c => c.Playlists)
                .Map(c => c.
                    ToTable("TrackPlaylists")
                    .MapLeftKey("TrackId")
                    .MapRightKey("PlaylistId"));

        }
    }
}
