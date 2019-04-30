using NUnit.Framework;
using System.Threading.Tasks;
using UpcomingMoviesApp.Services.Genres;
using UpcomingMoviesApp.Services.Movies;
using UpcomingMoviesApp.ViewModels;

namespace UpcomingMoviesApp.UnitTest.Specs.ViewModels
{
    public class UpcomingMoviesViewModelTests
    {
        [Test]
        public async Task GetGenresAsyncShouldFillGenresList()
        {
            //Arrange
            var movieService = new MockMovieService();
            var genreService = new MockGenreService();
            var upcomingMoviesViewModel = new UpcomingMoviesViewModel(movieService, genreService);
            upcomingMoviesViewModel.Genres.Clear();

            //Act
            await upcomingMoviesViewModel.GetGenresAsync();
            
            //Assert
            Assert.IsNotEmpty(upcomingMoviesViewModel.Genres);
        }
    }
}
