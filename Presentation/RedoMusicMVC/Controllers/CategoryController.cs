using Microsoft.AspNetCore.Mvc;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RedoMusicDbcontext _dbcontext;

        public CategoryController()
        {
            _dbcontext = new();
        }

        [HttpGet]
        public IActionResult GetCategory()
        {

            return View(_dbcontext.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string categoryName)
        {
            Category category= new Category(categoryName);
            _dbcontext.Categories.Add(category);
            _dbcontext.SaveChanges();

            return RedirectToAction("AddCategory");
        }

    }
}
