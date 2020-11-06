using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Data.Configurations
{
    public class TrackStatisticsConfiguration : EntityTypeConfiguration<TrackStatistics>
    {
        public TrackStatisticsConfiguration()
        {
            ToTable("TrackStatistics");

            HasKey(c => c.Id);

            Property(c => c.CountOfCalls).IsRequired();

            HasRequired(c => c.Track)
                .WithRequiredDependent(c => c.TrackStatistics)
                .WillCascadeOnDelete(true);
        }
    }
}
