using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SampleProductManagementApp.Data;

namespace SampleProductManagementApp.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                _context.Product.Add(product);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool DeleteProduct(int ProductId)
        {
            Product? product = _context.Product.FirstOrDefault(x => x.Id == ProductId);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
                
                return true;
            }

            return false;
        }

        public bool UpdateProduct(Product updatedProduct)
        {
            if (!_context.Product.Any(x => x.Id == updatedProduct.Id))
            {
                return false;
            }
            _context.Entry(updatedProduct).State = EntityState.Modified;

            _context.SaveChanges();

            return true;

        }

        public Product? GetProduct(int ProductId)
        {
            return _context.Product.FirstOrDefault(x => x.Id == ProductId);
        }

        public List<Product> GetAllProducts() 
        {            
            return _context.Product.ToList();
        }
    }
}
