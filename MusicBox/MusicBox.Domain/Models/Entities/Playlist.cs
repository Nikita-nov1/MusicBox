using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Playlist
    {
        public ICollection<Track> Tracks { get; set; }

    }
}
