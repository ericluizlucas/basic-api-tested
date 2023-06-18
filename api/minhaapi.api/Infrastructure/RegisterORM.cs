using minhaapi.Infrastructure.Interfaces;
using minhaapi.Infrastructure.Repositories;

namespace minhaapi.Infrastructure.RegisterORM
{

public static class RegisterORM
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ICategoryRepository,CategoryRepository>();
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
}
}