using JWTAuthentication_Authorization.Models;
using JWTAuthentication_Authorization.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetToken() 
        {
            ApplicationUser user = new ApplicationUser();
            AuthService auth = new AuthService();
            var JwtToken = auth.GenerateToken(user);
            return Ok(JwtToken);
        }
    }
}
