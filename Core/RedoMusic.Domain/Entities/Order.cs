using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusic.Domain.Entities
{
	public class Order : EntityBase<Guid>
	{
		public User User { get; set; }

		public Brand Brand { get; set; }

		public DateTime OrderDate { get; set; }

		public double OrderPrice { get; set; }	
	}
}
