using RedoMusic.Domain.Entities;
using RedoMusic.Domain.Enums;

namespace RedoMusicMVC.Models
{
    public class InstrumentRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BrandId { get; set; }
        public string Color { get; set; }
        public string? ProductionYear { get; set; }
        public string Barcode { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public string? CreatedByUserId { get; set; }

    }

}