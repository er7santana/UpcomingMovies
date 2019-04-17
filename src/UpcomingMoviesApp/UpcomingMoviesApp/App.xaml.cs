using FreshMvvm;
using UpcomingMoviesApp.Helpers;
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
        }

        void InitializeNavigation()
        {
            //var masterDetailNav = new ShaftMasterDetailNavigationContainer(NavigationContainerNames.MasterContainer);
            //masterDetailNav.Init("", "menu");
            //masterDetailNav.AddPage<VehiclesMapViewModel>("Vehicles", "car", null);
            //masterDetailNav.AddPage<MyAccountViewModel>("My Account", "account", null);
            //masterDetailNav.AddPage<DeliveriesViewModel>("Last Deliveries", "history", null);
            //masterDetailNav.AddPage<MyJobsViewModel>("My Jobs", "date", null);
            //masterDetailNav.AddPage<AlertsViewModel>("Alerts", "error", null);
            //masterDetailNav.AddPage<NotificationsViewModel>("Notifications", "notifications", null);
            //masterDetailNav.AddPage<TermsOfUseViewModel>("Terms Of Use", "description", null);
            //masterDetailNav.AddLogout("Logout", "exit");

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
