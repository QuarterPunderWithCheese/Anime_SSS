using System.Collections.Generic;
using DomainModel.Entities;

namespace WebApplication.ViewModels
{
    public class TopViewModel
    {
        public List<AnimeAndScore> AnimsAndScores { get; set; }
        public TopViewModel(List<AnimeAndScore> animeAndSc)
        {
            AnimsAndScores = animeAndSc;
        }
    }

    public class AnimeAndScore
    {
        public decimal Score { get; set; }
        public Anime Anime { get; set; }
        public int Rank { get; set; }
    }
}