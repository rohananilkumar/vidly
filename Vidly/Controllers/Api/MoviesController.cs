using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Runtime.Caching;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDB _context;
        public MoviesController()
        {
            _context = new ApplicationDB();
        }

        public IHttpActionResult GetMovies(string query = null)
        {

            var moviesQuery = _context.Movies
                 .Include(m => m.Genre)
                 .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return Ok(moviesQuery.ToList());
                
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        [Authorize(Roles = "CanManageMovie")]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(movie.NumberAvailable == 0)
            {
                movie.NumberAvailable = movie.NumberInStock;
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        [HttpPut]
        [Authorize(Roles = "CanManageMovie")]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                return NotFound();

            movieInDB.Name = movie.Name;
            movieInDB.NumberInStock = movie.NumberInStock;
            movieInDB.ReleaseDate = movie.ReleaseDate;
            movieInDB.GenreId = movie.GenreId;

            _context.SaveChanges();

            return Ok(movieInDB);
        }


        [HttpDelete]
        [Authorize(Roles = "CanManageMovie")]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDB == null)
                return NotFound();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok(movieInDB);
        }
    }
}
