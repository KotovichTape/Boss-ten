using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boss
{
    public class Login
    {
        private string path;


        public Login(string filename)
        {
            this.path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + filename;
            Show();
            Start();
        }

        private void Show()
        {
            Console.Clear();
            Console.SetCursorPosition(3, 0);
            Console.Write("Логин: ");
            Console.SetCursorPosition(3, 1);
            Console.Write("Пароль: ");
            Console.SetCursorPosition(3, 2);
            Console.Write("Войти: ");
        }

        public void Start()
        {
            int position = 0;
            string password = "";
            string login = "";
            ConsoleKeyInfo key;

            bool notFound = true;

            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");

            while (true)
            {
                //key = Console.ReadKey();

                ArrowMenu arrowMenu = new ArrowMenu(0, 2);

                position = arrowMenu.UserChoice();

                if (position == 0)
                {
                    Console.SetCursorPosition(9, 0);
                    login = Console.ReadLine();
                }
                else if (position == 1)
                {
                    Console.SetCursorPosition(10, 1);
                    password = CheckPassword();
                }
                else if (position == 2)
                {

                    string text = File.ReadAllText(path);

                    List<User> users = JsonConvert.DeserializeObject<List<User>>(text);

                    foreach (var user in users)
                    {
                        if ((login == user.Name) && (password == user.Password))
                        {
                            if (user.Role == "admin")
                            {
                                notFound = false;
                                Admin admin = new Admin(user.Name);
                            }
                        }
                    }
                    if (notFound == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Данные введены не верно. (Нажмите любую клавишу)");
                        Console.ReadLine();

                        Show();
                        Start();

                    }
                }
                else if (position == 3)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public static string CheckPassword()
        {
            try
            {
                string EnteredVal = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work  
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        EnteredVal += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && EnteredVal.Length > 0)
                        {
                            EnteredVal = EnteredVal.Substring(0, (EnteredVal.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            return EnteredVal;

                        }
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
