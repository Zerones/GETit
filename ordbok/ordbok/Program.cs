using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ordbok
{
    class Program
    {
        static void Main(string[] args)
        {
            var ordliste = ReadList();
            foreach(var line in ordliste)
            {
                Console.WriteLine(line.ToString());
            }

            Console.ReadKey();
        }
        private static Array ReadList()
        {
            var path = @"C:\Users\Brage\source\repos\GETit\ordbok\ordbok\fullform_bm.txt";
            var ordlist = new List<string>();
            string lastWord = null;
            foreach (var line in File.ReadLines(path, Encoding.UTF8))
            {
                var parts = line.Split('\t');
                var word = parts[1];
                if (word != lastWord
                    && word.Length > 6
                    && word.Length < 10
                    && !word.Contains("-"))
                {
                    ordlist.Add(word);
                }
                lastWord = word;
            }

            return ordlist.ToArray();
        }
    }
}
