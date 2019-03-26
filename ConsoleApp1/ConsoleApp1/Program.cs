using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var range = 250;
            var counts = new int[range];
            string test = "something";
            int total = 0;
            while (!string.IsNullOrWhiteSpace(test))
            {
                test = Console.ReadLine();
                string text = test.ToLower();
                foreach (var character in text ?? string.Empty)
                {
                    if(character != ' ')
                    {
                        counts[character]++;
                        total++;
                    }
                }
                for (var i = 0; i < range; i++)
                {
                    if (counts[i] > 0)
                    {
                        char character = (char)i;
                        int prosent = counts[i]*100/total;
                        string output = character + " - " + prosent + "%";
                        Console.CursorLeft = Console.BufferWidth - output.Length - 1;
                        Console.WriteLine(output);
                    }
                }
                Console.Write("There were in total: " + total + " letters in your sentence ;D");
                Console.Write("\n");
                total = 0;
                test = "something";
                counts = new int[range];
            }

        }
    }
}
