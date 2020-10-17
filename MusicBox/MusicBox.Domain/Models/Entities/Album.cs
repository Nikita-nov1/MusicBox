using System;
using System.Collections.Generic;

namespace MusicBox.Domain.Models.Entities
{
    public class Album : BaseEntity
    {
        public DateTime DateOfCreation { get; set; }   //
        public short Year { get; set; }  //
        public List<Track> Tracks { get; set; }  //
        public Artist Artist { get; set; }  //
        public AlbumImage AlbumImage { get; set; } //


    }
}
