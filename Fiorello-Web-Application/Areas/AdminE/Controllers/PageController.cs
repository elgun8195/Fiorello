using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_Web_Application.Areas.AdminE.Controllers
{
        [Area("AdminE")]
    public class PageController : Controller
    {
        private readonly AppDbContext _context;
        public PageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PageIntro pageIntro = _context.PageIntros.FirstOrDefault();
            return View(pageIntro);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PageIntro pageIntro = await _context.PageIntros.FindAsync(id);
            if (pageIntro == null)
            {
                return NotFound();
            }
            return View(pageIntro);
        }
      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PageIntro page = await _context.PageIntros.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            _context.PageIntros.Remove(page);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteAll()
        {
            List<PageIntro> pageIntros = _context.PageIntros.ToList();
            foreach (var item in pageIntros)
            {

                if (pageIntros == null)
                {
                    return NotFound();
                }
                _context.PageIntros.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PageIntro pageIntro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExistName = _context.PageIntros.Any(c => c.Title.ToLower() == pageIntro.Title.ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Title", "eyni adda title olmaz");
                return View();
            }
            PageIntro pageIntro1 = new PageIntro();
            pageIntro1.Title = pageIntro.Title;
            pageIntro1.Desc= pageIntro.Desc;
            pageIntro1.ImageUrl= pageIntro.ImageUrl;
            await _context.PageIntros.AddAsync(pageIntro1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Updatem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PageIntro dbpageIntro = await _context.PageIntros.FindAsync(id);
            if (dbpageIntro == null) return BadRequest();
            return View(dbpageIntro);
        }
        [HttpPost]
        public async Task<IActionResult> Updatem(int? id, PageIntro pageIntro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            PageIntro dbpageIntro = await _context.PageIntros.FindAsync(id);
            PageIntro existNamePageintro = _context.PageIntros.FirstOrDefault(c => c.Title.ToLower() == pageIntro.Title.ToLower());
            if (existNamePageintro != null)
            {
                if (dbpageIntro != existNamePageintro)
                {
                    ModelState.AddModelError("Name", "Name Already Exist");
                    return View();
                }
            }
            if (dbpageIntro == null) return BadRequest();
            dbpageIntro.Title = pageIntro.Title;
            dbpageIntro.Desc = pageIntro.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
