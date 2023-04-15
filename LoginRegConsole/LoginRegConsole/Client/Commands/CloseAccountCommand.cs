using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Client.Commands
{
    public class CloseAccountCommand
    {

        public static void Handle(User user)
        {
            Console.WriteLine("Please enter password for submission.\n" +
                "If you want to go back enter 1");
            string pass=Console.ReadLine();

            if (pass != null)
            {
                if (pass== "1")
                {
                    return;
                }
                else if (pass==user.Password)
                {
                    AppDbContext.AppUsers.Remove(user);
                    CustomConsole.WarningLine($"{user.Name} has successfully been deleted!");
                }
                else
                {
                   CustomConsole.RedLine("Invalid password");
                }
            }
        }
    }
}
