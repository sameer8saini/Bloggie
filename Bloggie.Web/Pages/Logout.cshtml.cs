using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
