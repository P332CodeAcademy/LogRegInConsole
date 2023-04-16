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
    public class RemoveUserByEmailCommand
    {
        public static void Handle()
        {
            User user = FindUserByEmail.Handle();
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
    }
}
