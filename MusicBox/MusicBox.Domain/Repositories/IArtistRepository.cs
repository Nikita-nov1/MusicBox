using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Domain.Repositories
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        List<InfArtist> GetInfArtists();
        Artist GetArtistWithImage(int id);
    }
}
