using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class Anime
    {
       public int Id { get; set; }
       public string ShortName { get; set; }
       public string LongName { get; set; }
       public uint? CurrentSeriesNumber { get; set; }
       public uint? NumberOfAllSeries { get; set; }
       public string Description { get; set; }
       public string PhotoPath { get; set; }
       public IEnumerable<AnimeRating> AnimeRatings { get; set; }
       public IEnumerable<Genre> Genres { get; set; }
       public IEnumerable<Comment> Comments { get; set; }
    }
}