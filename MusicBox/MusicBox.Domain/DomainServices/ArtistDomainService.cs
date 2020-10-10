using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.AdditionalModels;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.Collections.Generic;
using System.IO;

namespace MusicBox.Domain.DomainServices
{
    public class ArtistDomainService : IArtistDomainService
    {
        private readonly IArtistRepository artistRepository;
        private readonly IUnitOfWork unitOfWork;
        private const string pathDefaultImage = "C:/Users/Asus/source/repos/Nikita-nov1/MusicBox/MusicBox/MusicBox/Files/Images/Artists/defaultArtistImage.jpg"; //todo  как можно заменит? (картинка находиться в P-слое)
        public ArtistDomainService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            this.artistRepository = artistRepository;
            this.unitOfWork = unitOfWork;

        }

        public void AddArtist(Artist artist)
        {
            if (artist.ArtistImage.Image == null && artist.ArtistImage.Image.Length < 1)
            {
                using (FileStream fileStream = new FileStream(pathDefaultImage, FileMode.Open))   //todo в одельный метод , и узнать, нормально ли using в using вставлять
                {
                    using (var binaryReader = new BinaryReader(fileStream))
                    {
                        artist.ArtistImage.ContentType = Path.GetExtension(fileStream.Name);
                        artist.ArtistImage.Image = binaryReader.ReadBytes((int)fileStream.Length);
                    }
                }
            }
            artistRepository.Add(artist);
            unitOfWork.SaveChanges();
        }


        public List<Artist> GetAtrists()
        {
            return artistRepository.GetAll();
        }

        public List<InfArtist> GetInfArtist()
        {
            return artistRepository.GetInfArtists();

        }







    }
}
