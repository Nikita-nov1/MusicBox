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

        public Artist GetArtist(string artistTitle)
        {
            return artistRepository.GetArtist(artistTitle);
        }

        public Artist GetArtistWithImage(int id)
        {
            return artistRepository.GetArtistWithImage(id);
        }

        public Artist GetArtist(int id)
        {
            return artistRepository.Get(id);
        }

        public List<Album> GetAlbumsForArtist(string artistTitle)
        {
            return artistRepository.GetAlbumsForArtist(artistTitle);
        }

        public Artist GetArtistOrCreateNewIfHeNotExist(string artistTitle)
        {
            Artist atrist = artistRepository.GetFirstOrDefault(artistTitle);
            if (atrist == null)
            {
                atrist = AddArtist(new Artist { Title = artistTitle, ArtistImage = new ArtistImage() });
            }
            return atrist;
        }

        public List<Artist> GetAtrists() //todo исправить
        {
            return artistRepository.GetAll();
        }

        public Artist GetAtristWithTracksAndAlbumsWithAllAttachments(int id) //todo исправить
        {
            return artistRepository.GetAtristWithTracksAndAlbumsWithAllAttachments(id);
        }

        public void DeleteArtist(int id)
        {
            RemoveAlbumLinkForAllTracks(id);

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

        public bool IsUniqueNewTitle(string title)
        {
            return artistRepository.IsUniqueNewTitle(title);
        }

        public bool IsUniqueTitle(int id, string title)
        {
            return artistRepository.IsUniqueTitle(id, title);
        }

        private void OpenFileAndConvertToBytes(Artist artist)
        {
            using (FileStream fileStream = new FileStream(getDefaultImage.GetPathDefaultArtistImage(), FileMode.Open))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    artist.ArtistImage.ContentType = Path.GetExtension(fileStream.Name);
                    artist.ArtistImage.Image = binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        private void RemoveAlbumLinkForAllTracks(int artistId)
        {
            Artist artist = artistRepository.GetArtistWhitTracks(artistId);

            foreach (var track in artist.Tracks)
            {
                track.Album = null;
            }
            unitOfWork.SaveChanges();
        }

        public bool IsExistsArtist(string artistTitle)
        {
            return artistRepository.IsExistsArtist(artistTitle);
        }

        public bool IsUniqueNewTitleArtistAlbum(string artistTitle, string albumTitle)
        {
            return artistRepository.IsUniqueNewTitleArtistAlbum(artistTitle, albumTitle);
        }
    }
}
