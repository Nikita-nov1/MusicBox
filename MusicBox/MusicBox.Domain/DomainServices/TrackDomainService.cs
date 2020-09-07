using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;

namespace MusicBox.Domain.DomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;

        public TrackDomainService(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;
        }

    }
}
