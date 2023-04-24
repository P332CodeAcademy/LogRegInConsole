using LoginRegConsole.Admin.Commands.MessageSending;
using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Client.Commands;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Database.Repositories;
using LoginRegConsole.Extras;
using LoginRegConsole.Identity;
using LoginRegConsole.Services;
using LoginRegConsole.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin
{
    public class AdminDashboard
    {



        public static void Index()
        {
            CustomConsole.GreenLine($"Welcome back to Admin Dashboard dear {UserService.ActiveUser.Name} {UserService.ActiveUser.Surname}");
            UpdateSettingsForAdminCommand updateSettingsForAdminCommand = new UpdateSettingsForAdminCommand();
            string choice = string.Empty;
            UserRepository userRepository= new UserRepository();    
            do
            {
                Console.WriteLine("What you want to do?\n" +
               "1-Show All Users\n" +
               "2-Remove User by Id\n" +
               "3-Promote to Admin\n" +
               "4-Depromote from Admin\n" +
               "5-Update settings\n" +
               "6-Remove user by Email\n" +
               "7-Ban user\n" +
               "8-Disban user\n" +
               "9-Send Message\n" +
               "10-Register new User\n" +
               "0-Logout");

                Console.Write("Your Choice:");
                choice= Console.ReadLine();
                switch (choice)
                {
                    case "1":
						userRepository.ShowUsers();
                        break;
                    case "2":
						userRepository.RemoveUserById();
                        break;
                    case "3":
                        PromoteToAdmin.Handle();
                        break;
                    case "4":
                        DepromoteFromAdminCommand.Handle();
                        break;
                    case "5":
						updateSettingsForAdminCommand.Handle();
                        break;
                    case "6":
						userRepository.RemoveUserByEmail();
                        break;
                    case "7":
                        BanUserCommand.Handle();
                        break;
                    case "8":
                        DisBanUserCommand.Handle();
                        break;
                    case "9":
                        SendMessageCommand.Handle();
                        break;
                    case "10":
                        RegisterCommand.Register();
                        break;

                    default:
                        break;
                }

            } while (choice != "0");

        }
    }
}
