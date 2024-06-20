using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
	public class Hotel
	{
		private readonly string _name;
		private readonly string _description;
		private readonly List<Room> _rooms;
		private readonly List<Request> _requests;

		public string Name => _name;
		public string Description => _description;
		public List<Room> Rooms => _rooms;
		public List<Request> Requests => _requests;

		public Hotel(string name, string description, int commonRoomsCount, decimal commonRoomPrice, int eliteRoomsCount, decimal eliteRoomPrice)
		{
			this._name = name;
			this._description = description;
			this._requests = new List<Request>();

			this._rooms = new List<Room>();
			int roomNumber = 1;

			for (int i = 0; i < commonRoomsCount; i++)
			{
				this._rooms.Add(new CommonRoom(roomNumber++, commonRoomPrice));
			}

			for (int i = 0; i < eliteRoomsCount; i++)
			{
				this._rooms.Add(new EliteRoom(roomNumber++, eliteRoomPrice));
			}
		}

		public List<Room> GetAvailableRooms()
		{
			return this._rooms.Where(room => room.IsAvailable).ToList();
		}

		public List<Room> GetBookedRooms()
		{
			return this._rooms.Where(room => !room.IsAvailable).ToList();
		}

		public bool HasRoomWithNumber(int number)
		{
			return this._rooms.Any(room => room.Number == number);
		}

		public bool RequestRoom(int number)
		{
			if (!this._rooms.Find(room => room.Number == number)!.IsAvailable)
			{
				return false;
			}

			this._requests.Add(new Request(this, this._rooms.Find(room => room.Number == number)!));
			this._rooms.Find(room => room.Number == number)!.BookRoom();

			return true;
		}

		public void RequestRoom(Request request)
		{
			if (request.Room.IsAvailable)
			{
				this._requests.Add(request);
				request.Room.BookRoom();
			}
		}

		public bool RemoveRequest(int number)
		{
			if (!this._requests.Any(request => request.Room.Number == number))
			{
				return false;
			}

			this._rooms.Find(room => room.Number == number)!.VacateRoom();

			Request requestToRemove = this._requests.Find(request => request.Room.Number == number)!;

			if (requestToRemove.Client != null)
			{
				requestToRemove.Client.RemoveRequest(requestToRemove);
			}

			this._requests.Remove(requestToRemove);

			return true;
		}

		public void RemoveRequest(Request request)
		{
			request.Room.VacateRoom();
			this._requests.Remove(request);
		}

		public List<Client> GetClientsWhoRequestedRoom()
		{
			return this._requests.Where(request => request.Client != null).Select(request => request.Client).ToList()!;
		}
	}
}
