using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IMoodDomainService : IBaseDomainService
    {
        List<Mood> GetMoods();

        Mood GetMood(int id);

        bool IsExistsMood(int id);
    }
}
