using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IMoodDomainService : IBaseDomainService
    {
        List<Mood> GetMoods();
        Mood GetMood(int id);
    }
}
