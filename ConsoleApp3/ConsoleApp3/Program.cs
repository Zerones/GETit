using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false; 
            var ordliste = Les();
            int arraylengde = ordliste.Length;
            string help = ordliste.ToString();
            while(test == false)
            {
                string rimmer = Rim(arraylengde, ordliste);
                Console.WriteLine(rimmer);
                Console.ReadKey();
            }
        }


        private static Array Les()
        {
            string path = @"ordlist.txt";
            List<string> ordliste = new List<string>();
            string lastword = string.Empty;
            int count = 0;
            foreach (string line in File.ReadLines(path, Encoding.UTF8))
            {
                var linje = line.Split('\t');
                var ord = linje[1];
                if (ord != lastword && ord.Length > 5 && ord.Length < 11 && !ord.Contains("-"))
                {
                    ordliste.Add(ord);
                    lastword = ord;
                    count++;
                }
            }
            Array resultat = ordliste.ToArray();
            return resultat;
        }

        private static string Rim(int arraylengde, Array ordliste)
        {
            bool prøvpånytt = true;
            string ord1 = string.Empty;
            string ord2 = string.Empty;
            while(prøvpånytt == true)
            {
                Random tilfeldig = new Random();
                int rng = tilfeldig.Next(arraylengde);
                int counter = 0;
                string tilfeldigord = string.Empty;
                foreach (var line in ordliste)
                {
                    if (counter == rng)
                    {
                        tilfeldigord = line.ToString();
                    }
                    counter++;
                }
                string sisteboks = tilfeldigord.Substring(tilfeldigord.Length - 3, 3);
                string rim = string.Empty;
                foreach (var line in ordliste)
                {
                    string førstebokstaver = line.ToString().Substring(0, 3);
                    if (førstebokstaver == sisteboks)
                    {
                        rim = line.ToString();
                        ord1 = tilfeldigord;
                        ord2 = rim;
                        prøvpånytt = false;

                    }
                }
            }
            string resultat = ord1 + " " + ord2;
            return resultat;
        }
    }
}
