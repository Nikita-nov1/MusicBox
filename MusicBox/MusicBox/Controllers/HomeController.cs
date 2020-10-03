using MusicBox.Data.Context;
using MusicBox.Data.InitializersDb;
using MusicBox.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicBox.Controllers
{
    public class HomeController : Controller
    {
        private IMusicBoxDbContext db;
        public HomeController(IMusicBoxDbContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            InitializersDbMusicBoxDb db = new InitializersDbMusicBoxDb();
            db.Seed();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}