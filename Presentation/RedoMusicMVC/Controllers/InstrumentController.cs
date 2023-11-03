using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;

namespace RedoMusicMVC.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly RedoMusicDbcontext _dbContext;

        public InstrumentController()
        {
            _dbContext = new();
        }
        public IActionResult Index()
        {
            var products = _dbContext.Instruments.ToList();

            return View(products);
        }

           [HttpGet]
            public IActionResult Add()
            {
                var brands = _dbContext.Brands.ToList();
                var brandList = new SelectList(brands, "Id", "Name");
                ViewData["BrandList"] = brandList;

               /*var categories = _dbContext.Categories.ToList();
                var categoriesList = new SelectList(categories, "Id", "Name");
                ViewData["CategoriesList"] = categoriesList;*/
                return View();

            }
            [HttpPost]
            public IActionResult Add(Instrument instrument, string brandId, string categoryId)
            {
                var category = _dbContext.Categories.Where(x => x.Id == Guid.Parse(categoryId)).FirstOrDefault();
                /*if (category == null)
                {
                    ModelState.AddModelError("instrument.Category.Id", "Invalid Category selected.");
                    return View(instrument);
                }*/


                var brand = _dbContext.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();

                instrument.Id = Guid.NewGuid();
                instrument.Name = $"{instrument.Name}";
                instrument.Description = $"{instrument.Description}";
                instrument.Barcode = $"{instrument.Barcode}";
                instrument.Picture = $"{instrument.Picture}";
                instrument.ProductionYear = instrument.ProductionYear;
                instrument.Price = instrument.Price;
                instrument.Brand = brand;
                //instrument.Category = category;
                instrument.CreatedOn = DateTime.UtcNow;
                instrument.IsDeleted = false;
                instrument.CreatedByUserId = "LivanurErdem";

                _dbContext.Instruments.Add(instrument);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            

       /* [HttpGet]
        public IActionResult Add()
        {
            var brands = _dbContext.Brands.ToList();
            // var categories = _dbContext.Categories.ToList();
            return View(brands);
        }

        [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string price, string barcode, string pictureUrl, string categoryId)
        {
            var brand = _dbContext.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();
            //var category = _dbContext.Categories.Where(x => x.Id == Guid.Parse(categoryId)).FirstOrDefault();

            var instrument = new RedoMusic.Domain.Entities.Instrument()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Barcode = barcode,
                Brand = brand,
                //Category = category,
                CreatedOn = DateTime.UtcNow,
                Picture = pictureUrl,
                IsDeleted = false,
                CreatedByUserId = "LivanurErdem",
            };

            _dbContext.Instruments.Add(instrument);

            _dbContext.SaveChanges();

            return RedirectToAction("add");
        }*/


        [Route("[controller]/[action]/{id}")]
        public IActionResult Delete(string id)
        {
            var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _dbContext.Instruments.Remove(instrument);

            _dbContext.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Inspect(string id)
        {
            var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _dbContext.SaveChanges();

            return View(instrument);
        }


    }
}
