using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Models
{
    public class User
    {
        public string _name;
        public string _surname;
        public string _email;
        public string _password;
        public string _role;

        public User()
        {

        }

        public User(string name, string surname, string email, string password, string role)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _password = password;
            _role = role;
        }

        public void ShowInfo()
        {

            if (_role == "admin")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Welcome back, our dear {_name} {_surname}!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (_role == "user")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome back {_name} {_surname}!");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }


    }
}
