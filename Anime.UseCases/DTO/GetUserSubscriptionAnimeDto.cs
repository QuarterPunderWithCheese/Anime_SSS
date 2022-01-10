using System.Collections.Generic;
using DomainModel.Entities;

namespace DomainServices.DTO
{
    public class GetUserSubscriptionAnimeDto
    {
        public int UserId { get; set; }

        public List<FollowedAnime> Anime{ get; set; }
    }
}