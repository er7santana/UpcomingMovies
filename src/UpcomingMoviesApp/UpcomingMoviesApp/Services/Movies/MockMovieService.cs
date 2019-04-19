using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;

namespace UpcomingMoviesApp.Services.Movies
{
    public class MockMovieService : IMovieService
    {
        List<Movie> _mockMovies = new List<Movie>
        {
            new Movie{Title = "Title One"},
            new Movie{Title = "Title Two"},
            new Movie{Title = "Title Three"},
        };

        public Task<MovieApiReturn> GetMoviesAsync(int page, string language, string query)
        {
            var apiReturn = new MovieApiReturn();
            apiReturn.Movies = new Movie[] { new Movie { Title = $"{query} 1" }, new Movie { Title = $"{query} 2" }, };
            return Task.FromResult(apiReturn);
        }

        public Task<ObservableCollection<Movie>> GetUpComingMoviesAsync(int page, string language)
        {
            return Task.FromResult(_mockMovies.ToObservableCollection());
        }

        public Task<MovieApiReturn> GetUpcomingMoviesDataAsync(int page, string language)
        {
            var apiReturn = new MovieApiReturn();
            apiReturn.Movies = _mockMovies.ToArray();
            return Task.FromResult(apiReturn);
        }
    }
}
