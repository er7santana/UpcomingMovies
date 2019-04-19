using NUnit.Framework;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.ViewModels;

namespace UpcomingMoviesApp.UnitTest.Specs.ViewModels
{
    public class MovieDetailsViewModelTests
    {
        [Test]
        public void OnInitShouldNotCrashWhenParameterIsNotPassed()
        {
            //Arrange
            Movie destination = null;
            var movieDetailsViewModel = new MovieDetailsViewModel();

            //Act
            movieDetailsViewModel.Init(destination);

            //Assert
            Assert.AreEqual(movieDetailsViewModel.Movie, destination);
        }

        [Test]
        public void OnInitShouldFillMovieParameter()
        {
            //Arrange
            Movie destination = new Movie();
            var movieDetailsViewModel = new MovieDetailsViewModel();

            //Act
            movieDetailsViewModel.Init(destination);

            //Assert
            Assert.AreEqual(movieDetailsViewModel.Movie, destination);
        }

        [Test]
        public void OnInitShouldFillMovieTitleParameter()
        {
            //Arrange
            Movie destination = new Movie { Title = "Test Title" };
            var movieDetailsViewModel = new MovieDetailsViewModel();

            //Act
            movieDetailsViewModel.Init(destination);

            //Assert
            Assert.AreEqual(movieDetailsViewModel.Movie.Title, destination.Title);
        }

        [Test]
        public void OnInitShouldFillMovieGenresParameter()
        {
            //Arrange
            Movie destination = new Movie { GenreNames = "Test genres" };
            var movieDetailsViewModel = new MovieDetailsViewModel();

            //Act
            movieDetailsViewModel.Init(destination);

            //Assert
            Assert.AreEqual(movieDetailsViewModel.Movie.GenreNames, destination.GenreNames);
        }

        [Test]
        public void OnInitShouldFillMovieReleaseDateParameter()
        {
            //Arrange
            Movie destination = new Movie { ReleaseDate = "2019-12-01" };
            var movieDetailsViewModel = new MovieDetailsViewModel();

            //Act
            movieDetailsViewModel.Init(destination);

            //Assert
            Assert.AreEqual(movieDetailsViewModel.Movie.ReleaseDate, destination.ReleaseDate);
        }

        [Test]
        public void OnInitShouldFillMovieOverviewParameter()
        {
            //Arrange
            Movie destination = new Movie { Overview = "Test Overview" };
            var movieDetailsViewModel = new MovieDetailsViewModel();

            //Act
            movieDetailsViewModel.Init(destination);

            //Assert
            Assert.AreEqual(movieDetailsViewModel.Movie.Overview, destination.Overview);
        }
    }
}