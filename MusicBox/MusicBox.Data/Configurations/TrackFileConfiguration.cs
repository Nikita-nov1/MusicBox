using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class TrackFileConfiguration : EntityTypeConfiguration<TrackFile>
    {
        public TrackFileConfiguration()
        {
            ToTable("TrackFile");

            HasKey(c => c.Id);

            Property(c => c.TrackLocation).IsRequired().HasMaxLength(110);

            HasRequired<Track>(c => c.Track)
                .WithRequiredPrincipal(c => c.TrackFile)
                .Map(m => m.MapKey("TrackFileId"))
                .WillCascadeOnDelete(true);

        }
    }
}
