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

            Property(c => c.ContentType).HasMaxLength(50);

            HasRequired(c => c.Playlist)
                .WithRequiredDependent(c => c.PlaylistImage)
                .WillCascadeOnDelete(true);
        }
    }
}
