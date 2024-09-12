using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleProductManagementApp.Data;

namespace SampleProductManagementApp.Pages.ProductPages
{
    public class IndexModel : PageModel
    {
        private readonly SampleProductManagementApp.Data.ApplicationDbContext _context;

        public IndexModel(SampleProductManagementApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
