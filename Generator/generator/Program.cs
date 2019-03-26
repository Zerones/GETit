using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            if(IsValid(args))
            {
                string resultat = Miksing(args);
                Console.WriteLine(resultat);
            }
            else
            {
                ShowHelpText();
            }
        }
        static char GetRandomLetter(char min, char max)
        {
            return (char)Random.Next(min, max);
        }

        private static string WriteRandomLowerCaseLetter()
        {
            char character = GetRandomLetter('a', 'z');
            string bokstav = Char.ToString(character);
            bokstav.ToLower();
            return bokstav;
        }
        private static string WriteRandomUpperCaseLetter()
        {
            char character = GetRandomLetter('A', 'Z');
            string bokstav = Char.ToString(character);
            bokstav.ToUpper();
            return bokstav;
        }
        private static string WriteRandomDigit()
        {
            int tilfeldigtall = Random.Next(1, 10);
            if (tilfeldigtall == 10) return "0";
            else return tilfeldigtall.ToString();
        }
        private static string WriteRandomSpecialCharacter()
        {
            int tilfeldigtall = Random.Next(1, 13);
            if (tilfeldigtall == 1) return "!";
            else if (tilfeldigtall == 2) return "#";
            else if (tilfeldigtall == 3) return "¤";
            else if (tilfeldigtall == 4) return "%";
            else if (tilfeldigtall == 5) return "&";
            else if (tilfeldigtall == 6) return "/";
            else if (tilfeldigtall == 7) return "(";
            else if (tilfeldigtall == 8) return ")";
            else if (tilfeldigtall == 9) return "{";
            else if (tilfeldigtall == 10) return "}";
            else if (tilfeldigtall == 11) return "[";
            else if (tilfeldigtall == 12) return "]";
            else return "";
        }

        private static string Miksing(string[] args)
        {
            int tall = Int32.Parse(args[0]);
            string passord = args[1];
            char pad = 'l';
            string resultat = "";
            string pattern = passord.PadRight(tall, pad);

            while(pattern.Length > 1)
            {
                int index = pattern.Length - 1;
                if (pattern[index] == 'l')
                {
                    resultat += WriteRandomLowerCaseLetter();
                }
                else if (pattern[index] == 'L')
                {
                    resultat += WriteRandomUpperCaseLetter();
                }
                else if (pattern[index] == 'd')
                {
                    resultat += WriteRandomDigit();
                }
                else if (pattern[index] == 's')
                {
                    resultat += WriteRandomSpecialCharacter();
                }
                pattern = pattern.Remove(index);
            }
            return resultat;
        }
        private static bool IsValid(string[] args)
        {
            if(args.Length == 2)
            {
                string tall = args[0];
                string passord = args[1];
                if (tall.Length == 2)
                {
                    foreach (var character in tall)
                    {
                        if (char.IsDigit(character))
                        {
                            continue;
                        }
                        else return false;
                    }
                }
                else return false;
                for(var i = 0; i < passord.Length; i++)
                {
                    if (passord[i] == 'L' || passord[i] == 'l' || passord[i] == 'd' || passord[i] == 's')
                    {
                        continue;
                    }
                    else return false;
                }
                return true; 
            }
            else return false;
        }
        private static void ShowHelpText()
        {
            string passtext = Environment.NewLine +
                    "PasswordGenerator" + Environment.NewLine +
                    "Options:" + Environment.NewLine +
                    "- l = lower case letter" + Environment.NewLine +
                    "- L = upper case letter" + Environment.NewLine +
                    "- d = digit" + Environment.NewLine +
                    "- s = special character(!#¤%&/(){}[]" + Environment.NewLine +
                    "Example: PasswordGenerator 14 lLssdd " + Environment.NewLine +
                    "Min. 1 lower case" + Environment.NewLine +
                    "Min. 1 upper case" + Environment.NewLine +
                    "Min. 2 special characters" + Environment.NewLine +
                    "Min. 2 digits" + Environment.NewLine;
            Console.WriteLine(passtext);
            Environment.Exit(0);
        }

    }
}
