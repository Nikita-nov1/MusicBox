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

            HasRequired<Artist>(c => c.Artist)
                .WithRequiredPrincipal(c => c.ArtistImage)
                .Map(m => m.MapKey("ArtistImageId"))
                .WillCascadeOnDelete(true);


        }
    }
}
