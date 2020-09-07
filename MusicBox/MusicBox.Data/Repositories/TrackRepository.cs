using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Data.Repositories
{
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        public TrackRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
