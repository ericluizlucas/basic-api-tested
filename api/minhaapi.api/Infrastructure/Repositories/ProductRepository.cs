using minhaapi.Infrastructure.Entities;
using minhaapi.Infrastructure.Interfaces;

namespace minhaapi.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}