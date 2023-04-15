using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using LoginRegConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Shared.Commands
{
    public class UpdateSettingsCommand
    {

        public static void Handle(User user)
        {
            string updatedName = RegistrationHelper.NameValidation();
            string updatedSurname = RegistrationHelper.SurnameValidation();
            string updatedPassword = RegistrationHelper.PasswordValidation();

            user.Name = updatedName;
            user.Surname = updatedSurname;
            user.Password = updatedPassword;
            CustomConsole.GreenLine("Successfully updated!");
        }
    }
}
