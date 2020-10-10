using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Repositories
{
    public interface IArtistImageRepository : IBaseRepository<ArtistImage>
    {
        ArtistImage GetFirstOrDefault(object id);
    }
}
