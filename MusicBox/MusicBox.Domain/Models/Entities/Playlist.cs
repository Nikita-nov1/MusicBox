using System.Collections.Generic;
using MusicBox.Domain.Models.Entities.Identity;

namespace MusicBox.Domain.Models.Entities
{
    public class Playlist : BaseEntity
    {
        public List<Track> Tracks { get; set; }

        public PlaylistImage PlaylistImage { get; set; }

        public List<User> User { get; set; }
    }
}
