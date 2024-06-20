using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
	public class Room
	{
		private readonly int _number;
		private readonly decimal _price;
		private bool _isAvailable;

		public int Number => _number;
		public decimal Price => _price;
		public bool IsAvailable => _isAvailable;

		public Room(int number, decimal price)
		{
			this._number = number;
			this._price = price;
			this._isAvailable = true;
		}

		public void BookRoom()
		{
			this._isAvailable = false;
		}

		public void VacateRoom()
		{
			this._isAvailable = true;
		}
	}
}
