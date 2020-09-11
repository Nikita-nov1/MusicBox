using MusicBox.Data.Context;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Data.InitializersDb
{
    public class MusicBoxDbContextDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<MusicBoxDbContext>
    {
        protected void Seed1(MusicBoxDbContext db)
        {

            List<ArtistImage> artistImages = new List<ArtistImage>()
            {
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},

            };

            List<AlbumImage>  albumImages = new List<AlbumImage>()
            {
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},

            };

            List<Artist> artists = new List<Artist>()
            {
                new Artist(){Title = "Макс Корж",ArtistImage = artistImages[0]},
                new Artist(){Title = "Виктор Цой",ArtistImage = artistImages[1]},
                new Artist(){Title = "Сергей Михалок",ArtistImage = artistImages[2]},
                new Artist(){Title = "Григорий Лепс",ArtistImage = artistImages[3]},
                new Artist(){Title = "Неизвестный исполнитель",ArtistImage = artistImages[4]}

            };

            List<Album> albums = new List<Album>()
            {
                new Album(){AlbumImage =albumImages[0],Year = 1997,Title = "Альбом 1",Artist = artists[0]  }
            };

            //if (!db.Set<Album>().Any())
            //{
            //    db.Set<Album>().AddRange(new[]
            //    {
            //        new Album(){AlbumImage = albumImages[0], Artist = }

            //    });
            //}
            
        }

        protected override void Seed(MusicBoxDbContext db)
        {

            List<ArtistImage> artistImages = new List<ArtistImage>()
            {
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},
                new ArtistImage { Image = null},

            };

            List<AlbumImage> albumImages = new List<AlbumImage>()
            {
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},
                new AlbumImage { Image = null},

            };


            if (!db.Set<Artist>().Any())
            {
                db.Set<Artist>().AddRange(new[]
                {
                    new Artist(){Title = "Макс Корж",ArtistImage = artistImages[0]},
                    new Artist(){Title = "Виктор Цой",ArtistImage = artistImages[1]},
                    new Artist(){Title = "Сергей Михалок",ArtistImage = artistImages[2]},
                    new Artist(){Title = "Григорий Лепс",ArtistImage = artistImages[3]},
                    new Artist(){Title = "Неизвестный исполнитель",ArtistImage = artistImages[4]}

                });
            }

            //if (!db.Set<Album>().Any())
            //{
            //    db.Set<Album>().AddRange(new[]
            //    {
            //        new Album(){AlbumImage = albumImages[0], Artist = }

            //    });
            //}

        }
    }
}
