using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedoMusic.Domain.Entities;
using RedoMusic.Domain.Enums;
using RedoMusic.Persistence.Contexts;
using RedoMusicMVC.Models;
using System.Drawing.Drawing2D;

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
            var products = _dbContext.Instruments.Include(x => x.Brand).Include(x => x.Category).ToList();

            return View(products);
        }

        //Add method:
        [HttpGet]
        public IActionResult Add()
        {
            var brands = _dbContext.Brands.ToList();

            var categories = _dbContext.Categories.ToList();

            var addInstruments = new InstrumentAddBrandCategory
            {
                Brands = brands,
                Categories = categories,
                Instrument = new Instrument()
            };

            return View(addInstruments);
        }


        [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string price, string barcode, string pictureUrl, string categoryId, DateTime? productionYear, string color)
        {
            var brand = _dbContext.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();
            var category = _dbContext.Categories.Where(x => x.Id == Guid.Parse(categoryId)).FirstOrDefault();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(price))
            {
                // Gerekli alanlar boşsa veya null ise, hata mesajı oluşturun ve geri dönün.
                ModelState.AddModelError("Validation", "Name, Description, Barcode, and Price are required.");
                return View();
            }
            var instrument = new RedoMusic.Domain.Entities.Instrument()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Barcode = barcode,
                Price = decimal.Parse(price),
                Picture = pictureUrl,  // Burada "Picture" özelliğine bir değer atıyoruz
                Color = (RedoMusic.Domain.Enums.ColorType)Convert.ToInt32(color),
                ProductionYear = DateTime.UtcNow,
                Brand = brand,
                Category = category,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                CreatedByUserId = "LivanurErdem",
            };

            _dbContext.Instruments.Add(instrument);

            _dbContext.SaveChanges();

            return RedirectToAction("add");
        }
        [HttpGet]
        //Delete method:
        // [Route("[controller]/[action]/{id}")]
        public IActionResult DeleteInstrument(string id)
        {
            var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            _dbContext.Instruments.Remove(instrument);

            instrument.DeletedByUserId = "LivanurErdem";
            instrument.DeletedOn = DateTime.UtcNow;
            instrument.IsDeleted = true;

            _dbContext.SaveChanges();

            return RedirectToAction("index");
        }

        //Update method:
        [HttpGet]
        public IActionResult UpdateInstrument(Guid id)
        {
            var instrument = _dbContext.Instruments.Include(x => x.Brand).Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            var brands = _dbContext.Brands.ToList();
            var categories = _dbContext.Categories.ToList();

            var addInstrument = new InstrumentAddBrandCategory
            {
                Instrument = instrument,
                Brands = brands,
                Categories = categories
            };

            return View(addInstrument);
        }

        [HttpPost]
        public IActionResult UpdateInstrument(string id, string name, string description, string barcode, decimal price, string pictureUrl, DateTime? productionYear, ColorType color)
        {
            if (ModelState.IsValid)
            {
                var existingInstrument = _dbContext.Instruments.Include(x => x.Brand).Include(x => x.Category).FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (existingInstrument != null)
                {
                    existingInstrument.Name = name;
                    existingInstrument.Description = description;
                    existingInstrument.Barcode = barcode;
                    existingInstrument.Price = price;
                    existingInstrument.Picture = pictureUrl;
                    existingInstrument.ProductionYear = DateTime.UtcNow;
                    existingInstrument.Color = color;

                    _dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        //Update Method2: 
        /* [HttpGet]
         [Route("[controller]/[action]/{id}")]
         public IActionResult UpdateInstrument([FromRoute] string id)
         {
             InstrumentRequest instrumentRequest = new();

             //id'ye bağlı olarak kategori getirme
             var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

             // güncellenen name null değilse update işlemi gerçekleşir.
             if (instrumentRequest.Name != null)
             {
                 instrument.Name = instrumentRequest.Name;
                 instrument.Barcode = instrumentRequest.Barcode;
                 instrument.Color = instrumentRequest.Color;
                 instrument.Picture = instrumentRequest.Picture;
                 instrument.Brand = instrumentRequest.Brand;
                 instrument.Price = instrumentRequest.Price;
                 instrument.Category = instrumentRequest.Category;
                 instrument.ProductionYear = instrumentRequest.ProductionYear;
                
             }


             instrument.CreatedByUserId = instrumentRequest.CreatedByUserId;
             instrument.ModifiedByUserId = "LivanurErdem";
             instrument.ModifiedOn = DateTime.UtcNow;
             instrument.IsDeleted = false;

             _dbContext.SaveChanges();

             return View();
         }*/




        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Details(string id)
        {
            var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            if (instrument != null)
            {
                // Instrument nesnesinin Picture özelliğinde URL varsa, resmi görüntüle.
                if (!string.IsNullOrEmpty(instrument.Picture))
                {
                    return View(instrument);
                }
            }
            _dbContext.SaveChanges();
            return View(instrument);
        }


    }
}
