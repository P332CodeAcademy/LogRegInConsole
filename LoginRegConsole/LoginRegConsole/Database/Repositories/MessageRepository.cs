using LoginRegConsole.Database.Models;
using LoginRegConsole.Extras;
using LoginRegConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Repositories
{
	public class MessageRepository
	{
		public void ViewMessages()
		{

			int counter = 1;
			foreach (Message message in AppDbContext.Messages)
			{
				if (message.ReceivingUser.Email == UserService.ActiveUser.Email)
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
