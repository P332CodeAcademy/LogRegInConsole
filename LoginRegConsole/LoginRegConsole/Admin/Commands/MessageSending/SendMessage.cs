using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.MessageSending
{
    public class SendMessage
    {
        public static void Handle(User sendingUser)
        {
            User receivingUser = null;
            do
            {
                receivingUser = FindUserByEmail.Handle();

            } while (receivingUser != null);

            string subject=Console.ReadLine();
            string desc = Console.ReadLine();
            Message message = new Message(subject,desc,sendingUser.Name,receivingUser.Name);

        }
    }
}
