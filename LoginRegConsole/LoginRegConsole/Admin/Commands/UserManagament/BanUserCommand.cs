using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Database.Repositories;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.UserManagament
{
	public class BanUserCommand
	{
		public static void Handle()
		{
			UserRepository userRepository = new UserRepository();

			User user = userRepository.FindUserByEmail();
			if (user == null)
			{
				CustomConsole.RedLine("Invalid email");
			}
			else if (user.IsActive == false)
			{
				CustomConsole.RedLine("Alredy banned account");
			}
			else if (user.IsAdmin() == true)
			{
				CustomConsole.RedLine("You can't ban an admin");
			}
			else 
			{
				user.IsActive = false;
				CustomConsole.GreenLine($"{user.ShowFullName()} has successfully been BANNED!");
			}
		}

	}
}
