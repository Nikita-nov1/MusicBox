using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Repositories
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        bool IsExistsGenre(int id);
    }
}
