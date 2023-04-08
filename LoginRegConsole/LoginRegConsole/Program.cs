using System.Data;
using System.Xml.Linq;

namespace LoginRegConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Handler();
        }
        public static void Handler()
        {
            List<User> users = new List<User>();
            Identity identity = new Identity();
            User admin = new User();
            admin.AdminCreationSeed(users);

            string choice = string.Empty;

            Console.WriteLine("\nWelcome to user login/register app");
            do
            {
                Console.WriteLine("What you want to do\n" +
                    "1-Login\n" +
                    "2-Register\n" +
                    "3-Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        User user = identity.Login(users);
                        if (user == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Information is wrong");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        user.ShowInfo();
                        break;

                    case "2":
                        if (identity.Register(users) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Successfully registered");
                            Console.ForegroundColor = ConsoleColor.White;
                        };
                        break;

                    default:
                        break;
                }
            } while (choice != "3");

        }
    }

    public class Validation
    {
        public bool IsLengthBeetween(int min, int max, string input)
        {
            if (input.Length > max || input.Length < min) return false;
            return true;
        }
        public bool EmailValidation(string eMail, List<User> users, ref bool exsistingMail)
        {
            for (int i = 0; i < eMail.Length; i++)
            {
                if (eMail[i] == '@')
                {
                    foreach (User user in users)
                    {
                        if (user._email == eMail)
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
        public bool PasswordValidation(string password, string passwordCheck)
        {
            if (password != passwordCheck) { return false; }
            return true;
        }

    }
    public class Identity
    {
        public User Login(List<User> users)
        {
            Console.WriteLine("Please enter the email");
            string email = Console.ReadLine();
            Console.WriteLine("Plase enter the password");
            string pass = Console.ReadLine();

            foreach (User userInDb in users)
            {
                if (userInDb._email == email && userInDb._password == pass)
                {
                    return userInDb;
                }
            }
            return null;


        }

        public bool Register(List<User> users)
        {
            RegistrationHelper registrationHelper = new RegistrationHelper();

            string name = registrationHelper.NameValidation();
            string surname = registrationHelper.SurnameValidation();
            string password = registrationHelper.PasswordValidation();
            string eMail = registrationHelper.EmailValidation(users);

            User user = new User(name, surname, eMail, password, "user");
            users.Add(user);

            return true;
        }

    }
    public class RegistrationHelper
    {
        public Validation _validation=new Validation();



        public string NameValidation()
        {
            string name = string.Empty;
            while (true)
            {

                const int MAX_LENGTH_NAME = 3;
                const int MİN_LENGTH_NAME = 30;

                Console.WriteLine("Please enter the name");
                name = Console.ReadLine();
                if (_validation.IsLengthBeetween(MAX_LENGTH_NAME, MİN_LENGTH_NAME, name) == true)
                {
                    return name;
                }
                Console.WriteLine($"Length must be beetween {MAX_LENGTH_NAME} and {MİN_LENGTH_NAME} ");

            }
        }
        public string SurnameValidation()
        {

            string surname = string.Empty;
            while (true)
            {
                const int MİN_LENGTH_SURNAME = 5;
                const int MAX_LENGTH_SURNAME = 20;

                Console.WriteLine("Please enter the surname");
                surname = Console.ReadLine();

                if (_validation.IsLengthBeetween(MİN_LENGTH_SURNAME, MAX_LENGTH_SURNAME, surname) == true)
                {
                    return surname;
                }
                Console.WriteLine($"Length must be beetween {MİN_LENGTH_SURNAME} and {MAX_LENGTH_SURNAME} ");


            }

        }
        public string PasswordValidation()
        {
            string password = string.Empty;
            string passwordCheck = string.Empty;
            while (true)
            {
                Console.WriteLine("Please enter the password");
                password = Console.ReadLine();

                Console.WriteLine("Please enter the password again");
                passwordCheck = Console.ReadLine();

                if (_validation.PasswordValidation(password, passwordCheck) == true)
                {
                    return password;
                }
                Console.WriteLine($"{password} and {passwordCheck} does not match");

            }
        }
        public string EmailValidation(List<User> users)
        {
            string eMail = string.Empty;
            while (true)
            {
                Console.WriteLine("Please enter the Email");
                eMail = Console.ReadLine();
                bool check = false;
                if (_validation.EmailValidation(eMail, users, ref check) == true)
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
                    Console.WriteLine("Enter Correct length");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
        }
    }
    public class User
    {
        public string _name;
        public string _surname;
        public string _email;
        public string _password;
        public string _role;

        public User()
        {

        }

        public User(string name, string surname, string email, string password, string role)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _password = password;
            _role = role;
        }

        public void AdminCreationSeed(List<User> users)
        {
            string name = "Super";
            string surname = "Admin";
            string email = "admin@gmail.com";
            string password = "123321";
            string role = "admin";

            User user = new User(name, surname, email, password, role);

            users.Add(user);
        }

        public void ShowInfo()
        {
            if (_role == "admin")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Welcome to your account, our dear {_name} {_surname}!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (_role == "user")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome to your account {_name} {_surname}!");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }


    }

}








