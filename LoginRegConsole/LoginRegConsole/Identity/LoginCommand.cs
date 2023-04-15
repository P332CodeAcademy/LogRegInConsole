using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Identity
{
    public class LoginCommand
    {
        public static User Login()
        {
            Console.WriteLine("Please enter the email");
            string email = Console.ReadLine();
            Console.WriteLine("Plase enter the password");
            string pass = Console.ReadLine();

            foreach (User userInDb in AppDbContext.AppUsers)
            {
                if (userInDb._email == email && userInDb._password == pass)
                {
                    return userInDb;
                }
            }
            return null;
        }
    }
}
