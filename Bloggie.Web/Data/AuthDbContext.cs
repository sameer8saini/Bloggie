using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var superAdminRoleId = "589465c3-7396-46a4-8bf0-40203342faae";
            var adminRoleId = "aa2cf69c-a91a-4967-ba8c-18b8f6d54f60";
            var userRoleId = "a446eafe-5096-4d8c-889c-b4c92f5d6e63";

            // Seed Roles (User, Admin, Super Admin)
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Super Admin User
            var superAdminId = "c052ffb4-245b-4c3c-8390-f1bd806828e2";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper()
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                                    .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add All Roles To Super Admin User
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
