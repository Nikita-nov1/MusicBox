using MusicBox.Domain.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class AlbumImageConfiguration : EntityTypeConfiguration<AlbumImage>
    {
        public AlbumImageConfiguration()
        {
            ToTable("AlbumImages");

            HasKey(c => c.Id);

            Property(c => c.Image);

            Property(c => c.ContentType).HasMaxLength(50);


            HasRequired<Album>(c => c.Album)
                .WithRequiredDependent(c => c.AlbumImage)
                .WillCascadeOnDelete(true);
        }
    }
}
