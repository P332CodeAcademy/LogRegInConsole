using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.UserManagament
{
	public class DepromoteFromAdmin
	{
		public static void Handle(User isActiveAdmin)
		{

			User user = FindUserByEmail.Handle();
			if (user == null)
			{
				CustomConsole.RedLine("Invalid email");
			}
			else if (user == isActiveAdmin)
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
