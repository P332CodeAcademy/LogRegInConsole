using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using LoginRegConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Client.Commands
{
	public class CloseAccountCommand
	{

		public static void Handle()
		{
			Console.WriteLine("Please enter password for submission.\n" +
				"If you want to go back enter 1");
			string pass = Console.ReadLine();

			if (pass == "1")
			{
				return;
			}
			else if (pass == UserService.ActiveUser.Password)
			{
				AppDbContext.AppUsers.Remove(UserService.ActiveUser);
				CustomConsole.WarningLine($"{UserService.ActiveUser.ShowFullName()} has successfully been deleted!");
			}
			else
			{
				CustomConsole.RedLine("Invalid password");
			}

		}
	}
}
