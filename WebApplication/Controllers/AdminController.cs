using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET
        public IActionResult Admin()
        {
            return View();
        }
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }
        // GET
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult AddRole(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if (!_service.TryAddToRole(model.Email, model.Role).Result)
                {
                    return BadRequest("NotFound");
                }
                else
                {
                    string log = $"The user with Email:{model.Email} added to Role{model.Role}";
                    var client = WebRequest.Create("https://adminssswebapi.herokuapp.com/api/AddLog"+ log);
                    client.GetResponse();
                    return Redirect("Admin/Admin");
                }
            }
            return BadRequest("WriteNormalForm");
        }
    }
}