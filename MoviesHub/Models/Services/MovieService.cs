using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MoviesHub.Models.Interfaces;

namespace MoviesHub.Models
{
    public class MovieService : IMovieService
    {
        private readonly MoviesMvcContext context_;

        public MovieService(MoviesMvcContext context)
        {
            context_ = context;
        }

        public async Task<bool> AddAsync(Movie movie)
        {
            if (movie == null) {
                return false;
            }

            context_.Add(movie);

            await context_.SaveChangesAsync();

            return true;
        }

        public async Task<IList<Movie>> GetAllAsync()
        {
            var movies = await context_.Movie.ToListAsync();

            return movies;
        }

        public async Task<Movie> GetAsync(int id)
        {
            var movie = await context_.Movie
                .Include(m => m.ContentRating)
                .SingleOrDefaultAsync(m => m.MovieId == id);

            return movie;
        }

        public async Task<IList<ContentRating>> GetContentRatingsAsync()
        {
            var contentRatings = await context_.ContentRating.ToListAsync();

            return contentRatings;
        }
    }
}
