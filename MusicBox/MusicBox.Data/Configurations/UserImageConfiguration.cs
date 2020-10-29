using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Models.Entities.Identity;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    class UserImageConfiguration : EntityTypeConfiguration<UserImage>
    {
        public UserImageConfiguration()
        {
            ToTable("UserImages");

            HasKey(c => c.Id);

            Property(c => c.Image);

            Property(c => c.ContentType).HasMaxLength(50);


            HasRequired<User>(c => c.User)
                .WithRequiredDependent(c => c.UserImage)
                .WillCascadeOnDelete(true);
        }
    }
}
