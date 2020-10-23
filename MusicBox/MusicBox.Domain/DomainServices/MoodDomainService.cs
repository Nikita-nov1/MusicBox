using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices
{
    public class MoodDomainService : IMoodDomainService
    {
        private readonly IMoodRepository moodRepository;

        public MoodDomainService(IMoodRepository moodRepository)
        {
            this.moodRepository = moodRepository;
        }

        public List<Mood> GetMoods()
        {
            return moodRepository.GetAll();
        }

        public Mood GetMood(int id)
        {
            return moodRepository.Get(id);
        }

        public bool IsExistsMood(int id)
        {
            return moodRepository.IsExistsMood(id);
        }
    }
}
