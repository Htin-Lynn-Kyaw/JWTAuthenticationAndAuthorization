using JWTAuthentication_Authorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication_Authorization.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "Admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "Client";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "Seller";

            builder.Entity<IdentityRole>().HasData(admin, client, seller);
        }
    }
}
