using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace RedoMusic.Domain.Entities
{
	public class Favourite : EntityBase<Guid>
	{
        public Favourite() { }  
        public Favourite(Instrument instrument, User user)
        {
            User = user;
            Instrument = instrument;
        }

        public User User { get; set; }

		public Instrument Instrument { get; set; }
		
		public DateTime FavouriteAddTime { get; set; }
	}
}
