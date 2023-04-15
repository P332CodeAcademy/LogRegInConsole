using LoginRegConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database
{
    public class AppDbContext
    {

        public static List<User> AppUsers { get; set; } = new List<User>();
        public static List<Message> Messages { get; set; } = new List<Message>();

        static AppDbContext()
        {
            AdminCreationSeed();
        }

        public static void AdminCreationSeed()
        {
            string name = "Super";
            string surname = "Admin";
            string email = "admin@gmail.com";
            string password = "123321";
            string role = "admin";

            User user = new User(name, surname, email, password, role);
            AppDbContext.AppUsers.Add(user);
        }

    }
}
