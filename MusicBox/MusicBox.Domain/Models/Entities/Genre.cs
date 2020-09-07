using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Genre
    {
        public ICollection<Track> Tracks { get; set; }

    }
}
