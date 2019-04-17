using FreshMvvm;
using System.Threading.Tasks;

namespace UpcomingMoviesApp.ViewModels.Base
{
    public class BaseViewModel : FreshBasePageModel
    {
        public string Title { get; set; }
        public bool IsBusy { get; set; }

        public async Task DisplayAlert(string message)
        {
            await CoreMethods.DisplayAlert("", message, AppResources.OK);
        }
    }
}
