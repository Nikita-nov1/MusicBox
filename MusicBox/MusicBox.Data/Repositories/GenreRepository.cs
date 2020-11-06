using System.Linq;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public bool IsExistsGenre(int id)
        {
            return GetQueryableItems().Any(x => x.Id.Equals(id));
        }
    }
}
