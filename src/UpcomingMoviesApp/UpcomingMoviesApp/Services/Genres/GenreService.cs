using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMoviesApp.Models;
using UpcomingMoviesApp.Services.Base;

namespace UpcomingMoviesApp.Services.Genres
{
    public class GenreService : BaseService, IGenreService
    {
        public async Task<List<Genre>> GetAllAsync(string language)
        {
            var ret = await GetFromWebApi<GenreCollection>($"{Settings.GenresEndPoint}/movie/list?api_key={Settings.TmdbApiKey}&language={language}");
            if (ret != null && ret.Genres != null && ret.Genres.Length > 0)
            {
                return ret.Genres.ToList();
            }

            return new List<Genre>();
        }

        private string GetGenreName(int genreId, List<Genre> genres)
        {
            var genre = genres.FirstOrDefault(c => c.Id == genreId);
            if (genre == null)
            {
                return string.Empty;
            }

            return genre.Name;
        }

        public string GetGenreNames(int[] genreIds, List<Genre> genres)
        {
            if (genreIds == null || !genreIds.Any())
            {
                return string.Empty;
            }

            if (genres == null || !genres.Any())
            {
                return string.Empty;
            }

            var genreNames = string.Empty;
            for (int i = 0; i < genreIds.Length; i++)
            {
                string genreNameAux = GetGenreName(genreIds[i], genres);
                if (!string.IsNullOrWhiteSpace(genreNameAux))
                {
                    genreNames += $"{genreNameAux}, ";
                }
            }

            if (!string.IsNullOrWhiteSpace(genreNames) && genreNames.EndsWith(", "))
            {
                genreNames = genreNames.Substring(0, genreNames.Length - 2);
            }

            return genreNames;
        }
    }
}
