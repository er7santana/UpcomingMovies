using System.Linq;
using UpcomingMoviesApp.UITests.Support;
using Xamarin.UITest;

namespace UpcomingMoviesApp.UITests.Pages
{
    public class MovieDetailsPage : Page
    {
        public MovieDetailsPage(IApp app) : base(app)
        {
        }

        public void WaitForLoad()
        {
            App.WaitForElement(e => e.Marked("Movie Title"));
        }

        public string MovieTitle => App.WaitForElement(e => e.Marked("Movie Title")).FirstOrDefault().Text;
        public string GenreNames => App.WaitForElement(e => e.Marked("Genre")).FirstOrDefault().Text;
        public string ReleaseDate => App.WaitForElement(e => e.Marked("Release date")).FirstOrDefault().Text;
        public string Overview => App.WaitForElement(e => e.Marked("Overview")).FirstOrDefault().Text;
    }
}