﻿
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
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public ColorType Color { get; set; }
        public DateTime? ProductionYear { get; set; }
        public string Barcode {  get; set; }

        //public string Picture { get; set; }
        public decimal Price { get; set; }
    }
}
