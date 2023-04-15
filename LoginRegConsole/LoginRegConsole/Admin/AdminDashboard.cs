using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Database.Models;
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



        public static void Index(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome back to Admin Dashboard dear {user.Name} {user.Surname}");
            Console.ForegroundColor = ConsoleColor.White;


            string choice = string.Empty;

            do
            {
                Console.WriteLine("What you want to do?\n" +
               "1-Show All Users\n" +
               "2-Remove User by Id\n" +
               "3-Promote to Admin\n" +
               "4-Depromote from Admin\n" +
               "5-Update settings\n" +
               "6-Remove user\n" +
               "7-Ban user");

                Console.Write("Your Choice:");
                choice= Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowUserCommand.Handle();
                        break;
                    case "2":
                        RemoveUserByIdCommand.Handle();
                        break;
                    case "3":
                        PromoteToAdmin.Handle();
                        break;
                    case "4":
                        DepromoteFromAdmin.Handle(user);
                        break;

                    default:
                        break;
                }

            } while (choice != "0");

        }
    }
}
