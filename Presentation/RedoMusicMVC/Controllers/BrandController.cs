using Microsoft.AspNetCore.Mvc;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly RedoMusicDbcontext dbcontext;


        public BrandController()
        {
            dbcontext = new RedoMusicDbcontext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetBrands()
        {

            return View(dbcontext.Brands.ToList());
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string brandName, string brandDisplayText, string brandAddress) 
        { 
            Brand brand = new Brand(brandName, brandDisplayText, brandAddress);
            dbcontext.Brands.Add(brand);
            dbcontext.SaveChanges();

            return RedirectToAction("Add");
        }
    }
}
