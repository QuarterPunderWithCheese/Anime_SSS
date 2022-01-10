using System.Linq;
using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ISubscriptionManager _manager;
        private readonly IUserCatalog _catalog;
        private readonly IAnimeManager _animeManager;


        public CatalogController(ISubscriptionManager manager,IAnimeManager animeManager ,IUserCatalog catalog)
        {
            _catalog = catalog;
            _manager = manager;
            _animeManager = animeManager;
        }
        // GET
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Authorize]
        public IActionResult AnimeTitle(int id)
        {
            var anime = _animeManager.GetAnimeByIdOrDefault(id);
            var score = _animeManager.GetAnimeScore(anime.AnimeRatings.ToList());
            var animeWithScore = new TitleViewModel(new TitleAndScore(score, anime), _animeManager.GetAnimeRank(id));
            return View(animeWithScore);
        }
    }
}