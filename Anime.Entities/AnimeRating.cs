using System.Collections.Generic;


namespace DomainModel.Entities
{
    public class AnimeRating
    {
        public int Id { get; set; }
        public Anime Anime { get; set; }
        public int Value { get; set; }
        public User User { get; set; }
    }
}