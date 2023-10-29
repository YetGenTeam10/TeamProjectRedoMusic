using Microsoft.AspNetCore.Mvc;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly RedoMusicDbcontext _dbcontext;


        public UserController() 
        {
            _dbcontext = new RedoMusicDbcontext();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string usersurname, string useremail, string password)
        {
            User user = new User(username, usersurname, useremail, password);

            if (_dbcontext.Users.Any(u => u.Email == useremail))
            {
                ModelState.AddModelError("", "Bu e-posta zaten kullanılıyor.");
            }
            else
            {
                _dbcontext.Users.Add(user);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index", "Home");
                


            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string useremail, string password)
        {
            User user = _dbcontext.Users.FirstOrDefault(u => u.Email == useremail);

            if (user == null)
            {
                ModelState.AddModelError("", "User With That Email Not Found.");
            }else if(user.Password != password)
            {
                ModelState.AddModelError("", "Password is Not Correct.");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}
