using System;

namespace MusicBox.Domain.Models.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
