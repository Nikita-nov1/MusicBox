using System;

namespace MusicBox.Areas.Admin.Models.Albums
{
    public class GetAlbumsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateOfCreation { get; set; }

        public short Year { get; set; }

        public int NumberOfTracks { get; set; }

        public string ArtistName { get; set; }
    }
}