using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Authorization.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
