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
		public IActionResult Add()
		{
			return View();
		}

        [HttpPost]
        public void Add(string name, string email, string password)
        {
            bool isEmailInUse = _redoMusicDbContext.Users.Any(u => u.UserEmail == email);

            if (isEmailInUse)
            {
                // E-posta zaten kullanılıyorsa burada işlem yapabilirsiniz
                // Örneğin, kullanıcıya bir hata mesajı gösterip geri dönebilirsiniz.
            }
            else
            {
                // E-posta kullanılmıyorsa yeni kullanıcıyı oluşturun
                User user = new User(name, email, password);
                _redoMusicDbContext.Users.Add(user);
                _redoMusicDbContext.SaveChanges();

                // Kullanıcı başarıyla eklendiyse başka bir işlem yapabilirsiniz
            }
        }

        public IActionResult Login()
		{
			return View();
		}


	}
}
