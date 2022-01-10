using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainServices.Classes
{
    public class AnimeManager : IAnimeManager
    {
        private readonly AppDbContext _context;

        public AnimeManager(AppDbContext context)
        {
            _context = context;
        }

        public List<Anime> GetAllAnime()
        {
            return _context.Anime.Include(r => r.AnimeRatings).Select(x => x).ToList();
        }

        public Anime GetAnimeByIdOrDefault(int id)
        {
            Anime anime = _context.Anime.Include(r => r.AnimeRatings).FirstOrDefault(x => x.Id.Equals(id));
            return anime;
        }

        public decimal GetAnimeScore(List<AnimeRating> ratings)
        {
            decimal score = 0;
            int y = 0;
            foreach (var rating in ratings)
            {
                score = score + rating.Value;
                y++;
            }

            if (y == 0)
                y = 1;

            return Math.Round(score / y, 1);
        }

        public List<AnimeRating> GetAnimeRatings(Anime anime)
        {
            return _context.AnimeRatings.Where(x => x.Anime == anime).ToList();
        }
        
        public int GetAnimeRank(int id)
        {
            var rank = 1;
            var anime = GetAnimeByIdOrDefault(id);
            var anims = GetAllAnime();
            var animeRatings = GetAnimeRatings(anime);
            if (animeRatings.Count != 0)
            {
                var animsWithScore = new List<AnimeWithScore>();
                for (var i = 0; i < anims.Count; i++)
                {
                    animsWithScore.Add(new AnimeWithScore()
                    {
                        Anime = anims[i],
                        Score = GetAnimeScore(anims[i].AnimeRatings.ToList())
                    });
                }

                rank = animsWithScore.OrderByDescending(x => x.Score).ToList().FindIndex(a => a.Anime.Id == id) + 1;
            }
            else
            {
                rank = anims.Count;
            }
            return rank;
        }

        public class AnimeWithScore
        {
            public Anime Anime { get; set; }

            public decimal Score { get; set; }
        }

        public List<Anime> GetAnimsByUserName(string name)
        {
            var ratings = _context.AnimeRatings
                .Where(u => u.User.UserName == name)
                .ToList();
            var anims = GetAllAnime().Where(a => ratings
                                                    .Select(i => i.Anime.Id)
                                                    .Contains(a.Id))
                                                    .ToList();
            return anims;
        }
    }
}