using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginRegConsole.Database.Repositories;

namespace LoginRegConsole.Identity
{
    public class LoginCommand
    {
        public static User Login()
        {
            UserRepository userRepository = new UserRepository();
            Console.WriteLine("Please enter the email");
            string email = Console.ReadLine();
            Console.WriteLine("Plase enter the password");
            string pass = Console.ReadLine();

            foreach (User userInDb in userRepository.GetUsers())
            {
                if (userInDb.Email == email && userInDb.Password == pass)
                {
                    return userInDb;
                }
            }
            return null;
        }
    }
}
