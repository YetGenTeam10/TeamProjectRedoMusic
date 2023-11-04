using RedoMusic.Domain.Entities;

namespace RedoMusicMVC.Models
{
    public class MyViewModel
    {
        public User User { get; set; }
        public List<Instrument> Instruments { get; set; }
    }
}
