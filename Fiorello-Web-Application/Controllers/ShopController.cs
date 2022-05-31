using Fiorello_Web_Application.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web_Application.Controllers
{
    public class ShopController : Controller
    {
        private AppDbContext _context;
        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
