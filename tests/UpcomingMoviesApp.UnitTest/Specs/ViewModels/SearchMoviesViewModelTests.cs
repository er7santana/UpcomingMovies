using NUnit.Framework;
using System.Threading.Tasks;
using UpcomingMoviesApp.Services.Genres;
using UpcomingMoviesApp.Services.Movies;
using UpcomingMoviesApp.ViewModels;

namespace UpcomingMoviesApp.UnitTest.Specs.ViewModels
{
    public class SearchMoviesViewModelTests
    {
        [Test]
        public void OnInitShouldFillGenresList()
        {
            //Arrange
            var movieService = new MockMovieService();
            var genreService = new MockGenreService();
            var searchMoviesViewModel = new SearchMoviesViewModel(movieService, genreService);
            var genres = genreService.GetAllAsync("en-US").Result;

            //Act
            searchMoviesViewModel.Init(genres);

            //Assert
            Assert.AreEqual(searchMoviesViewModel.Genres, genres);
        }

        [Test]
        public async Task GetGenresAsyncShouldFillGenresList()
        {
            //Arrange
            var movieService = new MockMovieService();
            var genreService = new MockGenreService();
            var searchMoviesViewModel = new SearchMoviesViewModel(movieService, genreService);
            searchMoviesViewModel.Genres.Clear();

            //Act
            await searchMoviesViewModel.GetGenresAsync();

            //Assert
            Assert.IsNotEmpty(searchMoviesViewModel.Genres);
        }

        [Test]
        public async Task LoadMoreItemsAsyncShouldFillMoviesList()
        {
            //Arrange
            var movieService = new MockMovieService();
            var genreService = new MockGenreService();
            var searchMoviesViewModel = new SearchMoviesViewModel(movieService, genreService);
            searchMoviesViewModel.Movies.Clear();

            //Act
            await searchMoviesViewModel.LoadMoreItemsAsync();

            //Assert
            Assert.IsNotEmpty(searchMoviesViewModel.Movies);
        }


        [Test]
        public async Task LoadMoreItemsAsyncShouldNotFillMoviesListWhenGetMoreResultsPropertyIsFalse()
        {
            //Arrange
            var movieService = new MockMovieService();
            var genreService = new MockGenreService();
            var searchMoviesViewModel = new SearchMoviesViewModel(movieService, genreService);
            searchMoviesViewModel.Movies.Clear();
            searchMoviesViewModel.GetMoreResults = false;

            //Act
            await searchMoviesViewModel.LoadMoreItemsAsync();

            //Assert
            Assert.IsEmpty(searchMoviesViewModel.Movies);
        }
    }
}
