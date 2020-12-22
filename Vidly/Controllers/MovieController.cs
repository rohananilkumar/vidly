using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDB _context;
        public MovieController()
        {
            _context = new ApplicationDB();
        }
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole("CanManageMovie"))
            {
                return View("Movies");
            }
            return View("ReadOnlyList");
        }

        [Authorize(Roles ="CanManageMovie")]
        public ActionResult Edit(int? id)
        {
            var genres = _context.Genres.ToList();
            if (id.HasValue)
            {
                ViewBag.MovieId = id;
                var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

                if (movie == null)
                    return HttpNotFound();
                return View(new EditMovieViewModel { movie = movie, genres = genres });
            }

            return View(new EditMovieViewModel { genres = genres, movie = new Movie() });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageMovie")]
        public ActionResult Save(EditMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var InvalidViewModel = new EditMovieViewModel
                {
                    movie = viewModel.movie,
                    genres = _context.Genres.ToList()

                };
                return View("Edit", InvalidViewModel);
            }

            if (viewModel.movie.Id == 0)
            {
                _context.Movies.Add(new Movie { Name = viewModel.movie.Name, GenreId = viewModel.movie.GenreId, ReleaseDate = viewModel.movie.ReleaseDate, NumberInStock = viewModel.movie.NumberInStock, NumberAvailable = viewModel.movie.NumberInStock });
                _context.SaveChanges();
            }
            else
            {
                var movie = _context.Movies.Single(m => m.Id == viewModel.movie.Id);
                movie.Name = viewModel.movie.Name;
                movie.GenreId = viewModel.movie.GenreId;
                movie.ReleaseDate = viewModel.movie.ReleaseDate;
                movie.NumberInStock = viewModel.movie.NumberInStock;
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}