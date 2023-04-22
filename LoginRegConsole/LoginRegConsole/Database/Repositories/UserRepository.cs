using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Repositories
{
	public class UserRepository
	{
		public User FindUserByEmail()
		{
			Console.Write("Please enter the User email:");
			string email = Console.ReadLine();
			foreach (User user in AppDbContext.AppUsers)
			{
				if (user.Email == email)
				{
					return user;
				}
			}
			return null;
		}
		public void RemoveUserByEmail()
		{
			User user = FindUserByEmail();
			if (user == null)
			{
				CustomConsole.RedLine("Invalid email");
			}
			else if (user.IsAdmin())
			{
				CustomConsole.RedLine("You can't remove admin");
			}
			else
			{
				AppDbContext.AppUsers.Remove(user);
				CustomConsole.GreenLine($"{user.ShowFullName()} has successfully been DELETED!");
			}

		}
		public void RemoveUserById()
		{
			while (true)
			{
				Console.WriteLine("Please enter the id");
				try
				{
					int id = int.Parse(Console.ReadLine());
					foreach (var item in AppDbContext.AppUsers)
					{
						if (item.Id == id)
						{
							if (item.Role != "admin")
							{
								AppDbContext.AppUsers.Remove(item);
								CustomConsole.GreenLine($"{item.ShowFullName()} has been removed!");
								return;
							}
							CustomConsole.RedLine("You can't remove admin");
							return;
						}
					}
					CustomConsole.GreenLine($"There is no User in {id}:ID");
					return;
				}
				catch
				{
					CustomConsole.RedLine("Enter correct format ID");
					break;
				}
			}
		}
		public void ShowUsers()
		{
			int counter = 1;
			foreach (User user in AppDbContext.AppUsers)
			{
				Console.WriteLine($"{counter++} || ID:{user.Id} || Name:{user.ShowFullName()} || Role:{user.Role} || IsActive:{(user.IsActive ? "Active" : "Banned")}");
			}
			Console.WriteLine();
		}
	}
}
