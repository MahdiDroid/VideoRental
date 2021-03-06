﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VideoRental.Models;
using VideoRental.ViewModels;

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

        [HttpGet]
        public ActionResult New()
        {
            var genre = _Context.Genres;
            var viewmodel = new GenreViewModel
            {
                Genres = genre

            };
            //var genre = new Genre();
            return View(genre);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
         {

           _Context.Movies.Add(movie);
            _Context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}