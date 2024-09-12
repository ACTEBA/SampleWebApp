using Microsoft.EntityFrameworkCore;
using SampleProductManagementApp.Data;
namespace SampleProductManagementApp.Services.Tests
{
    [TestClass()]
    public class ProductServicesTests
    {
        [TestMethod()]
        public void CreateProductTest()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new ApplicationDbContext(options);

            ProductServices productServices = new ProductServices(context);

            Product testProduct = new Product()
            {
                Name = "Test Product",
                Price = 20,
                Description = "Test Description"
            };

            bool success = productServices.CreateProduct(testProduct);

            Assert.IsTrue(success);
            Assert.AreEqual("Test Product", productServices.GetAllProducts().First().Name);
        }


        [TestMethod()]
        public void UpdateProductTest()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new ApplicationDbContext(options);

            ProductServices productServices = new ProductServices(context);

            Product testProduct = new Product()
            {
                Name = "Test Product",
                Price = 20,
                Description = "Test Description to Update"
            };

            bool success = productServices.CreateProduct(testProduct);

            Assert.IsTrue(success);

            Product createdProduct = productServices.GetAllProducts().First();

            createdProduct.Description = "Updated Description";

            bool updated = productServices.UpdateProduct(createdProduct);

            Assert.IsTrue(updated);

            Assert.AreEqual("Updated Description", productServices.GetAllProducts().First().Description);
        }


        [TestMethod()]
        public void DeleteProductTest()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new ApplicationDbContext(options);

            ProductServices productServices = new ProductServices(context);

            Product testProduct = new Product()
            {
                Name = "Test Product",
                Price = 20,
                Description = "Test Description"
            };

            bool success = productServices.CreateProduct(testProduct);

            Assert.IsTrue(success);

            Product product = productServices.GetAllProducts().First();

            Assert.AreEqual("Test Product", product.Name);

            int productId = product.Id;

            bool deleted = productServices.DeleteProduct(productId);

            Assert.IsTrue(deleted);

            Product? deletedProduct = productServices.GetProduct(productId);

            Assert.IsNull(deletedProduct);

        }

        [TestMethod()]
        public void GetProductTest()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new ApplicationDbContext(options);

            ProductServices productServices = new ProductServices(context);

            Product testProduct = new Product()
            {
                Name = "Test Product",
                Price = 20,
                Description = "Test Description"
            };

            bool success = productServices.CreateProduct(testProduct);

            Assert.IsTrue(success);

            int productId = productServices.GetAllProducts().First().Id;

            Product? product = productServices.GetProduct(productId);

            Assert.IsNotNull(product);
        }

    }
}