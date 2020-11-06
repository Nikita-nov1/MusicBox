using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Models.AdditionalModels
{
    public class ArtistStatistics
    {
        public Artist Artist { get; set; }

        public int NumberOfAlbums { get; set; }

        public int NumberOfTracks { get; set; }
    }
}
