using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class TrackFileConfiguration : EntityTypeConfiguration<TrackFile>
    {
        public TrackFileConfiguration()
        {
            ToTable("TrackFiles");

            HasKey(c => c.Id);

            Property(c => c.TrackLocation).IsRequired().HasMaxLength(200);

            Property(c => c.ContentType).IsRequired().HasMaxLength(50);

            HasRequired<Track>(c => c.Track)
                .WithRequiredDependent(c => c.TrackFile)
                .WillCascadeOnDelete(true);

        }
    }
}
