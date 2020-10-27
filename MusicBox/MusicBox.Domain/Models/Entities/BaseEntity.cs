namespace MusicBox.Domain.Models.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
