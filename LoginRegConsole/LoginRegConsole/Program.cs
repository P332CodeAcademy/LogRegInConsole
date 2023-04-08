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

            do
            {
                Console.WriteLine("\nWelcome to user login/register app");
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
                        else if (user._role == "admin")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Welcome back dear admin {user._name} ");
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Welcome {user._name},{user._surname}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
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
            } while (choice != "3" );

        }
    }

    public class Validation
    {
        public bool IsLengthBeetween(int min, int max, string input)
        {
            if (input.Length > max && input.Length < min) return false;
            return true;
        }
        public bool EmailValidation(string eMail, List<User> users)
        {
            for (int i = 0; i < eMail.Length; i++)
            {
                if (eMail[i] == '@')
                {
                    foreach (User user in users)
                    {
                        if (user._email == eMail)
                        {

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
            User user = null;

            Console.WriteLine("Please enter the email");
            string email = Console.ReadLine();
            Console.WriteLine("Plase enter the password");
            string pass = Console.ReadLine();


            foreach (User userInDb in users)
            {
                if (userInDb._email == email && userInDb._password == pass)
                {
                    user=userInDb;
                    return user;
                }
            }
            return null;

            
        }

        public bool Register(List<User> users)
        {
            Validation validation = new Validation();
            string name = string.Empty;
            string surname = string.Empty;
            string password = string.Empty;
            string eMail = string.Empty;
            string passwordCheck = string.Empty;


            do
            {
                Console.WriteLine("Please enter the name");
                name = Console.ReadLine();

            } while (validation.IsLengthBeetween(3, 30, name) == false);

            do
            {
                Console.WriteLine("Please enter the surname");
                surname = Console.ReadLine();

            } while (validation.IsLengthBeetween(5, 20, surname) == false);

            do
            {
                Console.WriteLine("Please enter the password");
                password = Console.ReadLine();

                Console.WriteLine("Please enter the password again");
                passwordCheck = Console.ReadLine();

            } while (validation.PasswordValidation(password, passwordCheck) == false);

            do
            {
                Console.WriteLine("Please enter the Email");
                eMail = Console.ReadLine();

            } while (validation.EmailValidation(eMail, users) == false);

            User user = new User(name,surname,eMail,password,"user");

            users.Add(user);
            

            return true;
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

            User user = new User(name,surname,email,password,role);

            users.Add(user);

        }

    }

}








