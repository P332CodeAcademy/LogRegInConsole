using LoginRegConsole.Admin;
using LoginRegConsole.Client;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using LoginRegConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Helper
{
    public class UserConditionChecker
    {
        public static void Handle()
        {
            if (UserService.ActiveUser == null)
            {
                CustomConsole.RedLine("Login or Password is wrong");
            }
            else if (UserService.ActiveUser.IsActive == false)
            {
                CustomConsole.RedLine("Your account is banned!");
            }
            else if (UserService.ActiveUser.Role == "admin")
            {
                AdminDashboard.Index();
            }
            else if (UserService.ActiveUser.Role == "user")
            {
                ClientDashboard.Index();
            }
        }
    }
}
