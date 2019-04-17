using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Base;

namespace UpcomingMoviesApp.Services.Movies
{
    public class MovieService : BaseService, IMovieService
    {
        public MovieService() : base("")
        {
        }

        public async Task<ObservableCollection<Movie>> GetUpComingMoviesAsync(int page, string language)
        {
            var list = await GetFromWebApi<IEnumerable<Movie>>("obtertodas");
            return list?.ToObservableCollection();
        }
    }
}
