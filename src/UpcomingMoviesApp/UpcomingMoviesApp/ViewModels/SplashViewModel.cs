using UpcomingMoviesApp.Helpers;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.ViewModels.Base;
using Xamarin.Forms;

namespace UpcomingMoviesApp.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        public override void Init(object initData)
        {
            base.Init(initData);

            MessagingCenter.Subscribe<MessagingParameter>(this, MessageKeys.SplashScreenAnimationFinished, (parameter) => OnSplashScreenAnimationFinished());
        }

        void OnSplashScreenAnimationFinished()
        {
            CoreMethods.SwitchOutRootNavigation(NavigationContainerNames.MainContainer);
        }
    }
}
