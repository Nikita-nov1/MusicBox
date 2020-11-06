﻿using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Data.Configurations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            ToTable("Albums");

            HasKey(c => c.Id);

            Property(c => c.DateOfCreation).IsRequired();

            Property(c => c.Title).HasMaxLength(30).IsRequired();
            HasIndex(c => c.Title).IsUnique(false);

            Property(c => c.Year).IsOptional();

            HasRequired(a => a.Artist)
                .WithMany(a => a.Albums)
                .Map(m => m.MapKey("ArtistId"))
                .WillCascadeOnDelete(true);

            HasMany(c => c.Tracks)
                .WithOptional(c => c.Album)
                .Map(m => m.MapKey("AlbumId"))
                .WillCascadeOnDelete(false);
        }
    }
}
