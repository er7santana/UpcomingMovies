using UpcomingMoviesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpcomingMoviesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        Image SplashImage;

        public SplashPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetBackButtonTitle(this, "");

            var sub = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "logo300",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(SplashImage);

            BackgroundColor = Color.White;
            Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (SplashImage != null)
            {
                await SplashImage.ScaleTo(1, 1200);
                await SplashImage.ScaleTo(0.8, 1400, Easing.Linear);
                await SplashImage.ScaleTo(150, 2000, Easing.CubicInOut);
            }

            MessagingCenter.Send(new MessagingParameter(), MessageKeys.SplashScreenAnimationFinished);
        }
    }
}