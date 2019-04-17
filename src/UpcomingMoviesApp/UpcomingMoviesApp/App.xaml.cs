using FreshMvvm;
using UpcomingMoviesApp.Helpers;
using UpcomingMoviesApp.Services.Genres;
using UpcomingMoviesApp.Services.Movies;
using UpcomingMoviesApp.ViewModels;
using Xamarin.Forms;

namespace UpcomingMoviesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeIoC();
            InitializeNavigation();
        }

        private void InitializeIoC()
        {
            FreshIOC.Container.Register<IMovieService, MovieService>();
            FreshIOC.Container.Register<IGenreService, GenreService>();
        }

        void InitializeNavigation()
        {
            var splashPage = FreshPageModelResolver.ResolvePageModel<SplashViewModel>();
            var splashNavigationContainer = new FreshNavigationContainer(splashPage, NavigationContainerNames.SplashContainer);

            var mainPage = FreshPageModelResolver.ResolvePageModel<MoviesViewModel>();
            _ = new FreshNavigationContainer(mainPage, NavigationContainerNames.MainContainer)
            {
                BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"],
                BarTextColor = (Color)Application.Current.Resources["BarTextColor"],
            };

            MainPage = splashNavigationContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
