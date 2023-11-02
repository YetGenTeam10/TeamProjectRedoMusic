using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;
using RedoMusicMVC.Views.Models;

namespace RedoMusicMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RedoMusicDbcontext dbcontext;

        public CategoryController()
        {
            dbcontext = new();
        }

        public IActionResult Index()
        {
            var category = dbcontext.Categories.ToList();

            return View(category);
        }

        //Add Method
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string categoryName)
        {
            Category category= new ();
            category.CategoryName = categoryName;
            category.CreatedOn = DateTime.UtcNow;
            category.IsDeleted = false;
            category.CreatedByUserId = "nejlakucuk";
            dbcontext.Categories.Add(category);
            dbcontext.SaveChanges();

            return RedirectToAction("Add");
        }


        // Delete Method
        [HttpGet]
        public IActionResult Delete(string id)
        {

            var category= dbcontext.Categories.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            dbcontext.Categories.Remove(category);

            category.DeletedByUserId = "nejlakucuk";
            category.DeletedOn = DateTime.UtcNow;
            category.IsDeleted = true;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        //Update Method
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(string id)
        {
            CategoryRequest categoryRequest = new();

            //id'ye baðlý olarak kategori getirme
            var category = dbcontext.Categories.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            // güncellenen name null deðilse update iþlemi gerçekleþir.
            if (categoryRequest.CategoryName != null)
            {
                category.CategoryName = categoryRequest.CategoryName;
            }

                
            category.CreatedByUserId = categoryRequest.CreatedByUserId;
            category.ModifiedByUserId = "nejlakucuk";
            category.ModifiedOn = DateTime.UtcNow;
            category.IsDeleted = false;

            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
