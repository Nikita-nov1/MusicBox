using System;

namespace MusicBox.Domain.Models.Entities
{
    public class Track : BaseEntity
    {
        public DateTime DateOfCreation { get; set; } //
        
        public string DurationSong { get; set; }  //
        public TrackStatistics TrackStatistics { get; set; } //
        public TrackFile TrackFile { get; set; }  //

        public Artist Artist { get; set; } //

        public Album Album { get; set; } //


        //public Mood Mood { get; set; }

        //public Genre Genre { get; set; }

        //public Playlist Playlist { get; set; }
    }
}
