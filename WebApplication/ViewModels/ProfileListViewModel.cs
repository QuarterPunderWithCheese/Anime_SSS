using System.Collections.Generic;
using DomainModel.Entities;

namespace WebApplication.ViewModels
{
    public class ProfileListViewModel
    {
        public List<AnimeAndScore> AnimsAndScores { get; set; }
        public ProfileListViewModel(List<AnimeAndScore> animeAndSc)
        {
            AnimsAndScores = animeAndSc;
        }
    }
}