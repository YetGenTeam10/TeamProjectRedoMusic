using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence;
using RedoMusic.Persistence.Contexts;
using RedoMusicMVC.Models;
using System.Diagnostics;

namespace RedoMusicMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RedoMusicDbcontext _redoMusicDbcontext;

        public HomeController(ILogger<HomeController> logger)
        {
            _redoMusicDbcontext = new();
            _logger = logger;
        }

        public IActionResult Index()
        {

            
            var instruments = _redoMusicDbcontext.Instruments.ToList();
            MyViewModel myViewModel = new MyViewModel();

            // Başka bir sayfada kullanıcı kimlik bilgisine erişim
            Guid userId;
            User user = new User();
            if (HttpContext.Session.GetString("userId") != null)
            {

                userId = new Guid(HttpContext.Session.GetString("userId")); // Oturumdan userId'yi al
                user = _redoMusicDbcontext.Users.FirstOrDefault(u => u.Id == userId);

                if (userId != Guid.Empty)
                {
                    // Kullanıcı kimlik bilgisi mevcutsa, işlem yapabilirsiniz
                }
                else
                {
                    // Kullanıcı kimlik bilgisi mevcut değilse, giriş yapmış bir kullanıcı yoktur.
                    // Kullanıcıyı giriş sayfasına yönlendirebilirsiniz.
                }
            }

            Configurations.GetString("ConnectionStrings:PostgreSQL");
            myViewModel.User = user;
            myViewModel.Instruments = instruments;

            return View(myViewModel);


}

public class MyViewModel
{
    public User User { get; set; }
    public List<Instrument> Instruments { get; set; }
}