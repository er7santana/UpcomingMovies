using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Movies;
using UpcomingMoviesApp.ViewModels.Base;
using Xamarin.Forms;

namespace UpcomingMoviesApp.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        private readonly IMovieService movieService;
        public ICommand SelectMovieCommand => new Command<Movie>(async (movie) => await OnSelectedMovieCommand(movie));
        public ICommand SearchCommand => new Command(async () => await SearchMoviesAsync());
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 0;
        public int TotalResults { get; set; }
        public bool GetMoreResults { get; set; } = false;

        public MoviesViewModel(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        async Task SearchMoviesAsync()
        {
            var moviesData = await movieService.GetUpcomingMoviesDataAsync(CurrentPage, CultureInfo.CurrentCulture.Name);
            if (moviesData != null)
            {
                TotalPages = moviesData.TotalPages;
                TotalResults = moviesData.TotalResults;

                for (int i = 0; i < moviesData.Movies.Length; i++)
                {
                    Movies.Add(moviesData.Movies[i]);
                }
            }
            else
            {
                TotalPages = 0;
            }

            CurrentPage++;
            GetMoreResults = TotalPages > 0 && CurrentPage < TotalPages;
        }

        async Task OnSelectedMovieCommand(Movie movie)
        {
            if (movie != null)
            {
                await CoreMethods.PushPageModel<MovieDetailsViewModel>(movie);
            }
        }
    }
}
