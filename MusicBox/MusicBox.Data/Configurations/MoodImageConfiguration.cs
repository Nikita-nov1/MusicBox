﻿using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class MoodImageConfiguration : EntityTypeConfiguration<MoodImage>
    {
        public MoodImageConfiguration()
        {
            ToTable("MoodImages");

            HasKey(c => c.Id);

            Property(c => c.Image);

            Property(c => c.ContentType).HasMaxLength(50);

            HasRequired(c => c.Mood)
                .WithRequiredDependent(c => c.MoodImage)
                .WillCascadeOnDelete(true);
        }
    }
}
