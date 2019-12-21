using DelMe.Models;
using System.Data.Entity;
using DelMe.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;

namespace DelMe.Controllers
{
    public class MoviesController : Controller
    {
        //connecting to db
        private ApplicationDbContext _context;
        //creating constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Put: Movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var Genre = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel
            {
                Genres = Genre,
            };
            return View("MovieForm",viewModel); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {                    
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm",viewModel);
            }
            if(movie.Id == 0 && movie != null)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
                
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (Movie == null)
                return HttpNotFound();

            var viewModel = new MoviesFormViewModel(Movie)
            {                
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //Get: Movies
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(Movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "8 Miles"},
                new Movie { Id = 2, Name = "Dragon Ball Z"}
            };
        }

        // GET: Movies
        public ActionResult Randon()
        {
            var movie = new Movie() { Name = "Harry potter" };

            var cust = new List<Customer>
            {
                new Customer{Name ="Rajesh"},
                new Customer{Name ="Suresh"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movie,
                Customers = cust
            };
            return View(viewModel);
        }
    }
}