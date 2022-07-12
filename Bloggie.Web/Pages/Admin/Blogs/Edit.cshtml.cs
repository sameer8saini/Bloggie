using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }


        public async Task OnGet(Guid id)
        {
            BlogPost = await bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
            }

            await bloggieDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var existingBlog = await bloggieDbContext.BlogPosts.FindAsync(BlogPost.Id);

            if (existingBlog != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlog);
                await bloggieDbContext.SaveChangesAsync();

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
