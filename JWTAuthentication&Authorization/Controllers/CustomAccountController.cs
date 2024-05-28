using JWTAuthentication_Authorization.Models;
using JWTAuthentication_Authorization.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Authorization.Controllers
{
    public class CustomAccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }
    }
}
