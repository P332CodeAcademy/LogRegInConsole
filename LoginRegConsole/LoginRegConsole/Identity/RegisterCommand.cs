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

namespace LoginRegConsole.Identity
{
    public class RegisterCommand
    {
        public static void Register()
        {
            string name = RegistrationHelper.NameValidation();
            string surname = RegistrationHelper.SurnameValidation();
            string password = RegistrationHelper.PasswordValidation();
            string eMail = RegistrationHelper.EmailValidation();

            User user = new User(name, surname, eMail, password, Roles.USER);

            CustomConsole.GreenLine($"{user.Name} {user.Surname} Successfully registered at {user.RegistrationDate.ToString("f")}");
            AppDbContext.AppUsers.Add(user);


        }
    }
}
