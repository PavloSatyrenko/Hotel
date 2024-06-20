using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
	public class Request : IRequest
	{
		private readonly Hotel _hotel;
		private readonly Room _room;
		private readonly Client? _client;

		public Hotel Hotel => _hotel;
		public Room Room => _room;
		public Client? Client => _client;

		public Request(Hotel hotel, Room room, Client? client = null)
		{
			this._hotel = hotel;
			this._room = room;
			this._client = client;
		}
	}
}
