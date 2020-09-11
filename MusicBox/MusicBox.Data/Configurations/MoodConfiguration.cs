using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class MoodConfiguration : EntityTypeConfiguration<Mood>
    {
        public MoodConfiguration()
        {
            ToTable("Mood");

            HasKey(c => c.Id);

            Property(c => c.Title).HasMaxLength(25).IsRequired();

            HasMany(c => c.Tracks)
                .WithOptional(c => c.Mood)
                .Map(m => m.MapKey("MoodId"))
                .WillCascadeOnDelete(false);
        }
    }
}
