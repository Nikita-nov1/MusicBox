namespace MusicBox.Domain.Models.Entities
{
    public class TrackFile
    {
        public int Id { get; set; }

        public string ContentType { get; set; }

        public string TrackLocation { get; set; }

        public Track Track { get; set; }
    }
}
