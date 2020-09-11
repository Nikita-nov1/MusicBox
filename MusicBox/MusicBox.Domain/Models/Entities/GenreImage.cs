namespace MusicBox.Domain.Models.Entities
{

    public class GenreImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public Genre Genre { get; set; }
    }
}
