using MusicBox.Domain.Models.Entities.Identity;
using System.Data.Entity.ModelConfiguration;

namespace MusicBox.Data.Configurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(c => c.Description).IsOptional().HasMaxLength(126);

        }
    }
}
