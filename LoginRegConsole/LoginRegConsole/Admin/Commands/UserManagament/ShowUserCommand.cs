using LoginRegConsole.Database;
using LoginRegConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.UserManagament
{
    public class ShowUserCommand
    {

        public static void Handle()
        {
            int counter = 1;
            foreach (User user in AppDbContext.AppUsers)
            {
                Console.WriteLine($"{counter++} || ID:{user.Id} || Name:{user.Name} || Surname:{user.Surname} || Role:{user.Role} || IsActive:{(user.IsActive ? "Active":"Banned")}");
            }
            Console.WriteLine();
        }
    }
}
