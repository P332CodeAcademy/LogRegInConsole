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
    public class DisBanUserCommand
    {
        public static void Handle()
        {
			UserRepository userRepository = new UserRepository();
			User user = userRepository.FindUserByEmail();
            if (user == null)
            {
                CustomConsole.RedLine("Invalid email");
            }
            else if (user.IsActive == true)
            {
                CustomConsole.RedLine("Alredy active account");
            }
            else if (user.IsAdmin() == false)
            {
                user.IsActive = true;
                CustomConsole.GreenLine($"{user.ShowFullName()} has successfully been DISBANNED!");
            }
        }
    }
}
