using NUnit.Framework;
using UpcomingMoviesApp.UITests.Pages;
using UpcomingMoviesApp.UITests.Support;
using Xamarin.UITest;


namespace UpcomingMoviesApp.UITests.Specs
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class SearchMoviesPageTests : TestSetup<SearchMoviesPage>
    {
        public SearchMoviesPageTests(Platform platform) : base(platform)
        {
        }

        [SetUp]
        public void SetUp()
        {
            var upcomingMoviesPage = new UpcomingMoviesPage(App);
            upcomingMoviesPage.TapSearchToolbarItem();
        }

        [Test]
        public void SearchMoviesRetrievesResults()
        {

        }
    }
}
