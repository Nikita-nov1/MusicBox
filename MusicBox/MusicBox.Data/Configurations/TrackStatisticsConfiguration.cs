﻿using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    class TrackStatisticsConfiguration : EntityTypeConfiguration<TrackStatistics>
    {
        public TrackStatisticsConfiguration()
        {
            ToTable("TrackStatistics");

            HasKey(c => c.Id);

            Property(c => c.CountOfCalls);

            HasRequired<Track>(c => c.Track)
                .WithRequiredPrincipal(c => c.TrackStatistics)
                .Map(m => m.MapKey("TrackStatisticsId"))
                .WillCascadeOnDelete(true);

        }
    }
}