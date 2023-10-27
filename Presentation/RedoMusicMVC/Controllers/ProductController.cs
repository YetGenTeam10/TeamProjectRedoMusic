using Microsoft.AspNetCore.Mvc;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly RedoMusicDbcontext dbcontext;


        public ProductController()
        {
            dbcontext = new RedoMusicDbcontext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
