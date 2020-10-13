using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Areas.Admin.Models.Artists
{
    public class DetailsArtistsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Album> Albums { get; set; }
    }
}