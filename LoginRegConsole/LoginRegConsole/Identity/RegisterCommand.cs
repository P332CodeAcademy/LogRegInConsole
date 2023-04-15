using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginRegConsole.Services;
using LoginRegConsole.Extras;

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
            const string ROLE_FOR_USER = "user";

            User user = new User(name, surname, eMail, password, ROLE_FOR_USER);

            CustomConsole.GreenLine("Successfully registered");
            AppDbContext.AppUsers.Add(user);


        }
    }
}
