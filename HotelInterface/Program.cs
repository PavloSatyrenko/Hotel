using HotelLogic;

namespace HotelInterface
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HotelDB hotelDB = new HotelDB();
			ClientDB clientDB = new ClientDB();

			hotelDB.AddHotel("Hotel", "Hotel near sea", 2, 200, 3, 400);
			clientDB.AddClient("Pasha", "S", 18, "0991234567");


			bool isExited = false;
			string choose;

			while (!isExited)
			{
				Console.Clear();

				Console.WriteLine("Choose the option: \n" +
					"1 - Manage hotels\n" +
					"2 - Manage clients\n" +
					"3 - Exit\n" +
					"========================\n");

				Console.Write("==> ");
				choose = Console.ReadLine()!;
				Console.WriteLine();

				if (choose == "1")
				{
					Console.WriteLine("Choose the option: \n" +
					"1 - Add a hotel\n" +
					"2 - Remove the hotel\n" +
					"3 - View hotel info\n" +
					"4 - View all hotels\n" +
					"5 - Find hotel by keyword\n" +
					"6 - View free rooms\n" +
					"7 - View booked rooms\n" +
					"8 - Book a room\n" +
					"9 - Remove room booking\n" +
					"10 - Get all clients who booked room\n" +
					"11 - View requests\n" +
					"12 - Back\n" +
					"========================\n");

					Console.Write("==> ");
					choose = Console.ReadLine()!;
					Console.WriteLine();

					if (choose == "1")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine("Enter the description: ");
						string description = Console.ReadLine()!;
						Console.WriteLine("Enter the number of common rooms: ");
						int commonRoomCount = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine("Enter the price of common rooms: ");
						int commonRoomPrice = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine("Enter the number of elite rooms: ");
						int eliteRoomsCount = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine("Enter the price of elite rooms: ");
						int eliteRoomPrice = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine();

						if (hotelDB.AddHotel(name, description, commonRoomCount, commonRoomPrice, eliteRoomsCount, eliteRoomPrice))
						{
							Console.WriteLine("The hotel was successfully added. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("The hotel with that name already exists. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "2")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (hotelDB.RemoveHotel(name))
						{
							Console.WriteLine("The hotel was successfully removed. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("The hotel with that name does not exist. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "3")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						PrintHotel(hotelDB.GetHotel(name));
						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "4")
					{
						PrintHotelList(hotelDB.GetHotelList());
						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "5")
					{
						Console.WriteLine("Enter the keyword: ");
						string key = Console.ReadLine()!;
						Console.WriteLine();

						PrintHotelList(hotelDB.GetFilteredHotelList(key));
						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "6")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (hotelDB.GetHotel(name) == null)
						{
							Console.WriteLine("No hotel with entered name. Continue?");
							Console.ReadLine();
						}
						else
						{
							List<Room> roomList = hotelDB.GetHotel(name)!.GetAvailableRooms();

							if (roomList.Count == 0)
							{
								Console.WriteLine("No rooms are available");
							}
							else
							{
								PrintRoomList(roomList);
							}

							Console.WriteLine("Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "7")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (hotelDB.GetHotel(name) == null)
						{
							Console.WriteLine("No hotel with entered name. Continue?");
							Console.ReadLine();
						}
						else
						{
							List<Room> roomList = hotelDB.GetHotel(name)!.GetBookedRooms();

							if (roomList.Count == 0)
							{
								Console.WriteLine("No rooms were booked");
							}
							else
							{
								PrintRoomList(roomList);
							}
						}

						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "8")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine("Enter the number of the room: ");
						int number = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine();

						if (hotelDB.GetHotel(name) == null)
						{
							Console.WriteLine("No hotel with entered name. Continue?");
							Console.ReadLine();
						}
						else if (!hotelDB.GetHotel(name)!.HasRoomWithNumber(number))
						{
							Console.WriteLine("The hotel does not have such a room. Continue?");
							Console.ReadLine();
						}
						else if (!hotelDB.GetHotel(name)!.RequestRoom(number))
						{
							Console.WriteLine("The room is already booked. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("The room was successfully booked. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "9")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine("Enter the number of the room: ");
						int number = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine();

						if (hotelDB.GetHotel(name) == null)
						{
							Console.WriteLine("No hotel with entered name. Continue?");
							Console.ReadLine();
						}
						else if (!hotelDB.GetHotel(name)!.HasRoomWithNumber(number))
						{
							Console.WriteLine("The hotel does not have such a room. Continue?");
							Console.ReadLine();
						}
						else if (!hotelDB.GetHotel(name)!.RemoveRequest(number))
						{
							Console.WriteLine("The room is not booked. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("The room was successfully unbooked. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "10")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (hotelDB.GetHotel(name) == null)
						{
							Console.WriteLine("No hotel with entered name. Continue?");
							Console.ReadLine();
						}
						else
						{
							PrintClientList(hotelDB.GetHotel(name)!.GetClientsWhoRequestedRoom());
							Console.WriteLine("Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "11")
					{
						Console.WriteLine("Enter the name of the hotel: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (hotelDB.GetHotel(name) == null)
						{
							Console.WriteLine("No hotel with entered name. Continue?");
							Console.ReadLine();
						}
						else
						{
							List<Request> requestList = hotelDB.GetHotel(name)!.Requests;

							if (requestList.Count == 0)
							{
								Console.WriteLine("No request were made.");
							}
							else
							{
								PrintRequestList(hotelDB.GetHotel(name)!.Requests);
							}
							Console.WriteLine("Continue?");
							Console.ReadLine();
						}
					}
				}
				else if (choose == "2")
				{
					Console.WriteLine("Choose the option: \n" +
					"1 - Add a client\n" +
					"2 - Remove the client\n" +
					"3 - Edit client info\n" +
					"4 - View client info\n" +
					"5 - View all clients\n" +
					"6 - Find client by keyword\n" +
					"7 - Sort clients by first name\n" +
					"8 - Sort clients by last name\n" +
					"9 - Book a room\n" +
					"10 - Remove room booking\n" +
					"11 - View requests\n" +
					"12 - Back\n" +
					"========================\n");

					Console.Write("==> ");
					choose = Console.ReadLine()!;
					Console.WriteLine();

					if (choose == "1")
					{
						Console.WriteLine("Enter client first name: ");
						string firstName = Console.ReadLine()!;
						Console.WriteLine("Enter client last name: ");
						string lastName = Console.ReadLine()!;
						Console.WriteLine("Enter the age: ");
						int age = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine("Enter the phone: ");
						string phone = Console.ReadLine()!;
						Console.WriteLine();

						if (clientDB.AddClient(firstName, lastName, age, phone))
						{
							Console.WriteLine("The client was successfully added. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("A client with that name already exists. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "2")
					{
						Console.WriteLine("Enter client name: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (clientDB.RemoveClient(name))
						{
							Console.WriteLine("The client was successfully removed. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("A client with that name does not exist. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "3")
					{
						Console.WriteLine("Enter client name: ");
						string name = Console.ReadLine()!;
						Console.WriteLine("Enter client first name: ");
						string firstName = Console.ReadLine()!;
						Console.WriteLine("Enter client last name: ");
						string lastName = Console.ReadLine()!;
						Console.WriteLine("Enter the age: ");
						int age = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine("Enter the phone: ");
						string phone = Console.ReadLine()!;
						Console.WriteLine();

						if (clientDB.EditClient(name, firstName, lastName, age, phone))
						{

							Console.WriteLine("The client was successfully edited. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("A client with that name does not exist. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "4")
					{
						Console.WriteLine("Enter client name: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						PrintClient(clientDB.GetClient(name));
						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "5")
					{
						PrintClientList(clientDB.GetClientList());
						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "6")
					{
						Console.WriteLine("Enter the keyword: ");
						string key = Console.ReadLine()!;
						Console.WriteLine();

						PrintClientList(clientDB.GetFilteredClientList(key));
						Console.WriteLine("Continue?");
						Console.ReadLine();
					}
					else if (choose == "7")
					{
						clientDB.SortByFirstName();

						Console.WriteLine("Clients sorted by their first name. Continue?");
						Console.ReadLine();
					}
					else if (choose == "8")
					{
						clientDB.SortByLastName();

						Console.WriteLine("Clients sorted by their last name. Continue?");
						Console.ReadLine();
					}
					else if (choose == "9")
					{
						Console.WriteLine("Enter client name: ");
						string clientName = Console.ReadLine()!;
						Console.WriteLine("Enter the name of the hotel: ");
						string hotelName = Console.ReadLine()!;
						Console.WriteLine("Enter the number of the room: ");
						int number = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine();

						if (clientDB.GetClient(clientName) == null)
						{
							Console.WriteLine("A client with that name does not exist. Continue?");
							Console.ReadLine();
						}
						else if (hotelDB.GetHotel(hotelName) == null)
						{
							Console.WriteLine("A hotel with that name does not exist. Continue?");
							Console.ReadLine();
						}
						else if (!hotelDB.GetHotel(hotelName)!.HasRoomWithNumber(number))
						{
							Console.WriteLine("The hotel does not have such a room. Continue?");
							Console.ReadLine();
						}
						else if (!clientDB.GetClient(clientName)!.RequestRoom(hotelDB.GetHotel(hotelName)!, number))
						{
							Console.WriteLine("The room is already booked. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("The room was successfully booked. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "10")
					{
						Console.WriteLine("Enter client name: ");
						string clientName = Console.ReadLine()!;
						Console.WriteLine("Enter the name of the hotel: ");
						string hotelName = Console.ReadLine()!;
						Console.WriteLine("Enter the number of the room: ");
						int number = Convert.ToInt16(Console.ReadLine());
						Console.WriteLine();

						if (clientDB.GetClient(clientName) == null)
						{
							Console.WriteLine("A client with that name does not exist. Continue?");
							Console.ReadLine();
						}
						else if (hotelDB.GetHotel(hotelName) == null)
						{
							Console.WriteLine("A hotel with that name does not exist. Continue?");
							Console.ReadLine();
						}
						else if (!hotelDB.GetHotel(hotelName)!.HasRoomWithNumber(number))
						{
							Console.WriteLine("The hotel does not have such a room. Continue?");
							Console.ReadLine();
						}
						else if (!clientDB.GetClient(clientName)!.RemoveRequest(hotelDB.GetHotel(hotelName)!, number))
						{
							Console.WriteLine("The room is not booked. Continue?");
							Console.ReadLine();
						}
						else
						{
							Console.WriteLine("The room was successfully unbooked. Continue?");
							Console.ReadLine();
						}
					}
					else if (choose == "11")
					{
						Console.WriteLine("Enter client name: ");
						string name = Console.ReadLine()!;
						Console.WriteLine();

						if (clientDB.GetClient(name) == null)
						{
							Console.WriteLine("A client with that name does not exist. Continue?");
							Console.ReadLine();
						}
						else
						{
							List<Request> requestList = clientDB.GetClient(name)!.Requests;

							if (requestList.Count == 0)
							{
								Console.WriteLine("No request were made.");
							}
							else
							{
								PrintRequestList(clientDB.GetClient(name)!.Requests);
							}

							Console.WriteLine("Continue?");
							Console.ReadLine();
						}
					}
				}
				else if (choose == "3")
				{
					isExited = true;
				}
			}
		}

		static void PrintHotel(Hotel? hotel)
		{
			if (hotel != null)
			{
				Console.WriteLine("Hotel name: " + hotel.Name + ", hotel description: " + hotel.Description + ", available rooms: " + hotel.GetAvailableRooms().Count + ".");
			}
			else
			{
				Console.WriteLine("No hotel with entered name.");
			}
		}

		static void PrintHotelList(List<Hotel>? hotelList)
		{
			Console.WriteLine("Hotel list: ");

			if (hotelList != null)
			{
				foreach (Hotel hotel in hotelList)
				{
					Console.WriteLine("\tHotel name: " + hotel.Name + ", hotel description: " + hotel.Description + ", available rooms: " + hotel.GetAvailableRooms().Count + ".");
				}
			}
			else
			{
				Console.WriteLine("\tNo hotels found.");
			}
		}

		static void PrintClient(Client? client)
		{
			if (client != null)
			{
				Console.WriteLine("Client name: " + client.Name + ", client age: " + client.Age + ", client phone: " + client.Phone + ".");
			}
			else
			{
				Console.WriteLine("No client with entered name.");
			}
		}

		static void PrintClientList(List<Client>? clientList)
		{
			Console.WriteLine("Client list: ");

			if (clientList != null)
			{
				foreach (Client client in clientList)
				{
					Console.WriteLine("\tClient name: " + client.Name + ", client age: " + client.Age + ", client phone: " + client.Phone + ".");
				}
			}
			else
			{
				Console.WriteLine("\tNo clients found.");
			}
		}

		static void PrintRoomList(List<Room> roomList)
		{
			Console.WriteLine("Room list: ");

			foreach (Room room in roomList)
			{
				Console.Write("\tRoom type: ");

				if (room.GetType() == typeof(CommonRoom))
				{
					Console.Write("common");
				}
				else if (room.GetType() == typeof(EliteRoom))
				{
					Console.Write("elite");
				}

				Console.WriteLine(", room number: " + room.Number + ", room price: " + room.Price + ".");
			}
		}

		static void PrintRequestList(List<Request> requestList)
		{
			Console.WriteLine("Request list: ");

			if (requestList.Count != 0)
			{
				foreach (Request request in requestList)
				{
					Console.Write("\tHotel name: " + request.Hotel.Name + "Room number: " + request.Room.Number + ", room price: " + request.Room.Price);

					if (request.Client != null)
					{
						Console.WriteLine(", client name: " + request.Client.Name + ", client phone: " + request.Client.Phone + ".");
					}
					else
					{
						Console.WriteLine(", no client data.");
					}
				}
			}
			else
			{
				Console.WriteLine("\tNo requests found.");
			}
		}
	}
}