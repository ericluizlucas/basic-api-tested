using AutoMapper;
using minhaapi.Common.Models;
using minhaapi.Infrastructure.Entities;

namespace minhaapi.Service
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryModel, Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryModel>();

            CreateMap<ProductModel, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Product, ProductModel>();
        }
    }
}
