using System.Threading.Tasks;
using System.Windows.Input;
using UpcomingMoviesApp.ViewModels.Base;
using Xamarin.Forms;

namespace UpcomingMoviesApp.ViewModels
{
    public class MoviesViewModel : BaseViewModel
    {
        public ICommand MovieSelectedCommand => new Command(async () => await MovieSelectedAsync());

        private async Task MovieSelectedAsync()
        {
            await CoreMethods.PushPageModel<MovieDetailsViewModel>();
        }
    }
}
