using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public void OnGet()
        {
        }

        [HttpGet]
        public async Task<IActionResult> OnGetUsers()
        {
            // Get Users From Database
            var users = await userRepository.GetAll();

            var userViewModelList = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModelList.Add(new UserViewModel
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email
                });
            }

            // Render The Partial View
            return Partial("_UserList", userViewModelList);
        }
    }
}
