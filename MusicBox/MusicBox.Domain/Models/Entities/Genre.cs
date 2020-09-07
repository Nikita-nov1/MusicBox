using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Genre : BaseEntity
    {
        public List<Track> Tracks { get; set; }

    }
}
