using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
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
            User user = FindUserByEmail.Handle();
            if (user == null)
            {
                CustomConsole.RedLine("Invalid email");
            }
            else if (user.IsActive == false)
            {
                CustomConsole.RedLine("Alredy banned account");
            }
            else if (user.Role == "admin")
            {
                CustomConsole.RedLine("You can't ban an admin");
            }
            else if (user.Role == "user")
            {
                user.IsActive = false;
                CustomConsole.GreenLine($"{user.Name} has successfully been DELETED!");
            }
        }

    }
}
