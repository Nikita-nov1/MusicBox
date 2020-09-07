using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.PresentationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicBox.PresentationServices
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }

        //public List<UserViewModel> GetByNameWithRole(string name)
        //{
        //    var users = userDomainService.GetByNameWithRole(name);

        //    var usersViewModel = Mapper.Map<List<UserViewModel>>(users);

        //    return usersViewModel;
        //}
    }
}