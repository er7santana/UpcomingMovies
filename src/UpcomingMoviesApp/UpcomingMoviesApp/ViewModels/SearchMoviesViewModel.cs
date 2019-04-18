using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Movies;
using UpcomingMoviesApp.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Globalization;
using System.Linq;
using System;
using System.Collections.Generic;
using UpcomingMoviesApp.Services.Genres;

namespace UpcomingMoviesApp.ViewModels
{
    public class SearchMoviesViewModel : BaseViewModel
    {
        private readonly IMovieService movieService;
        private readonly IGenreService genreService;

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public string SearchTerm { get; set; } = string.Empty;
        public int CurrentPageNumber { get; set; } = 1;
        public int TotalPages { get; set; } = 0;
        public bool GetMoreResults { get; set; } = true;

        public ICommand SearchMoviesCommand => new Command(async () => await SearchMoviesAsync());
        public ICommand LoadMoreItemsCommand => new Command(async () => await LoadMoreItemsAsync());
        public ICommand SelectMovieCommand => new Command<Movie>(async (movie) => await OnSelectedMovieCommand(movie));

        public List<Genre> Genres { get; set; } = new List<Genre>();


        public SearchMoviesViewModel(IMovieService movieService, IGenreService genreService)
        {
            this.movieService = movieService;
            this.genreService = genreService;
        }

        public override void Init(object initData)
        {
            if (initData is List<Genre> genres)
            {
                Genres = genres;
            }
        }

        async Task SearchMoviesAsync()
        {
            CurrentPageNumber = 1;

            if (IsBusy)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(SearchTerm) || SearchTerm.Trim().Length < 5)
            {
                await DisplayAlert(AppResources.TypeAtLeast5CharactersToSearch);
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

                var moviesData = await movieService.GetMoviesAsync(CurrentPageNumber, CultureInfo.CurrentCulture.Name, SearchTerm);
                Movies.Clear();

                if (moviesData == null || moviesData.Movies == null || !moviesData.Movies.Any())
                {
                    await DisplayAlert(AppResources.NoRecordsFound);
                    TotalPages = 0;
                }
                else
                {
                    TotalPages = moviesData.TotalPages;

                    for (int i = 0; i < moviesData.Movies.Length; i++)
                    {
                        moviesData.Movies[i].GenreNames = genreService.GetGenreNames(moviesData.Movies[i].GenreIds, Genres);
                        Movies.Add(moviesData.Movies[i]);
                    }
                }

                CurrentPageNumber++;
                GetMoreResults = TotalPages > 0 && CurrentPageNumber < TotalPages;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await DisplayAlert(AppResources.ErrorSearchingMovies);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task LoadMoreItemsAsync()
        {
            if (!GetMoreResults)
            {
                return;
            }

            var moviesData = await movieService.GetMoviesAsync(CurrentPageNumber, CultureInfo.CurrentCulture.Name, SearchTerm);
            if (moviesData == null || moviesData.Movies == null || !moviesData.Movies.Any())
            {
                return;
            }
            else
            {
                TotalPages = moviesData.TotalPages;

                for (int i = 0; i < moviesData.Movies.Length; i++)
                {
                    moviesData.Movies[i].GenreNames = genreService.GetGenreNames(moviesData.Movies[i].GenreIds, Genres);
                    Movies.Add(moviesData.Movies[i]);
                }
            }

            CurrentPageNumber++;
            GetMoreResults = TotalPages > 0 && CurrentPageNumber < TotalPages;
        }

        async Task OnSelectedMovieCommand(Movie movie)
        {
            if (movie != null)
            {
                await CoreMethods.PushPageModel<MovieDetailsViewModel>(movie);
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

    }
}
