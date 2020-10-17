using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Repositories
{
    public interface IAlbumImageRepository : IBaseRepository<AlbumImage>
    {
        AlbumImage GetFirstOrDefault(int id);
    }
}
