﻿using LoginRegConsole.Admin.Commands.UserManagament;
using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginRegConsole.Helper;

namespace LoginRegConsole.Admin.Commands.MessageSending
{
	public class SendMessageCommand
	{
		public static void Handle(User sendingUser)
		{
			User receivingUser = null;
			string messageBody = string.Empty;

			do
			{
				receivingUser = FindUserByEmail.Handle();

			} while (receivingUser == null);


			do
			{
				Console.WriteLine("Please enter the message");
				messageBody = Console.ReadLine();

			} while (Validation.IsLengthBeetween(5, 50, messageBody) == false);

			Message message = new Message(messageBody, sendingUser, receivingUser);
			AppDbContext.Messages.Add(message);
			CustomConsole.GreenLine($"Message has successfully been send from {sendingUser.Email} ==> {receivingUser.Email}");

		}
	}
}
