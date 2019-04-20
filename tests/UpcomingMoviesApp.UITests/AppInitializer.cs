using Xamarin.UITest;

namespace UpcomingMoviesApp.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            // TODO: If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("br.com.shaft.upcomingmoviesapp")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .DeviceIdentifier("23D71287-9360-42C2-80A8-2B68C6412E9C")
                .InstalledApp("br.com.shaft.upcomingmoviesapp")
                .StartApp();
        }
    }
}
