using RedoMusic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusic.Domain.Entities
{
    public class Category : EntityBase<Guid>
    {
        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public string CategoryName { get; set; }

        public List<Instrument> InstrumentList { get; set; }

        public List<Brand> BrandList { get; set; }

    }
}
