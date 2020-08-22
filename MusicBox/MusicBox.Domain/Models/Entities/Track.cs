using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.Models.Entities
{
    public class Track : BaseEntity
    {


        public Guid ArtistId { get; set; }
        public  Artist Artist { get; set; }

        public Guid AlbumId { get; set; }
        public Album Album { get; set; }

        public Guid MoodId { get; set; }
        public Mood Mood { get; set; }

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
