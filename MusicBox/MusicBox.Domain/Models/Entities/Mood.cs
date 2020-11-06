using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Mood : BaseEntity
    {
        public List<Track> Tracks { get; set; }

        public MoodImage MoodImage { get; set; }
    }
}
