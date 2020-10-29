using MusicBox.Domain.Models.Entities.Identity;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(c => c.Id);

            Property(c => c.FirstName).IsRequired().HasMaxLength(25);
            Property(c => c.LastName).IsRequired().HasMaxLength(25);
            Property(c => c.DateBorn).HasColumnType("date");

        }
    }
}
