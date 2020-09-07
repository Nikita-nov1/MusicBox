using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Mood : BaseEntity
    {
        public ICollection<Track> Tracks { get; set; }
    }
}
