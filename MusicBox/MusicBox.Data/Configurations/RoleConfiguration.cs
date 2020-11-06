using System.Data.Entity.ModelConfiguration;
using MusicBox.Domain.Models.Entities.Identity;

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
