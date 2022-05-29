using Fiorello_Web_Application.DAL;
using Fiorello_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_Web_Application.Areas.AdminE.Controllers
{
    [Area("AdminE")]
    public class BioController : Controller
    {
        private readonly AppDbContext _context;
        public BioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Infdex()
        {
            Bio bio = _context.Bio.FirstOrDefault();
            return View(bio);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Bio pageIntro = await _context.Bio.FindAsync(id);
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
            Bio bio = await _context.Bio.FindAsync(id);
            if (bio == null)
            {
                return NotFound();
            }
            _context.Bio.Remove(bio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteAll()
        {
            List<Bio> pageIntros = _context.Bio.ToList();
            foreach (var item in pageIntros)
            {

                if (pageIntros == null)
                {
                    return NotFound();
                }
                _context.Bio.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Bio pageIntro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExistName = _context.Bio.Any(c => c.Author.ToLower() == pageIntro.Author.ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Author", "eyni adda Author olmaz");
                return View();
            }
            Bio pageIntro1 = new Bio();
            pageIntro1.Facebook = pageIntro.Facebook;
            pageIntro1.Linkedin = pageIntro.Linkedin;
            pageIntro1.Author = pageIntro.Author;
            pageIntro.Imageurl=pageIntro1.Imageurl;
            await _context.Bio.AddAsync(pageIntro1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Updatem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Bio dbpageIntro = await _context.Bio.FindAsync(id);
            if (dbpageIntro == null) return BadRequest();
            return View(dbpageIntro);
        }
        [HttpPost]
        public async Task<IActionResult> Updatem(int? id, Bio pageIntro)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Bio dbpageIntro = await _context.Bio.FindAsync(id);
            Bio existNamePageintro = _context.Bio.FirstOrDefault(c => c.Author.ToLower() == pageIntro.Author.ToLower());
            if (existNamePageintro != null)
            {
                if (dbpageIntro != existNamePageintro)
                {
                    ModelState.AddModelError("Author", "Author Already Exist");
                    return View();
                }
            }
            if (dbpageIntro == null) return BadRequest();
            dbpageIntro.Author = pageIntro.Author;
            dbpageIntro.Facebook = pageIntro.Facebook;
            dbpageIntro.Linkedin= pageIntro.Linkedin;
            dbpageIntro.Imageurl = pageIntro.Imageurl;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
