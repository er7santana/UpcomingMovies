using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;

namespace UpcomingMoviesApp.Services.Genres
{
    public class MockGenreService : IGenreService
    {
        public Task<List<Genre>> GetAllAsync(string language)
        {
            var list = new List<Genre>
            {
                new Genre{ Id = 1, Name = "One" },
                new Genre{ Id = 2, Name = "Two" },
            };
            return Task.FromResult(list);
        }

        public string GetGenreNames(int[] genreIds, List<Genre> genres)
        {
            return "Mock Genre Name";
        }
    }
}
