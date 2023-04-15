﻿using LoginRegConsole.Admin;
using LoginRegConsole.Client;
using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using LoginRegConsole.Helper;
using System.Data;
using System.Xml.Linq;

namespace LoginRegConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Handler();
        }
        public static void Handler()
        {

            string choice = string.Empty;

            Console.WriteLine("Welcome to user login/register app");
            do
            {
                Console.WriteLine("What you want to do\n" +
                    "1-Login\n" +
                    "2-Register\n" +
                    "3-Exit");
                Console.Write("Your choice:");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        User user = Identity.LoginCommand.Login();
                        if (user == null)
                        {
                            CustomConsole.RedLine("Login or Password is wrong");
                        }
                        else if (user.IsActive == false)
                        {
                            CustomConsole.RedLine("Your account is banned!");
                        }
                        else if (user.Role == "admin")
                        {
                            AdminDashboard.Index(user);
                        }
                        else if (user.Role == "user")
                        {
                            ClientDashboard.Index(user);
                        }
                        break;

                    case "2":
                        Identity.RegisterCommand.Register();
                        break;

                    default:
                        break;
                }
            } while (choice != "3");

        }
    }

    
   
    

}








