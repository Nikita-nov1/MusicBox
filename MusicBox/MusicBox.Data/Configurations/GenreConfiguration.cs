using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Data.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            ToTable("Genres");

            HasKey(c => c.Id);

            Property(p => p.Title).HasMaxLength(30);

            HasIndex(c => c.Title).IsUnique(true);

            HasMany(c => c.Tracks)
                .WithOptional(c => c.Genre)
                .Map(m => m.MapKey("GenreId"))
                .WillCascadeOnDelete(false);
        }
    }
}
