
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
        public Instrument()
        {
        }

        public Instrument(string name, string description, Brand brand, ColorType color, DateTime? productionYear, string barcode, string picture, decimal price, Category category)
        {
            Name = name;
            Description = description;
            Brand = brand;
            Color = color;
            ProductionYear = productionYear;
            Barcode = barcode;
            Picture = picture;
            Price = price;
            Category = category;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public ColorType Color { get; set; }
        public DateTime? ProductionYear { get; set; }
        public string Barcode {  get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
