using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_Web_Application.ViewComponents
{
    public class ProductsViewComponent: ViewComponent
    {
    private AppDbContext _context;
    public ProductsViewComponent(AppDbContext context)
    {
        _context = context;
    }
        public async Task<IViewComponentResult> IncokeAsync()
        {
            List<Product> products=_context.Products.Include(p=>p.Category).Take(2).ToList();
            return View(await Task.FromResult(products));
        } 
    }
}
