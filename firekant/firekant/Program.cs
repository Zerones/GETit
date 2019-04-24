using System;

namespace firekant
{
    public class Program
    {
        private static int _width = 40;
        private static int _height = 20;

        static void Main(string[] args)
        {
            bool lol = false; 
            while(lol == false)
            {
                var random = new Random();
                var box1 = new Box(random, 40, 18);
                var box2 = new Box(random, 40, 18);
                var screen = new VirtualScreen(50, 20);
                screen.Add(box1);
                screen.Add(box2);
                screen.Show();
                ConsoleKeyInfo test = Console.ReadKey();
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    lol = true;
                }
                else continue;

            }

        }
    }
}