using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index() //All Instruments will be shown
        {
            var products = _dbContext.Instruments.ToList(); 

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _dbContext.Brands.ToList();

            return View(brands);
        }

       /* [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string price, string barcode, string pictureUrl)
        {
            
            var brand = _dbContext.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();

            var instrument = new RedoMusic.Domain.Entities.Instrument()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Barcode = barcode,
                Brand = brand,
                CreatedOn = DateTime.UtcNow,
                Picture = pictureUrl
            };

            _dbContext.Instruments.Add(instrument);

            _dbContext.SaveChanges();

            return RedirectToAction("add");
        }*/
       
        [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string price, string barcode, string pictureUrl)
        {
            if (string.IsNullOrEmpty(brandId))
            {
                return RedirectToAction("error");
            }
            else
            {
                if (Guid.TryParse(brandId, out Guid parsedBrandId))
                {
                    var brand = _dbContext.Brands.FirstOrDefault(x => x.Id == parsedBrandId);

                    if (brand != null)
                    {
                        var instrument = new RedoMusic.Domain.Entities.Instrument()
                        {
                            Id = Guid.NewGuid(),
                            Name = name,
                            Description = description,
                            Barcode = barcode,
                            Brand = brand,
                            CreatedOn = DateTime.UtcNow,
                            Picture = pictureUrl
                        };

                        _dbContext.Instruments.Add(instrument);
                        _dbContext.SaveChanges();

                        return RedirectToAction("add");
                    }
                    else
                    {
                        return RedirectToAction("error");
                    }
                }
                else
                {
                  
                    return RedirectToAction("error");
                }
            }

            return RedirectToAction("add");
        }


        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Inspect(string id)
        {
            var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
             
            return View(instrument);
        }


    }
}
