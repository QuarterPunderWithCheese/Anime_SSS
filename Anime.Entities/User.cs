using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DomainModel.Entities
{
    public class User:IdentityUser
    {
        public Anime LastWatchedAnime { get; set;}
        public string Avatar { get; set;}
    }
}