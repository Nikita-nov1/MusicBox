using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IGenreDomainService : IBaseDomainService
    {
        List<Genre> GetGenres();
        Genre GetGenre(int id);
    }
}
