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
		public List<Message> GetMessages()
		{
			return AppDbContext.Messages;
		}
		public void ViewMessages()
		{

			int counter = 1;
			foreach (Message message in GetMessages())
			{
				if (message.ReceivingUser.Email == UserService.ActiveUser.Email)
				{
					CustomConsole.WarningLine($"{counter++}.{message.SendingUser.ShowFullName()} || FROM:{message.SendingUser.Email} || SENDING DATE {$"{message.SendTime.ToString("f")}"} || {message.MessageBody}");
				}
			}

			if (counter == 1)
			{
				CustomConsole.RedLine("No recieved Messages");
			}


		}
		public void AddMessage(Message message)
		{
			AppDbContext.Messages.Add(message);
		}
	}
}
