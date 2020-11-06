using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Playlist : BaseEntity
    {
        public List<Track> Tracks { get; set; }

        public PlaylistImage PlaylistImage { get; set; }
    }
}
