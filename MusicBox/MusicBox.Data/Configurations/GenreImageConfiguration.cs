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

            Property(c => c.ContentType).HasMaxLength(50);

            HasRequired(c => c.Genre)
                .WithRequiredDependent(c => c.GenreImage)
                .WillCascadeOnDelete(true);
        }
    }
}
