
using System;
using System.Collections.Generic;
using System.Linq;
using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ISubscriptionManager _manager;
        private readonly IUserCatalog _catalog;
        private readonly IAnimeManager _animeManager;


        public ProfileController(ISubscriptionManager manager,IAnimeManager animeManager ,IUserCatalog catalog)
        {
            _catalog = catalog;
            _manager = manager;
            _animeManager = animeManager;
        }
        // GET
        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var user = _catalog.GetUserByNameOrDefault(User.Identity.Name);
            if (user == null) return BadRequest("SomethingHappened");
            ProfileModelView model = new ProfileModelView
            {
                UserName = user.UserName,
                Avatar = user.Avatar,
                LastAnime = user.LastWatchedAnime,
            };
            return View(model);
        }       
        public IActionResult EditProfile()
        {
            return View();
        }
        public IActionResult AnimeList(string name)
        {
            var anims = _animeManager.GetAnimsByUserName(name);
            var animsAndScores = anims.Select(anime => new AnimeAndScore() {Anime = anime, Score = _animeManager.GetAnimeScore(anime.AnimeRatings.ToList())}).ToList();
            var profileList = new ProfileListViewModel(animsAndScores);
            return View(profileList);
        }
    }
}