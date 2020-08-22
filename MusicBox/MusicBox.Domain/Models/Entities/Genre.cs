using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.Models.Entities
{
    public class Genre
    {
        public ICollection<Track> Tracks { get; set; }

    }
}
