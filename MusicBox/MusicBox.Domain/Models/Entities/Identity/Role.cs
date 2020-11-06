using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicBox.Domain.Models.Entities.Identity
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
