using System.Collections.Generic;
using DomainModel.Entities;
using DomainServices.Classes;

namespace DomainServices
{
    public interface IAnimeManager
    {
        List<Anime> GetAllAnime();
        Anime GetAnimeByIdOrDefault(int id);
        decimal GetAnimeScore(List<AnimeRating> ratings);
        List<AnimeRating> GetAnimeRatings(Anime anime);
        int GetAnimeRank(int id);
        List<Anime> GetAnimsByUserName(string name);
    }
}