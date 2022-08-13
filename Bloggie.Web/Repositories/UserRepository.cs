using Bloggie.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public UserRepository(AuthDbContext authDbContext, UserManager<IdentityUser> userManager)
        {
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        public async Task<bool> AddUser(IdentityUser identityUser, string password, List<string> roles)
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

        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            return await authDbContext.Users.ToListAsync();
        }
    }
}
