using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Authorization.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
