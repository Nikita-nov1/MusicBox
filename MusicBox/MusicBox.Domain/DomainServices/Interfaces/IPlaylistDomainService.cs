using System;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IPlaylistDomainService : IBaseDomainService
    {
       void AddTrackToFavoritePlaylist(int trackId, string userId);
    }
}
