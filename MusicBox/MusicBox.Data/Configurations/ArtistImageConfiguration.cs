using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class ArtistImageConfiguration : EntityTypeConfiguration<ArtistImage>
    {
        public ArtistImageConfiguration()
        {
            ToTable("ArtistImages");

            HasKey(k => k.Id);

            Property(c => c.Image);

            Property(c => c.ContentType).HasMaxLength(50);

            HasRequired<Artist>(c => c.Artist)
                .WithRequiredDependent(c => c.ArtistImage)
                .WillCascadeOnDelete(true);


        }
    }
}
