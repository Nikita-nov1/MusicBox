using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            ToTable("Albums");

            HasKey(c => c.Id);

            Property(c => c.DateOfCreation).IsRequired();
            //HasIndex(c => c.Title).IsUnique(true);
            //Property(c => c.Title).IsRequired().HasMaxLength(25); 

            Property(c => c.Title).HasMaxLength(30);
            HasIndex(c => c.Title).IsUnique(true);
            


            //Property(p => p.Title)
            //    .HasColumnName("Full_Name")
            //    .HasMaxLength(30)
            //    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));

            Property(c => c.Year).IsOptional();

            HasRequired<Artist>(a => a.Artist)
                .WithMany(a => a.Albums)
                .Map(m => m.MapKey("ArtistId"))
                .WillCascadeOnDelete(false);

            HasMany<Track>(c => c.Tracks)
                .WithOptional(c => c.Album)
                .Map(m => m.MapKey("AlbumId"))
                .WillCascadeOnDelete(false);
          

        }
    }

}
