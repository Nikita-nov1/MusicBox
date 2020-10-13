using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Models.AdditionalModels
{
    public class ArtistStatistics  // todoM вмозможно лучеше добавить сюда  2 поля:  public ArtistImage ArtistImage { get; set; } и  public string Title { get; set; } , чтобы был один запрос был
    {
        public Artist Artist { get; set; }
        public int NumberOfAlbums { get; set; }
        public int NumberOfTracks { get; set; }
    }
}
