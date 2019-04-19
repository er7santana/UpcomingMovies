# Upcoming Movies App

Project developed with Xamarin.Forms to build an app for iOS and Android that offers to the user the list of upcoming movies and their details. The app also allows the search of a movie by entering a partial or full movie name.

All movies data is provided by [TMDb Api](https://developers.themoviedb.org/3).

## Third-party libraries used in the project


|Library | Link | Description | Why used|
| ------------------- | :------------------: |:------------------: |:------------------: |
| FreshMvvm |[Nuget](https://www.nuget.org/packages/FreshMvvm) [GitHub](https://github.com/rid00z/FreshMvvm)| Super light Mvvm Framework designed specifically for Xamarin.Forms. It's designed to be Easy, Simple and Flexible | Helps to implement Mvvm pattern, facilitates the navigation between ViewModels and provides a simple and effective IoC Container ||
| Json.Net |[Nuget](https://www.nuget.org/packages/Newtonsoft.Json) [GitHub](https://github.com/JamesNK/Newtonsoft.Json)| Json.NET is a popular high-performance JSON framework for .NET | Used to deserialize the data returned by TMDb Api ||
| PropertyChanged.Fody |[Nuget](https://www.nuget.org/packages/PropertyChanged.Fody) [GitHub](https://github.com/Fody/PropertyChanged)| Add property notification to all classes that implement INotifyPropertyChanged | Really saves a lot of time by injecting code that raises the PropertyChanged event for us ||
| Xamarin Essentials |[Nuget](https://www.nuget.org/packages/Xamarin.Essentials) [GitHub](https://github.com/xamarin/Essentials)| A kit of essential API's for Xamarin apps | The Connectivity feature was used to check if internet access is available ||
| FFImageLoading.Forms |[Nuget](https://www.nuget.org/packages/Xamarin.FFImageLoading.Forms) [GitHub](https://github.com/luberda-molinet/FFImageLoading)| Xamarin Library to load images quickly and easily on Xamarin.Forms | Used to load and locally cache the images of the movies ||
| Microsoft.Net.Test.Sdk |[Nuget](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk) [GitHub](https://github.com/microsoft/vstest/)| The MSbuild targets and properties for building .NET test projects | For building tests ||
| NUnit |[Nuget](https://www.nuget.org/packages/NUnit) [GitHub](https://github.com/nunit/nunit)| NUnit features a fluent assert syntax, parameterized, generic and theory tests and is user-extensible | For building unit tests ||
| NUnit3TestAdapter |[Nuget](https://www.nuget.org/packages/NUnit3TestAdapter) [GitHub](https://github.com/nunit/nunit3-vs-adapter)| A package including the NUnit 3 TestAdapter for Visual Studio 2012 onwards | For building unit tests ||


## Screenshots


<img src="https://github.com/er7santana/UpcomingMovies/blob/development/screenshots/screenshot_1.png" width="300px"/>
<img src="https://github.com/er7santana/UpcomingMovies/blob/development/screenshots/screenshot_2.png" width="300px"/>
<img src="https://github.com/er7santana/UpcomingMovies/blob/development/screenshots/screenshot_3.png" width="300px"/>
