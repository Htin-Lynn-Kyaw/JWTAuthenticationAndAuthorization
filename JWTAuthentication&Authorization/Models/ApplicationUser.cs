using Microsoft.AspNetCore.Identity;

namespace JWTAuthentication_Authorization.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public static class AuthSettings
    {
        public static string Key { get;} = "williamlynn123!@#ThisIsASufficientlyLongKey!williamlynn123!@#ThisIsASufficientlyLongKey!";
    }
}
