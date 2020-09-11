using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class PlaylistConfiguration : EntityTypeConfiguration<Playlist>
    {
        public PlaylistConfiguration()
        {
            ToTable("Playlist");

            HasKey(c => c.Id);

            Property(c => c.Title).HasMaxLength(25).IsRequired();

            HasMany(c => c.Tracks)
                .WithOptional(c => c.Playlist)
                .Map(m => m.MapKey("PlaylistId"))
                .WillCascadeOnDelete(false);
        }
    }
}
