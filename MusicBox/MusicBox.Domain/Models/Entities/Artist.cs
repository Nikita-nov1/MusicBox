using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Artist : BaseEntity
    {
        public List<Track> Tracks { get; set; }

        public List<Album> Albums { get; set; }

    }
}
