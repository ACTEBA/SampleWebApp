using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProductManagementApp.Data;

namespace SampleProductManagementApp.Services
{
    public interface IProductServices
    {

        public bool CreateProduct(Product product);

        public bool DeleteProduct(int ProductId);

        public bool UpdateProduct(Product updatedProduct);

        public Product? GetProduct(int ProductId);

        public List<Product> GetAllProducts();
    }
}
