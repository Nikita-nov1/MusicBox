namespace MusicBox.Domain.Models.Entities
{
    public class ArtistImage
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string ContentType { get; set; }

        public Artist Artist { get; set; }
    }
}
