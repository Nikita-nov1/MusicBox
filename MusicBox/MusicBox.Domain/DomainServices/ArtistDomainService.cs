using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Models.Entities;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using System.IO;

namespace MusicBox.Domain.DomainServices
{
    public class ArtistDomainService : IArtistDomainService
    {
        private readonly IArtistRepository artistRepository;
        private readonly IUnitOfWork unitOfWork;
        private const string pathDefaultImage = @"C:\Users\Asus\source\repos\Nikita-nov1\MusicBox\MusicBox\MusicBox\Files\Images\Artists\defaultArtistImage.jpg";

        public ArtistDomainService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
        {
            this.artistRepository = artistRepository;
            this.unitOfWork = unitOfWork;

        }

        public void AddArtist(Artist artist)
        {
            if(artist.ArtistImage.Image == null || artist.ArtistImage.Image.Length < 1)
            {
                //FileInfo file = new FileInfo(pathDefaultImage);
                //file.OpenRead
                //    FileStream(pathDefaultImage)
                //     byte[] imageBytes = null;

                //using (var binaryReader = new BinaryReader(FileStream(pathDefaultImage))
                //{
                //    imageBytes = binaryReader.ReadBytes(image.ContentLength);
                //}
                //return imageBytes;
                //// artist.ArtistImage.Image = 
            } 

            artistRepository.Add(artist);
            unitOfWork.SaveChanges();
        }
    }
}
