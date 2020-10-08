namespace MusicBox.Domain.Models.Entities
{

    public class MoodImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string ContentType { get; set; }
        public Mood Mood { get; set; }
    }
}
