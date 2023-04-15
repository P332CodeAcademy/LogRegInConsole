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
    public class SendMessageCommand
    {
        public static void Handle(User sendingUser)
        {
            User receivingUser = null;
            do
            {
                receivingUser = FindUserByEmail.Handle();

            } while (receivingUser == null);

            
            Console.WriteLine("Please enter the message");
            string messageBody = Console.ReadLine();

            Message message = new Message(messageBody,sendingUser,receivingUser);
            AppDbContext.Messages.Add(message);
            CustomConsole.GreenLine($"Message has successfully been send from {sendingUser.Email} ==> {receivingUser.Email}");

        }
    }
}
