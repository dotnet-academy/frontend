using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MoviesHub.Models;
using MoviesHub.Models.Interfaces;

namespace MoviesHub.Controllers
{
    public class MoviesNewController : Controller
    {
        private readonly IMovieService movieService_;

        public MoviesNewController(IMovieService movieService)
        {
            movieService_ = movieService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await movieService_.GetAllAsync();

            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await movieService_.GetAsync(id.Value);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var contentRatings = await movieService_.GetContentRatingsAsync();

            ViewData["ContentRatingId"] = new SelectList(contentRatings, "ContentRatingId", "ShortDescription");

            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Revenue,PosterUrl,VideoUrl,VideoPosterUrl,Summary,ReleaseDate,ContentRatingId")] Movie movie)
        {
            if (ModelState.IsValid) {
                await movieService_.AddAsync(movie);

                return RedirectToAction(nameof(Index));
            }

            var contentRatings = await movieService_.GetContentRatingsAsync();

            ViewData["ContentRatingId"] = new SelectList(contentRatings, "ContentRatingId", "ShortDescription", movie.ContentRatingId);

            return View(movie);
        }
    }
}
