using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = addUserRequest.Username,
                Email = addUserRequest.Email
            };

            var result = await userRepository
                .AddUser(identityUser, addUserRequest.Password, addUserRequest.Roles);

            if (result)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
