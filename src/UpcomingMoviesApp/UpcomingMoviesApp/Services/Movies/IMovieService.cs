using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;

namespace UpcomingMoviesApp.Services.Movies
{
    interface IMovieService
    {
        Task<ObservableCollection<Movie>> GetUpComingMoviesAsync(int page, string language);
    }
}
