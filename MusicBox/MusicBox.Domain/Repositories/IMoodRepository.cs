using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.Repositories
{
    public interface IMoodRepository : IBaseRepository<Mood>
    {
        bool IsExistsMood(int id);
    }
}
