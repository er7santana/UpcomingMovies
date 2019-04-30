using FluentAssertions;
using NUnit.Framework;
using UpcomingMoviesApp.UITests.Pages;
using UpcomingMoviesApp.UITests.Support;
using Xamarin.UITest;

namespace UpcomingMoviesApp.UITests.Specs
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class MovieDetailsPageTests : TestSetup<MovieDetailsPage>
    {
        public MovieDetailsPageTests(Platform platform) : base(platform)
        {
        }

        [SetUp]
        public void SetUp()
        {
            var upcomingMoviesPage = new UpcomingMoviesPage(App);
            upcomingMoviesPage.SelectMovie();
        }

        [Test]
        public void MovieTitleIsShown()
        {
            //Arrange

            //Act
            Page.WaitForLoad();

            //Assert
            Page.MovieTitle.Should().NotBeEmpty();
        }
    }
}
