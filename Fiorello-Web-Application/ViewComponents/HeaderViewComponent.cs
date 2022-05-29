using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_Web_Application.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> IncokeAsync()
        {
             Bio bios =  _context.Bio.FirstOrDefault();
            return View(await Task.FromResult(bios));
        }
    }
}
