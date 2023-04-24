using LoginRegConsole.Constants;
using LoginRegConsole.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegConsole.Services
{
    public class RegistrationHelper
    {
        public static string NameValidation()
        {
            string name = string.Empty;
            while (true)
            {

                

                Console.WriteLine("Please enter the name");
                name = Console.ReadLine();
                if (Validation.IsLengthBeetween(InputLengthValidations.MIN_LENGTH_NAME, InputLengthValidations.MAX_LENGTH_NAME, name) == true)
                {
                    return name;
                }
                Console.WriteLine($"Length must be beetween {InputLengthValidations.MIN_LENGTH_NAME} and {InputLengthValidations.MAX_LENGTH_NAME} ");

            }
        }
        public static string SurnameValidation()
        {

            string surname = string.Empty;
            while (true)
            {
                

                Console.WriteLine("Please enter the surname");
                surname = Console.ReadLine();

                if (Validation.IsLengthBeetween(InputLengthValidations.MİN_LENGTH_SURNAME, InputLengthValidations.MAX_LENGTH_SURNAME, surname) == true)
                {
                    return surname;
                }
                Console.WriteLine($"Length must be beetween {InputLengthValidations.MİN_LENGTH_SURNAME} and {InputLengthValidations.MAX_LENGTH_SURNAME} ");


            }

        }
        public static string PasswordValidation()
        {
            string password = string.Empty;
            string passwordCheck = string.Empty;
            while (true)
            {
                Console.WriteLine("Please enter the password");
                password = Console.ReadLine();

                Console.WriteLine("Please enter the password again");
                passwordCheck = Console.ReadLine();

                if (Validation.PasswordValidation(password, passwordCheck) == true)
                {
                    return password;
                }
                Console.WriteLine($"{password} and {passwordCheck} does not match");

            }
        }
        public static string EmailValidation()
        {
            string eMail = string.Empty;
            while (true)
            {
                Console.WriteLine("Please enter the Email");
                eMail = Console.ReadLine();
                bool check = false;
                if (Validation.EmailValidation(eMail, ref check) == true)
                {
                    return eMail;
                }
                else if (check == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{eMail} :email already exsists");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Correct Email format is { <(10-30 symbols)>@code.edu.az}");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
        }
    }
}
