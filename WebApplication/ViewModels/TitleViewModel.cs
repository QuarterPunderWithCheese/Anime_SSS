using System.Collections.Generic;
using DomainModel.Entities;

namespace WebApplication.ViewModels
{
    public class TitleViewModel
    {
        public TitleAndScore TitleAndScore { get; set; }
        public decimal Rank { get; set; }
        public TitleViewModel(TitleAndScore titleAndSc, decimal rank)
        {
            TitleAndScore = titleAndSc;
            Rank = rank;
        }
    }

    public class TitleAndScore
    {
        public decimal Score {get; set; }
        public Anime Anime {get; set; }

        public TitleAndScore(decimal score, Anime anime)
        {
            Score = score;
            Anime = anime;
        }
    }
}