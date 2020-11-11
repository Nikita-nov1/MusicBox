using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Data.Configurations
{
    public class MoodConfiguration : EntityTypeConfiguration<Mood>
    {
        public MoodConfiguration()
        {
            ToTable("Moods");

            HasKey(c => c.Id);

            Property(p => p.Title).HasMaxLength(30);

            HasIndex(c => c.Title).IsUnique(true);

            HasMany(c => c.Tracks)
                .WithOptional(c => c.Mood)
                .Map(m => m.MapKey("MoodId"))
                .WillCascadeOnDelete(false);
        }
    }
}
