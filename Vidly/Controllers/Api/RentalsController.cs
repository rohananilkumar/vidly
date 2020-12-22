using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dto;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDB _context;
        public RentalsController()
        {
            _context = new ApplicationDB();
        }

        [HttpGet]
        public IHttpActionResult GetRentals(int id)
        {

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Customer customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            foreach (var MovieId in newRental.MovieIds)
            {
                Movie movie = _context.Movies.Single(m => m.Id == MovieId);


                if (movie.NumberAvailable <= 0)
                {
                    return BadRequest($"Requested Movie {movie.Name} unavailable");
                }

                _context.Rentals.Add(new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                });
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}
