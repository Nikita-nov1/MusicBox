using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;

namespace MusicBox.Domain.DomainServices
{
    public class TrackFileDomainService : ITrackFileDomainService
    {
        private readonly ITrackFileRepository trackFileRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrackFileDomainService(ITrackFileRepository trackFileRepository, IUnitOfWork unitOfWork)
        {
            this.trackFileRepository = trackFileRepository;
            this.unitOfWork = unitOfWork;
        }
    }
}
