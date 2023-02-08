using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boss
{
    public class Admin : Cruds
    {

        private string name;
        private int place;


        public Admin(string name)
        {
            this.name = name;
            Show();
            Action();

        }

        public void Create()
        {
            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");

            Console.Clear();
            Console.Write("Введите имя: ");

            string name = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();
            Console.Write("Введите id: ");
            string id = Console.ReadLine();
            Console.Write("Введите роль: ");
            string role = Console.ReadLine();
            User new_user = new User(name, password, role, id);
            users.Add(new_user);

            MyConverter.MySerialize<List<User>>(users, "users.json");
            Console.Clear();
            Show();
            Action();
        }

        public void Delete()
        {
            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");

            if (users[place].Name != name)
            {
                users.Remove(users[place]);
                MyConverter.MySerialize<List<User>>(users, "users.json");
                Show();
                Action();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Нельзя удалить администратора, под которым вы зашли");
                Console.ReadLine();
                Console.Clear();

                Show();
                Action();
            }
        }

        public void Read()
        {
            int y = 0;

            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");

            foreach (var item in users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.Role);
                Console.SetCursorPosition(40, y);
                Console.Write(item.Id);
                y += 1;
            }
        }

        public void Search(string found)
        {
            Console.Clear();
            int y;

            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");
            List<User> sorted_users = new List<User>();

            foreach (var user in users)
            {
                if (found.Equals(user.Id) || found.Equals(user.Role) || found.Equals(user.Name))
                //Определяет, равен ли указанный объект текущему объекту
                {
                    sorted_users.Add(user);
                }
            }

            if (sorted_users.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("По данному запросу ничего не найдено (нажмите любую клавишу)");
                Console.ReadKey();
                Show();
                Action();
                return;
            }

            y = 0;
            foreach (var item in sorted_users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.Role);
                Console.SetCursorPosition(40, y);
                Console.Write(item.Id);
                y += 1;
            }

            y = 0;
            Console.SetCursorPosition(70, 0);
            Console.Write("F1 - Добавить пользователя");
            Console.SetCursorPosition(70, 1);
            Console.Write("F2 - Удалить пользователя");
            Console.SetCursorPosition(70, 3);
            Console.Write("F3 - Поиск");
            Console.SetCursorPosition(70, 7);
            Console.Write("Здравствуйте, " + name);


            Console.SetCursorPosition(3, sorted_users.Count + 3);
            Console.Write("Логин");
            Console.SetCursorPosition(20, sorted_users.Count + 3);
            Console.Write("Роль");
            Console.SetCursorPosition(40, sorted_users.Count + 3);
            Console.Write("Id");
            int position = 0;
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.Write("  ");
                    position -= 1;
                    if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                    if (position < 0) { position = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.Write("  ");
                    position += 1;
                    if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                    if (position < 0) { position = 0; }
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Create();
                    Console.Clear();
                    Show();
                    Action();
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    place = users.IndexOf(sorted_users[position]);
                    Delete();
                    break;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine("Введите текст, по которому хотите выполнить поиск: ");
                    string param = Console.ReadLine();
                    Search(param);
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    place = users.IndexOf(sorted_users[position]);
                    Update();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Show();
                    Action();
                    break;
                }
                Console.SetCursorPosition(0, position);
                Console.Write("->");
            }
        }

        public void Update()
        {
            Console.Clear();
            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");
            Console.WriteLine($"   id: {users[place].Id}\n   login: {users[place].Name}\n   password: {users[place].Password}\n   role: {users[place].Role}");
            int pos = 0;
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos -= 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos += 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (pos == 0)
                    {
                        Console.SetCursorPosition(7, 0);
                        Console.Write("                             ");
                        Console.SetCursorPosition(7, 0);
                        string new_id = Console.ReadLine();
                        users[place].Id = new_id;
                    }
                    else if (pos == 1)
                    {
                        Console.SetCursorPosition(10, 1);
                        Console.Write("                             ");
                        Console.SetCursorPosition(10, 1);
                        string new_login = Console.ReadLine();
                        users[place].Name = new_login;
                    }
                    else if (pos == 2)
                    {
                        Console.SetCursorPosition(13, 2);
                        Console.Write("                             ");
                        Console.SetCursorPosition(13, 2);
                        string new_password = Console.ReadLine();
                        users[place].Password = new_password;
                    }
                    else if (pos == 3)
                    {
                        Console.SetCursorPosition(9, 3);
                        Console.Write("                             ");
                        Console.SetCursorPosition(9, 3);
                        string new_role = Console.ReadLine();
                        users[place].Role = new_role;
                    }
                    Console.Clear();
                    Console.WriteLine($"   id: {users[place].Id}\n   login: {users[place].Name}\n   password: {users[place].Password}\n   role: {users[place].Role}");
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    MyConverter.MySerialize<List<User>>(users, "users.json");
                    Show();
                    Action();
                    break;
                }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }
        }

        public void Show()
        {
            int y = 0;

            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");

            Console.Clear();
            Console.SetCursorPosition(60, 0);
            Console.Write("F1 - добавить пользователя");
            Console.SetCursorPosition(60, 1);
            Console.Write("F2 - удалить пользователя");
            Console.SetCursorPosition(60, 5);
            Console.Write("Здравствуйте, " + name);
            Console.SetCursorPosition(60, 2);
            Console.Write("F3 - поиск");
            Console.SetCursorPosition(3, users.Count + 2);
            Console.Write("Логин");
            Console.SetCursorPosition(20, users.Count + 2);
            Console.Write("Роль");
            Console.SetCursorPosition(40, users.Count + 2);
            Console.Write("Id");

            foreach (var item in users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.Role);
                Console.SetCursorPosition(40, y);
                Console.Write(item.Id);
                y += 1;
            }

        }
        public void Action()
        {
            List<User> users = MyConverter.MyDeserialize<List<User>>("users.json");

            ArrowMenu arrowMenu = new ArrowMenu(0, users.Count - 1);

            ConsoleKeyInfo key = arrowMenu.UserChoiceWithF();

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    int pos = arrowMenu.currentPosition;

                    this.place = pos;
                    Update();
                    break;
                case ConsoleKey.F1:
                    Create();
                    break;
                case ConsoleKey.F2:
                    this.place = arrowMenu.currentPosition;
                    Delete();
                    break;
                case ConsoleKey.F3:
                    Console.Clear();
                    Console.WriteLine("Введите текст, по которому хотите выполнить поиск: ");
                    string param = Console.ReadLine();
                    Search(param);

                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    break;
            }
        }
    }
}
