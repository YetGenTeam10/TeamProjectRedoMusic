using Microsoft.AspNetCore.Mvc;

namespace RedoMusicMVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
