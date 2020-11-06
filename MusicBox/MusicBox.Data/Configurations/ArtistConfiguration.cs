using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Data.Configurations
{
    public class ArtistConfiguration : EntityTypeConfiguration<Artist>
    {
        public ArtistConfiguration()
        {
            ToTable("Artists");

            HasKey(c => c.Id);

            Property(p => p.Title).HasColumnName("Full_Name").HasMaxLength(30).IsRequired();
            HasIndex(c => c.Title).IsUnique(true);
        }
    }
}
