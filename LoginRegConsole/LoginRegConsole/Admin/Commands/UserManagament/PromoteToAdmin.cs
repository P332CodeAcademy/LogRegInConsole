using LoginRegConsole.Database.Models;
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

            User user = FindUserByEmail.Handle();
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
