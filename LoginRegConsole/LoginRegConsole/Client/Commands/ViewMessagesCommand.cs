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
    public class ViewMessagesCommand
    {
        public static void Handle(User user)
        {

            int counter = 1;
            foreach (Message message in AppDbContext.Messages)
            {
                if (message.ReceivingUser.Email == user.Email)
                {
                    CustomConsole.WarningLine($"{counter++}.{message.SendingUser.ShowFullName()} || FROM:{message.SendingUser.Email} || {message.MessageBody}");
                }
            }

            if (counter == 1)
            {
                CustomConsole.RedLine("No recieved Messages");
            }


        }
    }
}
