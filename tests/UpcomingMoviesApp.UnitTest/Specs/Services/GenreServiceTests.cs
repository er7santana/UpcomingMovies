using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Genres;

namespace UpcomingMoviesApp.UnitTest.Specs.Services
{
    public class GenreServiceTests
    {
        List<Genre> _genres = new List<Genre> {
                new Genre { Id = 1, Name = "One"},
                new Genre{ Id = 2, Name = "Two"},
                new Genre{ Id = 3, Name = "Three"},
            };

        [Test]
        public async Task GetAllAsyncShouldRetrieveGenres()
        {
            //Arrange
            var genreService = new GenreService();

            //Act
            var genres = await genreService.GetAllAsync("en-US");

            //Assert
            Assert.IsNotEmpty(genres);
        }

        [Test]
        public void GetGenreNameShouldResolveAValidGenreId()
        {
            //Arrange
            var genreService = new GenreService();

            //Act
            var genreName = genreService.GetGenreName(1, _genres);

            //Assert
            Assert.AreEqual(genreName, "One");
        }

        [Test]
        public void GetGenreNameShouldReturnEmptyForAnInvalidGenreId()
        {
            //Arrange
            var genreService = new GenreService();

            //Act
            var genreName = genreService.GetGenreName(5, _genres);

            //Assert
            Assert.IsEmpty(genreName);
        }

        [Test]
        public void GetGenreNameShouldReturnEmptyForAnEmptyGenresList()
        {
            //Arrange
            var genreService = new GenreService();

            //Act
            var genreName = genreService.GetGenreName(1, new List<Genre>());

            //Assert
            Assert.IsEmpty(genreName);
        }
        

        [Test]
        public void GetGenreNamesShouldResolveValidsGenreIds()
        {
            //Arrange
            var genreService = new GenreService();
            var genreIds = new int[] { 1, 2 };

            //Act
            var genreName = genreService.GetGenreNames(genreIds, _genres);

            //Assert
            Assert.AreEqual(genreName, "One, Two");
        }
        
        [Test]
        public void GetGenreNamesShouldReturnEmptyWhenGenreIdsIsNull()
        {
            //Arrange
            var genreService = new GenreService();
            int[] genreIds = null;

            //Act
            var genreName = genreService.GetGenreNames(genreIds, _genres);

            //Assert
            Assert.IsEmpty(genreName);
        }

        [Test]
        public void GetGenreNamesShouldReturnEmptyWhenGenreIdsIsEmpty()
        {
            //Arrange
            var genreService = new GenreService();
            int[] genreIds = new int[] { };

            //Act
            var genreName = genreService.GetGenreNames(genreIds, _genres);

            //Assert
            Assert.IsEmpty(genreName);
        }

        [Test]
        public void GetGenreNamesShouldReturnEmptyWhenGenresListIsNull()
        {
            //Arrange
            var genreService = new GenreService();
            var genreIds = new int[] { 1, 2 };
            List<Genre> nullGenres = null;

            //Act
            var genreName = genreService.GetGenreNames(genreIds, nullGenres);

            //Assert
            Assert.IsEmpty(genreName);
        }

        [Test]
        public void GetGenreNamesShouldReturnEmptyWhenGenresListIsEmpty()
        {
            //Arrange
            var genreService = new GenreService();
            var genreIds = new int[] { 1, 2 };
            var emptyGenres = new List<Genre>();

            //Act
            var genreName = genreService.GetGenreNames(genreIds, emptyGenres);

            //Assert
            Assert.IsEmpty(genreName);
        }
    }
}
