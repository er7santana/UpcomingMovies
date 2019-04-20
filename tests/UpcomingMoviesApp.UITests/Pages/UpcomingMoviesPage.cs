using System;
using System.Linq;
using UpcomingMoviesApp.UITests.Support;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UpcomingMoviesApp.UITests.Pages
{
    public class UpcomingMoviesPage : Page
    {
        Func<AppQuery, AppQuery> firstMovie = e => e.Marked("Movie Title").Index(0);
        Func<AppQuery, AppQuery> searchToolBarItem = e => e.Marked("Search Button").Index(0);

        public UpcomingMoviesPage(IApp app) : base(app)
        {
        }

        public void WaitForLoad()
        {
            App.WaitForElement(firstMovie);
        }

        public string FirstMovieTitle => App.WaitForElement(firstMovie).FirstOrDefault().Text;

        public void SelectMovie()
        {
            App.Tap(firstMovie);
        }

        public void TapSearchToolbarItem()
        {
            App.Tap(searchToolBarItem);
        }
    }
}
