using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
	public interface IRequest
	{
		public Hotel Hotel { get; }
		public Room Room { get; }
		public Client? Client { get; }
	}
}
