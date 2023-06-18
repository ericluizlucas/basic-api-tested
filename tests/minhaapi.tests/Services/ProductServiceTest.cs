using AutoMapper;
using minhaapi.Infrastructure.Interfaces;
using minhaapi.Services;
using Moq;

namespace minhaapi.tests.Services
{
    public class ProductServiceTest
    {
        private ProductService _service;

        public ProductServiceTest()
        {
            _service = new ProductService(new Mock<IProductRepository>().Object, new Mock<ICategoryRepository>().Object, new Mock<IMapper>().Object);
        }

        [Test]
        public void CreateCategory_SendingNullNome()
        {
            var exception = Assert.Throws<Exception>(() => _service.CreateCategory(new Common.Models.CategoryModel{}));
            Assert.That(Common.Messages.Validation.NullNome, Is.EqualTo(exception?.Message));
        }

        [Test]
        public void UpdateCategory_SendingNullNome()
        {
            var exception = Assert.Throws<Exception>(() => _service.UpdateCategory(new Common.Models.CategoryModel{}));
            Assert.That(Common.Messages.Validation.NullNome, Is.EqualTo(exception?.Message));
        }

        [Test]
        public void CreateProduct_SendingNullNome()
        {
            var exception = Assert.Throws<Exception>(() => _service.CreateProduct(new Common.Models.ProductModel{}));
            Assert.That(Common.Messages.Validation.NullNome, Is.EqualTo(exception?.Message));
        }
        
        [Test]
        public void UpdateProduct_SendingNullNome()
        {
            var exception = Assert.Throws<Exception>(() => _service.UpdateProduct(new Common.Models.ProductModel{CategoryUuid = "test"}));
            Assert.That(Common.Messages.Validation.NullNome, Is.EqualTo(exception?.Message));
        }

        [Test]
        public void UpdateProduct_SendingNullCategoryUuid()
        {
            var exception = Assert.Throws<Exception>(() => _service.UpdateProduct(new Common.Models.ProductModel{Nome = "nome"}));
            Assert.That(Common.Messages.Validation.NullCategory, Is.EqualTo(exception?.Message));
        }
    }
}