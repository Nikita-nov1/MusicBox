using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Domain.Interfaces
{
    public interface IGetPathServices
    {
        string GetPathDefaultArtistImage();

        string GetPathDefaultAlbumImage();

        string GetPathForSaveTracks();
    }
}
