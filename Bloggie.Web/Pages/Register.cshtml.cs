using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        [BindProperty]
        public Register RegisterViewModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = new IdentityUser
            {
                UserName = RegisterViewModel.Username,
                Email = RegisterViewModel.Email
            };

            var identityResult = await userManager.CreateAsync(user, RegisterViewModel.Password);

            if (identityResult.Succeeded)
            {
                var addRolesResult = await userManager.AddToRoleAsync(user, "User");

                if (addRolesResult.Succeeded)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Type = Enums.NotificationType.Success,
                        Message = "User registered successfully."
                    };

                    return Page();
                }
            }

            ViewData["Notification"] = new Notification
            {
                Type = Enums.NotificationType.Error,
                Message = "Something went wrong."
            };

            return Page();
        }
    }
}
