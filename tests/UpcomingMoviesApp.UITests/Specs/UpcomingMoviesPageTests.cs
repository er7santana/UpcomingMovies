using FluentAssertions;
using NUnit.Framework;
using UpcomingMoviesApp.UITests.Pages;
using UpcomingMoviesApp.UITests.Support;
using Xamarin.UITest;

namespace UpcomingMoviesApp.UITests.Specs
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class UpcomingMoviesPageTests : TestSetup<UpcomingMoviesPage>
    {
        public UpcomingMoviesPageTests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void MovieListIsShown()
        {
            //Arrange

            //Act
            Page.WaitForLoad();

            //Assert
            Page.FirstMovieTitle.Should().NotBeEmpty();
        }
    }
}
