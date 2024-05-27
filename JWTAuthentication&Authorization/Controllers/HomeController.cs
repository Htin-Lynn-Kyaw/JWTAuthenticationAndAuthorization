using JWTAuthentication_Authorization.Models;
using JWTAuthentication_Authorization.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JWTAuthentication_Authorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ApplicationUser user = new ApplicationUser();
            //AuthService auth = new AuthService();
            //var JwtToken = auth.GenerateToken(user);
            //TempData["Token"] = JwtToken;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
