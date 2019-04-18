using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Genres;
using UpcomingMoviesApp.Services.Movies;
using UpcomingMoviesApp.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UpcomingMoviesApp.ViewModels
{
    public class UpcomingMoviesViewModel : BaseViewModel
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;
        public ICommand SelectMovieCommand => new Command<Movie>(async (movie) => await OnSelectedMovieCommand(movie));
        public ICommand LoadMoviesCommand => new Command(async () => await GetUpcomingMoviesAsync());
        public ICommand SearchMoviesCommand => new Command(async () => await GoToSearchMoviesAsync());
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public int CurrentPageNumber { get; set; } = 1;
        public int TotalPages { get; set; } = 0;
        public bool GetMoreResults { get; set; } = true;

        public UpcomingMoviesViewModel(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService;
            this.genreService = genreService;
        }

        public override async void Init(object initData)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert(AppResources.ErrorNoConnection);
            }
            else
            {
                await GetGenresAsync();
                await GetUpcomingMoviesAsync();
            }
        }

        private async Task GetGenresAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            try
            {
                Genres = await genreService.GetAllAsync(CultureInfo.CurrentCulture.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                await DisplayAlert(AppResources.ErrorSearchingGenres);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task GetUpcomingMoviesAsync()
        {
            if (!GetMoreResults)
            {
                return;
            }

            if (IsBusy)
            {
                return;
            }

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await DisplayAlert(AppResources.ErrorNoConnection);
                return;
            }

            IsBusy = true;
            try
            {
                if (!Genres.Any())
                {
                    await GetGenresAsync();
                }

                var moviesData = await movieService.GetUpcomingMoviesDataAsync(CurrentPageNumber, CultureInfo.CurrentCulture.Name);
                if (moviesData != null)
                {
                    TotalPages = moviesData.TotalPages;

                    for (int i = 0; i < moviesData.Movies.Length; i++)
                    {
                        moviesData.Movies[i].GenreNames = genreService.GetGenreNames(moviesData.Movies[i].GenreIds, Genres);
                        Movies.Add(moviesData.Movies[i]);
                    }
                }
                else
                {
                    TotalPages = 0;
                }

                CurrentPageNumber++;
                GetMoreResults = TotalPages > 0 && CurrentPageNumber < TotalPages;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                await DisplayAlert(AppResources.ErrorSearchingMovies);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task OnSelectedMovieCommand(Movie movie)
        {
            if (movie != null)
            {
                await CoreMethods.PushPageModel<MovieDetailsViewModel>(movie);
            }
        }

        async Task GoToSearchMoviesAsync()
        {
            await CoreMethods.PushPageModel<SearchMoviesViewModel>(Genres);
        }
    }
}
