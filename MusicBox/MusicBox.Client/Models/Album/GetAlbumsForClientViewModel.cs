using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.Models.Album
{
    public class GetAlbumsForClientViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
    }
}