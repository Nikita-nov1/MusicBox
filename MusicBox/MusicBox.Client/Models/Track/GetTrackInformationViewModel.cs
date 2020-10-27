using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.Models.Track
{
    public class GetTrackInformationViewModel
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string TrackLocation { get; set; }
    }
}