using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_Web_Application.Areas.AdminE.Controllers
{
    [Area("AdminE")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Category categories =await _context.Categories.FindAsync(id);
            if (categories==null)
            {
                return NotFound();
            }
            return View(categories);
        }
        public async Task<IActionResult> Update(int? id,string title)
        {
            if (id == null || title==null)
            {
                return NotFound();
            }
            Category categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            categories.Desc= title;
            return View(categories);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteAll()
        {
            List<Category> categories = _context.Categories.ToList();
            foreach (var item in categories)
            {

            if (categories == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
