using System;

namespace MusicBox.Areas.Admin.Models.Tracks
{
    public class GetTracksViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string DurationSong { get; set; }
        public int CountOfCalls { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Mood { get; set; }
        public string Genre { get; set; }

    }
}