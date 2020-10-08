using MusicBox.Areas.Admin.Models.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBox.Areas.Admin.PresentationServices.Interfaces
{
    public interface IArtistPresentationServices : IBaseAdminPresentationService
    {
        void AddArtist(CreateArtistsViewModel artistVm);
    }
}
