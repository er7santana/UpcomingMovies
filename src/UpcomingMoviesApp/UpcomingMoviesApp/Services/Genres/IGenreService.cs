using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;

namespace UpcomingMoviesApp.Services.Genres
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllAsync(string language);
        string GetGenreNames(int[] genreIds, List<Genre> genres);
    }
}
