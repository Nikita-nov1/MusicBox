namespace MusicBox.Domain.Models.Entities
{

    public class PlaylistImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public Playlist Playlist { get; set; }
    }
}
