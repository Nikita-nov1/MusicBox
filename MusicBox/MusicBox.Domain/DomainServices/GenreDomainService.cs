using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;

namespace MusicBox.Domain.DomainServices
{
    public class GenreDomainService : IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;

        public GenreDomainService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

    }
}
