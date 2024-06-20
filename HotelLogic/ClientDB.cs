using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLogic
{
	public class ClientDB
	{
		private List<Client> _clients;

		public ClientDB()
		{
			this._clients = new List<Client>();
		}

		public bool AddClient(string firstName, string lastName, int age, string phone)
		{
			if (this._clients.Any(client => client.Name == firstName + " " + lastName))
			{
				return false;
			}

			this._clients.Add(new Client(firstName, lastName, age, phone));

			return true;
		}

		public bool RemoveClient(string name)
		{
			if (!this._clients.Any(client => client.Name == name))
			{
				return false;
			}

			this._clients.Remove(this._clients.Find(client => client.Name == name)!);

			return true;
		}

		public bool EditClient(string name, string firstName, string lastName, int age, string phone)
		{
			if (!this._clients.Any(client => client.Name == name))
			{
				return false;
			}

			this._clients.Find(client => client.Name == name)!.Edit(firstName, lastName, age, phone);

			return true;
		}

		public Client? GetClient(string name)
		{
			return this._clients.Find(client => client.Name == name);
		}

		public List<Client>? GetClientList()
		{
			if (this._clients.Count == 0)
			{
				return null;
			}

			return this._clients;
		}

		public void SortByFirstName()
		{
			this._clients = this._clients.OrderBy(client => client.Name.Split(" ")[0]).ToList();
		}

		public void SortByLastName()
		{
			this._clients = this._clients.OrderBy(client => client.Name.Split(" ")[1]).ToList();
		}

		public List<Client>? GetFilteredClientList(string key)
		{
			if (this.GetClientList() == null)
			{
				return null;
			}

			List<Client> newList = this.GetClientList()!.Where(client => client.Name.ToLower().Split(key.ToLower()).Length >= 2).ToList();

			if (newList.Count == 0)
			{
				return null;
			}

			return newList;
		}
	}
}
