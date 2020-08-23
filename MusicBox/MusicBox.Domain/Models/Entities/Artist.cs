using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.Models.Entities
{
    public class Artist : BaseEntity
    {
       
        public ICollection<Track> Tracks { get; set; }

        public ICollection<Album> Albums { get; set; }

    }
}
