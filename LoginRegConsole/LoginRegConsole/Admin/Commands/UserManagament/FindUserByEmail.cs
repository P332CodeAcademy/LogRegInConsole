using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.UserManagament
{
    public class FindUserByEmail
    {
        public static User Handle()
        {
            Console.Write("Please enter the User email:");
            string email = Console.ReadLine();
            foreach (User user in AppDbContext.AppUsers)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        } 
    }
}
