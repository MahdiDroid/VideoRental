using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace VideoRental.Controllers
{
    public class MovieController : Controller
    {
        private VRDbContext  _Context;

        public MovieController()
        {
            _Context = new VRDbContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _Context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
            //return Content("Hallo everyone");
        }
        public ActionResult Details(int id)
        {
            var singleMovie = _Context.Movies.SingleOrDefault(m => m.Id == id);
            return View(singleMovie);
        }
    }
}