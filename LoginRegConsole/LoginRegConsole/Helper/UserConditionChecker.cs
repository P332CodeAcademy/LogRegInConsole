using LoginRegConsole.Admin;
using LoginRegConsole.Client;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Helper
{
    public class UserConditionChecker
    {
        public static void Handle(User user)
        {
            if (user == null)
            {
                CustomConsole.RedLine("Login or Password is wrong");
            }
            else if (user.IsActive == false)
            {
                CustomConsole.RedLine("Your account is banned!");
            }
            else if (user.Role == "admin")
            {
                AdminDashboard.Index(user);
            }
            else if (user.Role == "user")
            {
                ClientDashboard.Index(user);
            }
        }
    }
}
