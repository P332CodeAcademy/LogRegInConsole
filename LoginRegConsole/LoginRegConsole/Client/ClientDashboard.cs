using LoginRegConsole.Admin.Commands.MessageSending;
using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Client.Commands;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Database.Repositories;
using LoginRegConsole.Extras;
using LoginRegConsole.Services;
using LoginRegConsole.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Client
{
    internal class ClientDashboard
    {
        public static void Index()
        {
            UpdateSettingsForUserCommand updateSettingsForUser = new UpdateSettingsForUserCommand();
            CustomConsole.WarningLine($"Welcome back {UserService.ActiveUser.Name} {UserService.ActiveUser.Surname}");
            string choice = string.Empty;
            MessageRepository messageRepository = new MessageRepository(); 
            do
            {
                Console.WriteLine("What you want to do?\n" +
                    "1-Update settings\n" +
                    "2-Close Account\n" +
                    "3-View Messages\n" +
                    "0-Log out");  

                Console.Write("Your Choice:");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
						updateSettingsForUser.Handle();
                        break;
                    case "2":
                        CloseAccountCommand.Handle();
                        return;
                    case "3":
						messageRepository.ViewMessages();
                        break;
                    default:
                        break;
                }

            } while (choice != "0");
        }

    }
}
