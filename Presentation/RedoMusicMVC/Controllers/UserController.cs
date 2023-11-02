using Microsoft.AspNetCore.Mvc;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
	public class UserController : Controller
	{
		private readonly RedoMusicDbcontext _redoMusicDbContext;

		public UserController() 
		{
            _redoMusicDbContext = new();
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

        [HttpPost]
        public RedirectToActionResult Register(string name, string email, string password)
        {
            bool isEmailInUse = _redoMusicDbContext.Users.Any(u => u.UserEmail == email);

            if (isEmailInUse)
            {
                // E-posta zaten kullanılıyorsa burada işlem yapabilirsiniz
                // Örneğin, kullanıcıya bir hata mesajı gösterip geri dönebilirsiniz.
                return RedirectToAction("Register");
            }
            else
            {
                // E-posta kullanılmıyorsa yeni kullanıcıyı oluşturun
                User user = new User(name, email, password);
                _redoMusicDbContext.Users.Add(user);
                _redoMusicDbContext.SaveChanges();
                return RedirectToAction("Login");

                // Kullanıcı başarıyla eklendiyse başka bir işlem yapabilirsiniz
            }

        }

        [HttpGet]
        public IActionResult Login()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            bool isEmailInUse = _redoMusicDbContext.Users.Any(u => u.UserEmail == email);

            if (!isEmailInUse)
            {
                //Email Not Found
                return RedirectToAction("Login");
            }
            else
            {
                string userPassword = _redoMusicDbContext.Users
                    .Where(u => u.UserEmail == email)
                    .Select(u => u.Password)
                    .FirstOrDefault();

                if (userPassword != null && string.Equals(userPassword, password))
                {
                    // Basarılı Giris
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


    }
}
