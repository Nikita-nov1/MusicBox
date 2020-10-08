namespace MusicBox.Domain.Models.Entities
{
    public class AlbumImage  
    {
        public int Id { get; set; } //
        public byte[] Image { get; set; } //
        public string ContentType { get; set; }

        public Album Album { get; set; } //
    }
}
