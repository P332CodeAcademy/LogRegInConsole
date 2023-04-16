using LoginRegConsole.Database;
using LoginRegConsole.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Commands.UserManagament
{
    public class RemoveUserByIdCommand
    {

        public static void Handle()
        {
            while (true)
            {
                Console.WriteLine("Please enter the id");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    foreach (var item in AppDbContext.AppUsers)
                    {
                        if (item.Id == id)
                        {
                            if (item.Role != "admin")
                            {
                                AppDbContext.AppUsers.Remove(item);
                                CustomConsole.GreenLine($"{item.ShowFullName()} has been removed!");
                                return;
                            }
                            CustomConsole.RedLine("You can't remove admin");
                            return;
                        }
                    }
                    CustomConsole.GreenLine($"There is no User in {id}:ID");
                    return;
                }
                catch
                {
                    CustomConsole.RedLine("Enter correct format ID");
                    break;
                }
            }
        }


    }
}
