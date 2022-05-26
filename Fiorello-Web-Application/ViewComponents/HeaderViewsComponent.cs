using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_Web_Application.ViewComponents
{
   
    public class HeaderViewsComponent : ViewComponent
    {
        private AppDbContext _context;
        public HeaderViewsComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> IncokeAsync()
        {
            Bio bio = _context.Bio.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }
    }
}
