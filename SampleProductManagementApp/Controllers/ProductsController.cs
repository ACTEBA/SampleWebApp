using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleProductManagementApp.Data;
using SampleProductManagementApp.Services;

namespace SampleProductManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductServices _productServices;

        public ProductsController(ApplicationDbContext context, IProductServices productServices)
        {
            _context = context;
            _productServices = productServices;
        }

        // GET: api/Products
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            List<Product> products = _productServices.GetAllProducts();

            return products;
        }

        // GET: api/Products/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Product? product = _productServices.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            bool success = _productServices.UpdateProduct(product);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            bool success = _productServices.CreateProduct(product);
            if (success)
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            else
                return BadRequest();
        }

        // DELETE: api/Products/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var success = _productServices.DeleteProduct(id);
            
            if (success)
                return NoContent();
            else
                return NotFound();
        }
    }
}
