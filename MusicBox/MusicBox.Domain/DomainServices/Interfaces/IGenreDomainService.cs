using System.Collections.Generic;
using MusicBox.Domain.Models.Entities;

namespace MusicBox.Domain.DomainServices.Interfaces
{
    public interface IGenreDomainService : IBaseDomainService
    {
        List<Genre> GetGenres();

        Genre GetGenre(int id);

        bool IsExistsGenre(int id);
    }
}
