using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.WebPages;
using DomainModel.Entities;
using DomainServices;
using DomainServices.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserCatalog _catalog;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IUserCatalog catalog, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _catalog = catalog;
        }

        // GET
        public IActionResult Signup()
        {
            return View();
        }

        public bool ValidateUser(RegisterViewModel user)
        {
            const string emailPattern =
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            var emailCheck = Regex.IsMatch(user.Email, emailPattern, RegexOptions.IgnoreCase);

            var passRegex = new Regex("^(?=.*)(?=.*[a-z])(?=.*[A-Z]).{6,}$");
            var passCheck = passRegex.IsMatch(user.Password);

            return (emailCheck && passCheck);
        }

        public bool FindUser(string email)
        {
            return _catalog.GetUserByEmailOrDefault(email) != null;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new User();
            var valid = ValidateUser(model);
            if (!valid)
                Response.Headers.Add("registration_result", new StringValues("error"));
            else if (FindUser(model.Email))
                Response.Headers.Add("registration_result", new StringValues("failed"));
            else
            {
                user = _catalog.AddUserOrDefault(new UserRegistrationDto
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password
                });
                Response.Headers.Add("registration_result", new StringValues("ok"));
            }

            if (user != null)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return Ok(model);
        }
    

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Check forms");
            DomainModel.Entities.User user = _catalog.TryLogIn(new TryLogInDto
            {
                Email = model.Email,
                Pass = model.Password
            });
            if (user == null) return BadRequest("Invalid pass");
            await _signInManager.SignInAsync(user, false);
            return Redirect("/Profile/Profile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}