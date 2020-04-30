using KudoCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using KudoCinema.ViewModels;

namespace KudoCinema.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var movies = context.Movies.Include(p => p.Genre).ToList();

                return View(movies);
            }
        }

        [Route("Movie/New")]
        public ActionResult New()
        {
           using(var context = new ApplicationDbContext())
            {
                var genres = context.Genres.ToList();

                var viewModel = new MovieFormViewModel()
                {
                    Genres = genres,
                };
                ViewBag.FormTitle = "Add new movie";
                return View("MovieForm", viewModel);
            }
        }

        [HttpPost]
        [Route("Movie/Save")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            using(var context = new ApplicationDbContext())
            {
                if (!ModelState.IsValid)
                {
                    var genres = context.Genres.ToList();
                    var viewModel = new MovieFormViewModel()
                    {
                        Genres = genres
                    };

                    return View("MovieForm", viewModel);
                }

                if(movie.Id == 0)
                {
                    context.Movies.Add(movie);
                }
                else
                {
                    var updateMovie = context.Movies.FirstOrDefault(p => p.Id == movie.Id);
                    updateMovie.Name = movie.Name;
                    updateMovie.ReleaseDate = movie.ReleaseDate;
                    updateMovie.GenreId = movie.GenreId;
                }

                context.SaveChanges();
                return RedirectToAction("Index", "Movie");
            }
        }

        [Route("Movie/Edit/id")]
        public ActionResult Edit(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var movie = context.Movies.Include(p => p.Genre).FirstOrDefault(p => p.Id == id);
                var genres = context.Genres.ToList();

                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = genres,
                };

                ViewBag.FormTitle = "Edit movie";
                return View("MovieForm", viewModel);
            }
        }
    }
}