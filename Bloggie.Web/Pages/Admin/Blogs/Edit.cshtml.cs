using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }


        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);

            if (BlogPost != null && BlogPost.Tags != null)
            {
                Tags = string.Join(',', BlogPost.Tags.Select(x => x.Name));
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                BlogPost.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }));

                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Record updated successfully!"
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Something went wrong!"
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog was deleted successfully!"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
