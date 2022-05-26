using Microsoft.AspNetCore.Mvc;

namespace Fiorello_Web_Application.Areas.AdminE.Controllers
{
    [Area("AdminE")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
