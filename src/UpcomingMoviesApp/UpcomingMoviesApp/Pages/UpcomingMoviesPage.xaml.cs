using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpcomingMoviesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesPage : ContentPage
    {
        public UpcomingMoviesPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, AppResources.Back);
        }
    }
}