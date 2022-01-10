using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DomainModel.Entities;
using DomainServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class TopController : Controller
    {
        private readonly ISubscriptionManager _manager;
        private readonly IUserCatalog _catalog;
        private readonly IAnimeManager _animeManager;


        public TopController(ISubscriptionManager manager,IAnimeManager animeManager ,IUserCatalog catalog)
        {
            _catalog = catalog;
            _manager = manager;
            _animeManager = animeManager;
        }
        // GET
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Authorize]
        public IActionResult Top()
        {
            var user = _catalog.GetUserByNameOrDefault(User.Identity.Name);
            if (!_manager.CheckSub(user)) return Redirect("/Membership/Membership");

            List<AnimeAndScore> animeAndScores = new List<AnimeAndScore>();
            var anime = _animeManager.GetAllAnime();
            foreach (var a in anime)
            {
                animeAndScores.Add(new AnimeAndScore
                {
                    Anime = a,
                    Score = _animeManager.GetAnimeScore(_animeManager.GetAnimeRatings(a)),
                    Rank = _animeManager.GetAnimeRank(a.Id)
                });
            }

            animeAndScores = new List<AnimeAndScore>(animeAndScores.OrderBy(x => x.Rank));
            
            TopViewModel model = new TopViewModel(animeAndScores);
            return View(model);
            
        }
    }
}