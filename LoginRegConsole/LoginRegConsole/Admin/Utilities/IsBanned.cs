using LoginRegConsole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Admin.Utilities
{
    public class IsBanned
    {
        public static bool Handle(User user)
        {
            if (user.IsActive == false)
            {
                return true;
            }
            return false;
        }
    }
}
