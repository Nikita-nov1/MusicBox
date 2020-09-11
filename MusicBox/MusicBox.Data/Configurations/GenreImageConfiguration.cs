using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class GenreImageConfiguration : EntityTypeConfiguration<GenreImage>
    {
        public GenreImageConfiguration()
        {
            ToTable("GenreImages");

            HasKey(c => c.Id);

            Property(c => c.Image);

            HasRequired(c => c.Genre)
                .WithRequiredPrincipal(c => c.GenreImage)
                .Map(m => m.MapKey("GenreImageId"))
                .WillCascadeOnDelete(true);
        }
    }
}
