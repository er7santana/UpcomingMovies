using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;

namespace UpcomingMoviesApp.Services.Movies
{
    public interface IMovieService
    {
        Task<ObservableCollection<Movie>> GetUpComingMoviesAsync(int page, string language);
        Task<MovieApiReturn> GetUpcomingMoviesDataAsync(int page, string language);
    }
}
