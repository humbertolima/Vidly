using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        { 
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        [HttpGet]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre);
         
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(x=>x.Id==id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        [HttpGet]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var vieModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", vieModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movietoEdit = _context.Movies.Single(m => m.Id == movie.Id);
                movietoEdit.Name = movie.Name;
                movietoEdit.GenreId = movie.GenreId;
                movietoEdit.ReleaseDate = movie.ReleaseDate;
                movietoEdit.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies.SingleOrDefault(m=>m.Id == id);
            if(movieToEdit == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movieToEdit)
            {
                Genres = _context.Genres.ToList()

            };
            
            return View("MovieForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
