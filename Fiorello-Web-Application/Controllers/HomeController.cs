using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Fiorello_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiorello_Web_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM();
            homeVM.Slider = _context.Sliders.ToList();
            homeVM.Bio=_context.Bio.FirstOrDefault();
            homeVM.PageIntro = _context.PageIntros.FirstOrDefault();
            homeVM.Products = _context.Products.Include(p=>p.Category).ToList();
            homeVM.Categories=_context.Categories.ToList();
            return View(homeVM);
        }
    }
}
