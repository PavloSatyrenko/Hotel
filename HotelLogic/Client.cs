using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelLogic
{
	public class Client
	{
		private string _firstName;
		private string _lastName;
		private int _age;
		private string _phone;
		private List<Request> _requests;

		public string Name => _firstName + " " + _lastName;
		public int Age => _age;
		public string Phone => _phone;
		public List<Request> Requests => _requests;

		public Client(string firstName, string lastName, int age, string phone)
		{
			this._firstName = firstName;
			this._lastName = lastName;
			this._age = age;
			this._phone = phone;
			this._requests = new List<Request>();
		}

		public void Edit(string firstName, string lastName, int age, string phone)
		{
			this._firstName = firstName;
			this._lastName = lastName;
			this._age = age;
			this._phone = phone;
		}

		public bool RequestRoom(Hotel hotel, int number)
		{
			if (!hotel.Rooms.Find(room => room.Number == number)!.IsAvailable)
			{
				return false;
			}

			Request newRequest = new Request(hotel, hotel.Rooms.Find(room => room.Number == number)!, this);

			this._requests.Add(newRequest);
			hotel.RequestRoom(newRequest);

			return true;
		}

		public bool RemoveRequest(Hotel hotel, int number)
		{
			if (!this._requests.Any(request => request.Hotel == hotel && request.Room.Number == number))
			{
				return false;
			}

			Request requestToRemove = this._requests.Find(request => request.Hotel == hotel && request.Room.Number == number)!;

			this._requests.Remove(requestToRemove);
			hotel.RemoveRequest(requestToRemove);

			return true;
		}

		public void RemoveRequest(Request request)
		{
			this._requests.Remove(request);
		}
	}
}
