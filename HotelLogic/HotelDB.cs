using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
	public class HotelDB
	{
		private readonly List<Hotel> _hotels;

		public HotelDB()
		{
			this._hotels = new List<Hotel>();
		}

		public bool AddHotel(string name, string description, int commonRoomsCount, decimal commonRoomPrice, int eliteRoomsCount, decimal eliteRoomPrice)
		{
			if (this._hotels.Any(hotel => hotel.Name == name))
			{
				return false;
			}

			this._hotels.Add(new Hotel(name, description, commonRoomsCount, commonRoomPrice, eliteRoomsCount, eliteRoomPrice));

			return true;
		}

		public bool RemoveHotel(string name)
		{
			if (!this._hotels.Any(hotel => hotel.Name == name))
			{
				return false;
			}

			this._hotels.Remove(this._hotels.Find(hotel => hotel.Name == name)!);

			return true;
		}

		public Hotel? GetHotel(string name)
		{
			return this._hotels.Find(hotel => hotel.Name == name);
		}

		public List<Hotel>? GetHotelList()
		{
			if (this._hotels.Count == 0)
			{
				return null;
			}

			return this._hotels;
		}

		public List<Hotel>? GetFilteredHotelList(string key)
		{
			if (this.GetHotelList() == null)
			{
				return null;
			}

			List<Hotel> newList = this.GetHotelList()!.Where(hotel => hotel.Name.ToLower().Split(key.ToLower()).Length >= 2).ToList();

			if (newList.Count == 0)
			{
				return null;
			}

			return newList;
		}
	}
}
