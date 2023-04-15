using LoginRegConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Client
{
    internal class ClientDashboard
    {


        public static void Index(User user)
        {
            Console.WriteLine($"Welcome back {user.Name} {user.Surname}");

        }

    }
}
