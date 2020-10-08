namespace MusicBox.Domain.Models.Entities
{

    public class UserImage : User
    {
        public byte[] Image { get; set; }
        public string ContentType { get; set; }
    }
}
