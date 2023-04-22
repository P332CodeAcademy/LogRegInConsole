using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginRegConsole.Helper;
using LoginRegConsole.Services;
using LoginRegConsole.Database.Repositories;

namespace LoginRegConsole.Admin.Commands.MessageSending
{
	public class SendMessageCommand
	{
		public static void Handle()
		{
			User receivingUser = null;
			string messageBody = string.Empty;
			UserRepository userRep=new UserRepository();
			MessageRepository messageRepository = new MessageRepository();

			do
			{
				receivingUser = userRep.FindUserByEmail();

			} while (receivingUser == null);


			do
			{
				Console.WriteLine("Please enter the message");
				messageBody = Console.ReadLine();

			} while (Validation.IsLengthBeetween(5, 50, messageBody) == false);

			Message message = new Message(messageBody, UserService.ActiveUser, receivingUser);
			messageRepository.AddMessage(message);
			CustomConsole.GreenLine($"Message has successfully been send from {UserService.ActiveUser.Email} ==> {receivingUser.Email}");

		}
	}
}
