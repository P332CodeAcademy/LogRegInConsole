﻿using LoginRegConsole.Database.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Database.Models
{
	public class User : BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public bool IsActive { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		public User(string name, string surname, string email, string password, string role)
		{
			Id = ++BaseEntity._idCounter;
			Name = name;
			Surname = surname;
			Email = email;
			Password = password;
			Role = role;
			IsActive = true;
			RegistrationDate = RegistrationDate;
		}

		public string ShowFullName()
		{
			return $"{Name} {Surname}";
		}
		public void ShowInfo()
		{

			if (Role == "admin")
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine($"Welcome back, our dear {Name} {Surname}!");
				Console.ForegroundColor = ConsoleColor.White;
			}
			else if (Role == "user")
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"Welcome back {Name} {Surname}!");
				Console.ForegroundColor = ConsoleColor.White;

			}

		}
		public bool IsAdmin()
		{
			if (Role == "admin")
			{
				return true;
			}
			return false;
		}
	}
}
