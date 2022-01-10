using System;

namespace DomainModel.Entities
{
    public class FollowedAnime
    {
        public int Id { get; set; }
        public Anime Anime { get; set; }
        public  User User { get; set; }
        public DateTime AddedTime { get; set; }
    }
}