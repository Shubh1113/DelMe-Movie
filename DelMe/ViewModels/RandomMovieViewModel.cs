using DelMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DelMe.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movies { get; set; }
        public List<Customer> Customers { get; set; } 
    }
}