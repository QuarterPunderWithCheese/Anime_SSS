using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class MembershipController : Controller
    {
        private readonly ISubscriptionManager _manager;
        public readonly IUserCatalog _catalog;

        public MembershipController(ISubscriptionManager manager, IUserCatalog catalog)
        {
            _catalog = catalog;
            _manager = manager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Membership()
        {
            return View();
        }

        public IActionResult GetSub()
        {
            var user = _catalog.GetUserByNameOrDefault(User.Identity.Name);
            if (!_manager.CheckSub(user))
            {
                _manager.AddSub(user);
            }
            
            return Redirect("/Profile/Profile");
            
        }
    }
}