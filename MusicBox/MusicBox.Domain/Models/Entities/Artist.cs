using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Artist : BaseEntity
    {

        public ICollection<Track> Tracks { get; set; }

        public ICollection<Album> Albums { get; set; }

    }
}
