using AuthenticationService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace AuthenticationService.DataBase.Identity;


public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

        // make sure they come after base.OnModelcreating to not create the tables
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();

    }

}