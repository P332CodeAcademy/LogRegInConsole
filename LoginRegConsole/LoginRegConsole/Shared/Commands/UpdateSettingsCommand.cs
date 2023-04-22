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

        public static void Handle()
        {
            string updatedName = RegistrationHelper.NameValidation();
            string updatedSurname = RegistrationHelper.SurnameValidation();
            string updatedPassword = RegistrationHelper.PasswordValidation();

			UserService.ActiveUser.Name = updatedName;
			UserService.ActiveUser.Surname = updatedSurname;
			UserService.ActiveUser.Password = updatedPassword;
            CustomConsole.GreenLine("Successfully updated!");
        }
    }
}
