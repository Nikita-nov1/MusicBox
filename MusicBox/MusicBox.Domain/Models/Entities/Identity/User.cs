using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateBorn { get; set; }

        public List<Playlist> Playlists { get; set; }
        public UserImage UserImage { get; set; }
    }
}
