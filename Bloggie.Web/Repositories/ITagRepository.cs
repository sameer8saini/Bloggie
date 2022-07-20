using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
