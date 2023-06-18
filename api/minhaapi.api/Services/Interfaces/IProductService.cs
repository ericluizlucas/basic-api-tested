using minhaapi.Common.Models;

namespace minhaapi.Services.Interfaces
{
    public interface IProductService : IServiceBase
    {
        // CATEGORY
        IEnumerable<CategoryModel> GetAllCategory();
        bool CreateCategory(CategoryModel model);
        bool UpdateCategory(CategoryModel model);
        bool DeleteCategory(string uuid);

        // PRODUCT
        IEnumerable<ProductModel> GetAllProduct();
        IEnumerable<ProductModel> GetProductByCategory(string categoryUuid);
        bool CreateProduct(ProductModel model);
        bool UpdateProduct(ProductModel model);
        bool DeleteProduct(string uuid);
    }
}