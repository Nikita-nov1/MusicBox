using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Data.Configurations
{
    public class UserImageConfiguration : EntityTypeConfiguration<UserImage>
    {
        public UserImageConfiguration()
        {
            ToTable("UserImages");

            HasKey(c => c.Id);

            Property(c => c.Image);

            Property(c => c.ContentType).HasMaxLength(50);

            HasRequired(c => c.User)
                .WithRequiredDependent(c => c.UserImage)
                .WillCascadeOnDelete(true);
        }
    }
}
