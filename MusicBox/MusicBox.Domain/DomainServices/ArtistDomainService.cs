using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Interfaces;
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
        private readonly IGetPathServices getDefaultImage;

        public ArtistDomainService(IArtistRepository artistRepository, IUnitOfWork unitOfWork, IGetPathServices getDefaultImage)
        {
            this.artistRepository = artistRepository;
            this.unitOfWork = unitOfWork;
            this.getDefaultImage = getDefaultImage;

        }

        public Artist AddArtist(Artist artist)
        {
            if (artist.ArtistImage.Image is null)  
            {
                OpenFileAndConvertToBytes(artist);
            }
            var result = artistRepository.AddWithEntityReturn(artist);
            unitOfWork.SaveChanges();
            return result;

        }

        
        public Artist GetArtistWithImage(int id)
        {
            return artistRepository.GetArtistWithImage(id);

        }

        public Artist GetArtist(int id)
        {
            return artistRepository.Get(id);

        }

        public List<Album> GetAlbumsForArtist(int artistId)
        {
          return artistRepository.GetAlbumsForArtist(artistId);
        }

        public Artist GetArtistOrCreateNewIfHeNotExist(string artistTitle)
        {
            Artist atrist = artistRepository.Get(artistTitle); // проверка, есть ли такой артист , если нет, то возвращаем null  
            if (atrist == null)
            {
                atrist = AddArtist(new Artist { Title = artistTitle ,ArtistImage = new ArtistImage()});
            }
            return atrist;

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
            using (FileStream fileStream = new FileStream(getDefaultImage.GetPathDefaultArtistImage(), FileMode.Open))    // потом можно сделать дженерик в базовый класс(как в репозитории)
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    artist.ArtistImage.ContentType = Path.GetExtension(fileStream.Name);
                    artist.ArtistImage.Image = binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }






    }
}
