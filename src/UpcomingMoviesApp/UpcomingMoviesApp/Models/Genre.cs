using Newtonsoft.Json;

namespace UpcomingMoviesApp.Models
{
    public class GenreCollection
    {
        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
