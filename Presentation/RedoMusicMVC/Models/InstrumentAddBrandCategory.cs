using Microsoft.AspNetCore.Mvc;
using RedoMusic.Domain.Entities;


namespace RedoMusicMVC.Models
{
    public class InstrumentAddBrandCategory 
    {
        public Instrument Instrument { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
    }
}
