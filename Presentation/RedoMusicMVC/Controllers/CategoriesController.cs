using Microsoft.AspNetCore.Mvc;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly RedoMusicDbcontext dbcontext;


        public CategoriesController()
        {
            dbcontext = new RedoMusicDbcontext();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetCategory()
        {

            return View(dbcontext.Categories.ToList());
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string categoryName)
        {
            Category category= new Category(categoryName);
            dbcontext.Categories.Add(category);
            dbcontext.SaveChanges();

            return RedirectToAction("AddCategory");
        }






    }
}
