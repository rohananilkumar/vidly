using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class EditMovieViewModel
    {
        public Movie movie { get; set; }
        public IEnumerable<Genre> genres { get; set; }
    }
}