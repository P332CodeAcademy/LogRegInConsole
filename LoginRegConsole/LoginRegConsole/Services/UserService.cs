﻿using LoginRegConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Services
{
	public class UserService
	{
		public static User ActiveUser { get; set; }

		public static bool IsBanned(User user)
		{
			if (user.IsActive == false)
			{
				return true;
			}
			return false;
		}
	}
}
