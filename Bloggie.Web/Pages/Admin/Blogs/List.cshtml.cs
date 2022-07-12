using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public async Task OnGet()
        {
            BlogPosts = await bloggieDbContext.BlogPosts.ToListAsync();
        }
    }
}
