using NUnit.Framework;
using System.Threading.Tasks;
using UpcomingMoviesApp.Services.Movies;

namespace UpcomingMoviesApp.UnitTest.Specs.Services
{
    public class MovieServiceTests
    {
        [Test]
        public async Task GetMoviesAsyncShouldRetrieveMovies()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var apiReturn = await movieService.GetMoviesAsync(1, "en-US", "Avengers");

            //Assert
            Assert.IsNotEmpty(apiReturn.Movies);
        }

        [Test]
        public async Task GetMoviesAsyncShouldNotRetrieveMoviesWhenQueryDoesNotHaveMatches()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var apiReturn = await movieService.GetMoviesAsync(1, "en-US", "This is a query without matches");

            //Assert
            Assert.IsEmpty(apiReturn.Movies);
        }

        [Test]
        public async Task GetMoviesAsyncShouldNotBreakWhenQueryContainsUriUnsafeCharacters()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var apiReturn = await movieService.GetMoviesAsync(1, "en-US", @"./\Avengers");

            //Assert
            Assert.IsNotEmpty(apiReturn.Movies);
        }

        [Test]
        public async Task GetMoviesAsyncShouldNotRetrieveMoviesWhenPageNumberDoesNotExist()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var apiReturn = await movieService.GetMoviesAsync(100, "en-US", "Avengers");

            //Assert
            Assert.IsEmpty(apiReturn.Movies);
        }

        [Test]
        public async Task GetUpComingMoviesAsyncShouldRetrieveMovies()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var movies = await movieService.GetUpComingMoviesAsync(1, "en-US");

            //Assert
            Assert.IsNotEmpty(movies);
        }

        [Test]
        public async Task GetUpComingMoviesAsyncShouldNotRetrieveMoviesWhenPageNumberDoesNotExist()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var movies = await movieService.GetUpComingMoviesAsync(100, "en-US");

            //Assert
            Assert.IsEmpty(movies);
        }

        [Test]
        public async Task GetUpcomingMoviesDataAsyncShouldRetrieveMovies()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var apiReturn = await movieService.GetUpcomingMoviesDataAsync(1, "en-US");

            //Assert
            Assert.IsNotEmpty(apiReturn.Movies);
        }

        [Test]
        public async Task GetUpcomingMoviesDataAsyncShouldNotRetrieveMoviesWhenPageNumberDoesNotExist()
        {
            //Arrange
            var movieService = new MovieService();

            //Act
            var apiReturn = await movieService.GetUpcomingMoviesDataAsync(100, "en-US");

            //Assert
            Assert.IsEmpty(apiReturn.Movies);
        }
    }
}

