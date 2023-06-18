using minhaapi.Infrastructure.Entities;
using minhaapi.Infrastructure.Interfaces;

namespace minhaapi.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}