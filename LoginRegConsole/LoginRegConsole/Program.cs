using LoginRegConsole.Admin;
using LoginRegConsole.Client;
using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using LoginRegConsole.Helper;
using LoginRegConsole.Services;
using System.Data;
using System.Xml.Linq;

namespace LoginRegConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Handle();
        }
        public static void Handle()
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
                        UserService.ActiveUser = Identity.LoginCommand.Login();
                        UserConditionChecker.Handle();
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








