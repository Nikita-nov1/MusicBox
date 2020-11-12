using System.Web.Mvc;
using MusicBox.PresentationServices.Interfaces;

namespace MusicBox.Controllers
{
    public class ChartsController : Controller
    {
        private readonly IChartsPresentationService presentationServices;

        public ChartsController(IChartsPresentationService presentationServices)
        {
            this.presentationServices = presentationServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(presentationServices.GetTracksVmForCharts());
        }
    }
}