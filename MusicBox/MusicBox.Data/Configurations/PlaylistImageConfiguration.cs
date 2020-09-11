using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class PlaylistImageConfiguration : EntityTypeConfiguration<PlaylistImage>
    {
        public PlaylistImageConfiguration()
        {
            ToTable("PlaylistImages");

            HasKey(c => c.Id);

            Property(c => c.Image);

            HasRequired(c => c.Playlist)
                .WithRequiredPrincipal(c => c.PlaylistImage)
                .Map(m => m.MapKey("PlaylistImageId"))
                .WillCascadeOnDelete(true);
        }
    }
}
