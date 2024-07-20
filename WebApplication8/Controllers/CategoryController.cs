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
            if(category.Name.ToLower() == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "it is same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View();
        }
     
       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var exists = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (exists == null)
            {
                return NotFound();
            }
            return View(exists);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
           var obj = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
           if(obj == null) { return NotFound(); }
           _db.Categories.Remove(obj);
           _db.SaveChanges();
           return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var exists =_db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (exists==null)
            {
               return NotFound();
            }
            return View(exists);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
