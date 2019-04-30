using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Base;
using System.Net;

namespace UpcomingMoviesApp.Services.Movies
{
    public class MovieService : BaseService, IMovieService
    {
        public async Task<MovieApiReturn> GetMoviesAsync(int page, string language, string query)
        {
            var encodedQuery = WebUtility.UrlEncode(query);
            return await GetFromWebApi<MovieApiReturn>($"{Settings.SearchEndPoint}/movie?api_key={Settings.TmdbApiKey}&language={language}&query={encodedQuery}&page={page}&include_adult=false");
        }

        public async Task<ObservableCollection<Movie>> GetUpComingMoviesAsync(int page, string language)
        {
            var ret = await GetFromWebApi<MovieApiReturn>($"{Settings.MoviesEndPoint}/upcoming?api_key={Settings.TmdbApiKey}&language={language}&page={page}");
            if (ret != null && ret.Movies != null && ret.Movies.Length > 0)
            {
                return ret.Movies.ToObservableCollection();
            }

            return new ObservableCollection<Movie>();
        }

        public async Task<MovieApiReturn> GetUpcomingMoviesDataAsync(int page, string language)
        {
            return await GetFromWebApi<MovieApiReturn>($"{Settings.MoviesEndPoint}/upcoming?api_key={Settings.TmdbApiKey}&language={language}&page={page}");
        }
    }
}
