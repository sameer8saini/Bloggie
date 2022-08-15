using Bloggie.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public UserRepository(AuthDbContext authDbContext,
            UserManager<IdentityUser> userManager)
        {
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        public async Task<bool> Add(IdentityUser identityUser, string password, List<string> roles)
        {
            var identityResult = await userManager.CreateAsync(identityUser, password);

            if (identityResult.Succeeded)
            {
                identityResult = await userManager.AddToRolesAsync(identityUser, roles);

                if (identityResult.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await authDbContext.Users.ToListAsync();
            var superAdminUser = await authDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == "superadmin@bloggie.com");

            if (superAdminUser != null)
            {
                users.Remove(superAdminUser);
            }

            return users;
        }
    }
}
