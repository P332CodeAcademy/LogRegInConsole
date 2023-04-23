using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginRegConsole.Services;
using LoginRegConsole.Extras;
using LoginRegConsole.Constants;
using LoginRegConsole.Database.Repositories;

namespace LoginRegConsole.Identity
{
    public class RegisterCommand
    {
        public static void Register()
        {
            UserRepository userRepository = new UserRepository();

            string name = RegistrationHelper.NameValidation();
            string surname = RegistrationHelper.SurnameValidation();
            string password = RegistrationHelper.PasswordValidation();
            string eMail = RegistrationHelper.EmailValidation();

            User user = new User(name, surname, eMail, password, Roles.USER);

            CustomConsole.GreenLine($"{user.Name} {user.Surname} Successfully registered at {user.RegistrationDate.ToString("f")}");
            userRepository.AddUser(user);

        }
        
    }
}
