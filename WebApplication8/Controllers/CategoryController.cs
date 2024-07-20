using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
   
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete() { return View(); }

        [HttpPost]
        public IActionResult Delete(string Name)
        {
            var obj = _db.Categories.Where(c => c.Name == Name).FirstOrDefault();
            _db.Categories.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
