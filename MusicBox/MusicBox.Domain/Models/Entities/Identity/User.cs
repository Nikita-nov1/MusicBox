using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicBox.Domain.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateBorn { get; set; }

        public List<Playlist> Playlists { get; set; }

        public UserImage UserImage { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            var yearClaim = Claims.FirstOrDefault(c => c.ClaimType == "Year");
            if (yearClaim != null)
            {
                userIdentity.AddClaim(new Claim(yearClaim.ClaimType, yearClaim.ClaimValue));
            }

            return userIdentity;
        }
    }
}
