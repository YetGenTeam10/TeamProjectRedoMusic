using Microsoft.AspNetCore.Mvc;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly RedoMusicDbcontext dbcontext;

        public IActionResult Index()
        {
            return View();
        }
    }
}
