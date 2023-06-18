using minhaapi.Infrastructure.RegisterORM;
using minhaapi.Services.Interfaces;

namespace minhaapi.Services
{
    public static class RegisterServices
    {
        public static void RegisterServiceIoC(this IServiceCollection services, IConfiguration configuration)
        {

            services.RegisterRepositories(configuration);

            services.AddScoped<IProductService, ProductService>();
        }
    }
}
