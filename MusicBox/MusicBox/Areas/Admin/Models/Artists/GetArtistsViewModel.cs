namespace MusicBox.Areas.Admin.Models.Artists
{
    public class GetArtistsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfAlbums { get; set; }
        public int NumberOfTracks { get; set; }

    }
}