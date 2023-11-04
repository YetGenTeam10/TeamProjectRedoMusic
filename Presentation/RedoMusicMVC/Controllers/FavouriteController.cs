using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;
using System.Diagnostics.Metrics;
using System.Linq;

namespace RedoMusicMVC.Controllers
{
    public class FavouriteController : Controller
    {

        private readonly RedoMusicDbcontext _redoMusicDbcontext;

        public FavouriteController()
        {
            _redoMusicDbcontext = new RedoMusicDbcontext();
        }

        public IActionResult Index()
        {
            Guid userId;
            User user = new User();
            List<RedoMusic.Domain.Entities.Instrument> instruments = new List<RedoMusic.Domain.Entities.Instrument>();

            if (HttpContext.Session.GetString("userId") != null)
            {
                userId = new Guid(HttpContext.Session.GetString("userId")); // Oturumdan userId'yi al
                user = _redoMusicDbcontext.Users.FirstOrDefault(u => u.Id == userId);
                

                if (userId != Guid.Empty)
                {
                    var favourites = _redoMusicDbcontext.Favourites.Include(f => f.Instrument).ToList();

                    foreach (var favourite in favourites)
                    {

                        instruments.Add(new RedoMusic.Domain.Entities.Instrument(favourite.Instrument.Name, favourite.Instrument.Description, favourite.Instrument.Brand, favourite.Instrument.Color, favourite.Instrument.ProductionYear, favourite.Instrument.Barcode, favourite.Instrument.Picture, favourite.Instrument.Price, favourite.Instrument.Category));
                    }

                }
                else
                {
                    // Kullanıcı kimlik bilgisi mevcut değilse, giriş yapmış bir kullanıcı yoktur.
                    // Kullanıcıyı giriş sayfasına yönlendirebilirsiniz.
                }
            }
            return View(instruments);
        }

        [HttpGet]
        public RedirectToActionResult Add(string barcode)
        {
            Guid userId;
            User user = new User();

            RedoMusic.Domain.Entities.Instrument instrument = _redoMusicDbcontext.Instruments.FirstOrDefault(u => u.Barcode == barcode);

            if (HttpContext.Session.GetString("userId") != null)
            {
                userId = new Guid(HttpContext.Session.GetString("userId")); // Oturumdan userId'yi al
                user = _redoMusicDbcontext.Users.FirstOrDefault(u => u.Id == userId);
                

                if (userId != Guid.Empty)
                {

                    _redoMusicDbcontext.Favourites.Add(new Favourite(instrument, user));
                    _redoMusicDbcontext.SaveChanges();
                }
                else
                {
                    // Kullanıcı kimlik bilgisi mevcut değilse, giriş yapmış bir kullanıcı yoktur.
                    // Kullanıcıyı giriş sayfasına yönlendirebilirsiniz.
                }


            }
            else
            {
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public RedirectToActionResult Remove(string barcode)
        {
            Guid userId;
            User user = new User();

            RedoMusic.Domain.Entities.Instrument instrument = _redoMusicDbcontext.Instruments.FirstOrDefault(u => u.Barcode == barcode);

            if (HttpContext.Session.GetString("userId") != null)
            {
                userId = new Guid(HttpContext.Session.GetString("userId")); // Oturumdan userId'yi al
                user = _redoMusicDbcontext.Users.FirstOrDefault(u => u.Id == userId);

                var matchingFavourite = _redoMusicDbcontext.Favourites
                    .FirstOrDefault(f => f.User.Id == userId && f.Instrument.Id == instrument.Id);

                if (userId != Guid.Empty && matchingFavourite != null)
                {
                    _redoMusicDbcontext.Favourites.Remove(matchingFavourite);
                    _redoMusicDbcontext.SaveChanges();
                }


                    
                

                    
                
                else
                {
                    // Kullanıcı kimlik bilgisi mevcut değilse, giriş yapmış bir kullanıcı yoktur.
                    // Kullanıcıyı giriş sayfasına yönlendirebilirsiniz.
                }


            }
            else
            {
            }

            return RedirectToAction("Index", "Favourite");

        }


    }
}
