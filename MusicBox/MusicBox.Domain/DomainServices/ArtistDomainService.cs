using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace MusicBox.Domain.DomainServices
{
    public class ArtistDomainService : IArtistDomainService
    {
        private readonly IArtistRepository artistRepository;
        private readonly IUnitOfWork unitOfWork;
        private string pathDefaultImage = HostingEnvironment.MapPath("~/Files/Images/Artists/defaultArtistImage.jpg"); //todoM  как можно заменит? (картинка находиться в P-слое)

        public ArtistDomainService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            this.artistRepository = artistRepository;
            this.unitOfWork = unitOfWork;

        }

        public void AddArtist(Artist artist)
        {
            if (artist.ArtistImage.Image is null)  // нет проверки на artist.ArtistImage.Image.Length < 1  -- проверить потом, чему равняется artist.ArtistImage.Image.Length п
            {
                OpenFileAndConvertToBytes(artist);
            }
            artistRepository.Add(artist);
            unitOfWork.SaveChanges();

        }

        public Artist GetArtistWithImage(int id)
        {
            return artistRepository.GetArtistWithImage(id);

        }

        public Artist GetArtist(int id)
        {
            return artistRepository.Get(id);

        }

        public List<Artist> GetAtrists()
        {
            return artistRepository.GetAll();

        }

        public Artist GetAtristWithTracksAndAlbumsWithAllAttachments(int id)
        {
            return artistRepository.GetAtristWithTracksAndAlbumsWithAllAttachments(id);
        }

        public void DeleteArtist(int id)
        {
            artistRepository.DeleteById(id);
            unitOfWork.SaveChanges();
        }

        public List<ArtistStatistics> GetArtistsStatistics()
        {
            return artistRepository.GetArtistsStatistics();

        }

        public void EditArtist()
        {
            unitOfWork.SaveChanges();

        }

        private void OpenFileAndConvertToBytes(Artist artist)
        {
            using (FileStream fileStream = new FileStream(pathDefaultImage, FileMode.Open))    // потом можно сделать дженерик в базовый класс(как в репозитории)
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    artist.ArtistImage.ContentType = Path.GetExtension(fileStream.Name);
                    artist.ArtistImage.Image = binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        public bool IsUniqueNewTitle(string title)
        {
            return artistRepository.IsUniqueNewTitle(title);
        }
    }
}
