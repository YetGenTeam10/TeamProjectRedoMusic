using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedoMusic.Domain.Entities;
using RedoMusic.Persistence.Contexts;
using RedoMusicMVC.Models;
using RedoMusicMVC.Views.Models;

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

        //hata alıyorum:
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

        /*[HttpGet]
        public IActionResult Add()
        {
            var brands = _dbContext.Brands.ToList();
            var categories = _dbContext.Categories.ToList();

            if (brands == null)
            {
                brands = new List<Brand>(); // Brands null ise boş bir liste oluştur.
            }

            if (categories == null)
            {
                categories = new List<Category>(); // Categories null ise boş bir liste oluştur.
            }

            var addInstruments = new InstrumentAddBrandCategory
            {
                Brands = brands,
                Categories = categories,
                Instrument = new Instrument()
            };

            return View(addInstruments);
        }*/


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
                Brand = brand,
                Category = category,
                ProductionYear = DateTime.UtcNow,
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
        //nejla ile yaptığım:
       /* [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult UpdateInstrument([FromRoute] string id)
        {  
            InstrumentRequest instrumentRequest = new();
          
                var instrument = _dbContext.Instruments.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (instrument != null)
                {
                    instrument.Name = instrumentRequest.Name;
                    instrument.Description = instrumentRequest.Description;
                    instrument.Barcode = instrumentRequest.Barcode;
                    instrument.ProductionYear = instrumentRequest.ProductionYear;
                    instrument.Price = instrumentRequest.Price;
                    instrument.Picture = instrumentRequest.Picture;
                    instrument.Color = instrumentRequest.Color;
                    instrument.Brand = instrumentRequest.Brand;
                    instrument.Category = instrumentRequest.Category;

       
                }

            instrument.CreatedByUserId = "LivanurErdem";

           var brands = _dbContext.Brands.ToList();
            var categories = _dbContext.Categories.ToList();

            var addInstrument = new InstrumentAddBrandCategory
            {
                Instrument = instrument,
                Brands = brands,
                Categories = categories
            };

         _dbContext.SaveChanges();

          return RedirectToAction("UpdateInstrument");
      }*/

        //ilk yaptığım
        /* [HttpGet]
         public IActionResult UpdateInstrument(Guid id)
         {
             var instrument = _dbContext.Instruments.FirstOrDefault(x => x.Id == id);
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
         public IActionResult UpdateInstrument(Instrument instrument)
         {
             if (ModelState.IsValid)
             {
                 var existingInstrument = _dbContext.Instruments.FirstOrDefault(x => x.Id == instrument.Id);
                 if (existingInstrument != null)
                 {
                     existingInstrument.Name = instrument.Name;
                     existingInstrument.Description = instrument.Description;
                     existingInstrument.Barcode = instrument.Barcode;
                     existingInstrument.ProductionYear = instrument.ProductionYear;
                     existingInstrument.Price = instrument.Price;
                     existingInstrument.Picture = instrument.Picture;
                     existingInstrument.Color = instrument.Color;
                     existingInstrument.Brand = instrument.Brand;
                     existingInstrument.Category = instrument.Category;

                     _dbContext.SaveChanges();
                 }

                 return RedirectToAction("Index");
             }

             var brands = _dbContext.Brands.ToList();
             var categories = _dbContext.Categories.ToList();

             var addInstrument = new InstrumentAddBrandCategory
             {
                 Instrument = instrument,
                 Brands = brands,
                 Categories = categories
             };

             return View(addInstrument);
         }*/
        [HttpGet]
        public IActionResult UpdateInstrument(Guid id)
        {
            var instrument = _dbContext.Instruments.FirstOrDefault(x => x.Id == id);
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
        public IActionResult UpdateInstrument(Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                var existingInstrument = _dbContext.Instruments.FirstOrDefault(x => x.Id == instrument.Id);
                if (existingInstrument != null)
                {
                    existingInstrument.Name = instrument.Name;
                    existingInstrument.Description = instrument.Description;
                    existingInstrument.Barcode = instrument.Barcode;
                    existingInstrument.ProductionYear = instrument.ProductionYear;
                    existingInstrument.Price = instrument.Price;
                    existingInstrument.Picture = instrument.Picture;
                    existingInstrument.Color = instrument.Color;
                    existingInstrument.Brand = instrument.Brand;
                    existingInstrument.Category = instrument.Category;

                    _dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }

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
