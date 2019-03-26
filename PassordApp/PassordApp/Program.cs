using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassordApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            if(!IsValid(args))
            {
                LoginFail();
            } else
            {
                Console.WriteLine("Korrekt passord");        
            }
        }
        private static bool IsValid(string[] args)
        {
            if (args.Length == 2)
            {
                string nummer = args[0];
                string text = args[1];
                if (!string.IsNullOrWhiteSpace(nummer) || !string.IsNullOrWhiteSpace(text))
                {
                    foreach (var character in nummer)
                    {
                        if (char.IsDigit(character)) continue;
                        else return false;
                    }
                    for (var i = 0; i < text.Length; i++)
                    {
                        if (i == 1)
                        {
                            if (char.IsUpper(text[i])) continue;
                            else return false;
                        }
                        else if (i == 2 || i == 3)
                        {
                            if (char.IsSymbol(text[i])) continue;
                            else return false;
                        }
                        else if (i == 4 || i == 5)
                        {
                            if (char.IsDigit(text[i])) continue;
                            else return false;
                        }
                        else
                        {
                            if (char.IsLower(text[i])) continue;
                            else return false;
                        }
                    }
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private static void LoginFail()
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
