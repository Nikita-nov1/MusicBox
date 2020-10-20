using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;

namespace MusicBox.Domain.DomainServices
{
    public class AlbumDomainService : IAlbumDomainService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IGetPathServices getDefaultImage;
        private readonly IArtistDomainService artistDomainService;
        private readonly IUnitOfWork unitOfWork;

        public AlbumDomainService(IAlbumRepository albumRepository, IGetPathServices getDefaultImage, IUnitOfWork unitOfWork, IArtistDomainService artistDomainService)
        {
            this.albumRepository = albumRepository;
            this.getDefaultImage = getDefaultImage;
            this.artistDomainService = artistDomainService;
            this.unitOfWork = unitOfWork;
        }

        public List<Album> GetAlbums()
        {
            return albumRepository.GetAllWithArtistAndTracks();
        }

        public Album GetAlbum(int id)
        {
            return albumRepository.Get(id);
        }

        public List<Album> GetAlbumsForArtist(string artistTitle)
        {
            return artistDomainService.GetAlbumsForArtist(artistTitle);
        }

        public Album GetAlbumWhitArtist(int id)
        {
            return albumRepository.GetAlbumWhitArtist(id);
        }

        public Album GetAlbumWithImageAndArtist(int id)
        {
            return albumRepository.GetAlbumWithImageAndArtist(id);
        }

        public void AddAlbum(Album album)
        {
            if (album.AlbumImage.Image is null)
            {
                OpenFileAndConvertToBytes(album);
            }
            album.DateOfCreation = DateTime.Now;
            albumRepository.Add(album);
            unitOfWork.SaveChanges();
        }

        public void EditAlbum()
        {
            unitOfWork.SaveChanges();
        }

        public void DeleteAlbum(int id)
        {
            RemoveAlbumLinkForAllTracks(id);
            albumRepository.DeleteById(id);
            unitOfWork.SaveChanges();
        }

        private void RemoveAlbumLinkForAllTracks(int albumId)
        {
            Album album = albumRepository.GetAlbumWhitTracks(albumId);

            foreach (var track in album.Tracks)
            {
                track.Album = null;
            }
            unitOfWork.SaveChanges();
        }

        private void OpenFileAndConvertToBytes(Album album)
        {
            using (FileStream fileStream = new FileStream(getDefaultImage.GetPathDefaultAlbumImage(), FileMode.Open))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    album.AlbumImage.ContentType = Path.GetExtension(fileStream.Name);
                    album.AlbumImage.Image = binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
        }

        public bool IsIdExists(int id)
        {
            return albumRepository.IsIdExists(id);
        }
    }
}
