using System;
using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Areas.Admin.Models.Albums
{
    public class DetailsAlbumsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public short Year { get; set; }

        public DateTime DateOfCreation { get; set; }

        public Artist Artist { get; set; }

        public List<Track> Tracks { get; set; }
    }
}