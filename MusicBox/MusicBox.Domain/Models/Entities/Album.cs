using System;
using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Album : BaseEntity
    {
        public ICollection<Track> Tracks { get; set; }


        public Guid ArtistId { get; set; }

        public Artist Artist { get; set; }



        public DateTime Year { get; set; }



    }
}
