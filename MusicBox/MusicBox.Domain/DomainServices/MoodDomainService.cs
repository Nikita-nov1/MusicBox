using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;

namespace MusicBox.Domain.DomainServices
{
    public class MoodDomainService : IMoodDomainService
    {
        private readonly IMoodRepository moodRepository;

        public MoodDomainService(IMoodRepository moodRepository)
        {
            this.moodRepository = moodRepository;
        }

    }
}
