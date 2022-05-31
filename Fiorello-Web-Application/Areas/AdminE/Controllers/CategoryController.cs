

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
            if (id == null)
            {
                return NotFound();
            }
            Category categories = await _context.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
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


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExistName = _context.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Name", "eyni adda name olmaz");
                return View();
            }
            Category category1 = new Category();
            category1.Name = category.Name;
            category1.Desc = category.Desc;
            await _context.Categories.AddAsync(category1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Updatem(int?id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Category dbcategory = await _context.Categories.FindAsync(id);
            if (dbcategory == null) return BadRequest();
            return View(dbcategory);
        }
        [HttpPost]
        public async Task<IActionResult> Updatem(int? id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category dbcategory = await _context.Categories.FindAsync(id);
            Category existNameCategory=_context.Categories.FirstOrDefault(c => c.Name.ToLower() == category.Name.ToLower());
            if (existNameCategory!=null)
            {
                if (dbcategory!=existNameCategory)
                {
                    ModelState.AddModelError("Name", "Name Already Exist");
                    return View();
                }
            }
            if (dbcategory == null) return BadRequest();
            dbcategory.Name = category.Name;
            dbcategory.Desc = category.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
