using Microsoft.AspNetCore.Mvc;

namespace RedoMusicMVC.Controllers
{
    public class InstrumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
