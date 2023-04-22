using LoginRegConsole.Database.Models;
using LoginRegConsole.Database.Repositories;
using LoginRegConsole.Extras;
using LoginRegConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.UserManagament
{
	public class DepromoteFromAdmin
	{
		public static void Handle()
		{
			UserRepository userRepository = new UserRepository();

			User user = userRepository.FindUserByEmail();
			if (user == null)
			{
				CustomConsole.RedLine("Invalid email");
			}
			else if (user == UserService.ActiveUser)
			{
				CustomConsole.WarningLine("You cannot depromote yourself to user");
			}
			else if (user.IsAdmin())
			{
				user.Role = "user";
				CustomConsole.GreenLine($"{user.ShowFullName()} depromoted to User!");
			}
			else 
			{
				CustomConsole.WarningLine("Alredy User!");
			}
			
		}
	}
}
