using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss
{
    internal class ArrowMenu
    {
        public int currentPosition;
        public int min;
        public int max;
        public ArrowMenu(int min, int max)
        {
            this.min = min;
            this.max = max;

            this.currentPosition = min;
        }

        public void DrawArrow(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
        }
        public void ClearArrow(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
        }
        public int UserChoice()
        {
            while (true)
            {
                this.DrawArrow(this.currentPosition);

                ConsoleKeyInfo InputKey = Console.ReadKey();

                switch (InputKey.Key)
                {
                    case (ConsoleKey.UpArrow):
                        if (this.currentPosition != this.min)
                        {
                            this.ClearArrow(this.currentPosition);
                            this.currentPosition--;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        if (this.currentPosition != this.max)
                        {
                            this.ClearArrow(this.currentPosition);
                            this.currentPosition++;
                        }
                        break;
                    case (ConsoleKey.Enter):

                        return this.currentPosition;

                        break;
                    case (ConsoleKey.Escape):
                        Console.Clear();
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }

            }
        }
        public ConsoleKeyInfo UserChoiceWithF()
        {
            while (true)
            {
                this.DrawArrow(this.currentPosition);

                ConsoleKeyInfo InputKey = Console.ReadKey();

                switch (InputKey.Key)
                {
                    case (ConsoleKey.UpArrow):
                        if (this.currentPosition != this.min)
                        {
                            this.ClearArrow(this.currentPosition);
                            this.currentPosition--;
                        }
                        break;
                    case (ConsoleKey.DownArrow):
                        if (this.currentPosition != this.max)
                        {
                            this.ClearArrow(this.currentPosition);
                            this.currentPosition++;
                        }
                        break;
                    case (ConsoleKey.Escape):
                    case ConsoleKey.F1:
                    case ConsoleKey.F2:
                    case ConsoleKey.F3:
                    case (ConsoleKey.Enter):
                        return InputKey;
                        break;
                    default:
                        break;
                }

            }
        }
        public bool IsEmptyMenu()
        {
            if (this.min == this.max)
            {
                return true;
            }
            return false;
        }
    }
}
