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
    public class PromoteToAdmin
    {

        public static void Handle()
        {
            UserRepository userRepository = new UserRepository();
			User user = userRepository.FindUserByEmail();
            if (user == null) 
            {
                CustomConsole.RedLine("Invalid email");
            }
            else if(user.IsAdmin())
            {
                CustomConsole.WarningLine("Alredy Admin!");
            }
            else
            {
                user.Role = "admin";
                CustomConsole.GreenLine($"{user.ShowFullName()} promoted to Admin!");
            }
        }

    }
}
