using LoginRegConsole.Admin.Commands.MessageSending;
using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Client.Commands;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
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


        public static void Index(User user)
        {
            Console.WriteLine($"Welcome back {user.Name} {user.Surname}");
            string choice = string.Empty;

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
                        UpdateSettingsCommand.Handle(user);
                        break;
                    case "2":
                        CloseAccountCommand.Handle(user);
                        return;
                    case "3":
                        ViewMessagesCommand.Handle(user);
                        break;
                    default:
                        break;
                }

            } while (choice != "0");
        }

    }
}
