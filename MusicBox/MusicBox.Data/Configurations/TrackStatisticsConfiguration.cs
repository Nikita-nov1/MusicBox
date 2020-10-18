using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    class TrackStatisticsConfiguration : EntityTypeConfiguration<TrackStatistics>
    {
        public TrackStatisticsConfiguration()
        {
            ToTable("TrackStatistics");

            HasKey(c => c.Id);

            Property(c => c.CountOfCalls).IsRequired();

            HasRequired<Track>(c => c.Track)
                .WithRequiredDependent(c => c.TrackStatistics)
                .WillCascadeOnDelete(true);

        }
    }
}
