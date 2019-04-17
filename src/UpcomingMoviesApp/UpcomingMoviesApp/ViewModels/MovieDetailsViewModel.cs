using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.ViewModels.Base;

namespace UpcomingMoviesApp.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        public Movie Movie { get; set; }
        public string MovieTitle { get; set; }
        public string GenreNames { get; set; }
        public string ReleaseData { get; set; }
        public string ImagePath { get; set; }
        public string Overview { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData is Movie movie)
            {
                Movie = movie;
                MovieTitle = movie.Title;
                GenreNames = movie.GenreNames;
                ReleaseData = movie.ReleaseDate;
                ImagePath = movie.ImagePath;
                Overview = movie.Overview;
            }
        }
    }
}
