
using RedoMusic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusic.Domain.Entities
{
    public class Instrument : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public ColorType Color { get; set; }
        public DateTime? ProductionYear { get; set; }
        public string Barcode {  get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        //public List<Brand> Brands { get; set; }

        // Livanur bunu silme lütfen categori ile ilişki kurdum :)
        public Category Category { get; set; }
    }
}
