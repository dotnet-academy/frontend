using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesHub.Models.Interfaces
{
    public interface IMovieService
    {
        Task<IList<Movie>> GetAllAsync();

        Task<Movie> GetAsync(int id);

        Task<IList<ContentRating>> GetContentRatingsAsync();

        Task<bool> AddAsync(Movie movie);
    }
}
