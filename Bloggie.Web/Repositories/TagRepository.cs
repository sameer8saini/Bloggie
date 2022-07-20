using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }


        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await bloggieDbContext.Tags.ToListAsync();

            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}
