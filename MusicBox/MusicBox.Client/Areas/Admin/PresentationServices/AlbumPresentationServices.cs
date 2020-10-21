using AutoMapper;
using MusicBox.Areas.Admin.Models.Albums;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using System.Collections.Generic;

namespace MusicBox.Areas.Admin.PresentationServices
{
    public class AlbumPresentationServices : BaseAdminPresentationService, IAlbumPresentationServices
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly IArtistDomainService artistDomainService;
        private readonly IAlbumImageDomainService albumImageDomainService;

        public AlbumPresentationServices(IAlbumDomainService albumDomainService, IArtistDomainService artistDomainService, IAlbumImageDomainService albumImageDomainService)
        {
            this.albumDomainService = albumDomainService;
            this.artistDomainService = artistDomainService;
            this.albumImageDomainService = albumImageDomainService;
        }

        public List<GetAlbumsViewModel> GetAlbums()
        {
            List<Album> albums  = albumDomainService.GetAlbums();
            return Mapper.Map<List<GetAlbumsViewModel>>(albums);   

        }

        public EditAlbumsViewModel GetEditAlbumVm(int id)
        {
            Album album = albumDomainService.GetAlbumWhitArtist(id);
            return Mapper.Map<EditAlbumsViewModel>(album);

        }

        public void EditAlbum(EditAlbumsViewModel albumsVm)
        {
            Album album = albumDomainService.GetAlbumWithImageAndArtist(albumsVm.Id);
            album = Mapper.Map<EditAlbumsViewModel, Album>(albumsVm, album);
            album.Artist = artistDomainService.GetArtistOrCreateNewIfHeNotExist(albumsVm.Artist);

            if (albumsVm.Image != null)
            {
                album.AlbumImage.Image = ConvertToBytes(albumsVm.Image);
            }

            albumDomainService.EditAlbum();

        }

        public DeleteAlbumsViewModel GetDeleteAlbumVm(int id)
        {
            Album album = albumDomainService.GetAlbumWhitArtist(id);
            return Mapper.Map<DeleteAlbumsViewModel>(album);

        }

        public DetailsAlbumsViewModel GetDetailsAlbumVm(int id)
        {
            return Mapper.Map<DetailsAlbumsViewModel>(albumDomainService.GetAlbumAndHisTracksWithAllAttachments(id));
        }

        public void DeleteAlbum(int id)
        {
            albumDomainService.DeleteAlbum(id);

        }

        public AlbumImage GetImage(int albumId)
        {
            AlbumImage albumImage = albumImageDomainService.GetAlbumImage(albumId);
            if (albumImage == null)
            {
                return new AlbumImage();
            }
            return albumImage;

        }
        public void AddAlbum(CreateAlbumsViewModel albumsVm)
        {
            Album album = Mapper.Map<Album>(albumsVm);
            album.AlbumImage.Image = ConvertToBytes(albumsVm.Image);
            album.Artist = artistDomainService.GetArtistOrCreateNewIfHeNotExist(albumsVm.Artist);

            albumDomainService.AddAlbum(album);
        }

        public (List<GetAlbumsForArtistVm>, bool isExistsArtist) GetAlbumsForArtist(string artistTitle)
        {
            if (!artistDomainService.IsExistsArtist(artistTitle))
            {
                return (null, false);
            }

            return (Mapper.Map<List<GetAlbumsForArtistVm>>(albumDomainService.GetAlbumsForArtist(artistTitle)), true);
            
        }



    }
}