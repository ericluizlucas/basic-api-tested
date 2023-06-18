using minhaapi.Infrastructure.Entities;
using minhaapi.Services.Interfaces;
using minhaapi.Infrastructure.Interfaces;
using minhaapi.Common.Models;
using AutoMapper;

namespace minhaapi.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetAllCategory()
        {
            try
            {
                var list = _categoryRepository.GetAll();
                IEnumerable<CategoryModel> resp = _mapper.Map<IEnumerable<CategoryModel>>(list);

                return resp;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool CreateCategory(CategoryModel model)
        {
            try
            {
                if (model.Nome is null) throw new Exception(Common.Messages.Validation.NullNome);
                Category entity = _mapper.Map<Category>(model);
                var inserted = _categoryRepository.Insert(entity);

                return inserted > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool UpdateCategory(CategoryModel model)
        {
            try
            {
                if (model.Nome is null) throw new Exception(Common.Messages.Validation.NullNome);

                Category entity = _categoryRepository.GetByParameter(new { Uuid = model.Uuid });
                if (entity is null) throw new Exception(Common.Messages.Database.RegisterNotFound);
                
                entity.Nome = model.Nome;
                entity.Enable = model.Enable;

                var updated = _categoryRepository.Update(entity);

                return updated > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool DeleteCategory(string uuid)
        {
            try
            {
                Category entity = _categoryRepository.GetByParameter(new { Uuid = uuid });
                if (entity is null) throw new Exception(Common.Messages.Database.RegisterNotFound);

                var deleted = _categoryRepository.Delete(entity.Id);

                return deleted > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

// ------------------------------------------------- PRODUCT -------------------------------------------------------- //

        public IEnumerable<ProductModel> GetAllProduct()
        {
            try
            {
                var list = _productRepository.GetAll();
                IEnumerable<ProductModel> resp = _mapper.Map<IEnumerable<ProductModel>>(list);

                return resp;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IEnumerable<ProductModel> GetProductByCategory(string categoryUuid)
        {
            try
            {
                var list = _productRepository.GetListByParameter(new { CategoryUuid = categoryUuid });
                IEnumerable<ProductModel> resp = _mapper.Map<IEnumerable<ProductModel>>(list);

                return resp;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool CreateProduct(ProductModel model)
        {
            try
            {
                if (model.Nome is null) throw new Exception(Common.Messages.Validation.NullNome);
                
                Category category = _categoryRepository.GetByParameter(new { Uuid = model.CategoryUuid });
                if(category is null) throw new Exception(Common.Messages.Database.CategoryNotFound);

                Product entity = _mapper.Map<Product>(model);
                var inserted = _productRepository.Insert(entity);

                return inserted > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool UpdateProduct(ProductModel model)
        {
            try
            {
                if (model.Nome is null) throw new Exception(Common.Messages.Validation.NullNome);
                if (model.CategoryUuid is null) throw new Exception(Common.Messages.Validation.NullCategory);

                Category category = _categoryRepository.GetByParameter(new { Uuid = model.CategoryUuid });
                if(category is null) throw new Exception(Common.Messages.Database.CategoryNotFound);

                Product entity = _productRepository.GetByParameter(new { Uuid = model.Uuid });
                if (entity is null) throw new Exception(Common.Messages.Database.RegisterNotFound);

                entity.Nome = model.Nome;
                entity.Enable = model.Enable;
                entity.CategoryUuid = model.CategoryUuid;

                var updated = _productRepository.Update(entity);

                return updated > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public bool DeleteProduct(string uuid)
        {
            try
            {
                Product entity = _productRepository.GetByParameter(new { Uuid = uuid });
                if (entity is null) throw new Exception(Common.Messages.Database.RegisterNotFound);

                var deleted = _productRepository.Delete(entity.Id);

                return deleted > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}