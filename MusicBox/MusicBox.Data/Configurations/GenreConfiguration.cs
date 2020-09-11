using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            ToTable("Genres");

            HasKey(c => c.Id);

            Property(c => c.Title).HasMaxLength(25).IsRequired();

            HasMany(c => c.Tracks)
                .WithOptional(c => c.Genre)
                .Map(m => m.MapKey("GenreId"))
                .WillCascadeOnDelete(false);
        }
    }
}
