using MusicBox.Domain.Models.Entities.Identity;

namespace MusicBox.Domain.Models.Entities
{
    public class UserImage
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string ContentType { get; set; }

        public User User { get; set; }
    }
}
