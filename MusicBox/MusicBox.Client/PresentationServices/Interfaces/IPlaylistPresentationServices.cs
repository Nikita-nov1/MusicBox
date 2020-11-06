namespace MusicBox.PresentationServices.Interfaces
{
    public interface IPlaylistPresentationServices : IBasePresentationService
    {
        void AddTrackToFavoritePlaylist(int trackId, string userId);
    }
}
