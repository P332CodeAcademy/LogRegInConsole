using LoginRegConsole.Database.Models;
using LoginRegConsole.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Helper
{
    public class Validation
    {
        public static bool IsLengthBeetween(int min, int max, string input)
        {
            if (input.Length > max || input.Length < min) return false;
            return true;
        }
        public static bool EmailValidation(string eMail, ref bool exsistingMail)
        {
            for (int i = 0; i < eMail.Length; i++)
            {
                if (eMail[i] == '@')
                {
                    foreach (User user in AppDbContext.AppUsers)
                    {
                        if (user.Email == eMail)
                        {
                            exsistingMail = true;
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public static bool PasswordValidation(string password, string passwordCheck)
        {
            if (password != passwordCheck) { return false; }
            return true;
        }

    }
}
